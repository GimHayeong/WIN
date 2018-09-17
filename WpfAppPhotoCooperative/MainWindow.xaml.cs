using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppPhotoCooperative.BLL;

namespace WpfAppPhotoCooperative
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public PhotoList m_photos;
        public PrintList m_shoppingCart;
        private Stack m_undoStack;
        private RubberbandAdorner m_cropSelector;

        public MainWindow()
        {
            InitializeComponent();

            InitData();
        }

        /// <summary>
        /// 데이터 초기화 및 UNDO 스택초기화
        /// </summary>
        private void InitData()
        {
            ObjectDataProvider dataProvider = this.Resources["Photos"] as ObjectDataProvider;

            PhotoList photoList = dataProvider.Data as PhotoList;
            m_photos = photoList;
            m_photos.Path = @"../../Photos";

            m_undoStack = new Stack();

            dataProvider = this.Resources["ShoppingCart"] as ObjectDataProvider;
            PrintList printList = dataProvider.Data as PrintList;
            m_shoppingCart = printList;
        }

        private void PhotoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string path = (sender as ListBox).SelectedItem.ToString();
            BitmapSource img = BitmapFrame.Create(new Uri(path));
            CurrentPhoto.Source = img;

            ClearUndoStack();
            if(m_cropSelector != null)
            {
                if(Visibility.Visible == m_cropSelector.Rubberband.Visibility)
                {
                    m_cropSelector.Rubberband.Visibility = Visibility.Hidden;
                }
            }
            btnCrop.IsEnabled = false;
        }

        private void ClearUndoStack()
        {
            if(m_undoStack != null) m_undoStack.Clear();
        }

        private void CurrentPhotoImage_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point ptAnchor = e.GetPosition(CurrentPhoto);
            m_cropSelector.CaptureMouse();
            m_cropSelector.StartSelection(ptAnchor);
            btnCrop.IsEnabled = true;
        }

        /// <summary>
        /// 선택 영영에서 사용할 고무밴드 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(CurrentPhoto);
            m_cropSelector = new RubberbandAdorner(CurrentPhoto);
            m_cropSelector.Windows = this;
            layer.Add(m_cropSelector);
            m_cropSelector.Rubberband.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Crop 버튼을 클릭하면 선택한 고무밴드 영역부분을 제외하고 이미지 자르기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CropButton_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentPhoto.Source != null)
            {
                BitmapSource img = (BitmapSource)CurrentPhoto.Source;
                m_undoStack.Push(img);
                Int32Rect rect = new Int32Rect();
                rect.X = (int)(m_cropSelector.SelectRect.X * img.PixelWidth / CurrentPhoto.ActualWidth);
                rect.Y = (int)(m_cropSelector.SelectRect.Y * img.PixelHeight / CurrentPhoto.ActualHeight);
                rect.Width = (int)(m_cropSelector.SelectRect.Width * img.PixelWidth / CurrentPhoto.ActualWidth);
                rect.Height = (int)(m_cropSelector.SelectRect.Height * img.PixelHeight / CurrentPhoto.ActualHeight);
                CurrentPhoto.Source = new CroppedBitmap(img, rect);
                m_cropSelector.Rubberband.Visibility = Visibility.Hidden;
                btnCrop.IsEnabled = false;
            }
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if(m_undoStack.Count > 0)
            {
                CurrentPhoto.Source = (BitmapSource)m_undoStack.Pop();
            }

            if (m_undoStack.Count == 0) btnUndo.IsEnabled = false;
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if(PrintTypeComboBox.SelectedItem != null)
            {
                PrintBase item;
                switch (PrintTypeComboBox.SelectedIndex)
                {
                    case 0:
                        item = new Print(CurrentPhoto.Source as BitmapSource);
                        break;

                    case 1:
                        item = new GreetingCard(CurrentPhoto.Source as BitmapSource);
                        break;

                    case 2:
                        item = new SShirt(CurrentPhoto.Source as BitmapSource);
                        break;

                    default:
                        return;
                }

                m_shoppingCart.Add(item);
                ShoppingCartListBox.ScrollIntoView(item);
                ShoppingCartListBox.SelectedItem = item;
                if(btnCheckout.IsEnabled == false)
                {
                    btnCheckout.IsEnabled = true;
                }

                if (btnRemoveItem.IsEnabled == false)
                {
                    btnRemoveItem.IsEnabled = true;
                }
            }
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            if(ShoppingCartListBox.SelectedItem != null)
            {
                PrintBase item = ShoppingCartListBox.SelectedItem as PrintBase;
                m_shoppingCart.Remove(item);
                ShoppingCartListBox.SelectedIndex = m_shoppingCart.Count - 1;
            }

            if(m_shoppingCart.Count == 0)
            {
                btnRemoveItem.IsEnabled = false;
                btnCheckout.IsEnabled = false;
            }
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            if(m_shoppingCart.Count > 0)
            {
                CheckoutWindow wnd = new CheckoutWindow();
                wnd.ShoppingCart = m_shoppingCart;
                wnd.Show();
                this.Hide();
            }
        }
    }
}
