using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.App.Utilities.FormControls;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.PublisherDto;
using Library.Services.Abstract;
using static System.String;

namespace Library.App.AdminPanel
{
    public partial class PublisherOperations : Form
    {
        #region Field

        private readonly IPublisherService _publisherService;
        private int _publisherId = -1;

        #endregion Field

        #region Constructor

        public PublisherOperations(IPublisherService publisherService)
        {
            _publisherService = publisherService;
            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void PublisherOperations_Load(object sender, EventArgs e)
        {
            FillGrid();
            FillComboBox();
        }

        #endregion FormLoad

        #region Methods 

        private void FillGrid(IList<Publisher> list = null)
        {
            if (list == null) list = GetAllNonDeleted();

            gcPublisher.DataSource = list.OrderBy(p=>p.Name);

            void PublisherColumnVisible()
            {
                gvPublisher.Columns[0].Visible = false;
                gvPublisher.Columns[3].Visible = false;
                gvPublisher.Columns[4].Visible = false;
            }
            PublisherColumnVisible();

            lblMessage.Text = $"{list.Count} adet yayınevi listeleniyor.";
        }

        private void FillComboBox()
        {
            cbStatus.Properties.Items.Clear();
            cbStatus.Properties.Items.AddRange(Enum.GetValues(typeof(GeneralStatus)));
        }

        private IList<Publisher> GetAllNonDeleted()
        {
            var publishers = _publisherService.GetAllNonDeleted();
            switch (publishers.ResultStatus)
            {
                case ResultStatus.Success:
                    return publishers.Data.Publishers;
                case ResultStatus.Warning:
                    Alert.Show(publishers.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(publishers.Message, ResultStatus.Error);
                    return null;
            }
        }

        private void GetObject()
        {
            if (gvPublisher.SelectedRowsCount <= 0) return;
            int.TryParse(gvPublisher.GetRowCellValue(gvPublisher.FocusedRowHandle, "Id").ToString(), out _publisherId);
            var publisher = _publisherService.Get(_publisherId);

            if (publisher.ResultStatus == ResultStatus.Success)
            {
                txtName.Text = publisher.Data.Publisher.Name;
                txtDescription.Text = publisher.Data.Publisher.Description;
                cbStatus.SelectedItem = Enum.Parse(typeof(GeneralStatus), publisher.Data.Publisher.GeneralStatus.ToString());
            }
            else
                Alert.Show(publisher.Message, ResultStatus.Warning);
        }

        private void Add()
        {
            var publisher = new PublisherAddDto
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem
            };
            var added = _publisherService.Add(publisher);
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

        private new void Update()
        {
            var publisher = new PublisherUpdateDto
            {
                Id = _publisherId,
                Name = txtName.Text,
                Description = txtDescription.Text,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem
            };
            var updatedPublisher = _publisherService.Update(publisher);
            if (updatedPublisher.ResultStatus == ResultStatus.Success)
            {
                Alert.Show(updatedPublisher.Message, ResultStatus.Success);
                FillGrid();
                ClearItems();
            }
            else Alert.Show(updatedPublisher.Message, ResultStatus.Error);
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_publisherId > -1)
            {
                if (XtraMessageBox.Show("Yayınevi kaldırılacaktır. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
                var result = _publisherService.Delete(_publisherId);
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
                Alert.Show("Lütfen arşivlenecek yayınevini seçiniz.", ResultStatus.Info);
        }

        private void ClearItems()
        {
            _publisherId = -1;
            txtSearch.Text = null;
            FormControls.ClearFormControls(this);
        }

        private void SearchByName()
        {
            var searchText = txtSearch.Text;
            if (IsNullOrEmpty(searchText)) FillGrid();

            var publishers = _publisherService.FindPublishersByText(searchText);
            if (publishers.ResultStatus == ResultStatus.Success) FillGrid(publishers.Data.Publishers);
            else FillGrid();
        }

        #endregion Methods

        #region Buttons

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormControls.CheckFormControls(gbPublisher))
            {
                Alert.Show("Lütfen tüm alanları doldurunuz.", ResultStatus.Warning);
                return;
            }
            if (_publisherId > -1) Update();
            else Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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
        /// Grid üzerindeki yayınevlerine mouse butonu ile işlem uygular.
        /// </summary>
        private void gcPublisher_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Yayınevini Arşivle", Delete));

            var rowIndex = gvPublisher.CalcHitInfo(e.X, e.Y).RowHandle;
            if (rowIndex <= -1) return;
            gvPublisher.ClearSelection();
            gvPublisher.SelectRow(rowIndex);
            _publisherId = Convert.ToInt32(gvPublisher.GetRowCellValue(rowIndex, "Id"));
            contextMenu.Show(gcPublisher, new Point(e.X, e.Y));
        }
        private void gvPublisher_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObject();
        }

        #endregion GridControl
    }
}