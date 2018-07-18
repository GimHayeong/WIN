namespace WinApp
{
    partial class ClipboardForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetFromClipboard = new System.Windows.Forms.Button();
            this.btnCutToClipboard = new System.Windows.Forms.Button();
            this.btnSetToClipboard = new System.Windows.Forms.Button();
            this.txtTgt = new System.Windows.Forms.TextBox();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbcTgt = new System.Windows.Forms.PictureBox();
            this.pbxSrc = new System.Windows.Forms.PictureBox();
            this.btnGetImageFromClipboard = new System.Windows.Forms.Button();
            this.btnCutImageToClipboard = new System.Windows.Forms.Button();
            this.btnSetImageToClipboard = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAudioTgt = new System.Windows.Forms.Button();
            this.btnAudioSrc = new System.Windows.Forms.Button();
            this.btnGetAudioStreamFromClipboard = new System.Windows.Forms.Button();
            this.btnCutAudioToClipboard = new System.Windows.Forms.Button();
            this.btnSetAudioToClipboard = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbxClipboardFormats = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObjHtmlTgt = new System.Windows.Forms.TextBox();
            this.txtObjTgt = new System.Windows.Forms.TextBox();
            this.txtObjSrc = new System.Windows.Forms.TextBox();
            this.btnGetFormats = new System.Windows.Forms.Button();
            this.btnGetObjectFromClipboard = new System.Windows.Forms.Button();
            this.btnCutObjectToClipboard = new System.Windows.Forms.Button();
            this.btnSetDataToClipboard = new System.Windows.Forms.Button();
            this.btnSetObjectToClipboard = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbxSrc = new System.Windows.Forms.ListBox();
            this.lbxTgt = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbxFileTgt = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcTgt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGetFromClipboard);
            this.groupBox1.Controls.Add(this.btnCutToClipboard);
            this.groupBox1.Controls.Add(this.btnSetToClipboard);
            this.groupBox1.Controls.Add(this.txtTgt);
            this.groupBox1.Controls.Add(this.txtSrc);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 137);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "텍스트복사(클립보드)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "복사본";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "원본";
            // 
            // btnGetFromClipboard
            // 
            this.btnGetFromClipboard.Location = new System.Drawing.Point(252, 32);
            this.btnGetFromClipboard.Name = "btnGetFromClipboard";
            this.btnGetFromClipboard.Size = new System.Drawing.Size(123, 88);
            this.btnGetFromClipboard.TabIndex = 6;
            this.btnGetFromClipboard.Text = "텍스트붙여넣기 (GetText)";
            this.btnGetFromClipboard.UseVisualStyleBackColor = true;
            this.btnGetFromClipboard.Click += new System.EventHandler(this.btnGetFromClipboard_Click);
            // 
            // btnCutToClipboard
            // 
            this.btnCutToClipboard.Location = new System.Drawing.Point(133, 79);
            this.btnCutToClipboard.Name = "btnCutToClipboard";
            this.btnCutToClipboard.Size = new System.Drawing.Size(113, 41);
            this.btnCutToClipboard.TabIndex = 7;
            this.btnCutToClipboard.Text = "텍스트자르기 (SetText)";
            this.btnCutToClipboard.UseVisualStyleBackColor = true;
            this.btnCutToClipboard.Click += new System.EventHandler(this.btnSetToClipboard_Click);
            // 
            // btnSetToClipboard
            // 
            this.btnSetToClipboard.Location = new System.Drawing.Point(133, 32);
            this.btnSetToClipboard.Name = "btnSetToClipboard";
            this.btnSetToClipboard.Size = new System.Drawing.Size(113, 41);
            this.btnSetToClipboard.TabIndex = 8;
            this.btnSetToClipboard.Text = "텍스트복사 (SetText)";
            this.btnSetToClipboard.UseVisualStyleBackColor = true;
            this.btnSetToClipboard.Click += new System.EventHandler(this.btnSetToClipboard_Click);
            // 
            // txtTgt
            // 
            this.txtTgt.Location = new System.Drawing.Point(389, 79);
            this.txtTgt.Name = "txtTgt";
            this.txtTgt.ReadOnly = true;
            this.txtTgt.Size = new System.Drawing.Size(100, 25);
            this.txtTgt.TabIndex = 5;
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(19, 79);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(100, 25);
            this.txtSrc.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbcTgt);
            this.groupBox2.Controls.Add(this.pbxSrc);
            this.groupBox2.Controls.Add(this.btnGetImageFromClipboard);
            this.groupBox2.Controls.Add(this.btnCutImageToClipboard);
            this.groupBox2.Controls.Add(this.btnSetImageToClipboard);
            this.groupBox2.Location = new System.Drawing.Point(12, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 137);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "이미지복사(클립보드)";
            // 
            // pbcTgt
            // 
            this.pbcTgt.Location = new System.Drawing.Point(389, 32);
            this.pbcTgt.Name = "pbcTgt";
            this.pbcTgt.Size = new System.Drawing.Size(100, 88);
            this.pbcTgt.TabIndex = 9;
            this.pbcTgt.TabStop = false;
            // 
            // pbxSrc
            // 
            this.pbxSrc.Image = global::WinApp.Properties.Resources.android_96X32;
            this.pbxSrc.Location = new System.Drawing.Point(19, 32);
            this.pbxSrc.Name = "pbxSrc";
            this.pbxSrc.Size = new System.Drawing.Size(100, 88);
            this.pbxSrc.TabIndex = 9;
            this.pbxSrc.TabStop = false;
            // 
            // btnGetImageFromClipboard
            // 
            this.btnGetImageFromClipboard.Location = new System.Drawing.Point(252, 32);
            this.btnGetImageFromClipboard.Name = "btnGetImageFromClipboard";
            this.btnGetImageFromClipboard.Size = new System.Drawing.Size(123, 88);
            this.btnGetImageFromClipboard.TabIndex = 6;
            this.btnGetImageFromClipboard.Text = "이미지붙여넣기 (GetImage)";
            this.btnGetImageFromClipboard.UseVisualStyleBackColor = true;
            this.btnGetImageFromClipboard.Click += new System.EventHandler(this.btnGetImageFromClipboard_Click);
            // 
            // btnCutImageToClipboard
            // 
            this.btnCutImageToClipboard.Location = new System.Drawing.Point(133, 79);
            this.btnCutImageToClipboard.Name = "btnCutImageToClipboard";
            this.btnCutImageToClipboard.Size = new System.Drawing.Size(113, 41);
            this.btnCutImageToClipboard.TabIndex = 7;
            this.btnCutImageToClipboard.Text = "이미지자르기 (SetImage)";
            this.btnCutImageToClipboard.UseVisualStyleBackColor = true;
            this.btnCutImageToClipboard.Click += new System.EventHandler(this.btnSetImageToClipboard_Click);
            // 
            // btnSetImageToClipboard
            // 
            this.btnSetImageToClipboard.Location = new System.Drawing.Point(133, 32);
            this.btnSetImageToClipboard.Name = "btnSetImageToClipboard";
            this.btnSetImageToClipboard.Size = new System.Drawing.Size(113, 41);
            this.btnSetImageToClipboard.TabIndex = 8;
            this.btnSetImageToClipboard.Text = "이미지복사 (SetImage)";
            this.btnSetImageToClipboard.UseVisualStyleBackColor = true;
            this.btnSetImageToClipboard.Click += new System.EventHandler(this.btnSetImageToClipboard_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAudioTgt);
            this.groupBox3.Controls.Add(this.btnAudioSrc);
            this.groupBox3.Controls.Add(this.btnGetAudioStreamFromClipboard);
            this.groupBox3.Controls.Add(this.btnCutAudioToClipboard);
            this.groupBox3.Controls.Add(this.btnSetAudioToClipboard);
            this.groupBox3.Location = new System.Drawing.Point(12, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(508, 137);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "오디오복사(클립보드)";
            // 
            // btnAudioTgt
            // 
            this.btnAudioTgt.Location = new System.Drawing.Point(436, 50);
            this.btnAudioTgt.Name = "btnAudioTgt";
            this.btnAudioTgt.Size = new System.Drawing.Size(53, 52);
            this.btnAudioTgt.TabIndex = 9;
            this.btnAudioTgt.Text = "▶";
            this.btnAudioTgt.UseVisualStyleBackColor = true;
            this.btnAudioTgt.Click += new System.EventHandler(this.btnAudioSrc_Click);
            // 
            // btnAudioSrc
            // 
            this.btnAudioSrc.Location = new System.Drawing.Point(22, 50);
            this.btnAudioSrc.Name = "btnAudioSrc";
            this.btnAudioSrc.Size = new System.Drawing.Size(53, 52);
            this.btnAudioSrc.TabIndex = 9;
            this.btnAudioSrc.Text = "▶";
            this.btnAudioSrc.UseVisualStyleBackColor = true;
            this.btnAudioSrc.Click += new System.EventHandler(this.btnAudioSrc_Click);
            // 
            // btnGetAudioStreamFromClipboard
            // 
            this.btnGetAudioStreamFromClipboard.Location = new System.Drawing.Point(252, 32);
            this.btnGetAudioStreamFromClipboard.Name = "btnGetAudioStreamFromClipboard";
            this.btnGetAudioStreamFromClipboard.Size = new System.Drawing.Size(167, 88);
            this.btnGetAudioStreamFromClipboard.TabIndex = 6;
            this.btnGetAudioStreamFromClipboard.Text = "오디오붙여넣기 (GetAudioStream)";
            this.btnGetAudioStreamFromClipboard.UseVisualStyleBackColor = true;
            this.btnGetAudioStreamFromClipboard.Click += new System.EventHandler(this.btnGetAudioStreamFromClipboard_Click);
            // 
            // btnCutAudioToClipboard
            // 
            this.btnCutAudioToClipboard.Location = new System.Drawing.Point(92, 79);
            this.btnCutAudioToClipboard.Name = "btnCutAudioToClipboard";
            this.btnCutAudioToClipboard.Size = new System.Drawing.Size(154, 41);
            this.btnCutAudioToClipboard.TabIndex = 7;
            this.btnCutAudioToClipboard.Text = "오디오자르기 (SetAudio)";
            this.btnCutAudioToClipboard.UseVisualStyleBackColor = true;
            this.btnCutAudioToClipboard.Click += new System.EventHandler(this.btnSetAudioToClipboard_Click);
            // 
            // btnSetAudioToClipboard
            // 
            this.btnSetAudioToClipboard.Location = new System.Drawing.Point(92, 32);
            this.btnSetAudioToClipboard.Name = "btnSetAudioToClipboard";
            this.btnSetAudioToClipboard.Size = new System.Drawing.Size(154, 41);
            this.btnSetAudioToClipboard.TabIndex = 8;
            this.btnSetAudioToClipboard.Text = "오디오복사 (SetAudio)";
            this.btnSetAudioToClipboard.UseVisualStyleBackColor = true;
            this.btnSetAudioToClipboard.Click += new System.EventHandler(this.btnSetAudioToClipboard_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listView2);
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Location = new System.Drawing.Point(16, 493);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(508, 137);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "파일목록복사(클립보드)";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(406, 32);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(95, 88);
            this.listView2.TabIndex = 10;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(7, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(95, 88);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(256, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 88);
            this.button3.TabIndex = 6;
            this.button3.Text = "파일목록붙여넣기 (GetFileDropList)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnGetFilesFromClipboard_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(108, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(142, 41);
            this.button4.TabIndex = 7;
            this.button4.Text = "파일목록자르기 (SetFileDropList)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSetFilesToClipboard_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(108, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(142, 41);
            this.button5.TabIndex = 8;
            this.button5.Text = "파일목록복사 (SetFileDropList)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnSetFilesToClipboard_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbxClipboardFormats);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtObjHtmlTgt);
            this.groupBox5.Controls.Add(this.txtObjTgt);
            this.groupBox5.Controls.Add(this.txtObjSrc);
            this.groupBox5.Controls.Add(this.btnGetFormats);
            this.groupBox5.Controls.Add(this.btnGetObjectFromClipboard);
            this.groupBox5.Controls.Add(this.btnCutObjectToClipboard);
            this.groupBox5.Controls.Add(this.btnSetDataToClipboard);
            this.groupBox5.Controls.Add(this.btnSetObjectToClipboard);
            this.groupBox5.Location = new System.Drawing.Point(16, 659);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(508, 214);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Serialized 오브젝트복사(클립보드)";
            // 
            // lbxClipboardFormats
            // 
            this.lbxClipboardFormats.FormattingEnabled = true;
            this.lbxClipboardFormats.ItemHeight = 15;
            this.lbxClipboardFormats.Location = new System.Drawing.Point(215, 137);
            this.lbxClipboardFormats.Name = "lbxClipboardFormats";
            this.lbxClipboardFormats.Size = new System.Drawing.Size(274, 64);
            this.lbxClipboardFormats.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "HTML 복사본";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "복사본";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "원본";
            // 
            // txtObjHtmlTgt
            // 
            this.txtObjHtmlTgt.Location = new System.Drawing.Point(389, 106);
            this.txtObjHtmlTgt.Name = "txtObjHtmlTgt";
            this.txtObjHtmlTgt.ReadOnly = true;
            this.txtObjHtmlTgt.Size = new System.Drawing.Size(100, 25);
            this.txtObjHtmlTgt.TabIndex = 12;
            // 
            // txtObjTgt
            // 
            this.txtObjTgt.Location = new System.Drawing.Point(389, 47);
            this.txtObjTgt.Name = "txtObjTgt";
            this.txtObjTgt.ReadOnly = true;
            this.txtObjTgt.Size = new System.Drawing.Size(100, 25);
            this.txtObjTgt.TabIndex = 12;
            // 
            // txtObjSrc
            // 
            this.txtObjSrc.Location = new System.Drawing.Point(19, 78);
            this.txtObjSrc.Name = "txtObjSrc";
            this.txtObjSrc.Size = new System.Drawing.Size(100, 25);
            this.txtObjSrc.TabIndex = 11;
            // 
            // btnGetFormats
            // 
            this.btnGetFormats.Location = new System.Drawing.Point(15, 137);
            this.btnGetFormats.Name = "btnGetFormats";
            this.btnGetFormats.Size = new System.Drawing.Size(194, 64);
            this.btnGetFormats.TabIndex = 6;
            this.btnGetFormats.Text = "클립보드포맷목록 (GetFormats)";
            this.btnGetFormats.UseVisualStyleBackColor = true;
            this.btnGetFormats.Click += new System.EventHandler(this.btnGetFormats_Click);
            // 
            // btnGetObjectFromClipboard
            // 
            this.btnGetObjectFromClipboard.Location = new System.Drawing.Point(256, 80);
            this.btnGetObjectFromClipboard.Name = "btnGetObjectFromClipboard";
            this.btnGetObjectFromClipboard.Size = new System.Drawing.Size(127, 40);
            this.btnGetObjectFromClipboard.TabIndex = 6;
            this.btnGetObjectFromClipboard.Text = "객체붙여넣기 (GetDataObject)";
            this.btnGetObjectFromClipboard.UseVisualStyleBackColor = true;
            this.btnGetObjectFromClipboard.Click += new System.EventHandler(this.btnGetObjectFromClipboard_Click);
            // 
            // btnCutObjectToClipboard
            // 
            this.btnCutObjectToClipboard.Location = new System.Drawing.Point(124, 79);
            this.btnCutObjectToClipboard.Name = "btnCutObjectToClipboard";
            this.btnCutObjectToClipboard.Size = new System.Drawing.Size(126, 41);
            this.btnCutObjectToClipboard.TabIndex = 7;
            this.btnCutObjectToClipboard.Text = "객체자르기 (SetDataObject)";
            this.btnCutObjectToClipboard.UseVisualStyleBackColor = true;
            this.btnCutObjectToClipboard.Click += new System.EventHandler(this.btnSetObjectToClipboard_Click);
            // 
            // btnSetDataToClipboard
            // 
            this.btnSetDataToClipboard.Location = new System.Drawing.Point(256, 33);
            this.btnSetDataToClipboard.Name = "btnSetDataToClipboard";
            this.btnSetDataToClipboard.Size = new System.Drawing.Size(121, 41);
            this.btnSetDataToClipboard.TabIndex = 8;
            this.btnSetDataToClipboard.Text = "멀티타입복사 (SetData)";
            this.btnSetDataToClipboard.UseVisualStyleBackColor = true;
            this.btnSetDataToClipboard.Click += new System.EventHandler(this.btnSetObjectToClipboard_Click);
            // 
            // btnSetObjectToClipboard
            // 
            this.btnSetObjectToClipboard.Location = new System.Drawing.Point(124, 32);
            this.btnSetObjectToClipboard.Name = "btnSetObjectToClipboard";
            this.btnSetObjectToClipboard.Size = new System.Drawing.Size(126, 41);
            this.btnSetObjectToClipboard.TabIndex = 8;
            this.btnSetObjectToClipboard.Text = "객체복사 (SetDataObject)";
            this.btnSetObjectToClipboard.UseVisualStyleBackColor = true;
            this.btnSetObjectToClipboard.Click += new System.EventHandler(this.btnSetObjectToClipboard_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbxTgt);
            this.groupBox6.Controls.Add(this.lbxSrc);
            this.groupBox6.Location = new System.Drawing.Point(536, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(424, 447);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "드래그 앤 드롭";
            // 
            // lbxSrc
            // 
            this.lbxSrc.FormattingEnabled = true;
            this.lbxSrc.ItemHeight = 15;
            this.lbxSrc.Location = new System.Drawing.Point(17, 32);
            this.lbxSrc.Name = "lbxSrc";
            this.lbxSrc.Size = new System.Drawing.Size(391, 169);
            this.lbxSrc.TabIndex = 0;
            this.lbxSrc.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.lbxSrc_QueryContinueDrag);
            this.lbxSrc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxSrc_MouseDown);
            // 
            // lbxTgt
            // 
            this.lbxTgt.FormattingEnabled = true;
            this.lbxTgt.ItemHeight = 15;
            this.lbxTgt.Location = new System.Drawing.Point(17, 222);
            this.lbxTgt.Name = "lbxTgt";
            this.lbxTgt.Size = new System.Drawing.Size(391, 199);
            this.lbxTgt.TabIndex = 0;
            this.lbxTgt.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbxTgt_DragDrop);
            this.lbxTgt.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbxTgt_DragEnter);
            this.lbxTgt.DragOver += new System.Windows.Forms.DragEventHandler(this.lbxTgt_DragOver);
            this.lbxTgt.DragLeave += new System.EventHandler(this.lbxTgt_DragLeave);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbxFileTgt);
            this.groupBox7.Location = new System.Drawing.Point(536, 493);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(424, 380);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "파일드롭";
            // 
            // lbxFileTgt
            // 
            this.lbxFileTgt.FormattingEnabled = true;
            this.lbxFileTgt.ItemHeight = 15;
            this.lbxFileTgt.Location = new System.Drawing.Point(17, 32);
            this.lbxFileTgt.Name = "lbxFileTgt";
            this.lbxFileTgt.Size = new System.Drawing.Size(391, 334);
            this.lbxFileTgt.TabIndex = 0;
            this.lbxFileTgt.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbxFileTgt_DragDrop);
            this.lbxFileTgt.DragOver += new System.Windows.Forms.DragEventHandler(this.lbxFileTgt_DragOver);
            // 
            // ClipboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 892);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClipboardForm";
            this.Text = "ClipboardForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbcTgt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetFromClipboard;
        private System.Windows.Forms.Button btnCutToClipboard;
        private System.Windows.Forms.Button btnSetToClipboard;
        private System.Windows.Forms.TextBox txtTgt;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbcTgt;
        private System.Windows.Forms.PictureBox pbxSrc;
        private System.Windows.Forms.Button btnGetImageFromClipboard;
        private System.Windows.Forms.Button btnCutImageToClipboard;
        private System.Windows.Forms.Button btnSetImageToClipboard;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGetAudioStreamFromClipboard;
        private System.Windows.Forms.Button btnCutAudioToClipboard;
        private System.Windows.Forms.Button btnSetAudioToClipboard;
        private System.Windows.Forms.Button btnAudioTgt;
        private System.Windows.Forms.Button btnAudioSrc;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnGetObjectFromClipboard;
        private System.Windows.Forms.Button btnCutObjectToClipboard;
        private System.Windows.Forms.Button btnSetObjectToClipboard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObjTgt;
        private System.Windows.Forms.TextBox txtObjSrc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObjHtmlTgt;
        private System.Windows.Forms.ListBox lbxClipboardFormats;
        private System.Windows.Forms.Button btnGetFormats;
        private System.Windows.Forms.Button btnSetDataToClipboard;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lbxTgt;
        private System.Windows.Forms.ListBox lbxSrc;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox lbxFileTgt;
    }
}