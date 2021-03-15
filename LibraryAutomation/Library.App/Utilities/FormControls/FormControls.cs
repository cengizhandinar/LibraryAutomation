using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Library.App.Utilities.FormControls
{
    internal static class FormControls
    {
        public static bool CheckFormControls(GroupBox groupBox)
        {
            var counter = 0;
            foreach (Control ctrl in groupBox.Controls)
            {
                if (!(ctrl is TextEdit edit)) continue;
                if (edit.Text == "")
                {
                    counter++;
                }
            }
            return counter <= 0;
        }
        public static void ClearFormControls(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is BaseEdit editor)
                    editor.EditValue = null;

                ClearFormControls(ctrl);
            }
        }
    }
}