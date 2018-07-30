using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class EventDelegateExam
    {
        /// <summary>
        /// UserDefineEvent 클래스의 OnClick 이벤트와 동일한 시그니처의 델리게이트 선언
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void ClickEvent(object sender, UserDefineEventArgs args);

        /// <summary>
        /// ClickEvent 델리게이트를 이용해 이벤트 선언
        /// </summary>
        private event ClickEvent m_Event;

        public EventDelegateExam()
        {
            UserDefineEvent obj = new UserDefineEvent();

            // 이벤트 등록
            m_Event += new ClickEvent(obj.OnClick);
        }

        public void OnUserDefineEvent(int clickCount)
        {
            if(m_Event != null)
            {
                UserDefineEventArgs args = new UserDefineEventArgs(clickCount);

                // 이벤트 호출
                m_Event(this, args);
            }
        }
    }

    class UserDefineEventArgs : EventArgs
    {
        private int m_ClickCount;
        public UserDefineEventArgs()
        {
            m_ClickCount = 0;
        }
        public UserDefineEventArgs(int clickCount)
        {
            m_ClickCount = clickCount;
        }
        public int GetClickCount()
        {
            return m_ClickCount;
        }
    }

    class UserDefineEvent
    {
        public void OnClick(object sender, UserDefineEventArgs args)
        {
            Console.WriteLine($"{sender} 개체에서 {args.GetClickCount()}번 클릭이벤트가 발생했습니다.");
        }
    }
}
