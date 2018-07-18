namespace WinApp
{
    partial class ListViewForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "서울",
            "605",
            "1026"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "부산",
            "758",
            "381"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "용인",
            "591",
            "583"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "춘천",
            "1116",
            "25"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "홍천",
            "1817",
            "7"}, -1);
            this.lvwDesign = new System.Windows.Forms.ListView();
            this.lvwCode = new System.Windows.Forms.ListView();
            this.colCity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPopulation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwDesign
            // 
            this.lvwDesign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCity,
            this.colArea,
            this.colPopulation});
            this.lvwDesign.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lvwDesign.Location = new System.Drawing.Point(12, 12);
            this.lvwDesign.Name = "lvwDesign";
            this.lvwDesign.Size = new System.Drawing.Size(611, 244);
            this.lvwDesign.TabIndex = 0;
            this.lvwDesign.UseCompatibleStateImageBehavior = false;
            this.lvwDesign.View = System.Windows.Forms.View.Details;
            this.lvwDesign.ItemActivate += new System.EventHandler(this.lvwDesign_ItemActivate);
            this.lvwDesign.SelectedIndexChanged += new System.EventHandler(this.lvwDesign_SelectedIndexChanged);
            // 
            // lvwCode
            // 
            this.lvwCode.Location = new System.Drawing.Point(12, 278);
            this.lvwCode.Name = "lvwCode";
            this.lvwCode.Size = new System.Drawing.Size(611, 244);
            this.lvwCode.TabIndex = 0;
            this.lvwCode.UseCompatibleStateImageBehavior = false;
            // 
            // colCity
            // 
            this.colCity.Text = "도시";
            this.colCity.Width = 100;
            // 
            // colArea
            // 
            this.colArea.Text = "면적";
            this.colArea.Width = 90;
            // 
            // colPopulation
            // 
            this.colPopulation.Text = "인구";
            this.colPopulation.Width = 120;
            // 
            // ListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 534);
            this.Controls.Add(this.lvwCode);
            this.Controls.Add(this.lvwDesign);
            this.Name = "ListViewForm";
            this.Text = "ListViewForm";
            this.Load += new System.EventHandler(this.ListViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwDesign;
        private System.Windows.Forms.ColumnHeader colCity;
        private System.Windows.Forms.ColumnHeader colArea;
        private System.Windows.Forms.ColumnHeader colPopulation;
        private System.Windows.Forms.ListView lvwCode;
    }
}