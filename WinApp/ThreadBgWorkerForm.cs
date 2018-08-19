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
    ///   1. 백그라운드 스레드에서 사용할 메서드 호출 대리자
    ///   2. 폼로드시, 백그라운드 스레드 인스턴스 생성[by 디자인모드] 및 RunWorkerCompleted 이벤트 바인딩[by 소스코드]
    ///   3. 백그라운드 스레드에서 수행하려는 작업 메서드를 호출하는 메서드 생성
    ///   4. 백그라운드 스레드 시작 (RunWorkerAsync 메서드 호출)
    ///   5. 백그라운드 작업 완료후 작업결과 보고하는(UI 변경) 메서드 생성
    /// </remarks>
    public partial class ThreadBgWorkerForm : Form
    {
        /// <summary>
        /// 1. 백그라운드 스레드에서 사용할 파라메터가 있는 메서드 호출 대리자
        /// </summary>
        /// <param name="msg"></param>
        delegate void m_dgtStringArgReturningVoid(string msg);

        private Thread m_thread = null;

        public ThreadBgWorkerForm()
        {
            InitializeComponent();
        }







        #region [ 백그라운드 스레드를 통한 안전한 UI 변경 ]

        /// <summary>
        /// 2. 백그라운드 스레드 인스턴스에 RunWorkerCompleted 이벤트 바인딩 [by 소스코드]
        /// [ 선작업 ] BackgroundWorker 인스턴스 생성 [by 디자인모드]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            bgWorker = new BackgroundWorker();

            bgWorker.RunWorkerCompleted += BgDoWorker_RunWorkerCompleted;
        }

        /// <summary>
        /// 3. 백그라운드 스레드 시작 메서드 호출 
        ///  [ 선작업 ] 1.의 메서드를 DoWork 인스턴스의 BackgroundWorker 이벤트의 바인딩 [by 디자인모드]
        /// (컨트롤을 만든 스레드가 아닌 스레드로부터 안전한 백그라운드 호출)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunBgWorkerAsync_Click(object sender, EventArgs e)
        {
            BgThreadStartByRunWorkerAsync();
        }


        /// <summary>
        /// 4. 백그라운드 스레드 시작 (RunWorkerAsync 인스턴스의 BackgroundWorker 메서드 호출)
        /// </summary>
        private void BgThreadStartByRunWorkerAsync()
        {
            bgWorker.RunWorkerAsync();
        }


        /// <summary>
        /// 5. 백그라운드 스레드에서 수행후 UI 변경 메서드
        /// (컨트롤을 만든 스레드가 아닌 스레드로부터 안전한 백그라운드 호출 결과 보고)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgDoWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tbxBgDoWorker.Text = "This text was set safely by BackgroundWorker.";
        }

        
        #endregion








        #region [ 컨트롤을 만든 스레드가 아닌 스레드로부터 안전하지 않은 호출 ]

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
                // 크로스 스레드 작업 오류 메시지 : 자신이 만들어진 스레드가 아닌 스레드로부터 호출
                MessageBox.Show(ex.Message);
            }
        }

        #endregion








        #region [ 컨트롤을 만든 스레드가 아닌 스레드로부터 안전한 호출 ]


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
        /// 스레드에서 안전하게 수행하려는 작업 메서드
        /// </summary>
        private void DoWorkerProcSafeThread()
        {
            SetText("This text was set safely.");
        }


        /// <summary>
        /// 스레드에서 수행할 작업 
        ///   : 컨트롤을 만든 스레드가 아닌 스레드로부터의 호출인 경우인지 체크하여 Invoke() 메서드를 통해 해당 메서드를 안전하게 호출
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

        #endregion


    }
}
