using System;
using System.Drawing;
using System.Windows.Forms;

namespace SignalForward
{
    /// <summary>
    /// 关闭软件时的密码验证框（需输入修改密码）
    /// </summary>
    public class PasswordPrompt : Form
    {
        private readonly string _password;
        private readonly TextBox _textBox;

        public PasswordPrompt(string password)
        {
            _password = password ?? string.Empty;

            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            MaximizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(380, 132);
            Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Text = LanguageHelper.T("关闭验证", "Close Verification");

            var label = new Label
            {
                AutoSize = true,
                Location = new Point(16, 16),
                Text = LanguageHelper.T("请输入修改密码以关闭软件：", "Enter the modify password to exit:")
            };

            _textBox = new TextBox
            {
                Location = new Point(16, 44),
                Size = new Size(348, 23),
                UseSystemPasswordChar = true
            };

            var okButton = new Button
            {
                Text = LanguageHelper.T("确定", "OK"),
                Location = new Point(196, 84),
                Size = new Size(78, 27)
            };
            okButton.Click += OkButton_Click;

            var cancelButton = new Button
            {
                Text = LanguageHelper.T("取消", "Cancel"),
                DialogResult = DialogResult.Cancel,
                Location = new Point(286, 84),
                Size = new Size(78, 27)
            };

            Controls.Add(label);
            Controls.Add(_textBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        /// <summary>
        /// 校验密码：正确则关闭对话框，错误则提示并允许重试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.Equals(_textBox.Text, _password))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(this, LanguageHelper.MsgWrongPassword);
                _textBox.SelectAll();
                _textBox.Focus();
            }
        }
    }
}
