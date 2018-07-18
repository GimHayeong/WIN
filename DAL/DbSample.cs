using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbSample
    {
        public DbSample()
        {

        }

        public DataTable GetPeopleTable(Person[] people)
        {
            DataTable tblPeople = new DataTable("tblPeople");
            DataColumn col;

            col = new DataColumn("Name", typeof(String));
            col.MaxLength = 10;
            col.AllowDBNull = false;
            col.Unique = true;// DataRelation 설정을 위해 부모의 키는 Unique 제약을 걸어 중복금지.
            //col.ColumnMapping = MappingType.Attribute;//XML 파일로 출력할 때 속성값으로 넣고 싶은 열 지정
            tblPeople.Columns.Add(col);
            tblPeople.PrimaryKey = new DataColumn[] { col };

            col = new DataColumn("Age", typeof(Int32));
            col.AllowDBNull = false;
            tblPeople.Columns.Add(col);

            col = new DataColumn("Male", typeof(bool));
            col.AllowDBNull = false;
            col.DefaultValue = false;
            tblPeople.Columns.Add(col);

            foreach(Person person in people)
            {
                InsertPerson(tblPeople, person);
            }
            //InsertPerson(tblPeople, new Person("정우성", 36, true));
            //InsertPerson(tblPeople, new Person("고소영", 32, false));
            //InsertPerson(tblPeople, new Person("배용준", 37, true));
            //InsertPerson(tblPeople, new Person("김태희", 29, false));

            tblPeople.AcceptChanges();

            return tblPeople;
        }


        private void InsertPerson(DataTable tblPeople, Person person)
        {
            DataRow row;

            row = tblPeople.NewRow();
            row["Name"] = person.Name;
            row["Age"] = person.Age;
            row["Male"] = person.Male;

            tblPeople.Rows.Add(row);
        }

        public DataTable GetSaleTable()
        {
            DataTable tblSale = new DataTable("tblSale");
            DataColumn col;

            col = new DataColumn("OrderNo", typeof(Int32));
            col.AllowDBNull = false;
            col.Unique = true;
            col.AutoIncrement = true;//IDENTITY(1,1)
            col.ReadOnly = true;
            tblSale.Columns.Add(col);
            tblSale.PrimaryKey = new DataColumn[] { col };//PRIMARY KEY
            //tblSale.PrimaryKey = new[] { col };

            col = new DataColumn("Customer", typeof(string));
            col.MaxLength = 10;
            col.AllowDBNull = false;
            tblSale.Columns.Add(col);
            

            col = new DataColumn("Item", typeof(string));
            col.MaxLength = 20;
            col.AllowDBNull = false;
            tblSale.Columns.Add(col);

            col = new DataColumn("OrderDate", typeof(DateTime));
            col.AllowDBNull = false;
            tblSale.Columns.Add(col);

            InsertSale(tblSale, new Sale("정우성", "면도기", new DateTime(2018, 1, 1)));
            InsertSale(tblSale, new Sale("고소영", "화장품", new DateTime(2018, 1, 2)));
            InsertSale(tblSale, new Sale("김태희", "핸드폰", new DateTime(2018, 1, 3)));
            InsertSale(tblSale, new Sale("김태희", "휘발유", new DateTime(2018, 1, 4)));

            tblSale.AcceptChanges();
            return tblSale;
        }

        private void InsertSale(DataTable tblSale, Sale sale)
        {
            DataRow row;

            row = tblSale.NewRow();
            row["Customer"] = sale.Customer;
            row["Item"] = sale.Item;
            row["OrderDate"] = sale.OrderDate;

            tblSale.Rows.Add(row);
        }
    }
}
