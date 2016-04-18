#region Header
// Based on:
// JtNamedGuidStorage.cs - implement named Guid storage, e.g. for a globally unique project identifier
//
// Copyright (C) 2010-2016 by Jeremy Tammik, Autodesk Inc. All rights reserved.
//
// Keywords: The Building Coder Revit API C# .NET add-in.
//
#endregion // Header

#region Namespaces
using System;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using System.Collections.Generic;
#endregion // Namespaces

namespace SlackitRevit
{
    class SlackitExtStoSettings
    {
        /// <summary>
        /// The extensible storage schema, 
        /// containing one single Guid field.
        /// </summary>
        public static class SlackitSettingsSchema
        {
            public readonly static Guid SchemaGuid = new Guid(
              "{B9FBF728-2A8F-43EA-B57A-F2A1D1E5855A}");

            /// <summary>
            /// Retrieve our extensible storage schema 
            /// or optionally create a new one if it does
            /// not yet exist.
            /// </summary>
            public static Schema GetSchema(
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

        public static void SetParameters( Application app, Document doc, string name, SlackSettings s)
        {


            ExtensibleStorageFilter f
                = new ExtensibleStorageFilter(
                    SlackitSettingsSchema.SchemaGuid);

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

                    // ntity = dataStorage.GetEntity(SlackitSettingsSchema.GetSchema());
                    //entity.Set("SlackOn", false);
                    entity = new Entity(SlackitSettingsSchema.GetSchema());
                    dataStorage.SetEntity(entity);

                    t.Commit();
                }
            }

            Transaction updateSettings = new Transaction(doc, "Update settings");
            updateSettings.Start();
            entity = dataStorage.GetEntity(SlackitSettingsSchema.GetSchema());
            
            
            Schema settingSchema = entity.Schema;
            IList<Field> fields = settingSchema.ListFields();
            Field slackOnField = settingSchema.GetField("slackOn");
            Field giphyOnField = settingSchema.GetField("giphyOn");
            Field slackTokenField = settingSchema.GetField("slackToken");
            Field slackChField = settingSchema.GetField("slackCh");
            Field slackChIdField = settingSchema.GetField("slackChId");       
         
            entity.Set(slackOnField, s.slackOn);
            Debug.Print(entity.Get<bool>(slackOnField).ToString());
            entity.Set(giphyOnField, s.giphyOn);
            entity.Set(slackTokenField, s.slackToken);
            Debug.Print(entity.Get<string>(slackTokenField));
            entity.Set(slackChField, s.slackCh);
            entity.Set(slackChIdField, s.slackChId);

            dataStorage.SetEntity(entity);
            updateSettings.Commit();
        }
    }

        public static class GetParameters
    {
        public static void Load(Document doc) { 
        ExtensibleStorageFilter fi
              = new ExtensibleStorageFilter(
                  SlackitExtStoSettings.SlackitSettingsSchema.SchemaGuid);

        DataStorage dataStorage
            = new FilteredElementCollector(doc)
            .OfClass(typeof(DataStorage))
            .WherePasses(fi)
            .Where<Element>(el => Variables.defNameSettings.Equals(el.Name))
            .FirstOrDefault<Element>() as DataStorage;

            if (dataStorage != null)
            {
                Entity entity = dataStorage.GetEntity(Schema.Lookup(SlackitExtStoSettings.SlackitSettingsSchema.SchemaGuid));
                using (Transaction t = new Transaction(doc, "Get Extensible Storage Data"))
                {
                    t.Start();
                    // entity.Schema.GetField("slca")
                    // entity.Get<bool>()
                    Variables.slackOn = entity.Get<bool>("slackOn");
                    Debug.Print(entity.Get<bool>("slackOn").ToString());
                    Variables.slackCh = entity.Get<string>("slackCh");
                    Variables.slackChId = entity.Get<string>("slackChId");
                    Variables.giphyOn = entity.Get<bool>("giphyOn");
                    Variables.slackToken = entity.Get<string>("slackToken");
                    t.Commit();
                }
            }
            else
            {
                Variables.slackCh = null;
                Variables.slackChId = null;
                Variables.slackOn = false;
                Variables.slackToken = null;
            }
        }
    }
}