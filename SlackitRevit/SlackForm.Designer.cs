namespace SlackitRevit
{
    partial class SlackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlackForm));
            this.checkbox_enable = new System.Windows.Forms.CheckBox();
            this.textbox_token = new System.Windows.Forms.TextBox();
            this.label_token = new System.Windows.Forms.Label();
            this.label_enable = new System.Windows.Forms.Label();
            this.combobox_channels = new System.Windows.Forms.ComboBox();
            this.label_channel = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.pictureboc_logo = new System.Windows.Forms.PictureBox();
            this.label_title = new System.Windows.Forms.Label();
            this.label_description = new System.Windows.Forms.Label();
            this.button_reload_ch = new System.Windows.Forms.Button();
            this.link_token = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_gifs = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboc_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // checkbox_enable
            // 
            this.checkbox_enable.AutoSize = true;
            this.checkbox_enable.Location = new System.Drawing.Point(92, 191);
            this.checkbox_enable.Name = "checkbox_enable";
            this.checkbox_enable.Size = new System.Drawing.Size(22, 21);
            this.checkbox_enable.TabIndex = 0;
            this.checkbox_enable.UseVisualStyleBackColor = true;
            // 
            // textbox_token
            // 
            this.textbox_token.Location = new System.Drawing.Point(8, 268);
            this.textbox_token.Name = "textbox_token";
            this.textbox_token.Size = new System.Drawing.Size(403, 26);
            this.textbox_token.TabIndex = 1;
            this.textbox_token.TextChanged += new System.EventHandler(this.textboxToken_TextChanged);
            // 
            // label_token
            // 
            this.label_token.AutoSize = true;
            this.label_token.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_token.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_token.Location = new System.Drawing.Point(3, 242);
            this.label_token.Name = "label_token";
            this.label_token.Size = new System.Drawing.Size(71, 20);
            this.label_token.TabIndex = 2;
            this.label_token.Text = "TOKEN";
            // 
            // label_enable
            // 
            this.label_enable.AutoSize = true;
            this.label_enable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_enable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_enable.Location = new System.Drawing.Point(3, 192);
            this.label_enable.Name = "label_enable";
            this.label_enable.Size = new System.Drawing.Size(82, 20);
            this.label_enable.TabIndex = 3;
            this.label_enable.Text = "ENABLE";
            // 
            // combobox_channels
            // 
            this.combobox_channels.FormattingEnabled = true;
            this.combobox_channels.Location = new System.Drawing.Point(8, 392);
            this.combobox_channels.Name = "combobox_channels";
            this.combobox_channels.Size = new System.Drawing.Size(400, 28);
            this.combobox_channels.TabIndex = 4;
            // 
            // label_channel
            // 
            this.label_channel.AutoSize = true;
            this.label_channel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_channel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_channel.Location = new System.Drawing.Point(9, 360);
            this.label_channel.Name = "label_channel";
            this.label_channel.Size = new System.Drawing.Size(188, 20);
            this.label_channel.TabIndex = 5;
            this.label_channel.Text = "PROJECT CHANNEL";
            // 
            // button_save
            // 
            this.button_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_save.Location = new System.Drawing.Point(8, 448);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(405, 38);
            this.button_save.TabIndex = 6;
            this.button_save.Text = "Save Settings";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.slackSave_Click);
            // 
            // pictureboc_logo
            // 
            this.pictureboc_logo.Image = global::SlackitRevit.Properties.Resources.SlackitLogoSmall;
            this.pictureboc_logo.Location = new System.Drawing.Point(267, 15);
            this.pictureboc_logo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureboc_logo.Name = "pictureboc_logo";
            this.pictureboc_logo.Size = new System.Drawing.Size(159, 138);
            this.pictureboc_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureboc_logo.TabIndex = 7;
            this.pictureboc_logo.TabStop = false;
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.BackColor = System.Drawing.SystemColors.Window;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_title.Location = new System.Drawing.Point(8, 14);
            this.label_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(142, 33);
            this.label_title.TabIndex = 8;
            this.label_title.Text = "SLACKIT";
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(9, 54);
            this.label_description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(250, 100);
            this.label_description.TabIndex = 9;
            this.label_description.Text = "Slackit is used to send messages\r\nfrom Revit to a specific Slack \r\nchannel. These" +
    " settings are saved\r\nin the project file and will be set \r\nfor the team.";
            // 
            // button_reload_ch
            // 
            this.button_reload_ch.Location = new System.Drawing.Point(260, 306);
            this.button_reload_ch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_reload_ch.Name = "button_reload_ch";
            this.button_reload_ch.Size = new System.Drawing.Size(150, 37);
            this.button_reload_ch.TabIndex = 10;
            this.button_reload_ch.Text = "Get Channels";
            this.button_reload_ch.UseVisualStyleBackColor = true;
            this.button_reload_ch.Click += new System.EventHandler(this.button_reload_ch_Click);
            // 
            // link_token
            // 
            this.link_token.AutoSize = true;
            this.link_token.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.link_token.Location = new System.Drawing.Point(84, 242);
            this.link_token.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.link_token.Name = "link_token";
            this.link_token.Size = new System.Drawing.Size(143, 20);
            this.link_token.TabIndex = 11;
            this.link_token.TabStop = true;
            this.link_token.Text = "How to get a token";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(133, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "INCLUDE GIFS";
            // 
            // checkBox_gifs
            // 
            this.checkBox_gifs.AutoSize = true;
            this.checkBox_gifs.Location = new System.Drawing.Point(277, 191);
            this.checkBox_gifs.Name = "checkBox_gifs";
            this.checkBox_gifs.Size = new System.Drawing.Size(22, 21);
            this.checkBox_gifs.TabIndex = 12;
            this.checkBox_gifs.UseVisualStyleBackColor = true;
            // 
            // SlackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(434, 503);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_gifs);
            this.Controls.Add(this.link_token);
            this.Controls.Add(this.button_reload_ch);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.pictureboc_logo);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_channel);
            this.Controls.Add(this.combobox_channels);
            this.Controls.Add(this.label_enable);
            this.Controls.Add(this.label_token);
            this.Controls.Add(this.textbox_token);
            this.Controls.Add(this.checkbox_enable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SlackForm";
            this.Text = "Slackit Revit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureboc_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkbox_enable;
        private System.Windows.Forms.TextBox textbox_token;
        private System.Windows.Forms.Label label_token;
        private System.Windows.Forms.Label label_enable;
        private System.Windows.Forms.ComboBox combobox_channels;
        private System.Windows.Forms.Label label_channel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.PictureBox pictureboc_logo;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Button button_reload_ch;
        private System.Windows.Forms.LinkLabel link_token;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_gifs;
    }
}