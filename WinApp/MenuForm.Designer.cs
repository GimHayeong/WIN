namespace WinApp
{
    partial class MenuForm
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
            this.mnuMainStrip = new System.Windows.Forms.MenuStrip();
            this.메뉴MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.편집EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.도형GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRed = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBold = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFont = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.창WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbContents = new System.Windows.Forms.RichTextBox();
            this.statusMainStrip = new System.Windows.Forms.StatusStrip();
            this.mnuBgStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuBgRed = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBgBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBgGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJungsikStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHansikStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPosInfo = new System.Windows.Forms.Label();
            this.mnuMainStrip.SuspendLayout();
            this.mnuBgStrip.SuspendLayout();
            this.mnuJungsikStrip.SuspendLayout();
            this.mnuHansikStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMainStrip
            // 
            this.mnuMainStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴MToolStripMenuItem,
            this.편집EToolStripMenuItem,
            this.도형GToolStripMenuItem,
            this.도움말HToolStripMenuItem,
            this.창WToolStripMenuItem});
            this.mnuMainStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMainStrip.Name = "mnuMainStrip";
            this.mnuMainStrip.Size = new System.Drawing.Size(612, 28);
            this.mnuMainStrip.TabIndex = 0;
            this.mnuMainStrip.Text = "menuStrip1";
            this.mnuMainStrip.MenuActivate += new System.EventHandler(this.mnuMainStrip_MenuActivate);
            // 
            // 메뉴MToolStripMenuItem
            // 
            this.메뉴MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuSave,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.메뉴MToolStripMenuItem.Name = "메뉴MToolStripMenuItem";
            this.메뉴MToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.메뉴MToolStripMenuItem.Text = "메뉴(&M)";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(181, 26);
            this.mnuNew.Text = "새로만들기(&N)";
            this.mnuNew.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(181, 26);
            this.mnuOpen.Text = "파일열기(&O)";
            this.mnuOpen.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(181, 26);
            this.mnuSave.Text = "파일저장(&S)";
            this.mnuSave.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(181, 26);
            this.mnuExit.Text = "종료";
            this.mnuExit.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // 편집EToolStripMenuItem
            // 
            this.편집EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy,
            this.mnuCut,
            this.mnuPaste});
            this.편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            this.편집EToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.편집EToolStripMenuItem.Text = "편집(&E)";
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(164, 26);
            this.mnuCopy.Text = "복사하기(&C)";
            this.mnuCopy.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuCut
            // 
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Size = new System.Drawing.Size(164, 26);
            this.mnuCut.Text = "오려두기(&X)";
            this.mnuCut.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(164, 26);
            this.mnuPaste.Text = "붙이기(&V)";
            this.mnuPaste.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // 도형GToolStripMenuItem
            // 
            this.도형GToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCircle,
            this.mnuRectangle,
            this.mnuLine,
            this.toolStripMenuItem2,
            this.mnuRed,
            this.mnuBlue,
            this.toolStripMenuItem3,
            this.mnuBold});
            this.도형GToolStripMenuItem.Name = "도형GToolStripMenuItem";
            this.도형GToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.도형GToolStripMenuItem.Text = "도형(&G)";
            // 
            // mnuCircle
            // 
            this.mnuCircle.Name = "mnuCircle";
            this.mnuCircle.Size = new System.Drawing.Size(144, 26);
            this.mnuCircle.Text = "동그라미";
            this.mnuCircle.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuRectangle
            // 
            this.mnuRectangle.Name = "mnuRectangle";
            this.mnuRectangle.Size = new System.Drawing.Size(144, 26);
            this.mnuRectangle.Text = "사각형";
            this.mnuRectangle.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuLine
            // 
            this.mnuLine.Name = "mnuLine";
            this.mnuLine.Size = new System.Drawing.Size(144, 26);
            this.mnuLine.Text = "직선";
            this.mnuLine.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuRed
            // 
            this.mnuRed.Name = "mnuRed";
            this.mnuRed.Size = new System.Drawing.Size(144, 26);
            this.mnuRed.Text = "빨간색";
            this.mnuRed.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuBlue
            // 
            this.mnuBlue.Name = "mnuBlue";
            this.mnuBlue.Size = new System.Drawing.Size(144, 26);
            this.mnuBlue.Text = "파란색";
            this.mnuBlue.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuBold
            // 
            this.mnuBold.Name = "mnuBold";
            this.mnuBold.Size = new System.Drawing.Size(144, 26);
            this.mnuBold.Text = "굵게";
            this.mnuBold.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfo,
            this.mnuPos,
            this.toolStripMenuItem15,
            this.mnuSelectFolder,
            this.mnuFont,
            this.mnuBackground});
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // mnuInfo
            // 
            this.mnuInfo.Name = "mnuInfo";
            this.mnuInfo.Size = new System.Drawing.Size(188, 26);
            this.mnuInfo.Text = "프로그램정보(&I)";
            this.mnuInfo.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuPos
            // 
            this.mnuPos.Name = "mnuPos";
            this.mnuPos.Size = new System.Drawing.Size(188, 26);
            this.mnuPos.Text = "좌표정보";
            this.mnuPos.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuSelectFolder
            // 
            this.mnuSelectFolder.Name = "mnuSelectFolder";
            this.mnuSelectFolder.Size = new System.Drawing.Size(188, 26);
            this.mnuSelectFolder.Text = "기본폴더설정";
            this.mnuSelectFolder.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuFont
            // 
            this.mnuFont.Name = "mnuFont";
            this.mnuFont.Size = new System.Drawing.Size(188, 26);
            this.mnuFont.Text = "기본글꼴설정";
            this.mnuFont.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuBackground
            // 
            this.mnuBackground.Name = "mnuBackground";
            this.mnuBackground.Size = new System.Drawing.Size(188, 26);
            this.mnuBackground.Text = "배경색상설정";
            this.mnuBackground.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // 창WToolStripMenuItem
            // 
            this.창WToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuHorizontal,
            this.mnuVertical});
            this.창WToolStripMenuItem.Name = "창WToolStripMenuItem";
            this.창WToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.창WToolStripMenuItem.Text = "창(&W)";
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(220, 26);
            this.mnuCascade.Text = "계단식 정렬(&C)";
            this.mnuCascade.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuHorizontal
            // 
            this.mnuHorizontal.Name = "mnuHorizontal";
            this.mnuHorizontal.Size = new System.Drawing.Size(220, 26);
            this.mnuHorizontal.Text = "수평 바둑판 정렬(&H)";
            this.mnuHorizontal.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // mnuVertical
            // 
            this.mnuVertical.Name = "mnuVertical";
            this.mnuVertical.Size = new System.Drawing.Size(220, 26);
            this.mnuVertical.Text = "수직 바둑판 정렬(&V)";
            this.mnuVertical.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // rtbContents
            // 
            this.rtbContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContents.Location = new System.Drawing.Point(0, 31);
            this.rtbContents.Name = "rtbContents";
            this.rtbContents.Size = new System.Drawing.Size(612, 415);
            this.rtbContents.TabIndex = 1;
            this.rtbContents.Text = "";
            // 
            // statusMainStrip
            // 
            this.statusMainStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusMainStrip.Location = new System.Drawing.Point(0, 449);
            this.statusMainStrip.Name = "statusMainStrip";
            this.statusMainStrip.Size = new System.Drawing.Size(612, 22);
            this.statusMainStrip.TabIndex = 2;
            this.statusMainStrip.Text = "statusStrip1";
            // 
            // mnuBgStrip
            // 
            this.mnuBgStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuBgStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBgRed,
            this.mnuBgBlue,
            this.mnuBgGreen});
            this.mnuBgStrip.Name = "mnuBgStrip";
            this.mnuBgStrip.Size = new System.Drawing.Size(124, 76);
            this.mnuBgStrip.Opening += new System.ComponentModel.CancelEventHandler(this.mnuBgStrip_Opening);
            // 
            // mnuBgRed
            // 
            this.mnuBgRed.Name = "mnuBgRed";
            this.mnuBgRed.Size = new System.Drawing.Size(123, 24);
            this.mnuBgRed.Text = "빨간색";
            this.mnuBgRed.Click += new System.EventHandler(this.mnuBgContext_Click);
            // 
            // mnuBgBlue
            // 
            this.mnuBgBlue.Name = "mnuBgBlue";
            this.mnuBgBlue.Size = new System.Drawing.Size(123, 24);
            this.mnuBgBlue.Text = "파란색";
            this.mnuBgBlue.Click += new System.EventHandler(this.mnuBgContext_Click);
            // 
            // mnuBgGreen
            // 
            this.mnuBgGreen.Name = "mnuBgGreen";
            this.mnuBgGreen.Size = new System.Drawing.Size(123, 24);
            this.mnuBgGreen.Text = "초록색";
            this.mnuBgGreen.Click += new System.EventHandler(this.mnuBgContext_Click);
            // 
            // mnuJungsikStrip
            // 
            this.mnuJungsikStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuJungsikStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.mnuJungsikStrip.Name = "mnuJungsikStrip";
            this.mnuJungsikStrip.Size = new System.Drawing.Size(124, 124);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(123, 24);
            this.toolStripMenuItem4.Text = "짜장면";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(123, 24);
            this.toolStripMenuItem5.Text = "짬뽕";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(123, 24);
            this.toolStripMenuItem6.Text = "볶음밥";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(123, 24);
            this.toolStripMenuItem7.Text = "탕수육";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(123, 24);
            this.toolStripMenuItem8.Text = "팔보채";
            // 
            // mnuHansikStrip
            // 
            this.mnuHansikStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuHansikStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14});
            this.mnuHansikStrip.Name = "mnuHansikStrip";
            this.mnuHansikStrip.Size = new System.Drawing.Size(139, 148);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem9.Text = "불고기";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem10.Text = "감자탕";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem11.Text = "된장찌게";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem12.Text = "닭갈비";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem13.Text = "비빔밥";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem14.Text = "갈비";
            // 
            // lblPosInfo
            // 
            this.lblPosInfo.AutoSize = true;
            this.lblPosInfo.Location = new System.Drawing.Point(247, 174);
            this.lblPosInfo.Name = "lblPosInfo";
            this.lblPosInfo.Size = new System.Drawing.Size(45, 15);
            this.lblPosInfo.TabIndex = 3;
            this.lblPosInfo.Text = "label1";
            this.lblPosInfo.Visible = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 471);
            this.ContextMenuStrip = this.mnuBgStrip;
            this.Controls.Add(this.lblPosInfo);
            this.Controls.Add(this.statusMainStrip);
            this.Controls.Add(this.rtbContents);
            this.Controls.Add(this.mnuMainStrip);
            this.MainMenuStrip = this.mnuMainStrip;
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuForm_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuForm_MouseUp);
            this.mnuMainStrip.ResumeLayout(false);
            this.mnuMainStrip.PerformLayout();
            this.mnuBgStrip.ResumeLayout(false);
            this.mnuJungsikStrip.ResumeLayout(false);
            this.mnuHansikStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMainStrip;
        private System.Windows.Forms.ToolStripMenuItem 메뉴MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem 편집EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.RichTextBox rtbContents;
        private System.Windows.Forms.StatusStrip statusMainStrip;
        private System.Windows.Forms.ToolStripMenuItem 도형GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCircle;
        private System.Windows.Forms.ToolStripMenuItem mnuRectangle;
        private System.Windows.Forms.ToolStripMenuItem mnuLine;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuRed;
        private System.Windows.Forms.ToolStripMenuItem mnuBlue;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuBold;
        private System.Windows.Forms.ContextMenuStrip mnuBgStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuBgRed;
        private System.Windows.Forms.ToolStripMenuItem mnuBgBlue;
        private System.Windows.Forms.ToolStripMenuItem mnuBgGreen;
        private System.Windows.Forms.ContextMenuStrip mnuJungsikStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ContextMenuStrip mnuHansikStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuPos;
        private System.Windows.Forms.Label lblPosInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuFont;
        private System.Windows.Forms.ToolStripMenuItem mnuBackground;
        private System.Windows.Forms.ToolStripMenuItem 창WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuVertical;
    }
}