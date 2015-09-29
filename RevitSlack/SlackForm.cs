using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RevitEvents;

namespace RevitSlack
{
    public partial class SlackForm : Form
    {
        private List<string> ch = null;
        private Dictionary<string, string> chdict = null;

        internal bool Enabled { get; set; }
        internal string Channel { get; set; }
        internal string ChannelId { get; set; }
        //internal string Token { get; set; }

        public SlackForm()
        {
            Enabled = Variables.slackOn;
            Channel = Variables.slackCh;
            ChannelId = Variables.slackChId;
            //Token = Variables.slackToken;

            ch = Command.chlist;
            chdict = Command.chdict;

            this.InitializeComponent();

            foreach (string name in ch)
            {
                slackChannels.Items.Add(name);
            }

            slackChannels.SelectedItem = Channel;
            slackToken.Text = Variables.slackToken;
            slackEnable.Checked = Enabled;

        }

        private void slackSave_Click(object sender, EventArgs e)
        {
         
            String s = slackChannels.SelectedItem.ToString();
            String id;

            chdict.TryGetValue(s, out id);

            Variables.slackCh = s;
            Variables.slackChId = id;
            Variables.slackOn = slackEnable.Checked;
            //Variables.slackToken = Token;
        }
        }
    }
