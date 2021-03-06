﻿using System;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Forms
{
    public partial class FrmDesk : Form
    {
        #region Properties

        private readonly IDeskConsumer consumer;

        public FrmHub Hub { get; set; }
        public FrmPreview Preview { get; set; }
        public frmNew New { get; set; }

        public ITranslationData Data { get; set; }

        public string PreviousSavePath { get; set; }
        public int NumberOfLines { get; set; }
        public bool UnsavedData { get => Data.DataChanged; set => Data.DataChanged = value; }

        #endregion


        #region Public Controls

        public TextBox TxtProjectName => txtProjectName;
        public Label LblMaxLine => lblMaxLine;
        public Label LblProgress => lblProgress;
        public ProgressBar PrgProgress => prgProgress;

        public RichTextBox RtbRawContent => rtbRawContent;
        public RichTextBox RtbTranslationContent => rtbTranslationContent;
        public CheckBox ChkComplete => chkComplete;
        public CheckBox ChkMark => chkMark;

        public NumericUpDown NudLineNumber => nudLineNumber;
        public ComboBox CmbEditMode => cmbEditMode;
        public CheckBox ChkAuto => chkAuto;
        
        #endregion


        #region Constructors

        public FrmDesk()
        {
            consumer = new DeskConsumer(this);
            InitializeComponent();
        }

        public FrmDesk(ITranslationData data, string prevSavePath, FrmHub hub) : this()
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            PreviousSavePath = prevSavePath ?? throw new ArgumentNullException(nameof(prevSavePath));
            Hub = hub ?? throw new ArgumentNullException(nameof(hub));
            consumer.DeskSetup();
        }

        public FrmDesk(ITranslationData data, FrmHub hub) : this()
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            Hub = hub ?? throw new ArgumentNullException(nameof(hub));
            ResetTranslationProject(data);
        }

        #endregion


        #region Control Events

        #region Basic Events

        private void FrmDesk_Load(object sender, EventArgs e)
        {

        }

        private void rtbRawContent_TextChanged(object sender, EventArgs e)
        {
            consumer.UpdateCurrentRaw(rtbRawContent.Text);
        }

        private void rtbTranslationContent_TextChanged(object sender, EventArgs e)
        {
            consumer.UpdateCurrentTranslation(rtbTranslationContent.Text);
        }

        private void chkComplete_CheckedChanged(object sender, EventArgs e)
        {
            consumer.UpdateCurrentCompletion(chkComplete.Checked);
        }

        private void chkMark_CheckedChanged(object sender, EventArgs e)
        {
            consumer.UpdateCurrentMarked(chkMark.Checked);
        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            consumer.UpdateProjectName(txtProjectName.Text);
        }

        private void nudLineNumber_ValueChanged(object sender, EventArgs e)
        {
            consumer.UpdateCurrentIndex((int)nudLineNumber.Value - 1);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            consumer.InsertLine();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            consumer.RemoveLine();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            consumer.PreviewProject();
        }

        private void cmbEditMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            consumer.ChangeEditMode();
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            consumer.ToggleAutoMode(chkAuto.Checked);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            consumer.GoToPrevLine();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            consumer.GoToNextLine();
        }

        #endregion

        #region Toolbar Events

        private void tsmiTools_Click(object sender, EventArgs e)
        {
            tsmiMarkComplete.Checked = Data.CurrentCompletion;
            tsmiMarkAttention.Checked = Data.CurrentMarked;
            tsmiAutoMode.Checked = Data.AutoTranslationMode;
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            consumer.NewProject();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            consumer.OpenProject();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            consumer.SaveProjectAs();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            consumer.SaveProject();
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            consumer.ExportProject();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            consumer.CloseDesk();
        }

        private void tsmiCopyRaw_Click(object sender, EventArgs e)
        {
            consumer.CopyText(rtbRawContent.Text);
        }

        private void tsmiAutoMode_Click(object sender, EventArgs e)
        {
            consumer.FlipAutoState();
        }

        private void tsmiDefault_Click(object sender, EventArgs e)
        {
            cmbEditMode.SelectedItem = "Default";
        }

        private void tsmiIncompleteOnly_Click(object sender, EventArgs e)
        {
            cmbEditMode.SelectedItem = "Incomplete Lines";
        }

        private void tsmiMarkedOnly_Click(object sender, EventArgs e)
        {
            cmbEditMode.SelectedItem = "Marked Lines";
        }

        private void tsmiCompleteOnly_Click(object sender, EventArgs e)
        {
            cmbEditMode.SelectedItem = "Complete Lines";
        }

        private void tsmiPreview_Click(object sender, EventArgs e)
        {
            consumer.PreviewProject();
        }

        private void tsmiMarkComplete_Click(object sender, EventArgs e)
        {
            consumer.FlipCompleteState();
        }

        private void tsmiMarkAttention_Click(object sender, EventArgs e)
        {
            consumer.FlipMarkedState();
        }

        private void tsmiGoogleTranslate_Click(object sender, EventArgs e)
        {
            consumer.OpenGoogleTranslate();
        }

        private void tsmiWeblio_Click(object sender, EventArgs e)
        {
            consumer.OpenWeblio();
        }

        private void tsmiShortcuts_Click(object sender, EventArgs e)
        {
            consumer.ShowShortcuts();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            consumer.ShowAbout();
        }
        
        #endregion

        #region Context Strip Events

        private void cmsDesk_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmiContextComplete.Checked = Data.CurrentCompletion;
            tsmiContextMarked.Checked = Data.CurrentMarked;
        }

        private void tsmiNextLine_Click(object sender, EventArgs e)
        {
            consumer.GoToNextLine();
        }

        private void tsmiPrevLine_Click(object sender, EventArgs e)
        {
            consumer.GoToPrevLine();
        }

        private void tsmiContextComplete_Click(object sender, EventArgs e)
        {
            consumer.FlipCompleteState();
        }

        private void tsmiContextMarked_Click(object sender, EventArgs e)
        {
            consumer.FlipMarkedState();
        }

        private void tsmiContextCopyRaw_Click(object sender, EventArgs e)
        {
            consumer.CopyText(rtbRawContent.Text);
        }

        private void tsmiContextShortcuts_Click(object sender, EventArgs e)
        {
            consumer.ShowShortcuts();
        }
        
        #endregion

        #endregion


        #region Other Events

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            consumer.ConfirmSave(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var isShortcut = consumer.ProcessShortcuts(keyData);
            if (isShortcut)
                return isShortcut;
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion


        #region Methods

        public void UpdateTranslationData(ITranslationData data)
        {
            consumer.UpdateTranslationData(data);
        }

        public void ResetTranslationDesk(ITranslationData data)
        {
            consumer.ResetTranslationDesk(data);
        }

        public void ResetTranslationProject(ITranslationData data)
        {
            consumer.ResetTranslationProject(data);
        }

        #endregion

    }
}
