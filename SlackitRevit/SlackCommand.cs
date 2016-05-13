#region Namespaces
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

#endregion

namespace SlackitRevit
{
    [Transaction(TransactionMode.Manual)]

    public class SlackCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            ParameterCommands.Load(doc);
            SlackForm slackForm = new SlackForm();

            slackForm.ShowDialog();

            if (slackForm.DialogResult == DialogResult.OK)
            {
                Autodesk.Revit.ApplicationServices.Application app = doc.Application;

                if (doc.IsFamilyDocument)
                {
                    TaskDialog.Show("Exception", "These settings can only be saved while in a Revit project, not in a Family.");
                }

                SlackSettings s = new SlackSettings();
                s.slackCh = Variables.slackCh;
                s.slackChId = Variables.slackChId;
                s.slackOn = Variables.slackOn;
                s.slackWSWarn = Variables.slackWSWarn;
                s.slackModelWarn = Variables.slackModelWarn;
                s.slackBPWarn = Variables.slackBPWarn;
                s.slackWSInfo = Variables.slackWSInfo;
                s.slackModelInfo = Variables.slackModelInfo;
                s.slackBPInfo = Variables.slackBPInfo;
                s.slackExtraTrackPin = Variables.slackExtraTrackPin;
                s.tidySet = Variables.tidySet;
                s.giphySet = Variables.giphySet;
                s.slackToken = Variables.slackToken;

                ParameterCommands.Set(app, doc, Variables.defNameSettings, s);
            }
            return Result.Succeeded;
        }
    
    }

}