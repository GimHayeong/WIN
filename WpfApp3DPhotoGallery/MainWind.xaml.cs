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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp3DPhotoGallery.ViewModel;

namespace WpfApp3DPhotoGallery
{
    /// <summary>
    /// MainWind.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWind : Window
    {
        private const string ADD_FAVORITES = "Add current folder to fa_vorites";
        private const string REMOVE_FAVORITES = "Remove current folder from fa_vorites";
        private const string ZOOM_TRANSFORM_RESKEY = "scaleTrans";
        private const int DEFAULT_ZOOM = 3;
        private ScaleTransform m_scaleTrans = null;
        private object m_dummyNode = null;
        private Photos m_photos = new Photos();
        private string CurrentPhotoFileName
        {
            get
            {
                return (lbxPicture.SelectedItem as Photo).FullPath;
            }
        }
        public MainWind()
        {
            InitializeComponent();

            InitPhotoGallery();
        }

        private void InitPhotoGallery()
        {
            this.DataContext = m_photos;

            m_photos.ItemsUpdated += delegate
            {
                this.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(Refresh));
            };
        }

        /// <summary>
        /// 프로그램 시작시 즐겨찾기 목록 파일에서 불러와 초기화
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("myFile", FileMode.OpenOrCreate, file))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (reader.Peek() > -1)
                    {
                        AddFavorite(reader.ReadLine());
                    }
                }
            }

            if (!trvFavoriteData.HasItems)
            {
                AddFavorite(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            }

            (trvFavoriteData.Items[0] as TreeViewItem).IsSelected = true;
        }

        /// <summary>
        /// 프로그램 시작시 로컬 드라이버 목록 불러와 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(string dir in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = dir;
                item.Tag = dir;
                item.Items.Add(m_dummyNode);
                item.Expanded += FolderTreeViewItem_Expanded;
                trvFolderData.Items.Add(item);
            }
        }

        /// <summary>
        /// 프로그램 종료 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if(MessageBox.Show("Are you sure you want to close Photo Gallery?"
                             , "Annoying Prompt"
                             , MessageBoxButton.YesNo
                             , MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 프로그램 종료시 즐겨찾기 목록 파일로 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForAssembly();
            using(IsolatedStorageFileStream stream = new IsolatedStorageFileStream("myFile", System.IO.FileMode.Create, file))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach(TreeViewItem item in trvFavoriteData.Items)
                    {
                        writer.WriteLine(item.Tag as string);
                    }
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            if(mnu != null)
            {
                switch (mnu.Name)
                {
                    case "mnuFavorites":
                        SetFavoritesMenu();
                        break;

                    case "mnuDelete":
                        DeleteCurrentPhoto();
                        break;

                    case "mnuRename":
                        RenameCurrentPhoto();
                        break;

                    case "mnuRefresh":
                        Refresh();
                        break;

                    case "mnuExit":
                        this.Close();
                        break;

                    case "mnuFix":
                        ShowCurrentPhoto(true);
                        break;

                    case "mnuPrint":
                        PrintCurrentPhoto();
                        break;

                    case "mnuEdit":
                        EditCurrentPhoto();
                        break;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            dpnlImageViewer.Visibility = Visibility.Hidden;
            btnBack.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// 트리뷰아이템을 확장할 때 하위 트리뷰아이템을 조회하지 않은 경우, 조회하여 하위 트리뷰아이템 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderTreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item != null && item.Items.Count == 1 && item.Items[0] == m_dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (string dir in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subItem = new TreeViewItem();
                        subItem.Header = dir.Substring(dir.LastIndexOf("\\") + 1);
                        subItem.Tag = dir;
                        subItem.Items.Add(m_dummyNode);
                        subItem.Expanded += FolderTreeViewItem_Expanded;
                        item.Items.Add(subItem);
                    }
                }
                catch (UnauthorizedAccessException) { }
            }
        }

        private void FolderTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Refresh();
        }

        private void PictureListBox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowCurrentPhoto(false);
        }

        /// <summary>
        /// 이미지 리스트박스 선택시, 항목 유무에 따라 활성화/비활성화 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isEnabled = false;
            double opacity = 0.5;

            if(e.AddedItems.Count > 0)
            {
                isEnabled = true;
                opacity = 1.0;
            }

            mnuDelete.IsEnabled = mnuRename.IsEnabled = mnuFix.IsEnabled = mnuPrint.IsEnabled = mnuEdit.IsEnabled = isEnabled;
            btnPrevious.IsEnabled = btnNext.IsEnabled = btnCounterclockwise.IsEnabled = btnClockwise.IsEnabled = btnDelete.IsEnabled = isEnabled;
            btnPrevious.Opacity = btnNext.Opacity = btnCounterclockwise.Opacity = btnClockwise.Opacity = btnDelete.Opacity = opacity;
        }

        private void FixBarButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnFixbarClockwise":
                        (imgPicture.LayoutTransform as RotateTransform).Angle += 90;
                        break;

                    case "btnFixbarCounterclockwise":
                        (imgPicture.LayoutTransform as RotateTransform).Angle -= 90;
                        break;

                    case "btnSave":
                        break;
                }
            }
        }

        private void BottomButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnZoom":
                        popZoom.IsOpen = true;
                        break;

                    case "btnDefaultSize":
                        sldZoom.Value = DEFAULT_ZOOM;
                        break;

                    case "btnPrevious":
                        ShowPreviousPhoto();
                        break;

                    case "btnSlidShow":
                        break;

                    case "btnNext":
                        ShowNextPhoto();
                        break;

                    case "btnClockwise":
                        RotateCurrentPhoto(90);
                        break;

                    case "btnCounterclockwise":
                        RotateCurrentPhoto(-90);
                        break;

                    case "btnDelete":
                        DeleteCurrentPhoto();
                        break;
                }
            }
        }

        

        private void ZoomPopup_MouseLeave(object sender, MouseEventArgs e)
        {
            popZoom.IsOpen = false;
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(m_scaleTrans == null)
            {
                m_scaleTrans = (ScaleTransform)FindResource(ZOOM_TRANSFORM_RESKEY);
            }

            m_scaleTrans.ScaleX = m_scaleTrans.ScaleY = sldZoom.Value;
        }

        private void AddFavorite(string favorite)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = favorite;
            item.Tag = favorite;
            trvFavoriteData.Items.Add(item);
        }

        private void AddPhotosInFolder(string folder)
        {
            try
            {
                foreach (string fileName in Directory.GetFiles(folder, "*.jpg"))
                {
                    m_photos.Add(new Photo(fileName));
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (IOException) { }
        }

        private void RemoveFavoriteTreeViewItem(string favorite)
        {
            for(int i=0; i<trvFavoriteData.Items.Count; i++)
            {
                if((trvFavoriteData.Items[i] as TreeViewItem).Header as string == favorite)
                {
                    trvFavoriteData.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void Refresh()
        {
            try
            {
                this.Cursor = Cursors.Wait;

                dpnlImageViewer.Visibility = Visibility.Hidden;
                btnBack.Visibility = Visibility.Hidden;

                m_photos.Clear();

                if(trvRootData.SelectedItem == trvFavoriteData)
                {
                    foreach(TreeViewItem item in trvFavoriteData.Items)
                    {
                        AddPhotosInFolder(item.Tag as string);
                    }
                    mnuFavorites.IsEnabled = false;
                }
                else if(trvRootData.SelectedItem != trvFolderData)
                {
                    string folder = (trvRootData.SelectedItem as TreeViewItem).Tag as string;
                    AddPhotosInFolder(folder);

                    mnuFavorites.IsEnabled = true;

                    foreach(TreeViewItem item in trvFavoriteData.Items)
                    {
                        if (item.Header as string == folder)
                        {
                            mnuFavorites.Header = REMOVE_FAVORITES;
                            return;
                        }
                    }
                    mnuFavorites.Header = ADD_FAVORITES;
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// 즐겨찾기에 추가/제거
        /// </summary>
        private void SetFavoritesMenu()
        {
            string folder = (trvRootData.SelectedItem as TreeViewItem).Tag as string;
            if(folder != null)
            {
                if(mnuFavorites.Header as string == ADD_FAVORITES)
                {
                    AddFavorite(folder);
                    mnuFavorites.Header = REMOVE_FAVORITES;
                }
                else
                {
                    RemoveFavoriteTreeViewItem(folder);
                    mnuFavorites.Header = ADD_FAVORITES;
                }
            }
        }

        private void RotateCurrentPhoto(int angle)
        {
            if(lbxPicture.SelectedItem != null)
            {
                ListBoxItem item = lbxPicture.ItemContainerGenerator.ContainerFromItem(lbxPicture.SelectedItem) as ListBoxItem;

                if(item.LayoutTransform as RotateTransform == null) { item.LayoutTransform = new RotateTransform(); }

                (item.LayoutTransform as RotateTransform).Angle += angle;
            }
        }

        private void DeleteCurrentPhoto()
        {
            if (MessageBox.Show($"Are you sure you want to delete {CurrentPhotoFileName}?"
                                          , "Delete Picture"
                                          , MessageBoxButton.YesNo
                                          , MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    File.Delete(CurrentPhotoFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message
                                  , "Cannot delete file"
                                  , MessageBoxButton.OK
                                  , MessageBoxImage.Error);
                }
            }
        }


        private void RenameCurrentPhoto()
        {
            string fileName = (lbxPicture.SelectedItem as Photo).FullPath;
            RenameDialog dlg = new RenameDialog(System.IO.Path.GetFileNameWithoutExtension(fileName));
            if(dlg.ShowDialog() == true)
            {
                try
                {
                    File.Move(fileName
                            , System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fileName), dlg.NewFileName) + System.IO.Path.GetExtension(fileName));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot rename file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ShowPreviousPhoto()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(m_photos);
            view.MoveCurrentToPrevious();

            if(view.IsCurrentBeforeFirst) { view.MoveCurrentToLast(); }

            if(dpnlImageViewer.Visibility == Visibility.Visible) { ShowCurrentPhoto(null); }
        }

        private void ShowNextPhoto()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(m_photos);
            view.MoveCurrentToNext();

            if(view.IsCurrentAfterLast) { view.MoveCurrentToFirst(); }

            if(dpnlImageViewer.Visibility == Visibility.Visible) { ShowCurrentPhoto(null); }
        }

        private void ShowCurrentPhoto(bool? showFixBar)
        {
            imgPicture.Source = new BitmapImage(new Uri(CurrentPhotoFileName));

            dpnlImageViewer.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;

            if(showFixBar == true)
            {
                spnlFixBar.Visibility = Visibility.Visible;
            }
            else if(showFixBar == false)
            {
                spnlFixBar.Visibility = Visibility.Collapsed;
            }
        }

        private void PrintCurrentPhoto()
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(CurrentPhotoFileName, UriKind.RelativeOrAbsolute));

            PrintDialog dlg = new PrintDialog();
            if(dlg.ShowDialog() == true)
            {
                dlg.PrintVisual(img
                               , $"{System.IO.Path.GetFileName(CurrentPhotoFileName)} from Photo Gallery");
            }
        }

        private void EditCurrentPhoto()
        {
            System.Diagnostics.Process.Start("mspaint.exe", CurrentPhotoFileName);
        }

    }
}
