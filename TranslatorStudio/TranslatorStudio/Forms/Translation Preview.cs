using System;
using System.ComponentModel;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Forms
{
    public partial class FrmPreview : Form
    {
        //Possible Drag Drop Functionality
        //https://www.experts-exchange.com/questions/27604665/Swap-2-cells-on-datagridview-with-drag-and-drop-VB-NET.html

        #region Properties

        private readonly IPreviewConsumer consumer;

        public FrmDesk Desk { get; set; }
        public ITranslationData Data { get; set; }
        public bool DataChanged { get; set; } = false;

        public int PreviewCurrentIndex { get => dgvPreview.CurrentRow.Index; }
        public DataGridViewRowCollection Rows { get => dgvPreview.Rows;}

        #endregion


        #region Constructors

        public FrmPreview(FrmDesk desk, ITranslationData data)
        {
            Desk = desk ?? throw new ArgumentNullException(nameof(desk));
            Data = data ?? throw new ArgumentNullException(nameof(data));
            consumer = new PreviewConsumer(this);

            InitializeComponent();

            consumer.LoadPreview(dgvPreview);
        }

        public FrmPreview(FrmDesk desk, ITranslationData data, IPreviewConsumer newConsumer)
        {
            Desk = desk ?? throw new ArgumentNullException(nameof(desk));
            Data = data ?? throw new ArgumentNullException(nameof(data));
            consumer = newConsumer ?? throw new ArgumentNullException(nameof(newConsumer));

            InitializeComponent();

            consumer.LoadPreview(dgvPreview);
        }

        #endregion


        #region Control Events

        private void Translation_Preview_Load(object sender, EventArgs e)
        {
            Text = consumer.GetPreviewTitle(Data.ProjectName);
        }

        private void dgvPreview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            consumer.CellValueChanged(dgvPreview.CurrentCell);
        }

        private void cmsPreview_Opening(object sender, CancelEventArgs e)
        {
            tsmiMarkComplete.Checked = Data.CompletedLines[PreviewCurrentIndex];
            tsmiMarkAttention.Checked = Data.MarkedLines[PreviewCurrentIndex];
        }

        private void tsmiMarkComplete_Click(object sender, EventArgs e)
        {
            consumer.toggleCurrentComplete();
        }

        private void tsmiMarkAttention_Click(object sender, EventArgs e)
        {
            consumer.toggleCurrentMarked();
        }

        private void tsmiCopyRaw_Click(object sender, EventArgs e)
        {
            var copyText = Data.RawLines[PreviewCurrentIndex];
            consumer.CopyRaw(copyText);
        }

        private void tsmiSaveChanges_Click(object sender, EventArgs e)
        {
            consumer.SaveChanges();
        }

        #endregion


        #region Methods

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            var performSave = consumer.ConfirmSave(e);
            if (performSave)
                Desk.ResetTranslationDesk(Data);
        }

        #endregion
    }
}
