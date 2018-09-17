using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAppPhotoCooperative
{
    public class RubberbandAdorner : Adorner
    {
        private const int MIN_SIZE = 3;

        public MainWindow Windows { get; set; }
        public Path Rubberband { get; set; }
        public Rect SelectRect { get { return m_selectRect; } }
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        private Rect m_selectRect;
        /// <summary>
        /// 사각형 선택영역
        /// </summary>
        private RectangleGeometry m_geometry;
        /// <summary>
        /// 선택영역
        /// </summary>
        private UIElement m_adornedElement;
        /// <summary>
        /// 선택영역 시작점
        /// </summary>
        private Point m_anchorPoint;

        public RubberbandAdorner(UIElement adornedElement) : base(adornedElement)
        {
            m_adornedElement = adornedElement;
            m_selectRect = new Rect();
            m_geometry = new RectangleGeometry();

            Rubberband = new Path();
            Rubberband.Data = m_geometry;
            Rubberband.StrokeThickness = 2;
            Rubberband.Stroke = Brushes.Yellow;
            Rubberband.Opacity = .6;
            Rubberband.Visibility = Visibility.Hidden;

            AddVisualChild(Rubberband);

            MouseMove += Rubberband_MouseDown;
            MouseUp += Rubberband_MouseUp;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size size = base.ArrangeOverride(finalSize);
            ((UIElement)GetVisualChild(0)).Arrange(new Rect(new Point(), size));
            return size;
        }

        /// <summary>
        /// 자식은 인덱스에 상관없이 Rubberband
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Visual GetVisualChild(int index)
        {
            return Rubberband;
        }

        /// <summary>
        /// 마우스를 눌렀을 때, 선택영역 설정 시작
        /// </summary>
        /// <param name="anchorPoint"></param>
        public void StartSelection(Point anchorPoint)
        {
            m_anchorPoint = anchorPoint;
            m_selectRect.Size = new Size(10, 10);
            m_selectRect.Location = anchorPoint;
            m_geometry.Rect = m_selectRect;

            if(Visibility.Visible != Rubberband.Visibility) { Rubberband.Visibility = Visibility.Visible; }
        }

        /// <summary>
        /// 마우스를 드래그할 때, 선택영역 설정 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rubberband_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Point ptPos = e.GetPosition(m_adornedElement);

                m_selectRect.X = (ptPos.X < m_anchorPoint.X) ? ptPos.X : m_anchorPoint.X;
                m_selectRect.Y = (ptPos.Y < m_anchorPoint.Y) ? ptPos.Y : m_anchorPoint.Y;
                m_selectRect.Width = Math.Abs(ptPos.X - m_anchorPoint.X);
                m_selectRect.Height = Math.Abs(ptPos.Y - m_anchorPoint.Y);

                m_geometry.Rect = m_selectRect;

                AdornerLayer layer = AdornerLayer.GetAdornerLayer(m_adornedElement);
                m_adornedElement.InvalidateArrange();
            }
        }

        /// <summary>
        /// 마우스를 뗄 때, 선택영역 설정 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rubberband_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(m_selectRect.Width <= MIN_SIZE || m_selectRect.Height <= MIN_SIZE)
            {
                Rubberband.Visibility = Visibility.Hidden;
            }
            else
            {
                Windows.btnCrop.IsEnabled = true;
            }

            ReleaseMouseCapture();
        }

    }
}
