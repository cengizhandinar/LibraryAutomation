using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.App.Utilities.FormControls;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Services.Abstract;
using static System.String;

namespace Library.App.AdminPanel
{
    public partial class ContactOperations : Form
    {
        #region Fields

        private readonly IContactService _contactService;

        // Gridde seçilen mesajın Id bilgisi
        private int _contactId = -1;

        #endregion Fields

        #region Form Load

        private void ContactOperations_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        #endregion Form Load

        #region Constructor

        public ContactOperations(IContactService contactService)
        {
            _contactService = contactService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        private void FillGrid(IList<Contact> list = null)
        {
            if (list == null) list = GetAllNonDeleted();
            var newList = from item in list
                          select new
                          {
                              item.Id,
                              item.GeneralStatus,
                              Mesaj_Sahibi = item.User.FirstName + " " + item.User.LastName,
                              Mesaj_Tarihi = item.CreatedDate
                          };
            gcContact.DataSource = newList.OrderBy(c => c.Mesaj_Tarihi);

            void ContactColumnVisible()
            {
                gvContact.Columns[0].Visible = false;
                gvContact.Columns[1].Visible = false;
            }
            ContactColumnVisible();

            lblMessage.Text = $"{list.Count} adet mesaj listeleniyor.      ";
        }

        /// <summary>
        /// Tüm aktif mesajların listesini getir.
        /// </summary>
        private IList<Contact> GetAllNonDeleted()
        {
            var contacts = _contactService.GetAllNonDeleted();
            switch (contacts.ResultStatus)
            {
                case ResultStatus.Success:
                    return contacts.Data.Contacts;
                case ResultStatus.Warning:
                    Alert.Show(contacts.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(contacts.Message, ResultStatus.Error);
                    return null;
            }
        }

        /// <summary>
        /// Gridde seçilen mesaj bilgilerini getir.
        /// </summary>
        private void GetObject()
        {
            if (gvContact.SelectedRowsCount <= 0) return;
            int.TryParse(gvContact.GetRowCellValue(gvContact.FocusedRowHandle, "Id").ToString(), out _contactId);
            var contact = _contactService.Get(_contactId);

            if (contact.ResultStatus == ResultStatus.Success)
            {
                txtFirstName.Text = contact.Data.Contact.User.FirstName;
                txtLastName.Text = contact.Data.Contact.User.LastName;
                txtContent.Text = contact.Data.Contact.Content;
                dateContactDate.DateTime = contact.Data.Contact.CreatedDate;
            }
            else
                Alert.Show(contact.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Seçilen mesajı arşivler.
        /// </summary>
        private void Delete(object sender, EventArgs e)
        {
            if (_contactId > -1)
            {
                if (XtraMessageBox.Show("Mesaj arşivlenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes) return;
                var result = _contactService.Delete(_contactId, "Admin");
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
                Alert.Show("Lütfen arşivlenecek mesajı seçiniz.", ResultStatus.Info);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _contactId = -1;
            txtSearchByUser.Text = null;
            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// İsme göre ara.
        /// </summary>
        private void SearchContact()
        {
            var searchText = txtSearchByUser.Text;
            if (IsNullOrEmpty(searchText)) FillGrid();

            var contacts = _contactService.FindContactsByUserName(searchText);
            if (contacts.ResultStatus == ResultStatus.Success) FillGrid(contacts.Data.Contacts);
            else FillGrid();
        }

        #endregion Methods

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = @"Excel Documents (*.xls)|*.xls", FileName = "messages.xls" };
            if (sfd.ShowDialog() == DialogResult.OK) gcContact.ExportToXls(sfd.FileName);
        }

        #endregion

        #region Buttons

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        #endregion

        #region GridControl

        private void gcContact_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Mesajı Arşivle", Delete));

            var rowIndex = gvContact.CalcHitInfo(e.X, e.Y).RowHandle;
            if (rowIndex <= -1) return;
            gvContact.ClearSelection();
            gvContact.SelectRow(rowIndex);
            _contactId = Convert.ToInt32(gvContact.GetRowCellValue(rowIndex, "Id"));
            contextMenu.Show(gcContact, new System.Drawing.Point(e.X, e.Y));
        }

        private void gvContact_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObject();
        }

        #endregion GridControl

        #region Timer

        private void timer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd.MMMM.yyyy HH:mm:ss");
        }

        #endregion Timer

        #region Events

        private void txtSearchByUser_TextChanged(object sender, EventArgs e)
        {
            SearchContact();
        }

        #endregion Events
    }
}