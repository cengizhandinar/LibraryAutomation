using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Library.App.Popup;
using Library.Core.Enum;
using DevExpress.XtraEditors;
using Library.Services.Abstract;
using Library.Entities.Entities.Concrete;
using Library.App.Utilities.FormControls;
using Library.Entities.Entities.Dtos.CategoryDto;
using static System.String;

namespace Library.App.AdminPanel
{
    public partial class CategoryOperations : Form
    {
        #region Field

        private readonly ICategoryService _categoryService;
        private readonly IBookCategoryService _bookCategoryService;
        private int _categoryId = -1;
        private bool _isParent;

        #endregion Field

        #region Constructor

        public CategoryOperations(ICategoryService categoryService, IBookCategoryService bookCategoryService)
        {
            _categoryService = categoryService;
            _bookCategoryService = bookCategoryService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Form Load

        private void CategoryOperations_Load(object sender, EventArgs e)
        {
            FillGrid();
            FillComboBox();
        }

        #endregion FormLoad

        #region Methods 

        private void FillGrid(IList<Category> list = null)
        {
            if (list == null) list = GetAllNonDeleted();
            var newList = from item in list
                          select new
                          {
                              item.Id,
                              item.ParentId,
                              Kategori_Adı = item.Name,
                              Üst_Kategori_Adı = item.ParentId != 0 ? _categoryService.GetByParent(item.ParentId).Data.Category.Name : Empty
                          };
            gcCategory.DataSource = newList.OrderBy(c => c.Üst_Kategori_Adı);

            void CategoryColumnVisible()
            {
                gvCategory.Columns["Id"].Visible = false;
                gvCategory.Columns["ParentId"].Visible = false;
            }
            CategoryColumnVisible();

            lblMessage.Text = $"{list.Count} adet kategori listeleniyor.";
        }

        /// <summary>
        /// Tüm comboboxları doldur.
        /// </summary>
        private void FillComboBox()
        {
            cbStatus.Properties.Items.Clear();
            cbAllParent.Properties.Items.Clear();
            cbGetParent.Properties.Items.Clear();
            var categories = _categoryService.GetAllNonDeleted();
            cbStatus.Properties.Items.AddRange(Enum.GetValues(typeof(GeneralStatus)));

            switch (categories.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        foreach (var category in categories.Data.Categories)
                        {
                            cbAllParent.Properties.Items.Add(category.Name);
                            cbGetParent.Properties.Items.Add(category.Name);
                        }
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(categories.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(categories.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Tüm aktif kategorilerin listesini getir.
        /// </summary>
        private IList<Category> GetAllNonDeleted()
        {
            var categories = _categoryService.GetAllNonDeleted();
            switch (categories.ResultStatus)
            {
                case ResultStatus.Success:
                    return categories.Data.Categories;
                case ResultStatus.Warning:
                    Alert.Show(categories.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(categories.Message, ResultStatus.Error);
                    return null;
            }
        }

        /// <summary>
        /// Gridde seçilen kategori bilgilerini getir.
        /// </summary>
        private void GetObject()
        {
            if (gvCategory.SelectedRowsCount <= 0) return;
            int.TryParse(gvCategory.GetRowCellValue(gvCategory.FocusedRowHandle, "Id").ToString(), out _categoryId);
            var category = _categoryService.Get(_categoryId);

            if (category.ResultStatus == ResultStatus.Success)
            {
                txtCategoryName.Text = category.Data.Category.Name;
                ceIsParent.Checked = category.Data.Category.ParentId != 0;
                cbAllParent.Enabled = category.Data.Category.ParentId != 0;
                if (category.Data.Category.ParentId == 0) cbAllParent.SelectedIndex = -1;
                else cbAllParent.SelectedItem = _categoryService.GetByParent(category.Data.Category.ParentId).Data.Category.Name;
                cbStatus.SelectedItem = Enum.Parse(typeof(GeneralStatus), category.Data.Category.GeneralStatus.ToString());
            }
            else
                Alert.Show(category.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Sisteme yeni kategori ekler.
        /// </summary>
        private void Add()
        {
            var category = new CategoryAddDto
            {
                Name = txtCategoryName.Text,
                ParentId = _isParent ? cbAllParent.SelectedIndex + 1 : 0,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem
            };
            var added = _categoryService.Add(category);
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
        /// Sistemdeki kategoriyi günceller.
        /// </summary>
        private new void Update()
        {
            var category = new CategoryUpdateDto
            {
                Id = _categoryId,
                Name = txtCategoryName.Text,
                ParentId = _isParent ? cbAllParent.SelectedIndex + 1 : 0,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem
            };
            var updatedCategory = _categoryService.Update(category);
            switch (updatedCategory.ResultStatus)
            {
                case ResultStatus.Success:
                    Alert.Show(updatedCategory.Message, ResultStatus.Success);
                    FillGrid();
                    ClearItems();
                    break;
                case ResultStatus.Warning:
                    Alert.Show(updatedCategory.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(updatedCategory.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Seçilen kategoriyi ve ilgili alt kategorileri kaldırır.
        /// </summary>
        private void Delete(object sender, EventArgs e)
        {
            if (_categoryId > -1)
            {
                if (XtraMessageBox.Show("Kategori arşivlenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes) return;
                if (XtraMessageBox.Show(
                    "Bağlı olduğu alt kategoriler ve ilgili kitapların kategori bilgisi varsa onlar da arşivlenecektir. Devam etmek istiyor musunuz?",
                    "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                var result = _categoryService.Delete(_categoryId);
                var resultTwo = _bookCategoryService.HardDeleteByCategoryId(_categoryId);
                var parents = _categoryService.GetParents(_categoryId);
                const int sleep = 1500;
                if (result.ResultStatus == ResultStatus.Success)
                {
                    switch (parents.ResultStatus)
                    {
                        case ResultStatus.Success when resultTwo.ResultStatus == ResultStatus.Success:
                            {
                                var count = parents.Data.Categories.Count;
                                for (var i = 0; i < count; i++)
                                {
                                    _categoryService.Delete(parents.Data.Categories[i].Id);
                                    _bookCategoryService.HardDeleteByCategoryId(parents.Data.Categories[i].Id);
                                }

                                Alert.Show(result.Message, ResultStatus.Success);
                                Thread.Sleep(sleep);
                                ClearItems();
                                FillGrid();
                                Alert.Show(resultTwo.Message, ResultStatus.Success);
                                break;
                            }
                        case ResultStatus.Success:
                            Alert.Show(resultTwo.Message, ResultStatus.Error);
                            break;
                        case ResultStatus.Warning:
                            Alert.Show(result.Message, ResultStatus.Success);
                            ClearItems();
                            FillGrid();
                            break;
                        default:
                            Alert.Show(parents.Message, ResultStatus.Error);
                            break;
                    }
                }
                else
                    Alert.Show(result.Message, ResultStatus.Error);
            }
            else
                Alert.Show("Lütfen arşivlenecek kategoriyi seçiniz.", ResultStatus.Info);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _categoryId = -1;
            _isParent = false;
            cbAllParent.Enabled = true;
            ceIsParent.Checked = true;
            txtSearch.Text = null;
            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// Kategori adına göre ara.
        /// </summary>
        private void SearchCategoryByName()
        {
            var searchText = txtSearch.Text;
            if (IsNullOrEmpty(searchText)) { FillGrid(); return; }

            var categories = _categoryService.FindCategoriesByText(searchText);
            if (categories.ResultStatus == ResultStatus.Success) FillGrid(categories.Data.Categories);
            else FillGrid();
        }

        /// <summary>
        /// Kategori adına göre alt kategorileri getir.
        /// </summary>
        private void SearchParentsByName()
        {
            var category = _categoryService.GetByName(cbGetParent.SelectedItem.ToString());
            if (category.ResultStatus==ResultStatus.Success)
            {
                var parents = _categoryService.GetParents(category.Data.Category.Id);
                if (parents.ResultStatus == ResultStatus.Success) FillGrid(parents.Data.Categories);
                else if (parents.ResultStatus == ResultStatus.Warning) {Alert.Show(parents.Message,ResultStatus.Info); FillGrid();}
                else FillGrid();
            }
        }

        #endregion Methods

        #region Buttons

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "" || cbStatus.SelectedIndex == -1)
            {
                Alert.Show("Lütfen tüm alanları doldurunuz.", ResultStatus.Warning);
                return;
            }
            if (_isParent && cbAllParent.SelectedIndex == -1)
            {
                Alert.Show("Lütfen ilgili alt kategoriyi seçiniz.", ResultStatus.Warning);
                return;
            }
            if (_categoryId > -1) Update();
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
            SearchCategoryByName();
        }
        private void ceIsParent_CheckedChanged(object sender, EventArgs e)
        {
            _isParent = ceIsParent.CheckState == CheckState.Checked;
            cbAllParent.Enabled = _isParent;
        }
        private void cbGetParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGetParent.SelectedIndex > -1)
                SearchParentsByName();
            else FillGrid();
        }

        #endregion Events

        #region GridControl

        private void gcCategory_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Kategoriyi Arşivle", Delete));

            int rowIndex = gvCategory.CalcHitInfo(e.X, e.Y).RowHandle;
            if (rowIndex <= -1) return;
            gvCategory.ClearSelection();
            gvCategory.SelectRow(rowIndex);
            _categoryId = Convert.ToInt32(gvCategory.GetRowCellValue(rowIndex, "Id"));
            contextMenu.Show(gcCategory, new System.Drawing.Point(e.X, e.Y));
        }

        private void gvCategory_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObject();
        }

        #endregion GridControl
    }
}