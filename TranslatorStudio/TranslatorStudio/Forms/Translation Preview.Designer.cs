namespace TranslatorStudio.Forms
{
    partial class FrmPreview
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPreview));
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.colLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRaw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTranslation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPreview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMarkComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarkAttention = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCopyRaw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.cmsPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowDrop = true;
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLineNumber,
            this.colRaw,
            this.colTranslation});
            this.dgvPreview.ContextMenuStrip = this.cmsPreview;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreview.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPreview.Location = new System.Drawing.Point(0, 0);
            this.dgvPreview.MultiSelect = false;
            this.dgvPreview.Name = "dgvPreview";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreview.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.dgvPreview.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPreview.Size = new System.Drawing.Size(784, 561);
            this.dgvPreview.TabIndex = 1;
            this.dgvPreview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreview_CellValueChanged);
            // 
            // colLineNumber
            // 
            this.colLineNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colLineNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLineNumber.Frozen = true;
            this.colLineNumber.HeaderText = "No.";
            this.colLineNumber.MinimumWidth = 40;
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.ReadOnly = true;
            this.colLineNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colLineNumber.Width = 40;
            // 
            // colRaw
            // 
            this.colRaw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colRaw.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRaw.HeaderText = "Raw";
            this.colRaw.MinimumWidth = 100;
            this.colRaw.Name = "colRaw";
            this.colRaw.ReadOnly = true;
            this.colRaw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTranslation
            // 
            this.colTranslation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTranslation.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTranslation.HeaderText = "Translation";
            this.colTranslation.MinimumWidth = 100;
            this.colTranslation.Name = "colTranslation";
            this.colTranslation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmsPreview
            // 
            this.cmsPreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMarkComplete,
            this.tsmiMarkAttention,
            this.toolStripSeparator1,
            this.tsmiCopyRaw,
            this.tsmiSaveChanges});
            this.cmsPreview.Name = "cmsPreview";
            this.cmsPreview.ShowCheckMargin = true;
            this.cmsPreview.Size = new System.Drawing.Size(219, 98);
            this.cmsPreview.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPreview_Opening);
            // 
            // tsmiMarkComplete
            // 
            this.tsmiMarkComplete.CheckOnClick = true;
            this.tsmiMarkComplete.Name = "tsmiMarkComplete";
            this.tsmiMarkComplete.Size = new System.Drawing.Size(218, 22);
            this.tsmiMarkComplete.Text = "Completed";
            this.tsmiMarkComplete.ToolTipText = "Mark or unmark as complete";
            this.tsmiMarkComplete.Click += new System.EventHandler(this.tsmiMarkComplete_Click);
            // 
            // tsmiMarkAttention
            // 
            this.tsmiMarkAttention.CheckOnClick = true;
            this.tsmiMarkAttention.Name = "tsmiMarkAttention";
            this.tsmiMarkAttention.Size = new System.Drawing.Size(218, 22);
            this.tsmiMarkAttention.Text = "Attention";
            this.tsmiMarkAttention.ToolTipText = "Mark or unmark for attention";
            this.tsmiMarkAttention.Click += new System.EventHandler(this.tsmiMarkAttention_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // tsmiCopyRaw
            // 
            this.tsmiCopyRaw.Name = "tsmiCopyRaw";
            this.tsmiCopyRaw.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiCopyRaw.Size = new System.Drawing.Size(218, 22);
            this.tsmiCopyRaw.Text = "Copy Raw";
            this.tsmiCopyRaw.Click += new System.EventHandler(this.tsmiCopyRaw_Click);
            // 
            // tsmiSaveChanges
            // 
            this.tsmiSaveChanges.Name = "tsmiSaveChanges";
            this.tsmiSaveChanges.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveChanges.Size = new System.Drawing.Size(218, 22);
            this.tsmiSaveChanges.Text = "Save Changes...";
            this.tsmiSaveChanges.Click += new System.EventHandler(this.tsmiSaveChanges_Click);
            // 
            // FrmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 240);
            this.Name = "FrmPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Translator Studio - Preview";
            this.Load += new System.EventHandler(this.Translation_Preview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.cmsPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.ContextMenuStrip cmsPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarkComplete;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarkAttention;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRaw;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTranslation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyRaw;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveChanges;
    }
}