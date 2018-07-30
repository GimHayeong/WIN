using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    /// <summary>
    /// Invoke() : 부모 컨트롤의 스레드 외의 다른 스레드로부터 안전하게 컨트롤 호출
    /// </summary>
    public partial class ThreadInvokeForm : Form
    {
        private string m_Msg = null;

        // 1. Invoke 메서드에 매개변수로 들어갈 delegate 선언
        public delegate void SetTextCallback(string msg);
        public delegate void SetBalanceCallback(int balance);
        public delegate void SetParamsCallback(string msg, int balance);

        // 2. delegate 형 1.의 참조변수 선언
        public SetTextCallback m_dgtSetText = null;
        public SetBalanceCallback m_dgtSetBalance = null;
        public SetParamsCallback m_dgtSetParams = null;

        public ThreadInvokeForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

            // 3. delegate 형 참조변수가 가리키는 메서드 설정
            m_dgtSetText = new SetTextCallback(AddMSG);
            m_dgtSetBalance = new SetBalanceCallback(AddBalance);
            m_dgtSetParams = new SetParamsCallback(AddParams);
        }

        private void AddMSG()
        {
            lock (tbxInfo)
            {
                tbxInfo.Text= m_Msg;
                tbxInfo.ScrollToCaret();
            }
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터 안전하지 않은 호출
        /// </summary>
        /// <remarks>
        /// 오류: "크로스 스레드 작업이 잘못되었습니다. 'tbxInfo' 컨트롤이 자신이 만들어진 스레드가 아닌 스레드에서 액세스되었습니다."
        /// </remarks>
        private void AddMSGUnSafe()
        {
            try
            {
                tbxInfo.Text = "This text was set unsafely.";
                tbxBalance.Text = "10000";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터 안전한 호출
        /// </summary>
        private void AddMSGSafe()
        {
            AddMSG("This text was set safely.");
            Random rnd = new Random();
            int balance = 5000 + rnd.Next(5000);
            AddBalance(balance);
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터 안전한 호출
        /// </summary>
        private void AddParamsSafe()
        {
            string msg = "안녕하세요.";
            int balance = 1000;
            AddParams(msg, balance);
        }



        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터의 호출인 경우인지 체크하여 Invoke() 메서드를 통해 해당 메서드를 안전하게 호출
        /// </summary>
        /// <param name="str"></param>
        private void AddMSG(string str)
        {
            try
            {
                // 컨트롤을 만든 스레드가 아닌 스레드로부터의 호출인 경우인지 체크 (호출메서드인 Invoke() 메서드를 호출해야 하는지 여부)
                if (tbxInfo.InvokeRequired)
                {
                    // 2 ~ 3. delegate 형 1.의 참조변수 선언하고 delegate 형 참조변수가 가리키는 메서드 설정
                    //SetTextCallback dgt = new SetTextCallback(AddMSG);

                    //4.컨트롤의 부모 컨트롤에서 Invoke() 메서드 호출
                    this.Invoke(m_dgtSetText, new object[] { str });
                }
                else
                {
                    tbxInfo.Text = str;
                }
            }
            catch { }
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터의 호출인 경우인지 체크하여 Invoke() 메서드를 통해 해당 메서드를 안전하게 호출
        /// </summary>
        /// <param name="balance"></param>
        private void AddBalance(int balance)
        {
            try
            {
                // 컨트롤을 만든 스레드가 아닌 스레드로부터의 호출인 경우인지 체크 (호출메서드인 Invoke() 메서드를 호출해야 하는지 여부)
                if (tbxInfo.InvokeRequired)
                {
                    // 2 ~ 3. delegate 형 1.의 참조변수 선언하고 delegate 형 참조변수가 가리키는 메서드 설정
                    //SetBalanceCallback dgt = new SetBalanceCallback(AddBalance);

                    //4.컨트롤의 부모 컨트롤에서 Invoke() 메서드 호출
                    this.Invoke(m_dgtSetBalance, new object[] { balance });
                }
                else
                {
                    tbxBalance.Text = balance.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터의 호출인 경우인지 체크하여 Invoke() 메서드를 통해 해당 메서드를 안전하게 호출
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="balance"></param>
        private void AddParams(string msg, int balance)
        {
            try
            {
                // 컨트롤을 만든 스레드가 아닌 스레드로부터의 호출인 경우인지 체크 (호출메서드인 Invoke() 메서드를 호출해야 하는지 여부)
                if (tbxInfo.InvokeRequired || tbxBalance.InvokeRequired)
                {
                    // 2 ~ 3. delegate 형 1.의 참조변수 선언하고 delegate 형 참조변수가 가리키는 메서드 설정
                    //SetParamsCallback dgtSetParams = new SetParamsCallback(AddParams);

                    object[] temp = { msg, balance };

                    //4.컨트롤의 부모 컨트롤에서 Invoke() 메서드 호출
                    this.Invoke(m_dgtSetParams, temp);
                }
                else
                {
                    tbxInfo.Text = msg;
                    tbxBalance.Text = balance.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드에서 안전하지 않은 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnsafe_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(AddMSGUnSafe));
            thread.Start();
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드에서 Invoke() 호출메서드를 통해 안전하게 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSafe_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(AddMSGSafe));
            thread.Start();
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드에서 Invoke() 호출메서드를 통해 안전하게 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSafeParam_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(AddParamsSafe));
            thread.Start();
        }
    }
}
