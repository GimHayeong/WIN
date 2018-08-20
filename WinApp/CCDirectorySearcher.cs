using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class CCDirectorySearcher : Control
    {
        /// <summary>
        /// 리스트박스에 표현하기 적합한 형태로 마샬링하는 대리자
        /// </summary>
        /// <param name="files"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        private delegate void FileListDelegate(string[] files, int startIndex, int count);

        /// <summary>
        /// 검색 호출 대리자
        /// </summary>
        private FileListDelegate m_dgtFileListBinding;

        /// <summary>
        /// 검색 완료 이벤트
        /// </summary>
        public event EventHandler SearchComplete;

        private ListBox lbxFiles;

        /// <summary>
        /// 검색 스레드 시작(검색중) 여부
        /// </summary>
        public bool Searching { get; private set; }

        /// <summary>
        /// 검색 스레드 연기 여부
        /// </summary>
        public bool DeferSearch { get; private set; }

        /// <summary>
        /// 현재 검색중이면 1. 검색을 멈추고 2. 검색조건 설정 후, 3. 검색 다시 시작
        /// </summary>
        public string SearchCriteria
        {
            get
            {
                return SearchCriteria;
            }
            set
            {
                bool wasSearching = Searching;

                if (wasSearching)
                {
                    StopSearch();
                }

                lbxFiles.Items.Clear();
                SearchCriteria = value;

                if (wasSearching)
                {
                    BeginSearch();
                }
            }
        }

        /// <summary>
        /// 검색스레드 인스턴스
        /// </summary>
        public Thread SearchThread { get; private set; }




        public CCDirectorySearcher()
        {
            InitializeComponent();

            InitControl();
        }

        /// <summary>
        /// 핸들생성 : 검색 스레드가 연기되었다면 연기된 검색 스레드 시작
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DeferSearch)
            {
                DeferSearch = false;
                BeginSearch();
            }
        }

        /// <summary>
        /// 핸들파괴 : 컨트롤이 자신의 핸들을 다시 만들고 있지 않다면 검색을 중지하고 핸들 파괴 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (!RecreatingHandle)
            {
                StopSearch();
            }

            base.OnHandleDestroyed(e);
        }

        private void InitControl()
        {
            Searching = false;
            DeferSearch = false;

            lbxFiles = new ListBox();
            lbxFiles.Dock = DockStyle.Fill;

            Controls.Add(lbxFiles);

            m_dgtFileListBinding = new FileListDelegate(AddFiles);
            SearchComplete = new EventHandler(OnSearchComplete);
        }

        /// <summary>
        /// 백그라운드 스레드에서 호출(BeginInvoke)되는 메서드. 
        ///  : 역순으로 리스트박스에 추가
        /// </summary>
        /// <param name="files"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        private void AddFiles(string[] files, int startIndex, int count)
        {
            while(count-- > 0)
            {
                lbxFiles.Items.Add(files[startIndex + count]);
            }
        }
        /// <summary>
        /// 백그라운드 스레드가 검색 작업을 끝낼 때 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSearchComplete(object sender, EventArgs e)
        {
            if(SearchComplete != null)
            {
                SearchComplete(sender, e);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }


        /// <summary>
        /// 검색중이 아니고 검색에 연결된 핸들이 있으면, 새 검색 스레드 시작, 
        /// 검색중이 아니고 검색에 연결된 핸들이 없으면, 검색 연기
        /// </summary>
        public void BeginSearch()
        {
            if (Searching) return;

            if (IsHandleCreated)
            {
                SearchThread = new Thread(new ThreadStart(ThreadProcedure));
                Searching = true;
                SearchThread.Start();
            }
            else
            {
                DeferSearch = true;
            }
        }

        /// <summary>
        /// 백그라운드 스레드에서 디렉토리를 조회하기 위해 실행 호출
        /// </summary>
        private void ThreadProcedure()
        {
            try
            {
                string searchPath = SearchCriteria;
                RecurseDirectory(searchPath);
            }
            finally
            {
                Searching = false;
                BeginInvoke(SearchComplete, new object[] { this, EventArgs.Empty });
            }
        }

        /// <summary>
        /// 크로스 스레드 호출 시작
        /// </summary>
        /// <param name="searchPath"></param>
        private void RecurseDirectory(string searchPath)
        {
            string dir = Path.GetDirectoryName(searchPath);
            string file = Path.GetFileName(searchPath);

            if (dir == null || file == null) return;

            string[] files;

            try
            {
                files = Directory.GetFiles(dir, file);
            }
            catch(UnauthorizedAccessException) { return; }
            catch(DirectoryNotFoundException) { return; }

            int idxStart = 0;
            int count;

            while(idxStart < files.Length)
            {
                count = 20;
                if(count + idxStart >= files.Length)
                {
                    count = files.Length - idxStart;
                }
                IAsyncResult result = BeginInvoke(m_dgtFileListBinding, new object[] { files, idxStart, count });
                idxStart += count;
            }
        }

        /// <summary>
        /// 검색중이 아니면, 검색스레드 중단
        /// </summary>
        private void StopSearch()
        {
            if (!Searching) return;

            if (SearchThread.IsAlive)
            {
                SearchThread.Abort();
                SearchThread.Join();
            }

            SearchThread = null;
            Searching = false;
        }

    }
}
