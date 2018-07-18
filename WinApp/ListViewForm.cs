using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class ListViewForm : Form
    {
        struct City
        {
            public string Name { get; set; }
            public int Area { get; set; }
            public int Population { get; set; }
            public City(string name, int area, int population)
            {
                Name = name;
                Area = area;
                Population = population;
            }
        }

        City[] cities =
        {
            new City("서울", 605, 1026)
                , new City("부산", 758, 381)
                , new City("용인", 591, 583)
                , new City("춘천", 1116, 25)
                , new City("홍천", 1817, 7)
        };

        public ListViewForm()
        {
            InitializeComponent();

            // Set ColumnHeader of ListView 
            lvwCode.View = View.Details;
            lvwCode.Columns.Add("도시", 100);
            lvwCode.Columns.Add("면적", 120);
            lvwCode.Columns.Add("인구", 150);
        }

        private void ListViewForm_Load(object sender, EventArgs e)
        {
            foreach(var c in cities)
            {
                lvwCode.Items.Add(new ListViewItem(new string[] { c.Name, c.Area.ToString(), c.Population.ToString() }));
            }
            lvwCode.SelectedIndexChanged += lvwDesign_SelectedIndexChanged;
            lvwCode.ItemActivate += lvwDesign_ItemActivate;
        }

        /// <summary>
        /// 항목의 선택사항이 변경될 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwDesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lvw = sender as ListView;
            if(lvw != null && lvw.SelectedItems.Count > 0)
            {
                Text = lvw.SelectedItems[0].Text;
            }
            else
            {
                Text = "선택된 항목이 없습니다.";
            }
        }

        /// <summary>
        /// 항목이 활성화될 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwDesign_ItemActivate(object sender, EventArgs e)
        {
            ListView lvw = sender as ListView;
            if(lvw != null)
            {
                Text = lvw.SelectedItems[0].Text + "에 대한 정보를 인쇄합니다.";
            }
        }
    }
}
