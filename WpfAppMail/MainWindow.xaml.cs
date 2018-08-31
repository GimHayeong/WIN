using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppMail
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AttachFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"c:\";
            dlg.Title = "첨부할 파일을 선택하세요.";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                tbxFile.Text = dlg.FileName;
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidMail()) return;

            try
            {
                var smtpServerName = ConfigurationManager.AppSettings["SmtpServer"];
                var port = ConfigurationManager.AppSettings["Port"];
                var senderEmailId = ConfigurationManager.AppSettings["SenderEmailId"];
                var senderPassword = ConfigurationManager.AppSettings["SenderPassword"];

                MailAddress from = new MailAddress(senderEmailId);
                MailAddress to = new MailAddress(tbxTo.Text.Trim());
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = tbxSubject.Text.Trim();
                mail.Body = tbxContent.Text.Trim();
                mail.BodyEncoding = Encoding.Default;

               if (!String.IsNullOrWhiteSpace(tbxFile.Text))
                {
                    Attachment attach = new Attachment(tbxFile.Text.Trim());
                    mail.Attachments.Add(attach);
                }

                SmtpClient client = new SmtpClient(smtpServerName, Convert.ToInt32(port))
                {
                    Credentials = new NetworkCredential(senderEmailId, senderPassword)
                    , EnableSsl = true
                };
                client.Send(mail);
                MessageBox.Show("메일을 성공적으로 발송하였습니다.");

                btnReset.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            catch(Exception ex)
            {
                MessageBox.Show($"메일전송실패: {ex.StackTrace}");
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            tbxTo.Clear();
            tbxSubject.Clear();
            tbxContent.Clear();
            tbxFile.Clear();
        }

        /// <summary>
        /// [유효성 검사]
        /// </summary>
        /// <returns></returns>
        private bool IsValidMail()
        {
            if (String.IsNullOrWhiteSpace(tbxTo.Text))
            {
                MessageBox.Show("받을 이메일 주소를 입력하세요.");
                tbxTo.Focus();
                tbxTo.SelectAll();
                return false;
            }
            else if (!Regex.IsMatch(tbxTo.Text, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"))
            {
                MessageBox.Show("유효한 받을 이메일 주소를 입력하세요.");
                tbxTo.Focus();
                tbxTo.SelectAll();
                return false;
            }

            if (String.IsNullOrWhiteSpace(tbxSubject.Text))
            {
                MessageBox.Show("메일 제목을 입력하세요.");
                tbxSubject.Focus();
                tbxSubject.SelectAll();
                return false;
            }

            if (String.IsNullOrWhiteSpace(tbxContent.Text))
            {
                MessageBox.Show("메일 내용을 입력하세요.");
                tbxContent.Focus();
                tbxContent.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// [전자우편 유효성 검사] @와 .이 포함되어 있으면 유효한 이메일로 판단
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool CheckEmail(string email)
        {
            byte stock = 0;

            foreach(char ch in email)
            {
                if (ch == '@' || ch == '.') stock++;
            }

            return stock == 2;
        }
    }
}
