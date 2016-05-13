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
            this.label_token = new System.Windows.Forms.Label();
            this.label_enable = new System.Windows.Forms.Label();
            this.combobox_channels = new System.Windows.Forms.ComboBox();
            this.label_channel = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.pictureboc_logo = new System.Windows.Forms.PictureBox();
            this.label_title = new System.Windows.Forms.Label();
            this.button_reload_ch = new System.Windows.Forms.Button();
            this.link_token = new System.Windows.Forms.LinkLabel();
            this.label_extras = new System.Windows.Forms.Label();
            this.label_giphy = new System.Windows.Forms.Label();
            this.combobox_giphy = new System.Windows.Forms.ComboBox();
            this.label_tidy = new System.Windows.Forms.Label();
            this.checkbox_ws_warn = new System.Windows.Forms.CheckBox();
            this.checkbox_model_warn = new System.Windows.Forms.CheckBox();
            this.checkbox_bp_warn = new System.Windows.Forms.CheckBox();
            this.checkbox_extra_trackpin = new System.Windows.Forms.CheckBox();
            this.combobox_tidy = new System.Windows.Forms.ComboBox();
            this.textbox_token = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkbox_ws_info = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbox_extra_tbd2 = new System.Windows.Forms.CheckBox();
            this.checkbox_extra_tbd1 = new System.Windows.Forms.CheckBox();
            this.checkbox_bp_info = new System.Windows.Forms.CheckBox();
            this.checkbox_model_info = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboc_logo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkbox_enable
            // 
            this.checkbox_enable.AutoSize = true;
            this.checkbox_enable.Location = new System.Drawing.Point(65, 144);
            this.checkbox_enable.Margin = new System.Windows.Forms.Padding(2);
            this.checkbox_enable.Name = "checkbox_enable";
            this.checkbox_enable.Size = new System.Drawing.Size(15, 14);
            this.checkbox_enable.TabIndex = 0;
            this.checkbox_enable.UseVisualStyleBackColor = true;
            // 
            // label_token
            // 
            this.label_token.AutoSize = true;
            this.label_token.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_token.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_token.Location = new System.Drawing.Point(2, 171);
            this.label_token.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_token.Name = "label_token";
            this.label_token.Size = new System.Drawing.Size(49, 13);
            this.label_token.TabIndex = 2;
            this.label_token.Text = "TOKEN";
            // 
            // label_enable
            // 
            this.label_enable.AutoSize = true;
            this.label_enable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_enable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_enable.Location = new System.Drawing.Point(2, 144);
            this.label_enable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_enable.Name = "label_enable";
            this.label_enable.Size = new System.Drawing.Size(55, 13);
            this.label_enable.TabIndex = 3;
            this.label_enable.Text = "ENABLE";
            // 
            // combobox_channels
            // 
            this.combobox_channels.FormattingEnabled = true;
            this.combobox_channels.Location = new System.Drawing.Point(5, 242);
            this.combobox_channels.Margin = new System.Windows.Forms.Padding(2);
            this.combobox_channels.Name = "combobox_channels";
            this.combobox_channels.Size = new System.Drawing.Size(326, 21);
            this.combobox_channels.TabIndex = 4;
            // 
            // label_channel
            // 
            this.label_channel.AutoSize = true;
            this.label_channel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_channel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_channel.Location = new System.Drawing.Point(2, 223);
            this.label_channel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_channel.Name = "label_channel";
            this.label_channel.Size = new System.Drawing.Size(125, 13);
            this.label_channel.TabIndex = 5;
            this.label_channel.Text = "PROJECT CHANNEL";
            // 
            // button_save
            // 
            this.button_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_save.Location = new System.Drawing.Point(6, 524);
            this.button_save.Margin = new System.Windows.Forms.Padding(2);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(326, 25);
            this.button_save.TabIndex = 6;
            this.button_save.Text = "Save Settings";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.slackSave_Click);
            // 
            // pictureboc_logo
            // 
            this.pictureboc_logo.Image = global::SlackitRevit.Properties.Resources.SlackitLogoSmall;
            this.pictureboc_logo.Location = new System.Drawing.Point(225, 12);
            this.pictureboc_logo.Name = "pictureboc_logo";
            this.pictureboc_logo.Size = new System.Drawing.Size(106, 90);
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
            this.label_title.Location = new System.Drawing.Point(5, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(93, 24);
            this.label_title.TabIndex = 8;
            this.label_title.Text = "SLACKIT";
            // 
            // button_reload_ch
            // 
            this.button_reload_ch.Location = new System.Drawing.Point(235, 216);
            this.button_reload_ch.Name = "button_reload_ch";
            this.button_reload_ch.Size = new System.Drawing.Size(96, 21);
            this.button_reload_ch.TabIndex = 10;
            this.button_reload_ch.Text = "Get Channels";
            this.button_reload_ch.UseVisualStyleBackColor = true;
            this.button_reload_ch.Click += new System.EventHandler(this.button_reload_ch_Click);
            // 
            // link_token
            // 
            this.link_token.AutoSize = true;
            this.link_token.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.link_token.Location = new System.Drawing.Point(62, 171);
            this.link_token.Name = "link_token";
            this.link_token.Size = new System.Drawing.Size(98, 13);
            this.link_token.TabIndex = 11;
            this.link_token.TabStop = true;
            this.link_token.Text = "How to get a token";
            this.link_token.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_token_LinkClicked);
            // 
            // label_extras
            // 
            this.label_extras.AutoSize = true;
            this.label_extras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_extras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_extras.Location = new System.Drawing.Point(24, 107);
            this.label_extras.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_extras.Name = "label_extras";
            this.label_extras.Size = new System.Drawing.Size(31, 13);
            this.label_extras.TabIndex = 17;
            this.label_extras.Text = "Extra";
            // 
            // label_giphy
            // 
            this.label_giphy.AutoSize = true;
            this.label_giphy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_giphy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_giphy.Location = new System.Drawing.Point(2, 470);
            this.label_giphy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_giphy.Name = "label_giphy";
            this.label_giphy.Size = new System.Drawing.Size(45, 13);
            this.label_giphy.TabIndex = 18;
            this.label_giphy.Text = "GIPHY";
            // 
            // combobox_giphy
            // 
            this.combobox_giphy.FormattingEnabled = true;
            this.combobox_giphy.Items.AddRange(new object[] {
            "None",
            "Small",
            "Large"});
            this.combobox_giphy.Location = new System.Drawing.Point(5, 486);
            this.combobox_giphy.Name = "combobox_giphy";
            this.combobox_giphy.Size = new System.Drawing.Size(155, 21);
            this.combobox_giphy.TabIndex = 19;
            // 
            // label_tidy
            // 
            this.label_tidy.AutoSize = true;
            this.label_tidy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tidy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label_tidy.Location = new System.Drawing.Point(172, 470);
            this.label_tidy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_tidy.Name = "label_tidy";
            this.label_tidy.Size = new System.Drawing.Size(57, 13);
            this.label_tidy.TabIndex = 20;
            this.label_tidy.Text = "TIDY UP";
            // 
            // checkbox_ws_warn
            // 
            this.checkbox_ws_warn.AutoSize = true;
            this.checkbox_ws_warn.Checked = true;
            this.checkbox_ws_warn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_ws_warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_ws_warn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_ws_warn.Location = new System.Drawing.Point(215, 22);
            this.checkbox_ws_warn.Name = "checkbox_ws_warn";
            this.checkbox_ws_warn.Size = new System.Drawing.Size(71, 17);
            this.checkbox_ws_warn.TabIndex = 21;
            this.checkbox_ws_warn.Text = "Warnings";
            this.checkbox_ws_warn.UseVisualStyleBackColor = true;
            // 
            // checkbox_model_warn
            // 
            this.checkbox_model_warn.AutoSize = true;
            this.checkbox_model_warn.Checked = true;
            this.checkbox_model_warn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_model_warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_model_warn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_model_warn.Location = new System.Drawing.Point(215, 45);
            this.checkbox_model_warn.Name = "checkbox_model_warn";
            this.checkbox_model_warn.Size = new System.Drawing.Size(71, 17);
            this.checkbox_model_warn.TabIndex = 22;
            this.checkbox_model_warn.Text = "Warnings";
            this.checkbox_model_warn.UseVisualStyleBackColor = true;
            // 
            // checkbox_bp_warn
            // 
            this.checkbox_bp_warn.AutoSize = true;
            this.checkbox_bp_warn.Checked = true;
            this.checkbox_bp_warn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_bp_warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_bp_warn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_bp_warn.Location = new System.Drawing.Point(215, 68);
            this.checkbox_bp_warn.Name = "checkbox_bp_warn";
            this.checkbox_bp_warn.Size = new System.Drawing.Size(71, 17);
            this.checkbox_bp_warn.TabIndex = 23;
            this.checkbox_bp_warn.Text = "Warnings";
            this.checkbox_bp_warn.UseVisualStyleBackColor = true;
            // 
            // checkbox_extra_trackpin
            // 
            this.checkbox_extra_trackpin.AutoSize = true;
            this.checkbox_extra_trackpin.Checked = true;
            this.checkbox_extra_trackpin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_extra_trackpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_extra_trackpin.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_extra_trackpin.Location = new System.Drawing.Point(141, 106);
            this.checkbox_extra_trackpin.Name = "checkbox_extra_trackpin";
            this.checkbox_extra_trackpin.Size = new System.Drawing.Size(145, 17);
            this.checkbox_extra_trackpin.TabIndex = 24;
            this.checkbox_extra_trackpin.Text = "Pinned Element Tracking";
            this.checkbox_extra_trackpin.UseVisualStyleBackColor = true;
            // 
            // combobox_tidy
            // 
            this.combobox_tidy.FormattingEnabled = true;
            this.combobox_tidy.Items.AddRange(new object[] {
            "None (Keep All Messages)",
            "Clean Up Synching",
            "(TBD) Clean Up All Warnings",
            "(TBD) Clean Up All Messages"});
            this.combobox_tidy.Location = new System.Drawing.Point(175, 486);
            this.combobox_tidy.Name = "combobox_tidy";
            this.combobox_tidy.Size = new System.Drawing.Size(156, 21);
            this.combobox_tidy.TabIndex = 25;
            // 
            // textbox_token
            // 
            this.textbox_token.Location = new System.Drawing.Point(5, 188);
            this.textbox_token.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_token.Name = "textbox_token";
            this.textbox_token.Size = new System.Drawing.Size(326, 20);
            this.textbox_token.TabIndex = 1;
            this.textbox_token.TextChanged += new System.EventHandler(this.textboxToken_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(9, 40);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(210, 92);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Worksharing";
            // 
            // checkbox_ws_info
            // 
            this.checkbox_ws_info.AutoSize = true;
            this.checkbox_ws_info.Checked = true;
            this.checkbox_ws_info.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_ws_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_ws_info.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_ws_info.Location = new System.Drawing.Point(141, 22);
            this.checkbox_ws_info.Name = "checkbox_ws_info";
            this.checkbox_ws_info.Size = new System.Drawing.Size(44, 17);
            this.checkbox_ws_info.TabIndex = 28;
            this.checkbox_ws_info.Text = "Info";
            this.checkbox_ws_info.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbox_extra_tbd2);
            this.groupBox1.Controls.Add(this.checkbox_extra_tbd1);
            this.groupBox1.Controls.Add(this.checkbox_bp_info);
            this.groupBox1.Controls.Add(this.checkbox_model_info);
            this.groupBox1.Controls.Add(this.checkbox_extra_trackpin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkbox_ws_info);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_extras);
            this.groupBox1.Controls.Add(this.checkbox_ws_warn);
            this.groupBox1.Controls.Add(this.checkbox_bp_warn);
            this.groupBox1.Controls.Add(this.checkbox_model_warn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(5, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 181);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MESSAGES";
            // 
            // checkbox_extra_tbd2
            // 
            this.checkbox_extra_tbd2.AutoSize = true;
            this.checkbox_extra_tbd2.Enabled = false;
            this.checkbox_extra_tbd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_extra_tbd2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_extra_tbd2.Location = new System.Drawing.Point(141, 149);
            this.checkbox_extra_tbd2.Name = "checkbox_extra_tbd2";
            this.checkbox_extra_tbd2.Size = new System.Drawing.Size(48, 17);
            this.checkbox_extra_tbd2.TabIndex = 34;
            this.checkbox_extra_tbd2.Text = "TBD";
            this.checkbox_extra_tbd2.UseVisualStyleBackColor = true;
            // 
            // checkbox_extra_tbd1
            // 
            this.checkbox_extra_tbd1.AutoSize = true;
            this.checkbox_extra_tbd1.Enabled = false;
            this.checkbox_extra_tbd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_extra_tbd1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_extra_tbd1.Location = new System.Drawing.Point(141, 129);
            this.checkbox_extra_tbd1.Name = "checkbox_extra_tbd1";
            this.checkbox_extra_tbd1.Size = new System.Drawing.Size(48, 17);
            this.checkbox_extra_tbd1.TabIndex = 33;
            this.checkbox_extra_tbd1.Text = "TBD";
            this.checkbox_extra_tbd1.UseVisualStyleBackColor = true;
            // 
            // checkbox_bp_info
            // 
            this.checkbox_bp_info.AutoSize = true;
            this.checkbox_bp_info.Checked = true;
            this.checkbox_bp_info.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_bp_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_bp_info.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_bp_info.Location = new System.Drawing.Point(141, 67);
            this.checkbox_bp_info.Name = "checkbox_bp_info";
            this.checkbox_bp_info.Size = new System.Drawing.Size(44, 17);
            this.checkbox_bp_info.TabIndex = 32;
            this.checkbox_bp_info.Text = "Info";
            this.checkbox_bp_info.UseVisualStyleBackColor = true;
            // 
            // checkbox_model_info
            // 
            this.checkbox_model_info.AutoSize = true;
            this.checkbox_model_info.Checked = true;
            this.checkbox_model_info.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_model_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_model_info.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkbox_model_info.Location = new System.Drawing.Point(141, 44);
            this.checkbox_model_info.Name = "checkbox_model_info";
            this.checkbox_model_info.Size = new System.Drawing.Size(44, 17);
            this.checkbox_model_info.TabIndex = 31;
            this.checkbox_model_info.Text = "Info";
            this.checkbox_model_info.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(24, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Best Practices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(24, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Model";
            // 
            // SlackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(343, 562);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.combobox_tidy);
            this.Controls.Add(this.label_tidy);
            this.Controls.Add(this.combobox_giphy);
            this.Controls.Add(this.label_giphy);
            this.Controls.Add(this.link_token);
            this.Controls.Add(this.button_reload_ch);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.pictureboc_logo);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_channel);
            this.Controls.Add(this.combobox_channels);
            this.Controls.Add(this.label_enable);
            this.Controls.Add(this.label_token);
            this.Controls.Add(this.textbox_token);
            this.Controls.Add(this.checkbox_enable);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SlackForm";
            this.Text = "Slackit Revit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureboc_logo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkbox_enable;
        private System.Windows.Forms.Label label_token;
        private System.Windows.Forms.Label label_enable;
        private System.Windows.Forms.ComboBox combobox_channels;
        private System.Windows.Forms.Label label_channel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.PictureBox pictureboc_logo;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Button button_reload_ch;
        private System.Windows.Forms.LinkLabel link_token;
        private System.Windows.Forms.Label label_extras;
        private System.Windows.Forms.Label label_giphy;
        private System.Windows.Forms.ComboBox combobox_giphy;
        private System.Windows.Forms.Label label_tidy;
        private System.Windows.Forms.CheckBox checkbox_ws_warn;
        private System.Windows.Forms.CheckBox checkbox_model_warn;
        private System.Windows.Forms.CheckBox checkbox_bp_warn;
        private System.Windows.Forms.CheckBox checkbox_extra_trackpin;
        private System.Windows.Forms.ComboBox combobox_tidy;
        private System.Windows.Forms.TextBox textbox_token;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkbox_ws_info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkbox_extra_tbd2;
        private System.Windows.Forms.CheckBox checkbox_extra_tbd1;
        private System.Windows.Forms.CheckBox checkbox_bp_info;
        private System.Windows.Forms.CheckBox checkbox_model_info;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}