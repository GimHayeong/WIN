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
    /// BackgroundWorker를 사용하여 스레드로부터 안전한 호출
    /// </summary>
    /// <remarks>
    ///   1. 백그라운드 스레드에서 수행하려는 작업 메서드 생성
    ///   2. 백그라운드 작업 완료후 작업결과 보고하는 메서드 생성
    ///   3. 1.의 메서드를 DoWork 인스턴스의 BackgroundWorker 이벤트에 바인딩
    ///   4. 2.의 메서드를 DoWork 인스턴스의 RunWorkerCompleted 이벤트에 바인딩 
    ///   5. 백그라운드 스레드 시작 (RunWorkerAsync 인스턴스의 BackgroundWorker 메서드 호출)
    /// </remarks>
    public partial class ThreadBgWorkerForm : Form
    {
        delegate void m_dgtStringArgReturningVoid(string msg);

        private Thread m_thread = null;

        public ThreadBgWorkerForm()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 1. 백그라운드 스레드에서 수행하려는 작업 메서드
        /// </summary>
        private void DoWorkerProcSafeThread()
        {
            SetText("This text was set safely.");
        }


        /// <summary>
        /// 2. 백그라운드 스레드에서 수행하려는 작업 메서드
        /// (컨트롤을 만든 스레드가 아닌 스레드로부터 안전한 백그라운드 호출 결과 보고)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgDoWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tbxBgDoWorker.Text = "This text was set safely by BackgroundWorker.";
        }

        /// <summary>
        /// 3. 1.의 메서드를 DoWork 인스턴스의 BackgroundWorker 이벤트의 바인딩 [by 디자인모드]
        /// (컨트롤을 만든 스레드가 아닌 스레드로부터 안전한 백그라운드 호출)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunBgWorkerAsync_Click(object sender, EventArgs e)
        {
            BgThreadStartByRunWorkerAsync();
        }

        /// <summary>
        /// 4. 2.의 메서드를 DoWork 인스턴스의 RunWorkerCompleted 이벤트에 바인딩 [by 소스코드]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            bgWorker = new BackgroundWorker();

            bgWorker.RunWorkerCompleted += BgDoWorker_RunWorkerCompleted;
        }

        /// <summary>
        /// 5. 백그라운드 스레드 시작 (RunWorkerAsync 인스턴스의 BackgroundWorker 메서드 호출)
        /// </summary>
        private void BgThreadStartByRunWorkerAsync()
        {
            bgWorker.RunWorkerAsync();
        }





        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터 안전하지 않은 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnsafe_Click(object sender, EventArgs e)
        {
            m_thread = new Thread(new ThreadStart(DoWorkerProcUnsafeThread));
            m_thread.Start();
        }


        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터 안전하지 않은 호출
        /// </summary>
        private void DoWorkerProcUnsafeThread()
        {
            try
            {
                tbxBgDoWorker.Text = "This text was set unsafely.";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터 안전한 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSafeThread_Click(object sender, EventArgs e)
        {
            m_thread = new Thread(new ThreadStart(DoWorkerProcSafeThread));
            m_thread.Start();
        }

        

        

        /// <summary>
        /// 컨트롤을 만든 스레드가 아닌 스레드로부터의 호출인 경우인지 체크하여 Invoke() 메서드를 통해 해당 메서드를 안전하게 호출
        /// </summary>
        /// <param name="msg"></param>
        private void SetText(string msg)
        {
            if (tbxBgDoWorker.InvokeRequired)
            {
                m_dgtStringArgReturningVoid dgt = new m_dgtStringArgReturningVoid(SetText);
                Invoke(dgt, new object[] { msg });
            }
            else
            {
                tbxBgDoWorker.Text = msg;
            }
        }

        
    }
}
