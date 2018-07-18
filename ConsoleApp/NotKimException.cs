using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // 사용자 정의 예외 : ApplicationExceptiion 을 상속받아 구현
    class NotKimException : ApplicationException
    {
        // 예외에 대한 추가적인 멤버 정의 가능
        public string ErrorName { get; set; }
        public NotKimException(string message) : base(message)
        {
            //
        }
    }

    class UserDefinedExceptionTest
    {
        private void AddKim(string name)
        {
            if(name[0] != '김')
            {
                NotKimException ex = new NotKimException("김씨만 등록가능");
                ex.HelpLink = "김씨 동호회 규약.txt";
                ex.Source = "UserDefinedExceptionTest.cs";
                ex.ErrorName = name;

                throw ex;
            }

            Console.WriteLine("{0} 등록완료", name);
        }

        public void MainTest()
        {
            try
            {
                AddKim("김서방");
                AddKim("오서방");
            } catch (NotKimException ex)
            {
                Console.WriteLine("{0}: {1}씨는 등록안됨", ex.Message, ex.ErrorName[0]);
            }
        }

        
    }
}
