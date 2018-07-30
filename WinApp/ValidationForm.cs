using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class ValidationForm : Form
    {
        public ValidationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 숫자와 영문자로 구성된 문자열인지 여부
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool ValidAlphaOrDigit(string str)
        {
            foreach(char c in str.ToLower())
            {
                if((c < 'a' || c > 'z') && (c < '0' || c > '9'))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 유효한 전화번호인지 여부
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool ValidPhonNumber(string str)
        {
            if (str.IndexOf('-') == -1) return false;

            foreach(char c in str)
            {
                if ((c != '-') && (c < '0' || c > '9'))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 유효한 숫자인지 여부
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool ValidDigit(string str)
        {
            foreach(char c in str.ToLower())
            {
                if((c < '0' || c > '9'))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 유효한 이메일인지 여부
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool ValidEmail(string str)
        {
            byte stock = 0;

            foreach(char c in str)
            {
                if( c == '@' || c == '.')
                {
                    stock++;
                }
            }

            return (stock >= 2);
        }

        /// <summary>
        /// 유효한 주민등록번호인지 여부
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool ValidSSN(string str)
        {
            // 검증1
            if (str.Length != 13) return false;

            // 검증2
            if (!ValidDigit(str)) return false;

            int validSum = 0;
            int validRemaind = 0;

            int[] num = new int[13];

            // 가중치
            int[] weightedValue = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5 };

            for(int i=0; i<num.Length; i++)
            {
                num[i] = Int32.Parse(str[i].ToString());
            }

            for(int i=0; i<num.Length - 1; i++)
            {
                validSum += weightedValue[i] * num[i];
            }

            validRemaind = validSum % 11;
            
            if(validRemaind == 0)
            {
                // 검증3 : 가중치합을 11로 나눈 나머지가 0이고 주민번호12번째 자리값이 1이면 true
                return (num[12] == 1);
            } 
            else if(validRemaind == 1)
            {
                // 검증4 : 가중치합을 11로 나눈 나머지가 1이고 주민번호 12번째 자리값이 0이면 true
                return (num[12] == 0);
            } 
            else if(11 - validRemaind == num[12])
            {
                // 검증5 : 가중치합을 11로 나눈 나머지를 11에서 뺀 값이 주민번호 12번째 자리값과 같으면 true
                return true;
            }
            else
            {
                // 검증6 : 가중치합을 11로 나눈 나머지값과 주민번호 12번째 자리값 비교가 유효하지 않으면 false
                return false;
            }
        }

        private void btnAlphaOrDigit_Click(object sender, EventArgs e)
        {
            if (ValidAlphaOrDigit(tbxAlphaOrDigit.Text.Trim()))
            {
                MessageBox.Show($"{tbxAlphaOrDigit.Text.Trim()}: 영문자 혹은 숫자", "유효문자입력확인");
            }
            else
            {
                MessageBox.Show($"{tbxAlphaOrDigit.Text.Trim()}: 영숫자가 아닌 문자가 있습니다.", "유효하지않은 문자입력");
                tbxAlphaOrDigit.SelectAll();
                tbxAlphaOrDigit.Focus();
            }
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            if (ValidPhonNumber(tbxPhone.Text.Trim()))
            {
                MessageBox.Show($"전화번호: {tbxPhone.Text.Trim()}", "유효전화번호입력확인");
            }
            else
            {
                MessageBox.Show($"{tbxPhone.Text.Trim()}은 유효하지 않은 번호입니다.", "유효하지않은 전화번호입력");
                tbxPhone.SelectAll();
                tbxPhone.Focus();
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (ValidEmail(tbxEmail.Text.Trim()))
            {
                MessageBox.Show($"Email: {tbxEmail.Text.Trim()}", "유효전자우편입력확인");
            }
            else
            {
                MessageBox.Show($"{tbxEmail.Text.Trim()}은 유효하지 않은 Email입니다.", "유효하지않은 전자우편입력");
                tbxEmail.SelectAll();
                tbxEmail.Focus();
            }
        }

        private void btnSSN_Click(object sender, EventArgs e)
        {
            if (ValidSSN(tbxSSN.Text.Trim()))
            {
                MessageBox.Show($"주민등록번호: {tbxSSN.Text.Trim()}", "유효주민등록번호입력확인");
            }
            else
            {
                MessageBox.Show($"{tbxSSN.Text.Trim()}은 유효하지 않은 주민등록번호입니다.", "유효하지않은 주민등록번호입력");
                tbxSSN.SelectAll();
                tbxSSN.Focus();

            }
        }
    }
    
}
