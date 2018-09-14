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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppPhotoGalleryDataBinding
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ADD_FAVORITES = "Add current folder to fa_vorites";
        private const string REMOVE_FAVORITE = "Remove current folder from fa_vorites";
        private const string ZOOM_TRANSFORM_RESKEY = "scaleTrans";
        private const int DEFAULT_ZOOM = 3;
        private ScaleTransform m_scaleTrans = null;
        private object m_dummyNode = null;
        private Photos m_photos = new Photos();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = m_photos;
            m_photos.ItemsUpdated += delegate { this.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(Refresh)); };

            GroupHelper("DateTime");
            //==>코드바인딩: UpdateCurrentFolderTextByBinding();
        }

        /// <summary>
        /// 프로그램 시작시, 저장된 즐겨찾기 목록이 있으면 조회하여 TreeView에 추가하고, 
        /// 즐겨찾기 목록이 없으면 MyPictures 를 TreeView의 즐겨찾기 항목으로 추가
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
        /// 프로그램 시작시, 하드디스크의 드라이브 목록 조회하여 TreeView에 추가
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
                item.Expanded += Folder_Expanded;
                trvFolderData.Items.Add(item);
            }
        }

        /// <summary>
        /// TreeViewItem 을 확장할 때, 포함된 하위 폴더가 있고 TreeView에 추가되지 않은 경우 TreeView에 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if(item != null && item.Items.Count == 1 && item.Items[0] == m_dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach(string dir in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = dir.Substring(dir.LastIndexOf("\\") + 1);
                        subitem.Tag = dir;
                        subitem.Items.Add(m_dummyNode);
                        subitem.Expanded += Folder_Expanded;
                        item.Items.Add(subitem);
                    }
                }
                catch (UnauthorizedAccessException) { }
            }
        }

        /// <summary>
        /// 프로그램 전 종료여부 확인
        /// </summary>
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
        /// 프로그램 종료시 즐겨찾기 저장
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForAssembly();
            using(IsolatedStorageFileStream stream = new IsolatedStorageFileStream("myFile", System.IO.FileMode.Create, file))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    foreach(TreeViewItem item in trvFavoriteData.Items)
                    {
                        writer.WriteLine(item.Tag as string);
                    }
                }
            }
        }

        /// <summary>
        /// 즐겨찾기에 추가/제거 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FavoritesMenu_Click(object sender, RoutedEventArgs e)
        {
            string folder = (trvRootData.SelectedItem as TreeViewItem).Tag as string;
            if(mnuFavorites.Header as string == ADD_FAVORITES)
            {
                AddFavorite(folder);
                mnuFavorites.Header = REMOVE_FAVORITE;
            }
            else
            {
                RemoveFavorite(folder);
                mnuFavorites.Header = ADD_FAVORITES;
            }
        }

        /// <summary>
        /// 이미지 파일 삭제 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            DeleteCurrentPhoto();
        }

        /// <summary>
        /// 이미지 파일이름 바꾸기 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameMenu_Click(object sender, RoutedEventArgs e)
        {
            string fileName = (lbxPicture.SelectedItem as Photo).FullPath;
            RenameDialog dlg = new RenameDialog(System.IO.Path.GetFileNameWithoutExtension(fileName));
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    File.Move(fileName
                            , System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fileName), dlg.NewFileName) + System.IO.Path.GetExtension(fileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot remane file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 이름, 날짜, 파일크기 기준 정렬 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if(item != null)
            {
                SortHelper(item.Header.ToString());
            }
        }

        

        /// <summary>
        /// 새로고침 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshMenu_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// 종료 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 선택된 이미지 팝업창으로 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowPhoto(true);
        }

        /// <summary>
        /// 선택된 이미지 인쇄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintMenu_Click(object sender, RoutedEventArgs e)
        {
            string fileName = (lbxPicture.SelectedItem as Photo).FullPath;
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(fileName, UriKind.RelativeOrAbsolute));

            PrintDialog dlg = new PrintDialog();
            if(dlg.ShowDialog() == true)
            {
                dlg.PrintVisual(img
                              , $"{System.IO.Path.GetFileName(fileName)} from Photo Gallery");
            }
        }

        /// <summary>
        /// 편집 메뉴 클릭 (그림판으로 해당 이미지 열기)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditMenu_Click(object sender, RoutedEventArgs e)
        {
            string fileName = (lbxPicture.SelectedItem as Photo).FullPath;
            System.Diagnostics.Process.Start("mspaint.exe", fileName);
        }


        /// <summary>
        /// 기본사이즈 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultSizeButton_Click(object sender, RoutedEventArgs e)
        {
            sldZoom.Value = DEFAULT_ZOOM;
        }

        /// <summary>
        /// 팝업창에서 기본 화면으로 돌아가기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            dpnlImageView.Visibility = Visibility.Hidden;
            btnBack.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// 확대/축소버튼 클릭시 슬라이더바 팝업창 보이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomButton_Click(object sender, RoutedEventArgs e)
        {
            popZoom.IsOpen = true;
        }

        /// <summary>
        /// 슬라이드쇼 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlideshowButton_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        /// <summary>
        /// 선택이미지 시계방향 회전 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClockwiseButton_Click(object sender, RoutedEventArgs e)
        {
            if(lbxPicture.SelectedItem != null)
            {
                ListBoxItem item = lbxPicture.ItemContainerGenerator.ContainerFromItem(lbxPicture.SelectedItem) as ListBoxItem;

                if(item.LayoutTransform as RotateTransform == null) { item.LayoutTransform = new RotateTransform(); }

                (item.LayoutTransform as RotateTransform).Angle += 90;
            }
        }

        /// <summary>
        /// 선택이미지 반시계방향 회전 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountclockwiseButton_Click(object sender, RoutedEventArgs e)
        {
            if(lbxPicture.SelectedItem != null)
            {
                ListBoxItem item = lbxPicture.ItemContainerGenerator.ContainerFromItem(lbxPicture.SelectedItem) as ListBoxItem;

                if(item.LayoutTransform as RotateTransform == null) { item.LayoutTransform = new RotateTransform(); }

                (item.LayoutTransform as RotateTransform).Angle -= 90;
            }
        }

        /// <summary>
        /// 삭제버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteCurrentPhoto();
        }

        /// <summary>
        /// 이전 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(m_photos);

            view.MoveCurrentToPrevious();

            if(view.IsCurrentBeforeFirst) { view.MoveCurrentToLast(); }

            if(dpnlImageView.Visibility == Visibility.Visible) { ShowPhoto(null); }
        }

        /// <summary>
        /// 다음 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(m_photos);

            view.MoveCurrentToNext();

            if(view.IsCurrentAfterLast) { view.MoveCurrentToFirst(); }

            if(dpnlImageView.Visibility == Visibility.Visible) { ShowPhoto(null); }
        }


        /// <summary>
        /// FixBar의 시계방향 회전 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixBarRotateClockwiseButton_Click(object sender, RoutedEventArgs e)
        {
            (imgPopup.LayoutTransform as RotateTransform).Angle += 90;
        }

        /// <summary>
        /// FixBar의 반시계방향 회전 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixBarCounterclockwiseButton_Click(object sender, RoutedEventArgs e)
        {
            (imgPopup.LayoutTransform as RotateTransform).Angle -= 90;
        }

        /// <summary>
        /// FixBar의 저장 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixBarSaveButton_Click(object sender, RoutedEventArgs e)
        {
            //
        }


        /// <summary>
        /// 마우스가 확대/축소 슬라이더 영역을 벗어나면 슬라이더 팝업 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomPopup_MouseLeave(object sender, MouseEventArgs e)
        {
            popZoom.IsOpen = false;
        }

        /// <summary>
        /// 확대/축소 슬라이더값 변경시, 가로:세로 같은 비율로 확대/축소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomSlider_ValueChanged(object sender, RoutedEventArgs e)
        {
            if(m_scaleTrans == null)
            {
                m_scaleTrans = (ScaleTransform)FindResource(ZOOM_TRANSFORM_RESKEY);
            }

            m_scaleTrans.ScaleX = m_scaleTrans.ScaleY = sldZoom.Value;
        }



        /// <summary>
        /// 이미지 목록의 아이템을 더블클릭하면 팝업창으로 해당 이미지를 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureListBox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowPhoto(false);
        }

        /// <summary>
        /// 이미지 목록의 선택항목 변경시, 선택항목의 존재여부에 따라 메뉴와 버튼 설정을 달리함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isEnabled = false;
            double opacity = 0.5;

            if (e.AddedItems.Count != 0)
            {
                isEnabled = true;
                opacity = 1;
            }

            mnuDelete.IsEnabled = isEnabled;
            mnuRename.IsEnabled = isEnabled;
            mnuFix.IsEnabled = isEnabled;
            mnuPrint.IsEnabled = isEnabled;
            mnuEdit.IsEnabled = isEnabled;
            btnPrevious.IsEnabled = isEnabled;
            btnPrevious.Opacity = opacity;
            btnNext.IsEnabled = isEnabled;
            btnNext.Opacity = opacity;
            btnCounterclockwise.IsEnabled = isEnabled;
            btnCounterclockwise.Opacity = opacity;
            btnClockwise.IsEnabled = isEnabled;
            btnClockwise.Opacity = opacity;
            btnDelete.IsEnabled = isEnabled;
            btnDelete.Opacity = opacity;
        }

        /// <summary>
        /// 트리뷰아이템 선택시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //UpdateCurrentFolderText((trvRootData.SelectedItem as TreeViewItem).Tag.ToString());
            Refresh();
        }

        #region [ 바인딩 관련 ... ]
        /// <summary>
        /// 현재위치 정보 업데이트 바인딩 설정
        ///  : FrameworkElement나 FrameworkContentElement에서 상속받은 바인딩 대상 객체의 SetBinding 인스턴스 메소드 호출
        /// </summary>
        /// <remarks>
        ///  Text = "{Binding ElementName=trvRootData, Path=SelectedItem.Tag}"
        ///  Text = "{Binding SelectedItem.Tag, ElementName=trvRootData}"
        ///  Text = "{Binding Source={StaticResource 리소스키}, Path=SelectedItem.Tag}"
        /// </remarks>
        private void UpdateCurrentFolderTextByBinding()
        {
            Binding binding = new Binding();
            binding.Source = trvRootData;
            binding.Path = new PropertyPath("SelectedItem.Tag");
            
            tbkCurrentFolder.SetBinding(TextBlock.TextProperty, binding);
        }

        /// <summary>
        /// 현재위치 정보 업데이트 바인딩 설정
        ///  : BindingOperations 클래스의 바인딩 대상 객체를 인수로 가지는 SetBinding 스태틱 메서드 호출
        /// </summary>
        /// <remarks>
        ///  Text = "{Binding ElementName=trvRootData, Path=SelectedItem.Tag}"
        /// </remarks>
        private void UpdateCurrentFolderTextByBindingOptions()
        {
            Binding binding = new Binding();
            binding.Source = trvRootData;
            binding.Path = new PropertyPath("SelectedItem.Tag");

            BindingOperations.SetBinding(tbkCurrentFolder, TextBlock.TextProperty, binding);
        }

        /// <summary>
        /// 대상 객체의 바인딩 제거
        /// </summary>
        private void ClearBindingByBindingOptions()
        {
            BindingOperations.ClearBinding(tbkCurrentFolder, TextBlock.TextProperty);
        }

        /// <summary>
        /// 대상 객체의 바인딩 대상 속성에 새로운 값을 설정해 바인딩 제거
        /// </summary>
        private void ClearBindingBySetValue()
        {
            tbkCurrentFolder.Text = "";
        }

        /// <summary>
        /// 대상 객체의 다중 바인딩 제거
        /// </summary>
        private void ClearAllBindingsByBindingOptions()
        {
            BindingOperations.ClearAllBindings(tbkCurrentFolder);
        }

        /// <summary>
        /// 현재위치 정보 업데이트
        /// </summary>
        /// <remarks>
        ///  Text = "{Binding ElementName=trvRootData, Path=SelectedItem.Tag}"
        /// </remarks>
        /// <param name="dir"></param>
        private void UpdateCurrentFolderText(string dir)
        {
            tbkCurrentFolder.Text = $"현재위치: {dir}";
        }

        #endregion


        /// <summary>
        /// 즐겨찾기에 추가
        /// </summary>
        /// <param name="folder"></param>
        private void AddFavorite(string folder)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = folder;
            item.Tag = folder;
            trvFavoriteData.Items.Add(item);
        }

        /// <summary>
        /// 즐겨찾기에서 제거
        /// </summary>
        /// <param name="folder"></param>
        private void RemoveFavorite(string folder)
        {
            for(int i=0; i<trvFavoriteData.Items.Count; i++)
            {
                if((trvFavoriteData.Items[i] as TreeViewItem).Header as string == folder)
                {
                    trvFavoriteData.Items.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// 정렬 (내림차순/오름차순 토글)
        /// </summary>
        /// <remarks>
        ///  ICollectionView.SortDescriptions.Clear() : 기본 정렬된 뷰 반환
        /// </remarks>
        /// <param name="sortPropertyName">Name | Date | Size</param>
        private void SortHelper(string sortPropertyName)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(m_photos);

            if(view.SortDescriptions.Count > 0 && view.SortDescriptions[0].PropertyName == sortPropertyName && view.SortDescriptions[0].Direction == ListSortDirection.Ascending)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(sortPropertyName, ListSortDirection.Descending));
            }else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(sortPropertyName, ListSortDirection.Ascending));
            }
        }

        /// <summary>
        /// 그룹핑
        /// </summary>
        /// <param name="groupPropertyName">그룹핑대상 속성</param>
        private void GroupHelper(string groupPropertyName)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(m_photos);

            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(new PropertyGroupDescription(groupPropertyName
                                                                  , new DateTimeToDateConverter()));
        }

        /// <summary>
        /// 필터설정
        /// </summary>
        private void FilterHelper()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(m_photos);

            view.Filter = delegate (object o)
            {
                return ((o as Photo).DateTime - DateTime.Now).Days <= 7;
            };
        }

        /// <summary>
        /// 필터제거
        /// </summary>
        private void ClearFilter()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(m_photos);
            view.Filter = null;
        }

        /// <summary>
        /// 이미지 데이터소스에 현재 폴더의 이미지 추가
        /// </summary>
        /// <param name="folder"></param>
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

        /// <summary>
        /// 이미지 리스트 새로 고침
        /// </summary>
        private void Refresh()
        {
            try
            {
                this.Cursor = Cursors.Wait;

                dpnlImageView.Visibility = Visibility.Hidden;
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
                        if(item.Header as string == folder)
                        {
                            mnuFavorites.Header = REMOVE_FAVORITE;
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
        /// 팝업창으로 이미지 목록의 선택항목의 이미지 보여주기
        /// </summary>
        /// <param name="showFixBar">팝업의 메뉴 보이기 여부</param>
        private void ShowPhoto(bool? showFixBar)
        {
            string fileName = (lbxPicture.SelectedItem as Photo).FullPath;
            dpnlImageView.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;

            imgPopup.Source = new BitmapImage(new Uri(fileName));
            if (showFixBar == true)
            {
                spnlFixBar.Visibility = Visibility.Visible;
            }
            else
            {
                spnlFixBar.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 선택 이미지 삭제
        /// </summary>
        private void DeleteCurrentPhoto()
        {
            string fileName = (lbxPicture.SelectedItem as Photo).FullPath;

            if(MessageBox.Show($"Are you sure you want to delete {fileName}?"
                              , "Delete Picture", MessageBoxButton.YesNo
                              , MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    File.Delete(fileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message
                                  , "Cannot delete file"
                                  , MessageBoxButton.OK
                                  , MessageBoxImage.Error);
                }
            }
        }
    }
}
