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
    public partial class TreeViewForm : Form
    {
        struct City
        {
            public int Parent { get; set; }
            public string Name { get; set; }
            public City(int parent, string name)
            {
                Parent = parent;
                Name = name;
            }
        }

        City[] cities =
        {
            new City(-1, "대한민국")
                , new City(0, "서울특별시")
                , new City(0, "경기도")
                , new City(0, "충청도")
                , new City(1, "은평구")
                , new City(2, "수원시")
                , new City(2, "용인시")
                , new City(3, "당진군")
                , new City(6, "죽전동")
        };

        public TreeViewForm()
        {
            InitializeComponent();
        }

        private void AddCity(TreeNode tndParent, int parent)
        {
            TreeNode tndChild;
            for(int i=0; i<cities.Length; i++)
            {
                if(cities[i].Parent == parent)
                {
                    tndChild = tndParent.Nodes.Add(cities[i].Name);
                    if (HaveChild(i))
                    {
                        AddCity(tndChild, i);
                    }
                }
            }
        }

        private bool HaveChild(int idx)
        {
            for(int i=0; i<cities.Length; i++)
            {
                if(cities[i].Parent == idx)
                {
                    return true;
                }
            }

            return false;
        }

        private void TreeViewForm_Load(object sender, EventArgs e)
        {
            InitTreeViewCode();
            InitTreeViewByRecursion();

            tvwCode.ExpandAll();
            tvwCode.BeforeSelect += tvwDesign_BeforeSelect;
            tvwCode.AfterSelect += tvwDesign_AfterSelect;

            tvwRecursion.BeforeSelect += tvwDesign_BeforeSelect;
            tvwRecursion.AfterSelect += tvwDesign_AfterSelect;
        }

        /// <summary>
        /// 재귀호출에 의한 트리뷰 초기화
        /// </summary>
        private void InitTreeViewByRecursion()
        {
            tvwRecursion.Nodes.Add(cities[0].Name);
            AddCity(tvwRecursion.Nodes[0], 0);
        }

        private void InitTreeViewCode()
        {
            tvwCode.Nodes.Add("대한민국");
            tvwCode.Nodes[0].Nodes.Add("서울특별시");
            tvwCode.Nodes[0].Nodes.Add("경기도");
            tvwCode.Nodes[0].Nodes.Add("충청도");

            tvwCode.Nodes[0].Nodes[0].Nodes.Add("은평구");

            tvwCode.Nodes[0].Nodes[1].Nodes.Add("수원시");
            tvwCode.Nodes[0].Nodes[1].Nodes.Add("용인시");
            tvwCode.Nodes[0].Nodes[1].Nodes[1].Nodes.Add("죽전동");

            tvwCode.Nodes[0].Nodes[2].Nodes.Add("당진군");
        }

        private void InitTreeViewDesign()
        {
            TreeNode tnd = new TreeNode("은평구");
            TreeNode tndSeoul = new TreeNode("서울특별기", new TreeNode[] { tnd });

            TreeNode tndYongin = new TreeNode("용인시", new TreeNode[] { new TreeNode("죽전동") });
            TreeNode tndSuwon = new TreeNode("수원시");
            TreeNode tndGyeonggi = new TreeNode("경기도", new TreeNode[] { tndSuwon, tndYongin });

            TreeNode tndChungcheong = new TreeNode("충청도", new TreeNode[] { new TreeNode("당진군") });

            TreeNode tndKorea = new TreeNode("대한민국", new TreeNode[] { tndSeoul, tndGyeonggi, tndChungcheong });
            tvwDesign.Nodes.Add(tndKorea);
        }

        private void tvwDesign_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Text == "당진군")
            {
                Text = "교통편이 존재하지 않습니다.";
                e.Cancel = true;
            }
        }

        private void tvwDesign_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Text == "대한민국")
            {
                Text = "행선지를 선택하십시오.";
            }
            else
            {
                Text = "부산에서 " + e.Node.Text + "(으)로 가는 표를 예매합니다.";
            }
        }
    }
}
