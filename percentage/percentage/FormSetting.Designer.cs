namespace percentage
{
    partial class FormSetting
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFG = new System.Windows.Forms.Button();
            this.btnBG = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.lblFont = new System.Windows.Forms.Label();
            this.btnFontDefault = new System.Windows.Forms.Button();
            this.btnBGDefault = new System.Windows.Forms.Button();
            this.btnFGDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(166, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(47, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnFG
            // 
            this.btnFG.Location = new System.Drawing.Point(47, 12);
            this.btnFG.Name = "btnFG";
            this.btnFG.Size = new System.Drawing.Size(75, 23);
            this.btnFG.TabIndex = 2;
            this.btnFG.Text = "Text Color";
            this.btnFG.UseVisualStyleBackColor = true;
            this.btnFG.Click += new System.EventHandler(this.btnFG_Click);
            // 
            // btnBG
            // 
            this.btnBG.Location = new System.Drawing.Point(47, 56);
            this.btnBG.Name = "btnBG";
            this.btnBG.Size = new System.Drawing.Size(75, 23);
            this.btnBG.TabIndex = 3;
            this.btnBG.Text = "Back Color";
            this.btnBG.UseVisualStyleBackColor = true;
            this.btnBG.Click += new System.EventHandler(this.btnBG_Click);
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(47, 96);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 23);
            this.btnFont.TabIndex = 4;
            this.btnFont.Text = "Text Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // lblFont
            // 
            this.lblFont.Location = new System.Drawing.Point(7, 138);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(272, 74);
            this.lblFont.TabIndex = 10;
            this.lblFont.Text = "Text Font";
            this.lblFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFontDefault
            // 
            this.btnFontDefault.Location = new System.Drawing.Point(166, 96);
            this.btnFontDefault.Name = "btnFontDefault";
            this.btnFontDefault.Size = new System.Drawing.Size(75, 23);
            this.btnFontDefault.TabIndex = 13;
            this.btnFontDefault.Text = "Default";
            this.btnFontDefault.UseVisualStyleBackColor = true;
            this.btnFontDefault.Click += new System.EventHandler(this.btnFontDefault_Click);
            // 
            // btnBGDefault
            // 
            this.btnBGDefault.Location = new System.Drawing.Point(166, 56);
            this.btnBGDefault.Name = "btnBGDefault";
            this.btnBGDefault.Size = new System.Drawing.Size(75, 23);
            this.btnBGDefault.TabIndex = 12;
            this.btnBGDefault.Text = "Default";
            this.btnBGDefault.UseVisualStyleBackColor = true;
            this.btnBGDefault.Click += new System.EventHandler(this.btnBGDefault_Click);
            // 
            // btnFGDefault
            // 
            this.btnFGDefault.Location = new System.Drawing.Point(166, 12);
            this.btnFGDefault.Name = "btnFGDefault";
            this.btnFGDefault.Size = new System.Drawing.Size(75, 23);
            this.btnFGDefault.TabIndex = 11;
            this.btnFGDefault.Text = "Default";
            this.btnFGDefault.UseVisualStyleBackColor = true;
            this.btnFGDefault.Click += new System.EventHandler(this.btnFGDefault_Click);
            // 
            // FormSetting
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(286, 261);
            this.Controls.Add(this.btnFontDefault);
            this.Controls.Add(this.btnBGDefault);
            this.Controls.Add(this.btnFGDefault);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.btnBG);
            this.Controls.Add(this.btnFG);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFG;
        private System.Windows.Forms.Button btnBG;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Button btnFontDefault;
        private System.Windows.Forms.Button btnBGDefault;
        private System.Windows.Forms.Button btnFGDefault;
    }
}