using System;
using System.Data;
using System.Windows.Forms;

namespace ORDesigner
{

    /// <summary>
    /// 마법사가 만든 클래스의 사용자 확장
    /// </summary>

    partial class ADOPeopleDataSet
    {
        partial class tblPeopleDataTable
        {
            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                switch(e.Column.ColumnName)
                {
                    case "Age":
                        CheckName(e);
                        if((int)e.ProposedValue < 0 || (int)e.ProposedValue > 100)
                        {
                            e.Row.SetColumnError("Age", "나이는 0~100 사이여야 합니다.");
                        }
                        else
                        {
                            e.Row.SetColumnError("Age", "");
                        }
                        
                        break;
                }
            }

            private void CheckName(DataColumnChangeEventArgs e)
            {
                if (e.Row["Name"] == null || String.IsNullOrWhiteSpace(e.Row["Name"].ToString()))
                {
                    e.Row.SetColumnError("Name", "이름은 필수입력사항입니다.");
                }
                else
                {
                    e.Row.SetColumnError("Name", "");
                }
            }
        }

        /// <summary>
        /// 사용자가 추가한 메서드
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}

namespace ORDesigner.ADOPeopleDataSetTableAdapters {
    
    
    public partial class tblPeopleTableAdapter
    {
        public void UserMessage()
        {
            MessageBox.Show("이 제품은 테스트용입니다.");
        }
    }
}
