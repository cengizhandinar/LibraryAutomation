using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Library.App.Popup;
using Library.App.Utilities.ImageControls;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class Writers : Form
    {
        #region Fields

        private readonly IWriterService _writerService;
        private int _writerId = -1;

        #endregion Fields

        #region Constructor

        public Writers(IWriterService writerService)
        {
            _writerService = writerService;
            InitializeComponent();
        }

        #endregion Constuctor

        #region FormLoad

        private void Writers_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        #endregion FormLoad

        #region Methods

        private void FillGrid(IList<Writer> list = null)
        {
            if (list == null) list = GetAllNonDeleted();

            gcWriter.DataSource = list.OrderBy(w => w.Name);

            void WriterColumnVisible()
            {
                gvWriter.Columns[0].Visible = false;
                gvWriter.Columns[2].Visible = false;
                gvWriter.Columns[3].Visible = false;
                gvWriter.Columns[5].Visible = false;
                gvWriter.Columns[6].Visible = false;
                gvWriter.Columns[7].Visible = false;
            }
            WriterColumnVisible();

            lblMessage.Text = $@"{list.Count} adet yazar listeleniyor.      ";
        }

        /// <summary>
        /// Tüm aktif yazarların listesini getir.
        /// </summary>
        private IList<Writer> GetAllNonDeleted()
        {
            var writers = _writerService.GetAllNonDeleted();
            switch (writers.ResultStatus)
            {
                case ResultStatus.Success:
                    return writers.Data.Writers;
                case ResultStatus.Warning:
                    Alert.Show(writers.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(writers.Message, ResultStatus.Error);
                    return null;
            }
        }

        /// <summary>
        /// Gridde seçilen yazar bilgilerini getir.
        /// </summary>
        private void GetObject()
        {
            if (gvWriter.SelectedRowsCount <= 0) return;
            int.TryParse(gvWriter.GetRowCellValue(gvWriter.FocusedRowHandle, "Id").ToString(), out _writerId);
            var writer = _writerService.Get(_writerId);

            if (writer.ResultStatus == ResultStatus.Success)
            {
                lblControl.Visible = true;
                lblNumberOfBooks.Visible = true;
                lblNumberOfBooks.Text = Convert.ToString(writer.Data.Writer.NumberOfBooks);
                txtName.Text = writer.Data.Writer.Name;
                dateBirth.DateTime = writer.Data.Writer.DateOfBirth;
                txtBiography.Text = writer.Data.Writer.Biography;
                var stream = new FileStream($"{Directory.GetCurrentDirectory()}\\img\\{writer.Data.Writer.Picture}", FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
            else
                Alert.Show(writer.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// İsme göre ara.
        /// </summary>
        private void SearchByName()
        {
            var searchText = txtSearch.Text;
            if (string.IsNullOrEmpty(searchText)) FillGrid();

            var writers = _writerService.FindWritersByText(searchText);
            if (writers.ResultStatus == ResultStatus.Success) FillGrid(writers.Data.Writers);
            else FillGrid();
        }

        #endregion Methods

        #region Events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchByName();
        }

        #endregion Events

        #region GridControl

        private void gvWriter_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObject();
        }

        #endregion GridControl

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog {Filter = @"Excel Documents (*.xls)|*.xls", FileName = "writers.xls"};
            if (sfd.ShowDialog() == DialogResult.OK) gcWriter.ExportToXls(sfd.FileName);
        }

        #endregion

        #region Timer

        private void timer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd.MMMM.yyyy HH:mm:ss");
        }

        #endregion Timer
    }
}