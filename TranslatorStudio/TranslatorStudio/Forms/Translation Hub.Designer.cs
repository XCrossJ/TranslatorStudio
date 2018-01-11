namespace TranslatorStudio.Forms
{
    partial class FrmHub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHub));
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnDesk = new System.Windows.Forms.Button();
            this.lblHubHeading = new System.Windows.Forms.Label();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(197, 99);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 50);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnDesk
            // 
            this.btnDesk.Location = new System.Drawing.Point(104, 99);
            this.btnDesk.Name = "btnDesk";
            this.btnDesk.Size = new System.Drawing.Size(75, 50);
            this.btnDesk.TabIndex = 1;
            this.btnDesk.Text = "Open Desk";
            this.btnDesk.UseVisualStyleBackColor = true;
            this.btnDesk.Click += new System.EventHandler(this.btnDesk_Click);
            // 
            // lblHubHeading
            // 
            this.lblHubHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHubHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHubHeading.Location = new System.Drawing.Point(0, 0);
            this.lblHubHeading.Name = "lblHubHeading";
            this.lblHubHeading.Size = new System.Drawing.Size(284, 47);
            this.lblHubHeading.TabIndex = 2;
            this.lblHubHeading.Text = "Translator Studio";
            this.lblHubHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewProject
            // 
            this.btnNewProject.Location = new System.Drawing.Point(12, 99);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(75, 50);
            this.btnNewProject.TabIndex = 0;
            this.btnNewProject.Text = "New Project";
            this.btnNewProject.UseVisualStyleBackColor = true;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // FrmHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.lblHubHeading);
            this.Controls.Add(this.btnDesk);
            this.Controls.Add(this.btnQuit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FrmHub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translator Studio - Hub";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnDesk;
        private System.Windows.Forms.Label lblHubHeading;
        private System.Windows.Forms.Button btnNewProject;
    }
}

