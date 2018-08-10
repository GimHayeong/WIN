using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfPhotoGallery
{
    /// <summary>
    /// WinPhotoGallery.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WinPhotoGallery : Window
    {
        /// <summary>
        /// 3배확대
        /// </summary>
        private ScaleTransform m_3XScale = new ScaleTransform(3, 3);
        private const string FILE_PATH = "myFile";
        public Photos PhotoList { get; private set; }

        public WinPhotoGallery()
        {
            InitializeComponent();

            PhotoList = new Photos();

            PhotoList.PhotoItemUpdateEvent += delegate
            {
                this.Dispatcher.Invoke(DispatcherPriority.Normal
                                     , new ThreadStart(RefreshImageViewer));
            };

            //btnDelete.Background = (Brush)this.FindResource("bgGradientBrush");
            //btnDelete.BorderBrush = (Brush)this.FindResource("borderBrush");
        }



        #region [ 컨트롤 이벤트 ]

        /// <summary>
        /// 프로그램 종료 여부 확인하여 종료할지 결정
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (MessageBox.Show("포토 갤러리 프로그램을 종료하시겠습니까?"
                             , "알림내용"
                             , MessageBoxButton.YesNo
                             , MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }

            //try
            //{
            //    if (TaskDialog(new WindowInteropHelper(this).Handle, IntPtr.Zero, "알림내용", "포토 갤러리 프로그램을 종료하시겠습니까?", "[Yes]를 클릭하면 프로그램이 종료됩니다.", TaskDialogButtons.Yes | TaskDialogButtons.No, TaskDialogIcon.Warning) == TaskDialogResult.No)
            //    {
            //        e.Cancel = true;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        /// <summary>
        /// 프로그램이 종료될때, 즐겨찾기 아이템 저장
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // 프로그램이 종료될 때마다 저장할 아이템 처리
            SaveFavoritesItem();
        }

        /// <summary>
        /// 프로그램이 시작될때, 기존의 즐겨찾기 아이템 복원
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // 프로그램이 시작될 때 개별 로드할 아이템 로드
            LoadFavoritesItem();
        }

        /// <summary>
        /// 윈도우 로드시 초기화 (트리뷰)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitFolderTreeViewItem();
        }

        /// <summary>
        /// 트리뷰가 확장될 때, 하위 아이템 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item != null && item.Items.Count == 1 && item.Items[0] == null)
            {
                item.Items.Clear();
                try
                {
                    TreeViewItem subitem;
                    foreach (var fullPath in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        subitem = new TreeViewItem();
                        subitem.Header = fullPath.Substring(fullPath.LastIndexOf(@"\") + 1);
                        subitem.Tag = fullPath;
                        subitem.Items.Add(null);
                        subitem.Expanded += TreeViewItem_Expanded;
                        item.Items.Add(subitem);
                    }
                }
                catch (UnauthorizedAccessException) { }//IO오류 또는 보안오류 등으로 OS 액세스거부
            }
        }

        /// <summary>
        /// 트리뷰의 선택폴더 변경시, PictureListBox 새로고침
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            RefreshImageViewer();
        }

        /// <summary>
        /// 선택이미지 변경시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                mnuDelete.IsEnabled = false;
                mnuRename.IsEnabled = false;
                mnuFix.IsEnabled = false;
                mnuPrint.IsEnabled = false;
                mnuEdit.IsEnabled = false;
                btnPrev.IsEnabled = false;
                btnPrev.Opacity = .5;
                btnNext.IsEnabled = false;
                btnNext.Opacity = .5;
                btnCounterClockWise.IsEnabled = false;
                btnCounterClockWise.Opacity = .5;
                btnClockWise.IsEnabled = false;
                btnClockWise.Opacity = .5;
                btnDelete.IsEnabled = false;
                btnDelete.Opacity = .5;
            }
            else
            {
                mnuDelete.IsEnabled = true;
                mnuRename.IsEnabled = true;
                mnuFix.IsEnabled = true;
                mnuPrint.IsEnabled = true;
                mnuEdit.IsEnabled = true;
                btnPrev.IsEnabled = true;
                btnPrev.Opacity = 1;
                btnNext.IsEnabled = true;
                btnNext.Opacity = 1;
                btnCounterClockWise.IsEnabled = true;
                btnCounterClockWise.Opacity = 1;
                btnClockWise.IsEnabled = true;
                btnClockWise.Opacity = 1;
                btnDelete.IsEnabled = true;
                btnDelete.Opacity = 1;
            }
        }

        /// <summary>
        /// 확대/축소 슬라이드를 변경할 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m_3XScale.ScaleX = sldZoom.Value;
            m_3XScale.ScaleY = sldZoom.Value;
        }

        /// <summary>
        /// 마우스가 확대/축소 슬라이더 팝업창을 벗어나면 슬라이더 숨기기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Popup_MouseLeave(object sender, MouseEventArgs e)
        {
            popZoom.IsOpen = false;
        }

        /// <summary>
        /// 하단 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int selectedIndex;

            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "btnBack":
                        pnlImageView.Visibility = Visibility.Hidden;
                        btnBack.Visibility = Visibility.Hidden;
                        mnuFix.IsEnabled = lbxPicture.SelectedItems.Count > 0;
                        (imgViewer.LayoutTransform as RotateTransform).Angle = 0;
                        break;

                    case "btnZoom":
                        popZoom.IsOpen = true;
                        break;

                    case "btnDefaultSize":
                        sldZoom.Value = 3;
                        break;

                    case "btnPrev":
                        selectedIndex = lbxPicture.SelectedIndex - 1;
                        if (selectedIndex < 0) selectedIndex = lbxPicture.Items.Count - 1;
                        ShowPhoto(selectedIndex);
                        break;

                    case "btnSliddShow":
                        MessageBox.Show("서비스 준비중입니다.");
                        break;

                    case "btnNext":
                        selectedIndex = lbxPicture.SelectedIndex + 1;
                        if (selectedIndex == lbxPicture.Items.Count) selectedIndex = 0;
                        ShowPhoto(selectedIndex);
                        break;

                    case "btnCounterClockWise":
                        ClockWise(-90);
                        break;

                    case "btnClockWise":
                        ClockWise(90);
                        break;

                    case "btnDelete":
                        DeletePhoto();
                        break;

                    case "btnRotateCW":
                        RotateImage(imgViewer.LayoutTransform as RotateTransform, 90);
                        break;

                    case "btnRotateCCW":
                        RotateImage(imgViewer.LayoutTransform as RotateTransform, -90);
                        break;

                    case "btnRotateSave":
                        MessageBox.Show("서비스 준비중입니다.");
                        break;
                }
            }
        }

        /// <summary>
        /// 상단 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            if (mnu != null)
            {
                switch (mnu.Name)
                {
                    case "mnuAdd":
                        UpdateFavoritesTreeViewItem();
                        break;

                    case "mnuDelete":
                        DeletePhoto();
                        break;

                    case "mnuRename":
                        RenamePhoto();
                        break;

                    case "mnuRefresh":
                        RefreshImageViewer();
                        break;

                    case "mnuExit":
                        this.Close();
                        break;

                    case "mnuFix":
                        ShowPhoto(true);
                        break;

                    case "mnuPrint":
                        PrintPhoto();
                        break;

                    case "mnuEdit":
                        EditPhoto();
                        break;
                }
            }
        }

        #endregion



        #region [ 즐겨찾기 트리뷰 아이템 초기화 / 저장 ]

        /// <summary>
        /// 디렉토리 트리뷰를 시스템의 디렉토리로 초기화
        /// </summary>
        private void InitFolderTreeViewItem()
        {
            TreeViewItem item;
            foreach (var dir in Directory.GetLogicalDrives())
            {
                item = new TreeViewItem();
                item.Header = dir;
                item.Tag = dir;
                item.Items.Add(null);
                item.Expanded += TreeViewItem_Expanded;
                trvItmFolder.Items.Add(item);
            }
        }

        /// <summary>
        /// 개별 즐겨찾기 아이템 저장
        /// </summary>
        private void SaveFavoritesItem()
        {
            IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, System.IO.FileMode.Create, isfile))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (TreeViewItem trvItm in trvItmFavorites.Items)
                    {
                        sw.WriteLine(trvItm.Tag as String);
                    }
                }
            }
        }

        /// <summary>
        /// 개별 즐겨찾기 아이템 로드
        /// </summary>
        private void LoadFavoritesItem()
        {
            IsolatedStorageFile isfile = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(FILE_PATH, FileMode.OpenOrCreate, isfile))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        AddFavoritesTreeViewItem(line);
                        line = sr.ReadLine();
                    }
                }
            }

            // 기존 즐겨찾기 목록이 없으면 MyPictures 의 이미지로 초기화
            if (!trvItmFavorites.HasItems)
            {
                AddFavoritesTreeViewItem(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            }

            (trvFolderExplorer.Items[0] as TreeViewItem).IsSelected = true;
        }

        #endregion



        #region [ 이미지 리스트박스 아이템 초기화 ]

        /// <summary>
        /// 해당 폴더의 JPEG 이미지 파일을 PictureListBox 목록에 추가
        /// </summary>
        /// <remarks>
        ///   + BitmapFrame 에 연결된 썸네일이미지가 있으면 해당 이미지 사용
        /// </remarks>
        /// <param name="folderPath"></param>
        private void AddPhotosListBox(string folderPath)
        {
            try
            {
                Photo photo;
                ListBoxItem item;
                TransformGroup tfg;
                Image img, imgTooltip;
                Uri uri;
                BitmapDecoder decoder;
                TextBlock tbkFileName, tbkFileDate;
                StackPanel pnlTooltip;
                BitmapImage bmp;

                foreach (string fileName in Directory.GetFiles(folderPath, "*.jpg"))
                {
                    photo = new Photo(fileName);
                    PhotoList.Add(photo);

                    item = new ListBoxItem();
                    item.Padding = new Thickness(3, 8, 3, 8);
                    item.MouseDoubleClick += delegate { ShowPhoto(true); };
                    tfg = new TransformGroup();
                    tfg.Children.Add(m_3XScale);
                    tfg.Children.Add(new RotateTransform());// 회전각도 초기화
                    item.LayoutTransform = tfg;
                    item.Tag = fileName;

                    img = new Image();
                    img.Height = 35;

                    uri = new Uri(fileName);
                    pnlTooltip = new StackPanel();

                    //decoder = BitmapDecoder.Create(uri, BitmapCreateOptions.DelayCreation, BitmapCacheOption.Default);
                    // 프로그램에서 이미지의 경로를 직접 사용하는 경우 이름변경이 안되므로, Cache옵션을 설정해 해결
                    decoder = BitmapDecoder.Create(uri, BitmapCreateOptions.IgnoreImageCache, BitmapCacheOption.OnLoad);

                    if (decoder.Frames[0] != null && decoder.Frames[0].Thumbnail != null)
                    {
                        // BitmapFrame 에 연결된 축소판 이미지가 있는 경우,
                        img.Source = decoder.Frames[0].Thumbnail;

                        imgTooltip = new Image();
                        imgTooltip.Source = decoder.Frames[0].Thumbnail;
                        pnlTooltip.Children.Add(imgTooltip);
                    }
                    else
                    {
                        // BitmapFrame 에 연결된 축소판 이미지가 없는 경우,
                        // 프로그램에서 이미지의 경로를 직접 사용하는 경우 이름변경이 안되므로, Cache옵션을 설정해 해결
                        bmp = GetBitmapImage(uri);

                        img.Source = bmp;// new BitmapImage(uri);
                        imgTooltip = null;
                    }

                    tbkFileName = new TextBlock();
                    tbkFileName.Text = System.IO.Path.GetFileName(fileName);
                    tbkFileDate = new TextBlock();
                    tbkFileDate.Text = photo.RegDate.ToString();

                    pnlTooltip.Children.Add(tbkFileName);
                    pnlTooltip.Children.Add(tbkFileDate);

                    item.ToolTip = pnlTooltip;
                    item.Content = img;

                    lbxPicture.Items.Add(item);
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (IOException) { }
        }

        /// <summary>
        /// 프로그램에서 이미지의 경로를 직접 사용하는 경우 이름변경이 안되므로, Cache옵션을 설정해 해결
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private BitmapImage GetBitmapImage(string filename)
        {
            return GetBitmapImage(new Uri(filename));
        }

        /// <summary>
        /// 프로그램에서 이미지의 경로를 직접 사용하는 경우 이름변경이 안되므로, Cache옵션을 설정해 해결
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private BitmapImage GetBitmapImage(Uri uri)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmp.UriSource = uri;
            bmp.EndInit();

            return bmp;
        }

        #endregion



        #region [ 상단 메뉴 ]

        #region File


        /// <summary>
        /// 해당 폴더 즐겨찾기에 추가
        /// </summary>
        /// <param name="folder"></param>
        private void AddFavoritesTreeViewItem(string folder)
        {
            TreeViewItem trvItm = new TreeViewItem();
            trvItm.Header = folder;
            trvItm.Tag = folder;

            trvItmFavorites.Items.Add(trvItm);
        }

        /// <summary>
        /// 해당 폴더 즐겨찾기에서 제거
        /// </summary>
        /// <param name="folder"></param>
        private void RemoveFavorite(string folder)
        {
            for (int i = 0; i < trvItmFavorites.Items.Count; i++)
            {
                if ((trvItmFavorites.Items[i] as TreeViewItem).Header as String == folder)
                {
                    trvItmFavorites.Items.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// 하단 버튼 활성화/비활성화
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="isEnabled"></param>
        private void EnableButton(Button btn, bool isEnabled)
        {
            if (isEnabled)
            {
                btn.IsEnabled = isEnabled;
                btn.Opacity = 1;
            }
            else
            {
                btn.IsEnabled = isEnabled;
                btn.Opacity = .5;
            }
        }

        /// <summary>
        /// 현재 선택된 폴더 즐겨찾기에 추가 / 삭제
        /// </summary>
        private void UpdateFavoritesTreeViewItem()
        {
            string folder = (trvFolderExplorer.SelectedItem as TreeViewItem).Tag as string;
            if (mnuAdd.Header as string == "즐겨찾기에 추가(_A)")
            {
                AddFavoritesTreeViewItem(folder);
                mnuAdd.Header = "즐겨찾기에서 제거(_D)";
            }
            else
            {
                RemoveFavorite(folder);
                mnuAdd.Header = "즐겨찾기에 추가(_A)";
            }
        }

        #endregion

        /// <summary>
        /// 이미지 팝업창 보이기
        /// </summary>
        /// <param name="showFixeBar">
        ///   우측의 버튼바 보이기 여부
        /// </param>
        private void ShowPhoto(bool? showFixeBar)
        {
            string fileName = (lbxPicture.SelectedItem as ListBoxItem).Tag as String;
            pnlImageView.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            imgViewer.Source = GetBitmapImage(fileName);

            if (showFixeBar == true)
            {
                pnlFixbar.Visibility = Visibility.Visible;
                mnuFix.IsEnabled = false;
            }
            else if (showFixeBar == false)
            {
                pnlFixbar.Visibility = Visibility.Collapsed;
                mnuFix.IsEnabled = true;
            }
        }

        /// <summary>
        /// 선택된 이미지 팝업보기
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void ShowPhoto(int selectedIndex)
        {
            (lbxPicture.Items[selectedIndex] as ListBoxItem).IsSelected = true;
            lbxPicture.ScrollIntoView(lbxPicture.SelectedItem);

            if (pnlImageView.Visibility == Visibility.Visible)
            {
                ShowPhoto(null);
            }
        }

        /// <summary>
        /// 선택된 이미지 인쇄
        /// </summary>
        private void PrintPhoto()
        {
            string fileName = (lbxPicture.SelectedItem as ListBoxItem).Tag as String;
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(fileName, UriKind.RelativeOrAbsolute));

            PrintDialog dlg = new PrintDialog();
            if (dlg.ShowDialog() == true)
            {
                dlg.PrintVisual(img, $"{ System.IO.Path.GetFileName(fileName)} from Photo Gallery.");
            }
        }

        /// <summary>
        /// 선택된 이미지 편집 : MSPaint 실행
        /// </summary>
        private void EditPhoto()
        {
            string fileName = (lbxPicture.SelectedItem as ListBoxItem).Tag as String;
            System.Diagnostics.Process.Start("mspaint.exe", fileName);
        }

        #endregion




        #region [ 하단 버튼 ]

        /// <summary>
        /// 선택된 이미지 회전(CW/CCW)
        /// </summary>
        /// <param name="angle">
        ///  CW: +angle
        ///  CCW: -angle
        /// </param>
        private void ClockWise(int angle)
        {
            if(lbxPicture.SelectedItem != null)
            {
                RotateTransform rotate = ((lbxPicture.SelectedItem as ListBoxItem).LayoutTransform as TransformGroup).Children[1] as RotateTransform;
                RotateImage(rotate, angle);
            }
        }

        /// <summary>
        /// 이미지 회전
        /// </summary>
        /// <param name="rotate"></param>
        /// <param name="angle">양의값: CW, 음의값: CCW</param>
        private void RotateImage(RotateTransform rotate, int angle)
        {
                rotate.Angle += angle;
        }

        /// <summary>
        /// 선택된 이미지 파일 삭제
        /// </summary>
        private void DeletePhoto()
        {
            string fileName = (lbxPicture.SelectedItem as ListBoxItem).Tag as String;
            if(MessageBox.Show("정말 삭제하시겠습니까?", "이미지 삭제 안내", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    File.Delete(fileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "파일명 변경 오류 안내", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 선택된 이미지 파일명 변경
        /// </summary>
        private void RenamePhoto()
        {
            string fileName = (lbxPicture.SelectedItem as ListBoxItem).Tag as String;
            DlgRename dlg = new DlgRename(System.IO.Path.GetFileNameWithoutExtension(fileName));
            if(dlg.ShowDialog() == true)
            {
                try
                {
                    File.Move(fileName, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fileName), dlg.NewFileName) + System.IO.Path.GetExtension(fileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message
                                  , "파일명 변경 오류 안내"
                                  , MessageBoxButton.OK
                                  , MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 현재 선택된 디렉토리폴더나 즐겨찾기 폴더의 이미지 목록으로 PictureListBox 새로고치기
        /// </summary>
        /// <remarks>
        ///   + 선택된 디렉토리폴더가 즐겨찾기에 이미 추가된 폴더이면 [즐겨찾기에서 제거] 메뉴, 아니면 [즐겨찾기에 추가] 메뉴
        /// </remarks>
        private void RefreshImageViewer()
        {
            try
            {
                this.Cursor = Cursors.Wait;

                pnlImageView.Visibility = Visibility.Hidden;
                btnBack.Visibility = Visibility.Hidden;

                lbxPicture.Items.Clear();
                PhotoList.Clear();

                if (trvFolderExplorer.SelectedItem == trvItmFavorites)
                {
                    foreach (TreeViewItem item in trvItmFavorites.Items)
                    {
                        AddPhotosListBox(item.Tag as String);
                    }
                    mnuAdd.IsEnabled = false;
                }
                else if (trvFolderExplorer.SelectedItem != trvItmFolder)
                {
                    string selectedFolder = (trvFolderExplorer.SelectedItem as TreeViewItem).Tag as String;
                    AddPhotosListBox(selectedFolder);

                    mnuAdd.IsEnabled = true;
                    foreach (TreeViewItem item in trvItmFavorites.Items)
                    {
                        if (item.Header as string == selectedFolder)
                        {
                            mnuAdd.Header = "즐겨찾기에서 제거(_D)";
                            return;
                        }
                    }
                    mnuAdd.Header = "즐겨찾기에 추가(_A)";
                }
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion


    }

    
}
