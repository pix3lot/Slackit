﻿#region Header
// Based on: https://github.com/jeremytammik/the_building_coder_samples/blob/master/BuildingCoder/BuildingCoder/JtNamedGuidStorage.cs
// JtNamedGuidStorage.cs - implement named Guid storage, e.g. for a globally unique project identifier
//
// Copyright (C) 2010-2016 by Jeremy Tammik, Autodesk Inc. All rights reserved.
//
// Keywords: The Building Coder Revit API C# .NET add-in.
//
#endregion // Header

#region Namespaces
using System;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
#endregion // Namespaces

namespace SlackitRevit
{
    class ExtensibleStorage
    {

        public static class SettingsSchema
        {
            public readonly static Guid SchemaGuid = new Guid(
              "{B9FBF728-2A8F-43EA-B57A-F2A1D1E5855A}");

            /// <summary>
            /// Retrieve our extensible storage schema 
            /// or optionally create a new one if it does
            /// not yet exist.
            /// </summary>
            public static Schema InitializeSchema(
              bool create = true)
            {
                Schema schema = Schema.Lookup(SchemaGuid);

                if (create && null == schema)
                {
                    SchemaBuilder schemaBuilder =
                      new SchemaBuilder(SchemaGuid);

                    schemaBuilder.SetSchemaName(
                      "SlackitSettings");

                    schemaBuilder.SetReadAccessLevel(AccessLevel.Public);

                    schemaBuilder.SetWriteAccessLevel(AccessLevel.Public);

                    schemaBuilder.AddSimpleField(
                        "slackOn", typeof(Boolean));

                    schemaBuilder.AddSimpleField(
                        "giphyOn", typeof(Boolean));

                    schemaBuilder.AddSimpleField(
                        "slackToken", typeof(String));

                    schemaBuilder.AddSimpleField(
                        "slackCh", typeof(String));

                    schemaBuilder.AddSimpleField(
                        "slackChId", typeof(String));

                    schema = schemaBuilder.Finish();
                }
                return schema;
            }
        }

    }

    public static class ParameterCommands
    {
        public static void Load(Document doc)
        {
            ExtensibleStorageFilter fi
                  = new ExtensibleStorageFilter(
                      ExtensibleStorage.SettingsSchema.SchemaGuid);

            DataStorage dataStorage
                = new FilteredElementCollector(doc)
                .OfClass(typeof(DataStorage))
                .WherePasses(fi)
                .Where<Element>(el => Variables.defNameSettings.Equals(el.Name))
                .FirstOrDefault<Element>() as DataStorage;

            if (dataStorage != null)
            {
                Entity entity = dataStorage.GetEntity(Schema.Lookup(ExtensibleStorage.SettingsSchema.SchemaGuid));
                Variables.slackOn = entity.Get<bool>("slackOn");
                Variables.slackCh = entity.Get<string>("slackCh");
                Variables.slackChId = entity.Get<string>("slackChId");
                Variables.giphyOn = entity.Get<bool>("giphyOn");
                Variables.slackToken = entity.Get<string>("slackToken");
            }
            else
            {
                Variables.slackCh = null;
                Variables.slackChId = null;
                Variables.slackOn = false;
                Variables.slackToken = null;
            }
        }

        public static void Set(Application app, Document doc, string name, SlackSettings s)
        {


            ExtensibleStorageFilter f
                = new ExtensibleStorageFilter(
                    ExtensibleStorage.SettingsSchema.SchemaGuid);

            DataStorage dataStorage
                = new FilteredElementCollector(doc)
                .OfClass(typeof(DataStorage))
                .WherePasses(f)
                .Where<Element>(e => name.Equals(e.Name))
                .FirstOrDefault<Element>() as DataStorage;

            Entity entity;
            if (dataStorage == null)
            {
                using (Transaction t = new Transaction(doc, "Create settings schema"))
                {
                    t.Start();

                    dataStorage = DataStorage.Create(doc);
                    dataStorage.Name = name;

                    entity = new Entity(ExtensibleStorage.SettingsSchema.InitializeSchema());
                    dataStorage.SetEntity(entity);

                    t.Commit();
                }
            }

            Transaction updateSettings = new Transaction(doc, "Update settings");
            updateSettings.Start();
            entity = dataStorage.GetEntity(ExtensibleStorage.SettingsSchema.InitializeSchema());

            entity.Set("slackOn", s.slackOn);
            entity.Set("giphyOn", s.giphyOn);
            entity.Set("slackToken", s.slackToken);
            entity.Set("slackCh", s.slackCh);
            entity.Set("slackChId", s.slackChId);

            dataStorage.SetEntity(entity);
            updateSettings.Commit();
        }
    }
}