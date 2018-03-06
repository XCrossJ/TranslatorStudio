using System.Windows.Forms;

namespace TranslatorStudio.Forms
{
    partial class FrmDesk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDesk));
            this.lblRawHeading = new System.Windows.Forms.Label();
            this.rtbRawContent = new System.Windows.Forms.RichTextBox();
            this.cmsDesk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNextLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrevLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tssContext1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiContextComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContextMarked = new System.Windows.Forms.ToolStripMenuItem();
            this.tssContext2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiContextCopyRaw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContextShortcuts = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTranslationHeading = new System.Windows.Forms.Label();
            this.rtbTranslationContent = new System.Windows.Forms.RichTextBox();
            this.chkComplete = new System.Windows.Forms.CheckBox();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tssFile = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tssFile2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyRaw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIncompleteOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarkedOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCompleteOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarkComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarkAttention = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTools = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiWebTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGoogleTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWeblio = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShortcuts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.chkMark = new System.Windows.Forms.CheckBox();
            this.spcDesk = new System.Windows.Forms.SplitContainer();
            this.spcRaw = new System.Windows.Forms.SplitContainer();
            this.spcTranslation = new System.Windows.Forms.SplitContainer();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblEditModeHeading = new System.Windows.Forms.Label();
            this.cmbEditMode = new System.Windows.Forms.ComboBox();
            this.lblProgressHeading = new System.Windows.Forms.Label();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblCurrentLineHeading = new System.Windows.Forms.Label();
            this.lblStatusHeading = new System.Windows.Forms.Label();
            this.lblProjectHeading = new System.Windows.Forms.Label();
            this.nudLineNumber = new System.Windows.Forms.NumericUpDown();
            this.lblMaxLine = new System.Windows.Forms.Label();
            this.spcTools = new System.Windows.Forms.SplitContainer();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lblTools = new System.Windows.Forms.Label();
            this.pnlDesk = new System.Windows.Forms.Panel();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.tsmiAutoMode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDesk.SuspendLayout();
            this.mnuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcDesk)).BeginInit();
            this.spcDesk.Panel1.SuspendLayout();
            this.spcDesk.Panel2.SuspendLayout();
            this.spcDesk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcRaw)).BeginInit();
            this.spcRaw.Panel1.SuspendLayout();
            this.spcRaw.Panel2.SuspendLayout();
            this.spcRaw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcTranslation)).BeginInit();
            this.spcTranslation.Panel1.SuspendLayout();
            this.spcTranslation.Panel2.SuspendLayout();
            this.spcTranslation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcTools)).BeginInit();
            this.spcTools.Panel1.SuspendLayout();
            this.spcTools.Panel2.SuspendLayout();
            this.spcTools.SuspendLayout();
            this.pnlDesk.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRawHeading
            // 
            this.lblRawHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRawHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRawHeading.Location = new System.Drawing.Point(0, 0);
            this.lblRawHeading.Name = "lblRawHeading";
            this.lblRawHeading.Size = new System.Drawing.Size(771, 35);
            this.lblRawHeading.TabIndex = 0;
            this.lblRawHeading.Text = "RAW";
            this.lblRawHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbRawContent
            // 
            this.rtbRawContent.ContextMenuStrip = this.cmsDesk;
            this.rtbRawContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRawContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbRawContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.rtbRawContent.Location = new System.Drawing.Point(0, 0);
            this.rtbRawContent.Name = "rtbRawContent";
            this.rtbRawContent.Size = new System.Drawing.Size(771, 203);
            this.rtbRawContent.TabIndex = 0;
            this.rtbRawContent.TabStop = false;
            this.rtbRawContent.Text = "";
            this.rtbRawContent.TextChanged += new System.EventHandler(this.rtbRawContent_TextChanged);
            // 
            // cmsDesk
            // 
            this.cmsDesk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNextLine,
            this.tsmiPrevLine,
            this.tssContext1,
            this.tsmiContextComplete,
            this.tsmiContextMarked,
            this.tssContext2,
            this.tsmiContextCopyRaw,
            this.tsmiContextShortcuts});
            this.cmsDesk.Name = "cmsDesk";
            this.cmsDesk.ShowCheckMargin = true;
            this.cmsDesk.Size = new System.Drawing.Size(231, 148);
            this.cmsDesk.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDesk_Opening);
            // 
            // tsmiNextLine
            // 
            this.tsmiNextLine.Name = "tsmiNextLine";
            this.tsmiNextLine.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Right)));
            this.tsmiNextLine.Size = new System.Drawing.Size(230, 22);
            this.tsmiNextLine.Text = "Next Line";
            this.tsmiNextLine.Click += new System.EventHandler(this.tsmiNextLine_Click);
            // 
            // tsmiPrevLine
            // 
            this.tsmiPrevLine.Name = "tsmiPrevLine";
            this.tsmiPrevLine.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Left)));
            this.tsmiPrevLine.Size = new System.Drawing.Size(230, 22);
            this.tsmiPrevLine.Text = "Prev Line";
            this.tsmiPrevLine.Click += new System.EventHandler(this.tsmiPrevLine_Click);
            // 
            // tssContext1
            // 
            this.tssContext1.Name = "tssContext1";
            this.tssContext1.Size = new System.Drawing.Size(227, 6);
            // 
            // tsmiContextComplete
            // 
            this.tsmiContextComplete.Name = "tsmiContextComplete";
            this.tsmiContextComplete.Size = new System.Drawing.Size(230, 22);
            this.tsmiContextComplete.Text = "Completed";
            this.tsmiContextComplete.ToolTipText = "Mark or unmark as Completed";
            this.tsmiContextComplete.Click += new System.EventHandler(this.tsmiContextComplete_Click);
            // 
            // tsmiContextMarked
            // 
            this.tsmiContextMarked.Name = "tsmiContextMarked";
            this.tsmiContextMarked.Size = new System.Drawing.Size(230, 22);
            this.tsmiContextMarked.Text = "Marked";
            this.tsmiContextMarked.ToolTipText = "Mark or unmark for Attention";
            this.tsmiContextMarked.Click += new System.EventHandler(this.tsmiContextMarked_Click);
            // 
            // tssContext2
            // 
            this.tssContext2.Name = "tssContext2";
            this.tssContext2.Size = new System.Drawing.Size(227, 6);
            // 
            // tsmiContextCopyRaw
            // 
            this.tsmiContextCopyRaw.Name = "tsmiContextCopyRaw";
            this.tsmiContextCopyRaw.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiContextCopyRaw.Size = new System.Drawing.Size(230, 22);
            this.tsmiContextCopyRaw.Text = "Copy Raw";
            this.tsmiContextCopyRaw.Click += new System.EventHandler(this.tsmiContextCopyRaw_Click);
            // 
            // tsmiContextShortcuts
            // 
            this.tsmiContextShortcuts.Name = "tsmiContextShortcuts";
            this.tsmiContextShortcuts.Size = new System.Drawing.Size(230, 22);
            this.tsmiContextShortcuts.Text = "Shortcuts";
            this.tsmiContextShortcuts.Click += new System.EventHandler(this.tsmiContextShortcuts_Click);
            // 
            // lblTranslationHeading
            // 
            this.lblTranslationHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTranslationHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranslationHeading.Location = new System.Drawing.Point(0, 0);
            this.lblTranslationHeading.Name = "lblTranslationHeading";
            this.lblTranslationHeading.Size = new System.Drawing.Size(771, 33);
            this.lblTranslationHeading.TabIndex = 0;
            this.lblTranslationHeading.Text = "Translation";
            this.lblTranslationHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbTranslationContent
            // 
            this.rtbTranslationContent.AcceptsTab = true;
            this.rtbTranslationContent.ContextMenuStrip = this.cmsDesk;
            this.rtbTranslationContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTranslationContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTranslationContent.Location = new System.Drawing.Point(0, 0);
            this.rtbTranslationContent.Name = "rtbTranslationContent";
            this.rtbTranslationContent.Size = new System.Drawing.Size(771, 176);
            this.rtbTranslationContent.TabIndex = 0;
            this.rtbTranslationContent.Text = "";
            this.rtbTranslationContent.TextChanged += new System.EventHandler(this.rtbTranslationContent_TextChanged);
            // 
            // chkComplete
            // 
            this.chkComplete.AutoSize = true;
            this.chkComplete.Location = new System.Drawing.Point(117, 53);
            this.chkComplete.Name = "chkComplete";
            this.chkComplete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkComplete.Size = new System.Drawing.Size(111, 17);
            this.chkComplete.TabIndex = 5;
            this.chkComplete.Text = "Mark as Complete";
            this.chkComplete.UseVisualStyleBackColor = true;
            this.chkComplete.CheckedChanged += new System.EventHandler(this.chkComplete_CheckedChanged);
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit,
            this.tsmiView,
            this.tsmiTools,
            this.helpToolStripMenuItem});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(1008, 24);
            this.mnuStrip.TabIndex = 10;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiOpen,
            this.tssFile,
            this.tsmiSave,
            this.tsmiSaveAs,
            this.tsmiExport,
            this.tssFile2,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Image = ((System.Drawing.Image)(resources.GetObject("tsmiNew.Image")));
            this.tsmiNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiNew.Size = new System.Drawing.Size(146, 22);
            this.tsmiNew.Text = "&New";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOpen.Image")));
            this.tsmiOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiOpen.Size = new System.Drawing.Size(146, 22);
            this.tsmiOpen.Text = "&Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tssFile
            // 
            this.tssFile.Name = "tssFile";
            this.tssFile.Size = new System.Drawing.Size(143, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSave.Image")));
            this.tsmiSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(146, 22);
            this.tsmiSave.Text = "&Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Size = new System.Drawing.Size(146, 22);
            this.tsmiSaveAs.Text = "Save &As";
            this.tsmiSaveAs.Click += new System.EventHandler(this.tsmiSaveAs_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(146, 22);
            this.tsmiExport.Text = "&Export";
            this.tsmiExport.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // tssFile2
            // 
            this.tssFile2.Name = "tssFile2";
            this.tssFile2.Size = new System.Drawing.Size(143, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(146, 22);
            this.tsmiExit.Text = "E&xit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyRaw});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(39, 20);
            this.tsmiEdit.Text = "&Edit";
            // 
            // tsmiCopyRaw
            // 
            this.tsmiCopyRaw.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCopyRaw.Image")));
            this.tsmiCopyRaw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiCopyRaw.Name = "tsmiCopyRaw";
            this.tsmiCopyRaw.Size = new System.Drawing.Size(127, 22);
            this.tsmiCopyRaw.Text = "&Copy Raw";
            this.tsmiCopyRaw.Click += new System.EventHandler(this.tsmiCopyRaw_Click);
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAutoMode,
            this.tsmiEditMode,
            this.tsmiPreview});
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(44, 20);
            this.tsmiView.Text = "&View";
            // 
            // tsmiEditMode
            // 
            this.tsmiEditMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDefault,
            this.tsmiIncompleteOnly,
            this.tsmiMarkedOnly,
            this.tsmiCompleteOnly});
            this.tsmiEditMode.Name = "tsmiEditMode";
            this.tsmiEditMode.Size = new System.Drawing.Size(177, 22);
            this.tsmiEditMode.Text = "Edit &Mode";
            // 
            // tsmiDefault
            // 
            this.tsmiDefault.Name = "tsmiDefault";
            this.tsmiDefault.Size = new System.Drawing.Size(162, 22);
            this.tsmiDefault.Text = "&Default";
            this.tsmiDefault.Click += new System.EventHandler(this.tsmiDefault_Click);
            // 
            // tsmiIncompleteOnly
            // 
            this.tsmiIncompleteOnly.Name = "tsmiIncompleteOnly";
            this.tsmiIncompleteOnly.Size = new System.Drawing.Size(162, 22);
            this.tsmiIncompleteOnly.Text = "&Incomplete Only";
            this.tsmiIncompleteOnly.Click += new System.EventHandler(this.tsmiIncompleteOnly_Click);
            // 
            // tsmiMarkedOnly
            // 
            this.tsmiMarkedOnly.Name = "tsmiMarkedOnly";
            this.tsmiMarkedOnly.Size = new System.Drawing.Size(162, 22);
            this.tsmiMarkedOnly.Text = "&Marked Only";
            this.tsmiMarkedOnly.Click += new System.EventHandler(this.tsmiMarkedOnly_Click);
            // 
            // tsmiCompleteOnly
            // 
            this.tsmiCompleteOnly.Name = "tsmiCompleteOnly";
            this.tsmiCompleteOnly.Size = new System.Drawing.Size(162, 22);
            this.tsmiCompleteOnly.Text = "&Complete Only";
            this.tsmiCompleteOnly.Click += new System.EventHandler(this.tsmiCompleteOnly_Click);
            // 
            // tsmiPreview
            // 
            this.tsmiPreview.Name = "tsmiPreview";
            this.tsmiPreview.Size = new System.Drawing.Size(177, 22);
            this.tsmiPreview.Text = "&Preview Translation";
            this.tsmiPreview.Click += new System.EventHandler(this.tsmiPreview_Click);
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMarkComplete,
            this.tsmiMarkAttention,
            this.tssTools,
            this.tsmiWebTools});
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(48, 20);
            this.tsmiTools.Text = "&Tools";
            this.tsmiTools.Click += new System.EventHandler(this.tsmiTools_Click);
            // 
            // tsmiMarkComplete
            // 
            this.tsmiMarkComplete.Name = "tsmiMarkComplete";
            this.tsmiMarkComplete.Size = new System.Drawing.Size(177, 22);
            this.tsmiMarkComplete.Text = "Toggle &Completion";
            this.tsmiMarkComplete.Click += new System.EventHandler(this.tsmiMarkComplete_Click);
            // 
            // tsmiMarkAttention
            // 
            this.tsmiMarkAttention.Name = "tsmiMarkAttention";
            this.tsmiMarkAttention.Size = new System.Drawing.Size(177, 22);
            this.tsmiMarkAttention.Text = "Toggle &Marked";
            this.tsmiMarkAttention.Click += new System.EventHandler(this.tsmiMarkAttention_Click);
            // 
            // tssTools
            // 
            this.tssTools.Name = "tssTools";
            this.tssTools.Size = new System.Drawing.Size(174, 6);
            // 
            // tsmiWebTools
            // 
            this.tsmiWebTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGoogleTranslate,
            this.tsmiWeblio});
            this.tsmiWebTools.Name = "tsmiWebTools";
            this.tsmiWebTools.Size = new System.Drawing.Size(177, 22);
            this.tsmiWebTools.Text = "Web &Tools";
            // 
            // tsmiGoogleTranslate
            // 
            this.tsmiGoogleTranslate.Name = "tsmiGoogleTranslate";
            this.tsmiGoogleTranslate.Size = new System.Drawing.Size(163, 22);
            this.tsmiGoogleTranslate.Text = "&Google Translate";
            this.tsmiGoogleTranslate.Click += new System.EventHandler(this.tsmiGoogleTranslate_Click);
            // 
            // tsmiWeblio
            // 
            this.tsmiWeblio.Name = "tsmiWeblio";
            this.tsmiWeblio.Size = new System.Drawing.Size(163, 22);
            this.tsmiWeblio.Text = "&Weblio";
            this.tsmiWeblio.Click += new System.EventHandler(this.tsmiWeblio_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShortcuts,
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // tsmiShortcuts
            // 
            this.tsmiShortcuts.Name = "tsmiShortcuts";
            this.tsmiShortcuts.Size = new System.Drawing.Size(145, 22);
            this.tsmiShortcuts.Text = "&Shortcuts List";
            this.tsmiShortcuts.Click += new System.EventHandler(this.tsmiShortcuts_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(145, 22);
            this.tsmiAbout.Text = "&About";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // chkMark
            // 
            this.chkMark.AutoSize = true;
            this.chkMark.Location = new System.Drawing.Point(118, 76);
            this.chkMark.Name = "chkMark";
            this.chkMark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMark.Size = new System.Drawing.Size(110, 17);
            this.chkMark.TabIndex = 6;
            this.chkMark.Text = "Mark for Attention";
            this.chkMark.UseVisualStyleBackColor = true;
            this.chkMark.CheckedChanged += new System.EventHandler(this.chkMark_CheckedChanged);
            // 
            // spcDesk
            // 
            this.spcDesk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcDesk.Location = new System.Drawing.Point(0, 0);
            this.spcDesk.Name = "spcDesk";
            this.spcDesk.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcDesk.Panel1
            // 
            this.spcDesk.Panel1.Controls.Add(this.spcRaw);
            // 
            // spcDesk.Panel2
            // 
            this.spcDesk.Panel2.Controls.Add(this.spcTranslation);
            this.spcDesk.Size = new System.Drawing.Size(771, 459);
            this.spcDesk.SplitterDistance = 242;
            this.spcDesk.TabIndex = 0;
            // 
            // spcRaw
            // 
            this.spcRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRaw.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcRaw.Location = new System.Drawing.Point(0, 0);
            this.spcRaw.Name = "spcRaw";
            this.spcRaw.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcRaw.Panel1
            // 
            this.spcRaw.Panel1.Controls.Add(this.lblRawHeading);
            // 
            // spcRaw.Panel2
            // 
            this.spcRaw.Panel2.Controls.Add(this.rtbRawContent);
            this.spcRaw.Size = new System.Drawing.Size(771, 242);
            this.spcRaw.SplitterDistance = 35;
            this.spcRaw.TabIndex = 4;
            // 
            // spcTranslation
            // 
            this.spcTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcTranslation.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcTranslation.Location = new System.Drawing.Point(0, 0);
            this.spcTranslation.Name = "spcTranslation";
            this.spcTranslation.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcTranslation.Panel1
            // 
            this.spcTranslation.Panel1.Controls.Add(this.lblTranslationHeading);
            // 
            // spcTranslation.Panel2
            // 
            this.spcTranslation.Panel2.Controls.Add(this.rtbTranslationContent);
            this.spcTranslation.Size = new System.Drawing.Size(771, 213);
            this.spcTranslation.SplitterDistance = 33;
            this.spcTranslation.TabIndex = 15;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(12, 123);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(97, 42);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview Translation";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblEditModeHeading
            // 
            this.lblEditModeHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditModeHeading.Location = new System.Drawing.Point(117, 118);
            this.lblEditModeHeading.Name = "lblEditModeHeading";
            this.lblEditModeHeading.Size = new System.Drawing.Size(111, 23);
            this.lblEditModeHeading.TabIndex = 0;
            this.lblEditModeHeading.Text = "Edit Mode";
            this.lblEditModeHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEditMode
            // 
            this.cmbEditMode.FormattingEnabled = true;
            this.cmbEditMode.Items.AddRange(new object[] {
            "Default",
            "Incomplete Lines",
            "Marked Lines",
            "Complete Lines"});
            this.cmbEditMode.Location = new System.Drawing.Point(118, 144);
            this.cmbEditMode.Name = "cmbEditMode";
            this.cmbEditMode.Size = new System.Drawing.Size(110, 21);
            this.cmbEditMode.TabIndex = 4;
            this.cmbEditMode.SelectedIndexChanged += new System.EventHandler(this.cmbEditMode_SelectedIndexChanged);
            // 
            // lblProgressHeading
            // 
            this.lblProgressHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressHeading.Location = new System.Drawing.Point(12, 140);
            this.lblProgressHeading.Name = "lblProgressHeading";
            this.lblProgressHeading.Size = new System.Drawing.Size(97, 23);
            this.lblProgressHeading.TabIndex = 0;
            this.lblProgressHeading.Text = "Progress";
            this.lblProgressHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgProgress
            // 
            this.prgProgress.Location = new System.Drawing.Point(4, 166);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(224, 23);
            this.prgProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgProgress.TabIndex = 16;
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(131, 140);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(100, 23);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentLineHeading
            // 
            this.lblCurrentLineHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLineHeading.Location = new System.Drawing.Point(12, 114);
            this.lblCurrentLineHeading.Name = "lblCurrentLineHeading";
            this.lblCurrentLineHeading.Size = new System.Drawing.Size(97, 23);
            this.lblCurrentLineHeading.TabIndex = 0;
            this.lblCurrentLineHeading.Text = "Current Line";
            this.lblCurrentLineHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusHeading
            // 
            this.lblStatusHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatusHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusHeading.Location = new System.Drawing.Point(0, 0);
            this.lblStatusHeading.Name = "lblStatusHeading";
            this.lblStatusHeading.Size = new System.Drawing.Size(237, 38);
            this.lblStatusHeading.TabIndex = 22;
            this.lblStatusHeading.Text = "Project Status";
            this.lblStatusHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProjectHeading
            // 
            this.lblProjectHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectHeading.Location = new System.Drawing.Point(12, 38);
            this.lblProjectHeading.Name = "lblProjectHeading";
            this.lblProjectHeading.Size = new System.Drawing.Size(128, 23);
            this.lblProjectHeading.TabIndex = 0;
            this.lblProjectHeading.Text = "Project Name";
            this.lblProjectHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudLineNumber
            // 
            this.nudLineNumber.Location = new System.Drawing.Point(110, 117);
            this.nudLineNumber.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineNumber.Name = "nudLineNumber";
            this.nudLineNumber.Size = new System.Drawing.Size(58, 20);
            this.nudLineNumber.TabIndex = 2;
            this.nudLineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLineNumber.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudLineNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineNumber.ValueChanged += new System.EventHandler(this.nudLineNumber_ValueChanged);
            // 
            // lblMaxLine
            // 
            this.lblMaxLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLine.Location = new System.Drawing.Point(170, 113);
            this.lblMaxLine.Name = "lblMaxLine";
            this.lblMaxLine.Size = new System.Drawing.Size(58, 23);
            this.lblMaxLine.TabIndex = 0;
            this.lblMaxLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spcTools
            // 
            this.spcTools.ContextMenuStrip = this.cmsDesk;
            this.spcTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.spcTools.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcTools.IsSplitterFixed = true;
            this.spcTools.Location = new System.Drawing.Point(0, 24);
            this.spcTools.MinimumSize = new System.Drawing.Size(237, 400);
            this.spcTools.Name = "spcTools";
            this.spcTools.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcTools.Panel1
            // 
            this.spcTools.Panel1.Controls.Add(this.txtProjectName);
            this.spcTools.Panel1.Controls.Add(this.lblProgressHeading);
            this.spcTools.Panel1.Controls.Add(this.lblStatusHeading);
            this.spcTools.Panel1.Controls.Add(this.prgProgress);
            this.spcTools.Panel1.Controls.Add(this.lblMaxLine);
            this.spcTools.Panel1.Controls.Add(this.lblProgress);
            this.spcTools.Panel1.Controls.Add(this.lblCurrentLineHeading);
            this.spcTools.Panel1.Controls.Add(this.nudLineNumber);
            this.spcTools.Panel1.Controls.Add(this.lblProjectHeading);
            // 
            // spcTools.Panel2
            // 
            this.spcTools.Panel2.Controls.Add(this.chkAuto);
            this.spcTools.Panel2.Controls.Add(this.btnRemove);
            this.spcTools.Panel2.Controls.Add(this.btnInsert);
            this.spcTools.Panel2.Controls.Add(this.lblTools);
            this.spcTools.Panel2.Controls.Add(this.chkComplete);
            this.spcTools.Panel2.Controls.Add(this.chkMark);
            this.spcTools.Panel2.Controls.Add(this.btnPreview);
            this.spcTools.Panel2.Controls.Add(this.lblEditModeHeading);
            this.spcTools.Panel2.Controls.Add(this.cmbEditMode);
            this.spcTools.Size = new System.Drawing.Size(237, 459);
            this.spcTools.SplitterDistance = 211;
            this.spcTools.TabIndex = 0;
            this.spcTools.TabStop = false;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(12, 60);
            this.txtProjectName.Multiline = true;
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(215, 41);
            this.txtProjectName.TabIndex = 1;
            this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 82);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(97, 23);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.Text = "Remove Line";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(12, 53);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(97, 23);
            this.btnInsert.TabIndex = 24;
            this.btnInsert.Text = "Insert Line";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lblTools
            // 
            this.lblTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTools.Location = new System.Drawing.Point(0, 0);
            this.lblTools.Name = "lblTools";
            this.lblTools.Size = new System.Drawing.Size(237, 38);
            this.lblTools.TabIndex = 23;
            this.lblTools.Text = "Additional Tools";
            this.lblTools.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDesk
            // 
            this.pnlDesk.ContextMenuStrip = this.cmsDesk;
            this.pnlDesk.Controls.Add(this.spcDesk);
            this.pnlDesk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesk.Location = new System.Drawing.Point(237, 24);
            this.pnlDesk.Name = "pnlDesk";
            this.pnlDesk.Size = new System.Drawing.Size(771, 459);
            this.pnlDesk.TabIndex = 18;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAuto.Location = new System.Drawing.Point(114, 98);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(114, 17);
            this.chkAuto.TabIndex = 26;
            this.chkAuto.Text = "Toggle Auto Mode";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // tsmiAutoMode
            // 
            this.tsmiAutoMode.Name = "tsmiAutoMode";
            this.tsmiAutoMode.Size = new System.Drawing.Size(177, 22);
            this.tsmiAutoMode.Text = "Toggle &Auto Mode";
            this.tsmiAutoMode.Click += new System.EventHandler(this.tsmiAutoMode_Click);
            // 
            // FrmDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1008, 483);
            this.Controls.Add(this.pnlDesk);
            this.Controls.Add(this.spcTools);
            this.Controls.Add(this.mnuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuStrip;
            this.Name = "FrmDesk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translator Studio - Desk";
            this.Load += new System.EventHandler(this.FrmDesk_Load);
            this.cmsDesk.ResumeLayout(false);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.spcDesk.Panel1.ResumeLayout(false);
            this.spcDesk.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcDesk)).EndInit();
            this.spcDesk.ResumeLayout(false);
            this.spcRaw.Panel1.ResumeLayout(false);
            this.spcRaw.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRaw)).EndInit();
            this.spcRaw.ResumeLayout(false);
            this.spcTranslation.Panel1.ResumeLayout(false);
            this.spcTranslation.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcTranslation)).EndInit();
            this.spcTranslation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLineNumber)).EndInit();
            this.spcTools.Panel1.ResumeLayout(false);
            this.spcTools.Panel1.PerformLayout();
            this.spcTools.Panel2.ResumeLayout(false);
            this.spcTools.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcTools)).EndInit();
            this.spcTools.ResumeLayout(false);
            this.pnlDesk.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRawHeading;
        private System.Windows.Forms.RichTextBox rtbRawContent;
        private System.Windows.Forms.Label lblTranslationHeading;
        private System.Windows.Forms.RichTextBox rtbTranslationContent;
        private System.Windows.Forms.CheckBox chkComplete;
        private MenuStrip mnuStrip;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiSaveAs;
        private ToolStripMenuItem tsmiExport;
        private CheckBox chkMark;
        private SplitContainer spcDesk;
        private ToolStripMenuItem tsmiEdit;
        private ComboBox cmbEditMode;
        private Label lblEditModeHeading;
        private ToolStripMenuItem tsmiView;
        private ToolStripMenuItem tsmiEditMode;
        private ToolStripMenuItem tsmiDefault;
        private ToolStripMenuItem tsmiIncompleteOnly;
        private ToolStripMenuItem tsmiMarkedOnly;
        private ToolStripMenuItem tsmiCompleteOnly;
        private Button btnPreview;
        private ToolStripMenuItem tsmiPreview;
        private ToolStripSeparator tssFile2;
        private ToolStripMenuItem tsmiExit;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem tsmiShortcuts;
        private ToolStripMenuItem tsmiAbout;
        private Label lblProgressHeading;
        private ProgressBar prgProgress;
        private Label lblProgress;
        private Label lblCurrentLineHeading;
        private Label lblStatusHeading;
        private Label lblProjectHeading;
        private NumericUpDown nudLineNumber;
        private Label lblMaxLine;
        private SplitContainer spcTools;
        private Label lblTools;
        private SplitContainer spcRaw;
        private SplitContainer spcTranslation;
        private Panel pnlDesk;
        private ToolStripMenuItem tsmiTools;
        private ToolStripMenuItem tsmiMarkComplete;
        private ToolStripMenuItem tsmiMarkAttention;
        private ToolStripSeparator tssTools;
        private ToolStripMenuItem tsmiWebTools;
        private ToolStripMenuItem tsmiGoogleTranslate;
        private ToolStripMenuItem tsmiWeblio;
        private ContextMenuStrip cmsDesk;
        private ToolStripMenuItem tsmiContextCopyRaw;
        private ToolStripSeparator tssContext1;
        private ToolStripMenuItem tsmiContextComplete;
        private ToolStripMenuItem tsmiContextMarked;
        private ToolStripMenuItem tsmiContextShortcuts;
        private ToolStripMenuItem tsmiNextLine;
        private ToolStripMenuItem tsmiPrevLine;
        private ToolStripSeparator tssContext2;
        private TextBox txtProjectName;
        private ToolStripMenuItem tsmiSave;
        private ToolStripMenuItem tsmiCopyRaw;
        private ToolStripMenuItem tsmiNew;
        private ToolStripMenuItem tsmiOpen;
        private ToolStripSeparator tssFile;
        private Button btnRemove;
        private Button btnInsert;
        private CheckBox chkAuto;
        private ToolStripMenuItem tsmiAutoMode;
    }
}