namespace BalluffVisionConfigurator
{
    partial class FormSettingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingWindow));
            this.labelLanguage = new System.Windows.Forms.Label();
            this.cBSystemLanguage = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelStatement = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLanguage.Location = new System.Drawing.Point(27, 32);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(80, 16);
            this.labelLanguage.TabIndex = 0;
            this.labelLanguage.Text = "Language:";
            // 
            // cBSystemLanguage
            // 
            this.cBSystemLanguage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBSystemLanguage.FormattingEnabled = true;
            this.cBSystemLanguage.Items.AddRange(new object[] {
            "English",
            "中文"});
            this.cBSystemLanguage.Location = new System.Drawing.Point(127, 29);
            this.cBSystemLanguage.Name = "cBSystemLanguage";
            this.cBSystemLanguage.Size = new System.Drawing.Size(121, 24);
            this.cBSystemLanguage.TabIndex = 2;
            this.cBSystemLanguage.SelectedIndexChanged += new System.EventHandler(this.cBSystemLanguage_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelStatement);
            this.panel1.Location = new System.Drawing.Point(12, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 248);
            this.panel1.TabIndex = 3;
            // 
            // labelStatement
            // 
            this.labelStatement.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatement.Location = new System.Drawing.Point(14, 22);
            this.labelStatement.Name = "labelStatement";
            this.labelStatement.Size = new System.Drawing.Size(414, 196);
            this.labelStatement.TabIndex = 0;
            this.labelStatement.Text = resources.GetString("labelStatement.Text");
            this.labelStatement.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormSettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 451);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cBSystemLanguage);
            this.Controls.Add(this.labelLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(488, 490);
            this.MinimumSize = new System.Drawing.Size(488, 490);
            this.Name = "FormSettingWindow";
            this.Text = "Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettingWindow_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.ComboBox cBSystemLanguage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelStatement;
    }
}