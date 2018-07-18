namespace WinApp
{
    partial class GDIPlusForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GDIPlusForm));
            this.timerOffset = new System.Windows.Forms.Timer(this.components);
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // timerOffset
            // 
            this.timerOffset.Interval = 200;
            this.timerOffset.Tick += new System.EventHandler(this.timerOffset_Tick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "baby.jpg");
            this.imgList.Images.SetKeyName(1, "clover.jpg");
            // 
            // GDIPlusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 581);
            this.Name = "GDIPlusForm";
            this.Text = "GDI+";
            this.Load += new System.EventHandler(this.GDIPlusForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GDIPlusForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GDIPlusForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerOffset;
        private System.Windows.Forms.ImageList imgList;
    }
}