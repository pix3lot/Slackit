namespace RevitSlack
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
            this.slackEnable = new System.Windows.Forms.CheckBox();
            this.slackToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.slackChannels = new System.Windows.Forms.ComboBox();
            this.slackChannel = new System.Windows.Forms.Label();
            this.slackSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // slackEnable
            // 
            this.slackEnable.AutoSize = true;
            this.slackEnable.Location = new System.Drawing.Point(8, 42);
            this.slackEnable.Name = "slackEnable";
            this.slackEnable.Size = new System.Drawing.Size(18, 17);
            this.slackEnable.TabIndex = 0;
            this.slackEnable.UseVisualStyleBackColor = true;
            // 
            // slackToken
            // 
            this.slackToken.Location = new System.Drawing.Point(8, 91);
            this.slackToken.Name = "slackToken";
            this.slackToken.Size = new System.Drawing.Size(242, 22);
            this.slackToken.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enable";
            // 
            // slackChannels
            // 
            this.slackChannels.FormattingEnabled = true;
            this.slackChannels.Location = new System.Drawing.Point(12, 151);
            this.slackChannels.Name = "slackChannels";
            this.slackChannels.Size = new System.Drawing.Size(247, 24);
            this.slackChannels.TabIndex = 4;
            // 
            // slackChannel
            // 
            this.slackChannel.AutoSize = true;
            this.slackChannel.Location = new System.Drawing.Point(12, 131);
            this.slackChannel.Name = "slackChannel";
            this.slackChannel.Size = new System.Drawing.Size(60, 17);
            this.slackChannel.TabIndex = 5;
            this.slackChannel.Text = "Channel";
            // 
            // slackSave
            // 
            this.slackSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.slackSave.Location = new System.Drawing.Point(12, 197);
            this.slackSave.Name = "slackSave";
            this.slackSave.Size = new System.Drawing.Size(246, 31);
            this.slackSave.TabIndex = 6;
            this.slackSave.Text = "Save Settings";
            this.slackSave.UseVisualStyleBackColor = true;
            this.slackSave.Click += new System.EventHandler(this.slackSave_Click);
            // 
            // SlackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 242);
            this.Controls.Add(this.slackSave);
            this.Controls.Add(this.slackChannel);
            this.Controls.Add(this.slackChannels);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slackToken);
            this.Controls.Add(this.slackEnable);
            this.Name = "SlackForm";
            this.Text = "SlackerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox slackEnable;
        private System.Windows.Forms.TextBox slackToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox slackChannels;
        private System.Windows.Forms.Label slackChannel;
        private System.Windows.Forms.Button slackSave;
    }
}