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
    public partial class TokenForm : Form
    {
        public TokenForm()
        {
            InitializeComponent();
        }

        private void TokenForm_Load(object sender, EventArgs e)
        {
            tbxMsg.Text = "S_S_FILE#검색서버IP#파일개수#파일이름&파일사이즈&파일생성일";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string msg = tbxMsg.Text;
            string[] token = msg.Split('#');
            for(int i=0; i<token.Length; i++)
            {
                if(token[i].IndexOf('&') > 0)
                {
                    tbxInfo.AppendText($"\r\n{token[i]}");
                    string[] subToken = token[i].Split('&');
                    for(int j=0; j<subToken.Length; j++)
                    {
                        tbxInfo.AppendText($"\r\n\t==>{subToken[j]}");
                    }
                }
                else
                {
                    tbxInfo.AppendText($"\r\n{token[i]}");
                }
            }
        }
    }
}
