using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using TallComponents.PDF.Rasterizer;
using TallComponents.PDF.Rasterizer.Configuration;

namespace WpfPhotoGallery
{
    /// <summary>
    /// WinLayer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WinLayer : Window
    {

        /// <summary>
        /// 툴박스 창 도킹여부 (툴박스 버튼의 보이기 속성의 Visible 여부로 판단)
        /// </summary>
        private bool IsDockingToolbox
        {
            get { return btnToolbox.Visibility == Visibility.Visible; }
        }

        /// <summary>
        /// 솔루션탐색 창 도킹여부 (솔루션탐색 버튼의 보이기 속성의 Visible 여부로 판단)
        /// </summary>
        private bool IsDockingSolutionExplorer
        {
            get { return btnSolutionExplorer.Visibility == Visibility.Visible; }
        }

        /// <summary>
        /// 툴박스창(레이어1)의 도킹창이 추가되는 영역크기 (툴박스창이 도킹시 주레이어에 보여질 영역)
        /// </summary>
        private ColumnDefinition m_ColToolboxForLayer0;

        /// <summary>
        /// 솔루션탐색창(레이어2)의 도킹창이 추가되는 영역크기 (솔루션탐색창이 도킹시 주레이어에 보여질 영역)
        /// </summary>
        private ColumnDefinition m_ColSolutionExplorerForLayer0;

        /// <summary>
        /// 솔루션탐색창(레이어2)의 도킹창이 추가되는 영역크기 (솔루션탐색창이 도킹시 레이어1에 보여질 영역)
        /// </summary>
        private ColumnDefinition m_ColSolutionExplorerForLayer1;

        private RotateTransform m_RotateTrans = new RotateTransform();

        public WinLayer()
        {
            InitializeComponent();

            InitDummyColumns();
        }

        /// <summary>
        /// 도킹 핀 고정
        /// </summary>
        private void InitRotateTransform()
        {
            m_RotateTrans.CenterX = .5;
            m_RotateTrans.CenterY = .5;
            m_RotateTrans.Angle = -90;
        }

        /// <summary>
        /// 도킹 시 툴박스창과 솔루션탐색창이 나타날 부분을 각 레이어에 표현하기 위한 더미 컬럼
        /// </summary>
        private void InitDummyColumns()
        {
            m_ColToolboxForLayer0 = new ColumnDefinition();
            m_ColToolboxForLayer0.SharedSizeGroup = "colToolbox";
            m_ColSolutionExplorerForLayer0 = new ColumnDefinition();
            m_ColSolutionExplorerForLayer0.SharedSizeGroup = "colSolutionExplorer";
            m_ColSolutionExplorerForLayer1 = new ColumnDefinition();
            m_ColSolutionExplorerForLayer1.SharedSizeGroup = "colSolutionExplorer";
        }

        /// <summary>
        /// 메인 레이어로 마우스가 들어오면 도킹되지 않은 창 접기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainLayer_MouseEnter(object sender, MouseEventArgs e)
        {
            if (IsDockingToolbox)
            {
                grdLayer1.Visibility = Visibility.Collapsed;
            }

            if (IsDockingSolutionExplorer)
            {
                grdLayer2.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 툴박스/솔루션탐색 창 도킹버튼 마우스오버이면 관련 도킹창 보이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnToolbox":
                        SetLayerVisibility(grdLayer1, grdLayer2, IsDockingSolutionExplorer);
                        break;

                    case "btnSolutionExplorer":
                        SetLayerVisibility(grdLayer2, grdLayer1, IsDockingToolbox);
                        break;
                }
            }
        }

        /// <summary>
        /// 버튼과 관련된 도킹 창 보이기
        /// </summary>
        /// <remarks>
        /// 1. 보여질 레이어 보이기
        /// 2. 보여질 레이어가 최상위로 Z-index 조정
        /// 3. 접혀질 레이어가 현재 보이기 상태이면 접기
        /// </remarks>
        /// <param name="visibleGridLayer">보여질 레이어</param>
        /// <param name="collapseGridLayer">접혀질 레이어</param>
        /// <param name="isDockingCollaspeGridLayer">접혀질 레이어의 보이기상태</param>
        private void SetLayerVisibility(Grid visibleGridLayer, Grid collapseGridLayer, bool isDockingCollaspeGridLayer)
        {
            visibleGridLayer.Visibility = Visibility.Visible;
            Grid.SetZIndex(visibleGridLayer, 1);
            Grid.SetZIndex(collapseGridLayer, 0);

            if (isDockingCollaspeGridLayer)
            {
                collapseGridLayer.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 도킹 핀 버튼 클릭
        ///  (도킹 상태이면 도킹해제하고, 아니면 도킹설정)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "btnToolboxPin":
                        if (IsDockingToolbox)
                        {
                            SetDockPanel(1);
                        }
                        else
                        {
                            SetUndockPanel(1);
                        }
                        break;

                    case "btnSolutionExplorerPin":
                        if (IsDockingSolutionExplorer)
                        {
                            SetDockPanel(2);
                        }
                        else
                        {
                            SetUndockPanel(2);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 도킹 설정
        /// (도킹창)
        /// </summary>
        /// <param name="dockingLayer">도킹 설정할 레이어</param>
        private void SetDockPanel(int dockingLayer)
        {
            if(dockingLayer == 1)
            {
                btnToolbox.Visibility = Visibility.Collapsed;
                btnToolboxPin.RenderTransform = m_RotateTrans;

                grdLayer0.ColumnDefinitions.Add(m_ColToolboxForLayer0);
                if(!IsDockingSolutionExplorer)
                {
                    grdLayer1.ColumnDefinitions.Add(m_ColSolutionExplorerForLayer1);
                }
            }
            else if(dockingLayer == 2)
            {
                btnSolutionExplorer.Visibility = Visibility.Collapsed;
                btnSolutionExplorerPin.RenderTransform = m_RotateTrans;

                grdLayer0.ColumnDefinitions.Add(m_ColSolutionExplorerForLayer0);
                if(!IsDockingToolbox)
                {
                    grdLayer1.ColumnDefinitions.Add(m_ColSolutionExplorerForLayer1);
                }
            }
        }

        /// <summary>
        /// 도킹 해제
        /// (도킹레이어의 관련 핀버튼 보이기)
        /// </summary>
        /// <param name="undockingLayer">도킹 해제할 레이어</param>
        private void SetUndockPanel(int undockingLayer)
        {
            if(undockingLayer == 1)
            {
                grdLayer1.Visibility = Visibility.Visible;
                btnToolbox.Visibility = Visibility.Visible;
                btnToolboxPin.RenderTransform = null;

                grdLayer0.ColumnDefinitions.Remove(m_ColToolboxForLayer0);
                grdLayer1.ColumnDefinitions.Remove(m_ColSolutionExplorerForLayer1);
            }
            else if(undockingLayer == 2)
            {
                grdLayer2.Visibility = Visibility.Visible;
                btnSolutionExplorer.Visibility = Visibility.Visible;
                btnSolutionExplorerPin.RenderTransform = null;

                grdLayer0.ColumnDefinitions.Remove(m_ColSolutionExplorerForLayer0);
                grdLayer1.ColumnDefinitions.Remove(m_ColSolutionExplorerForLayer1);
            }
        }

        /// <summary>
        /// 도킹 창으로 마우스가 들어왔을 때 도킹되지 않은 경우 다른 창을 감추다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelArea_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid grd = sender as Grid;
            if(grd != null)
            {
                switch (grd.Name)
                {
                    case "grdPanelToolbox":
                        if (IsDockingSolutionExplorer)
                        {
                            grdLayer2.Visibility = Visibility.Collapsed;
                        }
                        break;

                    case "grdPanelSolutionExplorer":
                        if (IsDockingToolbox)
                        {
                            grdLayer1.Visibility = Visibility.Collapsed;
                        }
                        break;
                }
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;

            if(menu != null)
            {
                string menuName = menu.Tag as String;
                if(menuName != null)
                {
                    switch (menuName)
                    {
                        case "renameFile":
                            DlgRename dlg = new DlgRename();
                            if(dlg.ShowDialog() == true)
                            {
                                string oldFilename = @"D:\downloads\temp\oldfile.txt";
                                if(RenameFile(oldFilename, dlg.FileName))
                                {
                                    MessageBox.Show($"{oldFilename} 파일의 이름을 {System.IO.Path.Combine(System.IO.Path.GetDirectoryName(oldFilename), dlg.FileName) + System.IO.Path.GetExtension(oldFilename)}으로 변경하였습니다");
                                }
                            }
                            break;

                        case "closeAll":
                            this.Close();
                            break;

                        case "print":
                            StartPrint();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 파일열기
        /// </summary>
        private void OpenPdfFile()
        {
            OpenFileDialog dlg = new OpenFileDialog { DefaultExt = ".pdf", Filter = "PDF files (*.pdf)|*.pdf|All files(*.*)|*.*" };

            bool? dlgResult = dlg.ShowDialog();
            if( dlgResult != true)
            {
                return;
            }
        }

        private void StartPrint()
        {
            PrintDialog dlg = new PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;

            if(dlg.ShowDialog() != true)
            {
                return;
            }

            //프린트작업 ....
        }

        /// <summary>
        /// 파일 인쇄
        /// </summary>
        /// <param name="fileName"></param>
        private void StartPrint(string fileName)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;

            bool? dlgResult = dlg.ShowDialog();
            if( dlgResult != true)
            {
                return;
            }

            FixedDocument fixedDoc;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                Document doc = new Document(fs);
                RenderSettings renderSettings = new RenderSettings();
                ConvertToWpfOptions renderOptions = new ConvertToWpfOptions { ConvertToImages = false };
                renderSettings.RenderPurpose = RenderPurpose.Print;
                renderSettings.ColorSettings.TransformationMode = ColorTransformationMode.HighQuality;
                fixedDoc = doc.ConvertToWpf(renderSettings, renderOptions);
            }

            dlg.PrintDocument(fixedDoc.DocumentPaginator, "Print");
        }

        /// <summary>
        /// 파일명 변경
        /// </summary>
        /// <param name="oldName">기존 파일명</param>
        /// <param name="newName">바꿀 파일명</param>
        private bool RenameFile(string oldName, string newName)
        {
            try
            {
                File.Move(oldName
                        , System.IO.Path.Combine(System.IO.Path.GetDirectoryName(oldName), newName) + System.IO.Path.GetExtension(oldName));
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message
                              , "Cannot rename file."
                              , MessageBoxButton.OK
                              , MessageBoxImage.Error);
                return false;
            }
        }
    }
}
