using System;
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
using System.Windows.Shapes;

namespace Wpf
{
    /// <summary>
    /// ResourceWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ResourceWindow : Window
    {

        public Photos PhotoList { get; set; }

        public ResourceWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitResource();
            InitBinding();
        }

        private void InitResource()
        {
            this.Resources.Add("bgCodeBrush", new SolidColorBrush(Colors.Khaki));
            this.Resources.Add("borderCodeBrush", new SolidColorBrush(Colors.Gold));

            int odd = 0;
            foreach(var btn in pnlBottomButton.Children)
            {
                if(btn is Button && odd++ % 2 == 1)
                {
                    ((Button)btn).Background = (Brush)this.TryFindResource("bgCodeBrush");
                    //((Button)btn).BorderBrush = (Brush)this.FindResource("borderCodeBrush");
                    ((Button)btn).SetResourceReference(Button.BorderBrushProperty, "borderCodeBrush");
                }
            }
        }

        private void InitBinding()
        {
            Binding binding = new Binding();
            binding.Source = tvwFolders;
            binding.Path = new PropertyPath("SelectedItem.Header");
            tbkCurrentFolder.SetBinding(TextBlock.TextProperty, binding);
        }

        /// <summary>
        /// BindingOperations 클래스의 SetBinding 스태틱 메서드를 이용해 바인딩
        ///  + FrameworkElement나 FrameworkContentElement 에서 파생되지 않은 객체도 데이터 바인딩 가능
        /// </summary>
        /// <param name="binding"></param>
        private void InitBindingOperations(Binding binding)
        {
            BindingOperations.SetBinding(tbkCurrentFolder, TextBlock.TextProperty, binding);
        }

        /// <summary>
        /// BindingOperations 클래스의 ClearBinding 스태틱 메서드를 이용해 바인딩 제거
        /// </summary>
        /// <param name="tbx"></param>
        private void RemoveBindingForTextBox(TextBox tbx)
        {
            BindingOperations.ClearBinding(tbx, TextBox.TextProperty);
        }

        /// <summary>
        /// BindingOperations 클래스의 ClearAllBindings 스태틱 메서드를 이용해 모든 바인딩 제거
        /// </summary>
        /// <param name="tbx"></param>
        private void RemoveAllBindingForTextBox(TextBox tbx)
        {
            BindingOperations.ClearAllBindings(tbx);
        }
    }
}
