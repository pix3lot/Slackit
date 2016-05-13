using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Slack;
using Newtonsoft.Json;
using RestSharp;

namespace SlackitRevit
{
    public partial class SlackForm : Form
    {
        private BindingSource bs;
        private BindingList<String> bList;

        internal bool enabled { get; set; }
        internal bool slackWSWarn { get; set; }
        internal bool slackModelWarn { get; set; }
        internal bool slackBPWarn { get; set; }
        internal bool slackWSInfo { get; set; }
        internal bool slackModelInfo { get; set; }
        internal bool slackBPInfo { get; set; }
        internal bool slackExtraTrackPin { get; set; }
        internal int giphySet { get; set;  }
        internal int tidySet { get; set; }
        internal string channel { get; set; }
        internal string channelid { get; set; }
        private string token { get; set; }

        public List<string> ch_list = null;
        public Dictionary<string, string> ch_dict = null;

        public SlackForm()
        {
            enabled = Variables.slackOn;
            slackWSWarn = Variables.slackWSWarn;
            slackModelWarn = Variables.slackModelWarn;
            slackBPWarn = Variables.slackBPWarn;
            slackWSInfo = Variables.slackWSInfo;
            slackModelInfo = Variables.slackModelInfo;
            slackBPInfo = Variables.slackBPInfo;
            slackExtraTrackPin = Variables.slackExtraTrackPin;
            giphySet = Variables.giphySet;
            tidySet = Variables.tidySet;
            channel = Variables.slackCh;
            channelid = Variables.slackChId;
            token = Variables.slackToken;

            this.InitializeComponent();

            bList = new BindingList<String>();
            bs = new BindingSource();
            bs.DataSource = bList;
            combobox_channels.DataSource = bs;

            try
            {
                loadChannels();
            }
            catch
            {

            }

            textbox_token.Text = token;
            combobox_channels.SelectedItem = channel;
            checkbox_enable.Checked = enabled;
            checkbox_model_warn.Checked = slackModelWarn;
            checkbox_ws_warn.Checked = slackWSWarn;
            checkbox_bp_warn.Checked = slackBPWarn;
            checkbox_model_info.Checked = slackModelInfo;
            checkbox_ws_info.Checked = slackWSInfo;
            checkbox_bp_info.Checked = slackBPInfo;
            checkbox_extra_trackpin.Checked = slackExtraTrackPin;
            combobox_giphy.SelectedIndex = giphySet;
            combobox_tidy.SelectedIndex = tidySet;
            

        }

        private void slackSave_Click(object sender, EventArgs e)
        {         
            try
            {
                String s = combobox_channels.SelectedItem.ToString();
                String id;

                ch_dict.TryGetValue(s, out id);

                Variables v = new Variables();

                Variables.slackCh = s;
                Variables.slackChId = id;
                Variables.slackOn = checkbox_enable.Checked;
                Variables.slackWSWarn = checkbox_ws_warn.Checked;
                Variables.slackModelWarn = checkbox_model_warn.Checked;
                Variables.slackBPWarn = checkbox_bp_warn.Checked;
                Variables.slackWSInfo = checkbox_ws_info.Checked;
                Variables.slackModelInfo = checkbox_model_info.Checked;
                Variables.slackBPInfo = checkbox_bp_info.Checked;
                Variables.slackExtraTrackPin = checkbox_extra_trackpin.Checked;
                Variables.giphySet = combobox_giphy.SelectedIndex;
                Variables.tidySet = combobox_tidy.SelectedIndex;
                Variables.slackToken = token;
             }
            catch
            {
                TaskDialog.Show("Slack Settings Error", "There is an issue with your token or channel selection.");
            }
         }

        private void button_reload_ch_Click(object sender, EventArgs e)
        {
            try
            {
                loadChannels();
            }
            catch
            {
                TaskDialog.Show("Error - Slack Channels", "Invalid token");
            }
            
        }


        private void textboxToken_TextChanged(object sender, EventArgs e)
        {
            token = (sender as System.Windows.Forms.TextBox).Text;
        }

        private void loadChannels()
        {
            Variables.slackToken = token;

            var ch_name = new List<string>();
            var ch_name_id = new Dictionary<string, string>();

            combobox_channels.DataSource = null;
            bList.Clear();
            combobox_channels.DataSource = bs;

            var slackClient = new SlackClient(Variables.slackToken);
            string ch_response = slackClient.GetChannelsList(true).Content;
            var ch = JsonConvert.DeserializeObject<ChannelsListResponse>(ch_response);

            foreach (var item in ch.channels)
            {
                ch_name_id.Add(item.name, item.id);
            }

            foreach (var item in ch.channels)
            {
                ch_name.Add(item.name);
            }

            foreach (string name in ch_name)
            {
                bList.Add(name);
            }

            ch_list = ch_name;
            ch_dict = ch_name_id;
        }

        private void link_token_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.slack.com/docs/oauth-test-tokens");
        }

    }
 }
