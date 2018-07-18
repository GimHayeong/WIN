namespace WinApp
{
    partial class TreeViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("은평구");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("서울특별시", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("수원시");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("죽전동");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("용인시", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("경기도", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("당진군");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("충청도", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("대한민국", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6,
            treeNode8});
            this.tvwDesign = new System.Windows.Forms.TreeView();
            this.tvwCode = new System.Windows.Forms.TreeView();
            this.tvwRecursion = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvwDesign
            // 
            this.tvwDesign.FullRowSelect = true;
            this.tvwDesign.Location = new System.Drawing.Point(12, 12);
            this.tvwDesign.Name = "tvwDesign";
            treeNode1.Name = "노드2";
            treeNode1.Text = "은평구";
            treeNode2.Name = "노드1";
            treeNode2.Text = "서울특별시";
            treeNode3.Name = "노드4";
            treeNode3.Text = "수원시";
            treeNode4.Name = "노드0";
            treeNode4.Text = "죽전동";
            treeNode5.Name = "노드5";
            treeNode5.Text = "용인시";
            treeNode6.Name = "노드3";
            treeNode6.Text = "경기도";
            treeNode7.Name = "노드9";
            treeNode7.Text = "당진군";
            treeNode8.Name = "노드8";
            treeNode8.Text = "충청도";
            treeNode9.Name = "노드0";
            treeNode9.Text = "대한민국";
            this.tvwDesign.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.tvwDesign.ShowLines = false;
            this.tvwDesign.ShowPlusMinus = false;
            this.tvwDesign.Size = new System.Drawing.Size(288, 509);
            this.tvwDesign.TabIndex = 0;
            this.tvwDesign.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwDesign_BeforeSelect);
            this.tvwDesign.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDesign_AfterSelect);
            // 
            // tvwCode
            // 
            this.tvwCode.Location = new System.Drawing.Point(312, 12);
            this.tvwCode.Name = "tvwCode";
            this.tvwCode.Size = new System.Drawing.Size(288, 509);
            this.tvwCode.TabIndex = 0;
            // 
            // tvwRecursion
            // 
            this.tvwRecursion.Location = new System.Drawing.Point(612, 12);
            this.tvwRecursion.Name = "tvwRecursion";
            this.tvwRecursion.Size = new System.Drawing.Size(288, 509);
            this.tvwRecursion.TabIndex = 0;
            // 
            // TreeViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 533);
            this.Controls.Add(this.tvwRecursion);
            this.Controls.Add(this.tvwCode);
            this.Controls.Add(this.tvwDesign);
            this.Name = "TreeViewForm";
            this.Text = "TreeViewForm";
            this.Load += new System.EventHandler(this.TreeViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvwDesign;
        private System.Windows.Forms.TreeView tvwCode;
        private System.Windows.Forms.TreeView tvwRecursion;
    }
}