using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp
{
    // 지연실행 : query문은 결과셋을 얻기 위한 질문 내용만 저장되므로, query 이후에 배열의 요소가 변경되면 순회(실행)할 때 수정된 배열의 요소가 읽힘
    // 즉시실행 : Count, Sum, Average 등은 단일 값을 가지므로 지연실행하지 않고 즉시 실행된다. ToList나 ToArray 메서드를 호출시 query문 즉시실행.
    // JOIN : join 결과셋 중 출력대상을 지정하기 위해 쿼리문 마지막에 select 문이나 group by 절이 끝에 와야 함. 내부조인이고 동등조인. 다른 데이터소스도 조인 가능.
    // 프로젝션 : 결과셋의 출력 형태를 데이터 소스와 다르게 변형하는 것.

    class LINQExam
    {
        void MainLinq()
        {
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //IEnumerable<int> query = from n in ar
            //                         where (n % 3 == 0)
            //                         select n;

            var query = from n in ar
                        where (n % 3 == 0)
                        select n;

            Console.WriteLine("3의 배수:  {0} 개", query.Count());
            foreach(var q in query)
            {
                Console.WriteLine(q);
            }
        }

        void DisplayFiles()
        {
            var query = from file in Directory.GetFiles("c:\\")
                        select file;

            Console.WriteLine("C: 드라이브");
            foreach(var q in query)
            {
                Console.WriteLine("파일명: {0}", q);
            }
        }

        void DisplayArray()
        {
            People[] peoples = { new People("정우성", 36, true)
                                , new People("고소영", 32, false)
                                , new People("배용준", 37, true)
                                , new People("김태희", 29, false)
            };

            var query = from p in peoples
                        select p;

            Console.WriteLine("::남자회원목록::");
            foreach (var q in query.Where(o => o.IsMale == true))
            {
                Console.WriteLine("이름: {0}, 나이: {1}", q.Name, q.Age);
            }

            Console.WriteLine("::여자회원목록::");
            foreach (var q in query.Where(o => o.IsMale == false))
            {
                Console.WriteLine("이름: {0}, 나이: {1}", q.Name, q.Age);
            }

            Console.WriteLine("::전체회원명단::");
            foreach(var q in query.Select(o => o.Name))
            {
                Console.WriteLine(q);
            }

            Console.WriteLine("::전체회원명단(이름역순)::");
            var queryDesc = from p in peoples
                            orderby p.Name descending
                            select p.Name;
            foreach (var q in queryDesc)
            {
                Console.WriteLine(q);
            }

            //IEnumerable<IGrouping<out TKey, out TElement>> 결과셋
            // (추측) from 절에서 해당하는 결과셋의 초기익명타입을 할당한 결과를 group [p] by [TKey]에서 <그룹키, 초기익명타입>의 최종 출력형태의 익명타입 도출

            Console.WriteLine("::전체회원명단(이름역순/성별구분)::");
            //IEnuerable<IGrouping<bool, People>> 결과셋
            var queryGroup = from p in peoples
                             orderby p.Name descending
                             group p by p.IsMale;

            foreach (var grp in queryGroup)
            {
                Console.WriteLine("성별: {0}", grp.Key ? "남성" : "여성");
                foreach (var q in grp)
                {
                    Console.WriteLine(q.Name);
                }
            }

            // 그룹핑 결과를 into [임시 식별자] 에 대입하고 특정 조건에 해당하는 그룹만 조회
            //IEnuerable<IGrouping<bool, People>> 결과셋
            queryGroup = from p in peoples
                         orderby p.Name descending
                         group p by p.IsMale
                         into gp
                         where gp.Key == false
                         select gp;

            Console.WriteLine("::여성회원::");
            foreach (var grp in queryGroup)
            {
                foreach (var q in grp)
                {
                    Console.WriteLine(q.Name);
                }
            }




            //IEnuerable<IGrouping<int, People>> 결과셋
            var queryGroupAge = from p in peoples
                                let a = p.Age / 10
                                orderby a, p.Name
                                group p by a;

            foreach (var grp in queryGroupAge)
            {
                Console.WriteLine("{0} 대", grp.Key * 10);
                foreach (var q in grp)
                {
                    Console.WriteLine(q.Name);
                }
            }

            // (추측) from 절에서 해당하는 결과셋의 초기익명타입을 할당하며 select 절에서 해당 익명타입의 부분값만 가져오는 것은 가능하나, 
            // 초기 익명타입외의 멤버를 추가하려면 select 절에서 최종 출력형태의 익명타입 도출 ==> select new { 초기 익명타입 일부멤버들, 새로운 멤버 }
            Console.WriteLine("::전체회원명단(김씨)::");
            var queryGim = from p in peoples
                           let x = p.Name[0]
                           where x == '김'
                           select new { Name = p.Name, Seong = x };                            
            foreach (var q in queryGim)
            {
                Console.WriteLine(q);
            }

            // 익명타입 부분집합
            //var anonymous = from a in peoples
            //                select new { Name = a.Name, Age = a.Age };
            var anonymous = from a in peoples
                            select new { a.Name, a.Age };

            // XML 생성
            // <회원들>
            //     <회원><이름>정우성</이름><나이>36</나이><남자>true</남자></회원>
            //     <회원><이름>고소영</이름><나이>32</나이><남자>false</남자></회원>
            //     <회원><이름>배용준</이름><나이>37</나이><남자>true</남자></회원>
            //     <회원><이름>김태희</이름><나이>29</나이><남자>false</남자></회원>
            // </회원들>
            var xml = new XElement("회원들"
                                    , from x in peoples
                                      select new XElement("회원"
                                                          , new XElement("이름", x.Name)
                                                          , new XElement("나이", x.Age)
                                                          , new XElement("남자", x.IsMale)
                                                          )
                                    );

        }

        // (조회할 대상).Except(제외할 대상)
        void DisplayExcept()
        {
            var mine = new List<string> { "맨발의 기붕이", "뚝방전설", "디워", "마파도2", "타짜" };
            var woochi = new List<string> { "뚝방전설", "왕의 남자", "중천", "디워", "라디오스타" };

            var onlyWoochiQuery = (from w in woochi select w).Except(from m in mine select m);

            foreach(var q in onlyWoochiQuery)
            {
                Console.WriteLine(q);//왕의남자, 중천, 라디오스타
            }
        }
    }

    class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }
        public People(string name, int age, bool isMale)
        {
            Name = name;
            Age = age;
            IsMale = isMale;
        }
    }

    class Sale
    {
        public string Customer { get; set; }
        public string Item { get; set; }
        public DateTime SaleDate { get; set; }

        public Sale(string customer, string item, DateTime saleDate)
        {
            Customer = customer;
            Item = item;
            SaleDate = saleDate;
        }
    }
}
