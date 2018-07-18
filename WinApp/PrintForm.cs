using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class PrintForm : Form
    {
        private bool m_IsPrintAll = false;
        private Font m_Font;
        private int m_StartPageIndex = 0;
        private int m_EndPageIndex = 0;
        private int m_CurrentPageIndex = 0;
        const int LPP = 20;//Line Per Page


        public PrintForm()
        {
            InitializeComponent();
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            PrintContents(e.Graphics);
        }

        private void PrintContents(Graphics g)
        {
            PrintContents(g, 0, 0);
        }

        private void PrintContents(Graphics g, int left, int top)
        {
            string str = "문재인 정부의 성공을 기원합니다.";
            Font font = new Font("바탕", 12);
            g.DrawString(str, font, Brushes.Black, left + 100, top + 100);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(pen, left + 100 - font.Height, top + 100 - font.Height, 290, 50);
        }

        /// <summary>
        /// 인쇄설정 버튼
        /// PrintDialog : 인쇄 대화상사
        ///   + PrinterSettings : 인쇄할 프린터의 프린터옵션 정보
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintOption_Click(object sender, EventArgs e)
        {
            if(prtDlg.ShowDialog() == DialogResult.OK)
            {
                PrinterSettings prtSet = prtDlg.PrinterSettings;
                lbxData.Items.Clear();
                lbxData.Items.Add("인쇄할 프린터: " + prtSet.PrinterName);
                lbxData.Items.Add("인쇄 매수: " + prtSet.Copies);
                lbxData.Items.Add("한부씩 인쇄: " + prtSet.Collate);

                switch (prtSet.PrintRange)
                {
                    case PrintRange.AllPages:
                        lbxData.Items.Add("문서 전체 인쇄");
                        break;

                    case PrintRange.CurrentPage:
                        lbxData.Items.Add("현재 페이지 인쇄");
                        break;

                    case PrintRange.Selection:
                        lbxData.Items.Add("선택 영역 인쇄");
                        break;

                    case PrintRange.SomePages:
                        lbxData.Items.Add(prtSet.FromPage + " ~ " + prtSet.ToPage + " 까지 인쇄");
                        break;
                }

                if (prtSet.PrintToFile)
                {
                    prtSet.PrintFileName = @"D:\downloads\temp\spool.prn";
                    lbxData.Items.Add(prtSet.PrintFileName + " 파일에 인쇄");
                }
            }
        }

        /// <summary>
        /// 페이지설정 버튼
        /// PageSetupDialog : 페이지 설정 대화상자
        ///   + PageSettings : 인쇄할 페이지 인쇄옵션 정보
        ///   + PageSettings 객체와 PrinterSettings 객체는 대화상자를 호출하기 전에 미리 생성하여 대입해야 함.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            pgsDlg.PageSettings = new PageSettings();
            pgsDlg.PrinterSettings = new PrinterSettings();
            if(pgsDlg.ShowDialog() == DialogResult.OK)
            {
                PageSettings pgSet = pgsDlg.PageSettings;
                lbxData.Items.Clear();
                lbxData.Items.Add("가로 방향 인쇄 : " + pgSet.Landscape);
                lbxData.Items.Add("용지 종류 : " + pgSet.PaperSize.Kind);
                lbxData.Items.Add("급지 장치 : " + pgSet.PaperSource.Kind);
                lbxData.Items.Add("여백 : " + pgSet.Margins);
                lbxData.Items.Add("용지 크기 : " + pgSet.Bounds);
                lbxData.Items.Add("컬러 인쇄 : " + pgSet.Color);
            }
        }

        /// <summary>
        /// 미리보기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            prtPrvDlg.Document = prtDoc;
            prtPrvDlg.ShowDialog();
        }

        /// <summary>
        /// 인쇄하기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            m_IsPrintAll = false;
            if (prtDlg.ShowDialog() == DialogResult.OK)
            {
                prtDoc.PrinterSettings = prtDlg.PrinterSettings;
                prtDoc.DocumentName = "테스트 문서";
                prtDoc.Print();
            }
        }

        /// <summary>
        /// 전체인쇄 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            m_IsPrintAll = true;

            prtDlg.AllowSelection = true;
            prtDlg.AllowSomePages = true;
            prtDlg.AllowCurrentPage = true;

            if(prtDlg.ShowDialog() == DialogResult.OK)
            {
                prtDoc.PrinterSettings = prtDlg.PrinterSettings;
                prtDoc.DocumentName = "테스트 문서";
                switch (prtDlg.PrinterSettings.PrintRange)
                {
                    case PrintRange.AllPages://1페이지~5페이지 : 1 ~ 100
                        m_StartPageIndex = 0;
                        m_EndPageIndex = 4;
                        break;

                    case PrintRange.CurrentPage://3페이지 : 41 ~ 60
                        m_StartPageIndex = 2;
                        m_EndPageIndex = 2;
                        break;

                    case PrintRange.Selection://4페이지 : 61 ~ 80
                        m_StartPageIndex = 3;
                        m_EndPageIndex = 3;
                        break;

                    case PrintRange.SomePages://2페이지~3페이지 : 21 ~ 60
                        m_StartPageIndex = prtDlg.PrinterSettings.FromPage - 1;
                        m_EndPageIndex = prtDlg.PrinterSettings.ToPage - 1;
                        break;
                }
                prtDoc.Print();
            }
        }

        private void prtDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (!m_IsPrintAll)
            {
                Pen pen = new Pen(Color.Blue, 5);
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, e.MarginBounds);

                PrintContents(e.Graphics, e.MarginBounds.Left, e.MarginBounds.Top);
            }
            else
            {
                string str;
                for(int i=0; i<LPP; i++)
                {
                    str = String.Format("{0}번째 줄입니다.", m_CurrentPageIndex * LPP + i + 1);
                    e.Graphics.DrawString(str, m_Font, Brushes.Black, e.MarginBounds.Left + 10, e.MarginBounds.Top + i * 40);
                }

                m_CurrentPageIndex++;
                if(m_CurrentPageIndex <= m_EndPageIndex)
                {
                    e.HasMorePages = true;
                }
            }
        }

        /// <summary>
        /// 인쇄 시작 전, 글꼴이나 파일 등의 리소스 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prtDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            //if(MessageBox.Show("정말 인쇄하시겠습니까?", "인쇄확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}

            if (m_IsPrintAll)
            {
                m_Font = new Font("바탕", 14);
                m_CurrentPageIndex = m_StartPageIndex;
            }
        }

        /// <summary>
        /// 인쇄를 끝낼때, BeginPrint에서 준비한 리소스 해제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prtDoc_EndPrint(object sender, PrintEventArgs e)
        {
            if (m_IsPrintAll)
            {
                m_Font.Dispose();
            }
        }

        /// <summary>
        /// PrintPage 이벤트 직전, 페이지별로 설정 변경. 특정 페이지만 가로나 흑백 인쇄 설정 가능.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prtDoc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {

        }

        
    }
}
