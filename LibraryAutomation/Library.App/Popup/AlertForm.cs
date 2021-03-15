using System;
using System.Drawing;
using System.Windows.Forms;
using Library.Core.Enum;

namespace Library.App.Popup
{
    public partial class AlertForm : Form
    {
        public enum Action
        {
            Wait,
            Start,
            Close
        }
        public AlertForm()
        {
            InitializeComponent();
        }

        private int _x, _y;
        private Action _action;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (_action)
            {
                case Action.Wait:
                    timer1.Interval = 2250;
                    _action = Action.Close;
                    break;
                case Action.Start:
                    timer1.Interval = 1;
                    Opacity += 0.25;
                    if (_x < Location.X) Left--;
                    else if (Opacity == 1.0) _action = Action.Wait;
                    break;
                case Action.Close:
                    timer1.Interval = 1;
                    Opacity -= 0.25;
                    Left -= 3;
                    if (Opacity == 0.0) Close();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void ShowAlert(string message, ResultStatus resultStatus)
        {
            Opacity = 0.0;
            StartPosition = FormStartPosition.Manual;
            for (var i = 1; i < 10; i++)
            {
                var alertName = "Uyarı " + i;
                var alertForm = (AlertForm)Application.OpenForms[alertName];
                if (alertForm != null) continue;
                Name = alertName;
                _x = Screen.PrimaryScreen.WorkingArea.Width - Width + 15;
                _y = Screen.PrimaryScreen.WorkingArea.Height - (Height * i) - (5 * i);
                Location = new Point(_x, _y);
                break;
            }
            _x = Screen.PrimaryScreen.WorkingArea.Width - Width - 5;

            switch (resultStatus)
            {
                case ResultStatus.Success:
                    btnSuccess.Visible = true;
                    BackColor = Color.SeaGreen;
                    break;
                case ResultStatus.Error:
                    btnError.Visible = true;
                    BackColor = Color.Brown;
                    break;
                case ResultStatus.Warning:
                    btnWarning.Visible = true;
                    BackColor = Color.Peru;
                    break;
                case ResultStatus.Info:
                    btnInfo.Visible = true;
                    BackColor = Color.SteelBlue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(resultStatus), resultStatus, null);
            }

            lblMessage.Text = message;
            Show();
            _action = Action.Start;
            timer1.Interval = 1;
            timer1.Start();
        }
    }
}