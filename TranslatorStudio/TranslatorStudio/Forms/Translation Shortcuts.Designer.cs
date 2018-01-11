namespace TranslatorStudio.Forms
{
    partial class FrmShortcuts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShortcuts));
            this.lstShortcut = new System.Windows.Forms.ListView();
            this.lblShortcutsHeading = new System.Windows.Forms.Label();
            this.colCommands = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShortcuts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstShortcut
            // 
            this.lstShortcut.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCommands,
            this.colShortcuts});
            this.lstShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstShortcut.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstShortcut.Location = new System.Drawing.Point(0, 59);
            this.lstShortcut.Name = "lstShortcut";
            this.lstShortcut.Size = new System.Drawing.Size(384, 302);
            this.lstShortcut.TabIndex = 24;
            this.lstShortcut.UseCompatibleStateImageBehavior = false;
            this.lstShortcut.View = System.Windows.Forms.View.Details;
            // 
            // lblShortcutsHeading
            // 
            this.lblShortcutsHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblShortcutsHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcutsHeading.Location = new System.Drawing.Point(0, 0);
            this.lblShortcutsHeading.Name = "lblShortcutsHeading";
            this.lblShortcutsHeading.Size = new System.Drawing.Size(384, 59);
            this.lblShortcutsHeading.TabIndex = 25;
            this.lblShortcutsHeading.Text = "Shortcuts";
            this.lblShortcutsHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colCommands
            // 
            this.colCommands.Text = "Commands";
            this.colCommands.Width = 141;
            // 
            // colShortcuts
            // 
            this.colShortcuts.Text = "Shortcuts";
            this.colShortcuts.Width = 228;
            // 
            // FrmShortcuts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.lstShortcut);
            this.Controls.Add(this.lblShortcutsHeading);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShortcuts";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shortcuts";
            this.Load += new System.EventHandler(this.FrmShortcuts_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstShortcut;
        private System.Windows.Forms.Label lblShortcutsHeading;
        private System.Windows.Forms.ColumnHeader colCommands;
        private System.Windows.Forms.ColumnHeader colShortcuts;
    }
}