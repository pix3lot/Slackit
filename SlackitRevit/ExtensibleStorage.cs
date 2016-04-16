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

                    schemaBuilder.SetWriteAccessLevel(AccessLevel.Vendor);

                    schemaBuilder.AddSimpleField(
                      "Guid", typeof(Guid));

                    schemaBuilder.AddSimpleField(
                        "SlackOn", typeof(Boolean));

                    schemaBuilder.AddSimpleField(
                        "GiphyOn", typeof(Boolean));

                    schemaBuilder.AddSimpleField(
                        "SlackToken", typeof(String));

                    schemaBuilder.AddSimpleField(
                        "SlackCh", typeof(String));

                    schemaBuilder.AddSimpleField(
                        "SlackChId", typeof(String));

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

                    entity = dataStorage.GetEntity(SlackitSettingsSchema.GetSchema());
                    entity.Set("SlackOn", false);

                    dataStorage.SetEntity(entity);

                    t.Commit();
                }
            }
            else {
                entity = dataStorage.GetEntity(SlackitSettingsSchema.GetSchema());
                
            }
            
            Schema settingSchema = entity.Schema;

            Field slackOnField = settingSchema.GetField("slackOn");
            Field giphyOnField = settingSchema.GetField("giphyOn");
            Field slackTokenField = settingSchema.GetField("slackToken");
            Field slackChField = settingSchema.GetField("slackCh");
            Field slackChIdField = settingSchema.GetField("slackChId");       
         
            entity.Set(slackOnField, s.slackOn);
            entity.Set(giphyOnField, s.giphyOn);
            entity.Set(slackTokenField, s.slackToken);
            entity.Set(slackChField, s.slackCh);
            entity.Set(slackChIdField, s.slackChId);

        
        }
    }
}