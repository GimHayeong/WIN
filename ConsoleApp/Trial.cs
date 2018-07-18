//#define TRIAL
//#define FREE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Trial
    {
#if TRIAL
        // Conditional : #define 별명 으로 정의되어 있으면 컴파일에 포함
        // OR : TRIAL 이나 FREE 둘 중 하나라도 정의되어 있으면 컴파일
        [Conditional("TRIAL"), Conditional("FREE")]
        public void TralMessage()
        {
#line 10000
            //
#line default
        }


        [Conditional("TRIAL")]
        public void TrialMessage2()
        {
#if FREE
            TrialMessage3();
#endif
        }
#endif

#if FREE
        // TrialMessage2 메서드에서 호출되는 경우
        // AND : TRIAL 과 FREE 둘 다 정의되어 있어야 컴파일
        [Conditional("FREE")]
        public void TrialMessage3()
        {

        }
#endif

        #region 폐기 또는 폐기대상
        // Obsolete: 곧 폐기될 메서드
        [Obsolete("NewMethod를 사용하시오")]
        public void OldMethod()
        {
//#warning [경고] 곧 폐기될 메서드를 사용했습니다. 컴파일을 계속됩니다.
        }

        // Obsolete: 컴파일 거부 메서드
        [Obsolete("이 메서드를 사용하지 마시오", true)]
        public void OutMethod()
        {
//#error [에러] 폐기된 메서드를 사용했습니다. 컴파일을 중단합니다.
        }
        #endregion

        // DllImport : 외부 DLL 함수 선언
        [DllImport("User32.dll")]
        public static extern int MessageBox(int hParent, string Message, string Caption, int Type);


    }
}
