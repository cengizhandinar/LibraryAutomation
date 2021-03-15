using Library.Core.Enum;

namespace Library.App.Popup
{
    public static class Alert
    {
        public static void Show(string message, ResultStatus resultStatus)
        {
            var form = new AlertForm();
            form.ShowAlert(message, resultStatus);
        }
    }
}
