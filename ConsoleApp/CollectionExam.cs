using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// 컬렉션 : 크기가 동적으로 변하는 상태에서 이질적인 데이터를 처리
    ///   + IEnumerable : 인터페이스를 상속받은 클래스는 GetEnumerator() 메서드 재정의 필수
    ///                   GetEnumerator()는 IEnumerator 인스턴스를 반환
    ///   + IEnumerator : 컬렉션의 첫요소부터 순차적으로 추출(MoveNext)하면서 현재요소(Current)에 접근하거나 처음으로 이동(Reset) 가능
    ///   + ICollection : 제네릭이 아닌 모든 컬렉션에 대한 크기, 열거자 및 동기화 메서드를 정의. IEnumerable 인테페이스 상속받음
    ///                   컬렉션의 개체수(Count), 동기화처리(IsSynchronized), 동기화에 사용되는 개체(SyncRoot)
    ///   + IList :리스트 형식으로 인덱싱기능, 삽입/삭제/검색 기능 제공. ICollection 인터페이스 상속.
    ///   + IDictionary : Key와 Value 쌍으로 데이터 검출. ICollection 상속
    ///   + IDictionEnumerator : IDictionary 인터페이스에 Enumerator 기능 추가. IDictionary에 포함된 데이터들에 대해 열거 기능 wprhd
    ///   =============================================================================================================================
    ///   + SortedList 클래스 : 데이터를 삽입할 때 키값을 기준으로 내부적으로 데이터들의 인덱싱 자동 조정.
    ///   + Hashtable 클래스 : 입력된 순서대로 키와 값의 쌍
    /// </summary>
    public class CollectionExam
    {
        public string GetColorEnumerator()
        {
            int idx = 0;
            string[] colors = { "빨", "주", "노", "초", "파", "남", "보" };
            StringBuilder sb = new StringBuilder();

            IEnumerator color = colors.GetEnumerator();

            sb.AppendLine($"전체 색상 수: {colors.Length}");
            while (color.MoveNext())
            {
                sb.AppendFormat(" - {0}", color.Current);
            }
            sb.AppendLine();

            color.Reset();
            sb.AppendLine("짝수번째 색상 목록");
            while (color.MoveNext())
            {
                if ((idx % 2) == 1)
                {
                    sb.AppendFormat(" - {0}", color.Current);
                }
                idx++;
            }
            sb.AppendLine();

            return sb.ToString();
        }

        public string GetColorCollection()
        {
            string[] colors = { "빨", "주", "노", "초", "파", "남", "보" };

            return GetCollection(colors);
        }

        public string GetNumberCollection()
        {
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            return GetCollection(nums);
        }

        public string GetArrayCollection()
        {
            ArrayList ary = new ArrayList();
            ary.Add(2);
            ary.Add(3);

            return GetCollection(ary);
        }

        public string GetCopyArrayCollection(int[] src, int[] dest)
        {
            src.CopyTo(dest, 2);//dest의 두번째 인덱스에 src를 복사(기존데이터 덮어쓰기)

            return GetCollection(dest);
        }

        public string GetCollection(ICollection collection)
        {
            StringBuilder sb = new StringBuilder();

            lock (collection.SyncRoot)
            {
                sb.AppendLine($"전체 컬렉션 수: {collection.Count}");
                foreach (var item in collection)
                {
                    sb.AppendFormat(" - {0}", item);
                }
            }

            return sb.ToString();
        }

        public string GetSortedFrutes()
        {
            SortedList list = new SortedList();
            list.Add("strawbarry", "딸기");
            list.Add("apple", "사과");
            list.Add("orange", "오렌지");
            list.Add("banana", "바나나");

            return GetSortedFrutes(list);
        }

        public string GetSortedFrutes(SortedList list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"데이터 변경 전 리스트: {list.Count}");
            for (int i = 0; i < list.Count; i++)
            {
                sb.AppendFormat("{0} : {1}", list.GetKey(i), list.GetByIndex(i));//Key : Value
            }

            list.Add("pineapple", "파인애플");
            list.RemoveAt(0);

            sb.AppendLine($"데이터 변경 후 리스트: {list.Count}");
            foreach (DictionaryEntry de in list)
            {
                sb.AppendFormat("{0} : {1}", de.Key, de.Value);//Key : Value
            }

            sb.AppendLine("데이터 조회 결과 =======================================");
            sb.AppendFormat("키 {0} 조회결과 ==> {1}", "orange", list.ContainsKey("orange") ? "있음" : "없음");
            sb.AppendFormat("값 {0} 조회결과 ==> {1}", "포도", list.ContainsValue("포도") ? "있음" : "없음");

            return sb.ToString();
        }

        public string GetHashtableFrutes()
        {
            Hashtable list = new Hashtable();
            list.Add("strawbarry", "딸기");
            list.Add("apple", "사과");
            list.Add("orange", "오렌지");
            list.Add("banana", "바나나");

            return GetHashtableFrutes(list);
        }

        public string GetHashtableFrutes(Hashtable list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"데이터 변경 전 리스트: {list.Count}");
            foreach (DictionaryEntry de in list)
            {
                sb.AppendFormat("{0} : {1}", de.Key, de.Value);//Key : Value
            }

            list.Add("pineapple", "파인애플");
            list.Remove("banana");//키로 접근

            sb.AppendLine($"데이터 변경 후 리스트: {list.Count}");
            foreach (DictionaryEntry de in list)
            {
                sb.AppendFormat("{0} : {1}", de.Key, de.Value);//Key : Value
            }

            sb.AppendLine("데이터 조회 결과 =======================================");
            sb.AppendFormat("키 {0} 조회결과 ==> {1}", "orange", list.ContainsKey("orange") ? "있음" : "없음");
            sb.AppendFormat("값 {0} 조회결과 ==> {1}", "포도", list.ContainsValue("포도") ? "있음" : "없음");

            return sb.ToString();
        }

        public string GetQueueFrutes()
        {
            Queue list = new Queue();
            list.Enqueue("strawbarry");
            list.Enqueue("apple");
            list.Enqueue("orange");
            list.Enqueue("banana");

            return GetQueueFrutes(list);
        }

        public string GetQueueFrutes(Queue list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"데이터 변경 전 리스트: {list.Count}");
            int idx = 0;
            foreach (var data in list)
            {
                sb.AppendFormat("{0}번째 데이터: {1}", idx++, data);
            }

            list.Enqueue("pineapple");//입력순서대로 접근. 마지막에 추가
            list.Dequeue();//입력순서대로 접근. 첫번째 제거

            sb.AppendLine($"데이터 변경 후 리스트: {list.Count}");
            idx = 0;
            foreach (var data in list)
            {
                sb.AppendFormat("{0}번째 데이터: {1}", idx++, data);
            }

            sb.AppendLine("데이터 조회 결과 =======================================");
            sb.AppendFormat("{0} 조회결과 ==> {1}", "orange", list.Contains("orange") ? "있음" : "없음");
            sb.AppendFormat("첫번째 값 ==> {0}", list.Peek());//첫번째 데이터 조회할 뿐 제거하지 않음.

            sb.AppendLine($"데이터 조회 후 리스트: {list.Count}");
            idx = 0;
            foreach (var data in list)
            {
                sb.AppendFormat("{0}번째 데이터: {1}", idx++, data);
            }

            return sb.ToString();
        }


        public string GetStackFrutes()
        {
            Stack list = new Stack();
            list.Push("strawbarry");
            list.Push("apple");
            list.Push("orange");
            list.Push("banana");

            return GetStackFrutes(list);
        }

        public string GetStackFrutes(Stack list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"데이터 변경 전 리스트: {list.Count}");
            int idx = 0;
            foreach (var data in list)
            {
                sb.AppendFormat("{0}번째 데이터: {1}", idx++, data);
            }

            list.Push("pineapple");//입력순서대로 접근. 마지막에 추가
            list.Pop();//입력 역순으로 접근. 마지막 제거

            sb.AppendLine($"데이터 변경 후 리스트: {list.Count}");
            idx = 0;
            foreach (var data in list)
            {
                sb.AppendFormat("{0}번째 데이터: {1}", idx++, data);
            }

            sb.AppendLine("데이터 조회 결과 =======================================");
            sb.AppendFormat("{0} 조회결과 ==> {1}", "orange", list.Contains("orange") ? "있음" : "없음");
            sb.AppendFormat("첫번째 값 ==> {0}", list.Peek());//첫번째 데이터 조회할 뿐 제거하지 않음.

            sb.AppendLine($"데이터 조회 후 리스트: {list.Count}");
            idx = 0;
            foreach (var data in list)
            {
                sb.AppendFormat("{0}번째 데이터: {1}", idx++, data);
            }

            return sb.ToString();
        }
    }
}
