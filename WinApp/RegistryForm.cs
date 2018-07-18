//#define REGISTER
using Microsoft.Win32;
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
    public partial class RegistryForm : Form
    {
#if REGISTER
        const string REG_ROOT = @"Software\YeongSoft\RegistryTest";//
#endif
        public RegistryForm()
        {
            InitializeComponent();
        }

        private void RegistryForm_Load(object sender, EventArgs e)
        {
#if REGISTER
            string setting = REG_ROOT + @"\Setting";
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(setting);//readonly (컴퓨터\HKEY_CURRENT_USER\ + setting)
            if (regKey == null)
            {
                txtRegText.Text = "첫문자열";
                nudRegValue.Value = 12;
            }
            else
            {
                txtRegText.Text = (string)regKey.GetValue("Text");
                nudRegValue.Value = (int)regKey.GetValue("Value");
                regKey.Close();//RegistryKey.Close()필요
            }
#endif
        }

        private void RegistryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
#if REGISTER
            string setting = REG_ROOT + @"\Setting";
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(setting, true);//read/write (컴퓨터\HKEY_CURRENT_USER\ + setting)
            if(regKey == null)
            {
                regKey = Registry.CurrentUser.CreateSubKey(setting);
            }

            regKey.SetValue("Text", txtRegText.Text);
            regKey.SetValue("Value", nudRegValue.Value, RegistryValueKind.DWord);//32비트 정수형값 저장
            regKey.Close();//RegistryKey.Close()필요
#endif
        }
    }
}
