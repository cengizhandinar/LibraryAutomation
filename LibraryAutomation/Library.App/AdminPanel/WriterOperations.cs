using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Library.App.Popup;
using Library.Core.Enum;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Library.Services.Abstract;
using Library.Data.ImageHelper;
using System.Collections.Generic;
using Library.Entities.Entities.Concrete;
using Library.App.Utilities.FormControls;
using Library.App.Utilities.ImageControls;
using Library.Entities.Entities.Dtos.WriterDto;

namespace Library.App.AdminPanel
{
    public partial class WriterOperations : Form
    {
        #region Fields

        private readonly IImageHelper _imageHelper;
        private readonly IWriterService _writerService;
        private int _writerId = -1;
        private string _fileName = string.Empty;

        #endregion Fields

        #region Constructor

        public WriterOperations(IWriterService writerService, IImageHelper imageHelper)
        {
            _writerService = writerService;
            _imageHelper = imageHelper;
            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void WriterOperations_Load(object sender, EventArgs e)
        {
            FillGrid();
            FillComboBox();
        }

        #endregion FormLoad

        #region Methods

        private void FillGrid(IList<Writer> list = null)
        {
            if (list == null) list = GetAllNonDeleted();

            gcWriter.DataSource = list.OrderBy(w=>w.Name);

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

            lblMessage.Text = $"{list.Count} adet yazar listeleniyor.      ";
        }

        /// <summary>
        /// Tüm comboboxları doldur.
        /// </summary>
        private void FillComboBox()
        {
            cbStatus.Properties.Items.Clear();
            cbStatus.Properties.Items.AddRange(Enum.GetValues(typeof(GeneralStatus)));
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
                cbStatus.SelectedItem = Enum.Parse(typeof(GeneralStatus), writer.Data.Writer.GeneralStatus.ToString());
                var stream = new FileStream($"{Directory.GetCurrentDirectory()}\\img\\{writer.Data.Writer.Picture}", FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
            else
                Alert.Show(writer.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Sisteme yeni yazar ekler.
        /// </summary>
        private void Add()
        {
            var writer = new WriterAddDto
            {
                Name = txtName.Text,
                DateOfBirth = dateBirth.DateTime,
                Biography = txtBiography.Text,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem,
                Picture = !string.IsNullOrEmpty(_fileName)
                    ? _imageHelper.Upload(txtName.Text, _fileName, PictureType.Writer).Data.FullName
                    : "writerImages/defaultWriter.jpg"
            };
            var added = _writerService.Add(writer);
            switch (added.ResultStatus)
            {
                case ResultStatus.Success:
                    Alert.Show(added.Message, ResultStatus.Success);
                    FillGrid();
                    ClearItems();
                    break;
                case ResultStatus.Warning:
                    Alert.Show(added.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(added.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Sistemdeki yazar bilgisini günceller.
        /// </summary>
        private new void Update()
        {
            var newWriter = new WriterUpdateDto
            {
                Id = _writerId,
                Name = txtName.Text,
                DateOfBirth = dateBirth.DateTime,
                Biography = txtBiography.Text,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem
            };
            var isNewPicture = false;
            var oldWriter = _writerService.Get(_writerId);
            string oldWriterPicture;
            if (oldWriter.ResultStatus==ResultStatus.Success)
            {
                oldWriterPicture = _writerService.Get(_writerId).Data.Writer.Picture;
                if (_fileName != string.Empty)
                {
                    var uploadedImageDtoResult = _imageHelper.Upload(txtName.Text, _fileName, PictureType.Writer);
                    if (uploadedImageDtoResult.ResultStatus == ResultStatus.Success)
                    {
                        newWriter.Picture = uploadedImageDtoResult.Data.FullName;
                        if (oldWriterPicture != "writerImages/defaultWriter.jpg")
                            isNewPicture = true;
                    }
                    else
                    {
                        Alert.Show(uploadedImageDtoResult.Message, ResultStatus.Error);
                        return;
                    }
                }
                else
                    newWriter.Picture = oldWriterPicture;
            }
            else
            {
                Alert.Show(oldWriter.Message, ResultStatus.Warning);
                return;
            }
            var updatedWriter = _writerService.Update(newWriter);
            if (updatedWriter.ResultStatus == ResultStatus.Success)
            {
                if (isNewPicture)
                {
                    var deleteResult = _imageHelper.Delete(oldWriterPicture);
                    if (deleteResult.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(deleteResult.Message, ResultStatus.Error);
                        return;
                    }
                }
                Alert.Show(updatedWriter.Message, ResultStatus.Success);
                FillGrid();
                ClearItems();
            }
            else Alert.Show(updatedWriter.Message, ResultStatus.Error);
        }

        /// <summary>
        /// Seçilen yazarı arşivler.
        /// </summary>
        private void Delete(object sender, EventArgs e)
        {
            if (_writerId > -1)
            {
                if (XtraMessageBox.Show("Yazar arşivlenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes) return;
                var result = _writerService.Delete(_writerId);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    FillGrid();
                }
                else
                    Alert.Show(result.Message, ResultStatus.Error);
            }
            else
                Alert.Show("Lütfen arşivlenecek yazarı seçiniz.", ResultStatus.Info);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _writerId = -1;
            pictureBox1.Image = null;
            _fileName = string.Empty;
            lblControl.Visible = false;
            lblNumberOfBooks.Visible = false;
            txtSearch.Text = null;

            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// İsme göre yazar ara.
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

        #region Buttons

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormControls.CheckFormControls(gbWriter))
            {
                Alert.Show("Lütfen tüm alanları doldurunuz.", ResultStatus.Warning);
                return;
            }
            if (_writerId > -1) Update();
            else Add();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog() { Filter = @"Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                _fileName = ofd.FileName;
                var stream = new FileStream(_fileName, FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
        }

        #endregion Buttons

        #region Events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchByName();
        }

        #endregion Events

        #region GridControl

        /// <summary>
        /// Grid üzerindeki yazarlara mouse butonu ile işlem uygular.
        /// </summary>
        private void gcWriter_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Yazarı Arşivle", Delete));

            var rowIndex = gvWriter.CalcHitInfo(e.X, e.Y).RowHandle;
            if (rowIndex <= -1) return;
            gvWriter.ClearSelection();
            gvWriter.SelectRow(rowIndex);
            _writerId = Convert.ToInt32(gvWriter.GetRowCellValue(rowIndex, "Id"));
            contextMenu.Show(gcWriter, new Point(e.X, e.Y));
        }

        private void gvWriter_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObject();
        }

        #endregion GridControl

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = @"Excel Documents (*.xls)|*.xls", FileName = "writers.xls" };
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