namespace TranslatorStudio.Forms
{
    partial class frmNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNew));
            this.rtbRAW = new System.Windows.Forms.RichTextBox();
            this.spcProject = new System.Windows.Forms.SplitContainer();
            this.lblRAW = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spcProject)).BeginInit();
            this.spcProject.Panel1.SuspendLayout();
            this.spcProject.Panel2.SuspendLayout();
            this.spcProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbRAW
            // 
            this.rtbRAW.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbRAW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbRAW.Location = new System.Drawing.Point(0, 80);
            this.rtbRAW.Name = "rtbRAW";
            this.rtbRAW.Size = new System.Drawing.Size(584, 426);
            this.rtbRAW.TabIndex = 0;
            this.rtbRAW.Text = "";
            // 
            // spcProject
            // 
            this.spcProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcProject.Location = new System.Drawing.Point(0, 0);
            this.spcProject.Name = "spcProject";
            this.spcProject.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcProject.Panel1
            // 
            this.spcProject.Panel1.Controls.Add(this.lblRAW);
            this.spcProject.Panel1.Controls.Add(this.txtProjectName);
            this.spcProject.Panel1.Controls.Add(this.lblProjectName);
            this.spcProject.Panel1.Controls.Add(this.rtbRAW);
            // 
            // spcProject.Panel2
            // 
            this.spcProject.Panel2.Controls.Add(this.btnQuit);
            this.spcProject.Panel2.Controls.Add(this.btnCreate);
            this.spcProject.Size = new System.Drawing.Size(584, 561);
            this.spcProject.SplitterDistance = 506;
            this.spcProject.TabIndex = 1;
            // 
            // lblRAW
            // 
            this.lblRAW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRAW.Location = new System.Drawing.Point(12, 55);
            this.lblRAW.Name = "lblRAW";
            this.lblRAW.Size = new System.Drawing.Size(126, 22);
            this.lblRAW.TabIndex = 3;
            this.lblRAW.Text = "RAW";
            this.lblRAW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(144, 15);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(132, 20);
            this.txtProjectName.TabIndex = 1;
            // 
            // lblProjectName
            // 
            this.lblProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.Location = new System.Drawing.Point(12, 15);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(126, 22);
            this.lblProjectName.TabIndex = 1;
            this.lblProjectName.Text = "Project Name";
            this.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(12, 16);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(497, 15);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.spcProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Translator Studio - Create New Project";
            this.spcProject.Panel1.ResumeLayout(false);
            this.spcProject.Panel1.PerformLayout();
            this.spcProject.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcProject)).EndInit();
            this.spcProject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbRAW;
        private System.Windows.Forms.SplitContainer spcProject;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblRAW;
        private System.Windows.Forms.TextBox txtProjectName;
    }
}