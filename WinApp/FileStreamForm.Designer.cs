namespace WinApp
{
    partial class FileStreamForm
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
            this.txtData = new System.Windows.Forms.TextBox();
            this.grbxFileStream = new System.Windows.Forms.GroupBox();
            this.btnReadForBinary = new System.Windows.Forms.Button();
            this.btnReadCrypto = new System.Windows.Forms.Button();
            this.btnReadForString = new System.Windows.Forms.Button();
            this.btnWriteCrypto = new System.Windows.Forms.Button();
            this.btnWriteForBinary = new System.Windows.Forms.Button();
            this.btnWriteForString = new System.Windows.Forms.Button();
            this.btnReadForByte = new System.Windows.Forms.Button();
            this.btnWriteForByte = new System.Windows.Forms.Button();
            this.grbxSerialize = new System.Windows.Forms.GroupBox();
            this.btnReadXMLForSoap = new System.Windows.Forms.Button();
            this.btnWriteXMLForSoap = new System.Windows.Forms.Button();
            this.btnReadObjectForSerializedBinary = new System.Windows.Forms.Button();
            this.btnWriteObjectForSerializedBinary = new System.Windows.Forms.Button();
            this.grbxFileInfo = new System.Windows.Forms.GroupBox();
            this.btnDirectoryInfo = new System.Windows.Forms.Button();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.btnFileInfoCopy = new System.Windows.Forms.Button();
            this.btnFileCopy = new System.Windows.Forms.Button();
            this.fswFileWatcher = new System.IO.FileSystemWatcher();
            this.grbxFileStream.SuspendLayout();
            this.grbxSerialize.SuspendLayout();
            this.grbxFileInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswFileWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(301, 13);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(514, 650);
            this.txtData.TabIndex = 1;
            // 
            // grbxFileStream
            // 
            this.grbxFileStream.Controls.Add(this.btnReadForBinary);
            this.grbxFileStream.Controls.Add(this.btnReadCrypto);
            this.grbxFileStream.Controls.Add(this.btnReadForString);
            this.grbxFileStream.Controls.Add(this.btnWriteCrypto);
            this.grbxFileStream.Controls.Add(this.btnWriteForBinary);
            this.grbxFileStream.Controls.Add(this.btnWriteForString);
            this.grbxFileStream.Controls.Add(this.btnReadForByte);
            this.grbxFileStream.Controls.Add(this.btnWriteForByte);
            this.grbxFileStream.Location = new System.Drawing.Point(9, 13);
            this.grbxFileStream.Name = "grbxFileStream";
            this.grbxFileStream.Size = new System.Drawing.Size(283, 291);
            this.grbxFileStream.TabIndex = 2;
            this.grbxFileStream.TabStop = false;
            this.grbxFileStream.Text = "파일입출력";
            // 
            // btnReadForBinary
            // 
            this.btnReadForBinary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReadForBinary.Location = new System.Drawing.Point(143, 165);
            this.btnReadForBinary.Name = "btnReadForBinary";
            this.btnReadForBinary.Size = new System.Drawing.Size(130, 53);
            this.btnReadForBinary.TabIndex = 1;
            this.btnReadForBinary.Text = "파일 읽기 (BinaryReader)";
            this.btnReadForBinary.UseVisualStyleBackColor = false;
            this.btnReadForBinary.Click += new System.EventHandler(this.btnReadBinary_Click);
            // 
            // btnReadCrypto
            // 
            this.btnReadCrypto.BackColor = System.Drawing.SystemColors.Info;
            this.btnReadCrypto.Location = new System.Drawing.Point(143, 224);
            this.btnReadCrypto.Name = "btnReadCrypto";
            this.btnReadCrypto.Size = new System.Drawing.Size(130, 53);
            this.btnReadCrypto.TabIndex = 2;
            this.btnReadCrypto.Text = "복호화 읽기 (CryptoStream)";
            this.btnReadCrypto.UseVisualStyleBackColor = false;
            this.btnReadCrypto.Click += new System.EventHandler(this.btnDecrypto_Click);
            // 
            // btnReadForString
            // 
            this.btnReadForString.Location = new System.Drawing.Point(143, 95);
            this.btnReadForString.Name = "btnReadForString";
            this.btnReadForString.Size = new System.Drawing.Size(130, 53);
            this.btnReadForString.TabIndex = 2;
            this.btnReadForString.Text = "파일 읽기 (StreamReader)";
            this.btnReadForString.UseVisualStyleBackColor = true;
            this.btnReadForString.Click += new System.EventHandler(this.btnReadString_Click);
            // 
            // btnWriteCrypto
            // 
            this.btnWriteCrypto.BackColor = System.Drawing.SystemColors.Info;
            this.btnWriteCrypto.Location = new System.Drawing.Point(9, 224);
            this.btnWriteCrypto.Name = "btnWriteCrypto";
            this.btnWriteCrypto.Size = new System.Drawing.Size(130, 53);
            this.btnWriteCrypto.TabIndex = 4;
            this.btnWriteCrypto.Text = "암호화 쓰기 (CryptoStream)";
            this.btnWriteCrypto.UseVisualStyleBackColor = false;
            this.btnWriteCrypto.Click += new System.EventHandler(this.btnEncryptData_Click);
            // 
            // btnWriteForBinary
            // 
            this.btnWriteForBinary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnWriteForBinary.Location = new System.Drawing.Point(9, 165);
            this.btnWriteForBinary.Name = "btnWriteForBinary";
            this.btnWriteForBinary.Size = new System.Drawing.Size(130, 53);
            this.btnWriteForBinary.TabIndex = 3;
            this.btnWriteForBinary.Text = "파일 쓰기 (BinaryWriter)";
            this.btnWriteForBinary.UseVisualStyleBackColor = false;
            this.btnWriteForBinary.Click += new System.EventHandler(this.btnWriteBinary_Click);
            // 
            // btnWriteForString
            // 
            this.btnWriteForString.Location = new System.Drawing.Point(9, 95);
            this.btnWriteForString.Name = "btnWriteForString";
            this.btnWriteForString.Size = new System.Drawing.Size(130, 53);
            this.btnWriteForString.TabIndex = 4;
            this.btnWriteForString.Text = "파일 쓰기 (StreamWriter)";
            this.btnWriteForString.UseVisualStyleBackColor = true;
            this.btnWriteForString.Click += new System.EventHandler(this.btnWriteString_Click);
            // 
            // btnReadForByte
            // 
            this.btnReadForByte.Location = new System.Drawing.Point(143, 25);
            this.btnReadForByte.Name = "btnReadForByte";
            this.btnReadForByte.Size = new System.Drawing.Size(130, 53);
            this.btnReadForByte.TabIndex = 5;
            this.btnReadForByte.Text = "파일 읽기 (FileStream)";
            this.btnReadForByte.UseVisualStyleBackColor = true;
            this.btnReadForByte.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWriteForByte
            // 
            this.btnWriteForByte.Location = new System.Drawing.Point(9, 25);
            this.btnWriteForByte.Name = "btnWriteForByte";
            this.btnWriteForByte.Size = new System.Drawing.Size(130, 53);
            this.btnWriteForByte.TabIndex = 6;
            this.btnWriteForByte.Text = "파일 쓰기 (FileStream)";
            this.btnWriteForByte.UseVisualStyleBackColor = true;
            this.btnWriteForByte.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // grbxSerialize
            // 
            this.grbxSerialize.Controls.Add(this.btnReadXMLForSoap);
            this.grbxSerialize.Controls.Add(this.btnWriteXMLForSoap);
            this.grbxSerialize.Controls.Add(this.btnReadObjectForSerializedBinary);
            this.grbxSerialize.Controls.Add(this.btnWriteObjectForSerializedBinary);
            this.grbxSerialize.Location = new System.Drawing.Point(9, 310);
            this.grbxSerialize.Name = "grbxSerialize";
            this.grbxSerialize.Size = new System.Drawing.Size(283, 167);
            this.grbxSerialize.TabIndex = 2;
            this.grbxSerialize.TabStop = false;
            this.grbxSerialize.Text = "시리얼라이즈";
            // 
            // btnReadXMLForSoap
            // 
            this.btnReadXMLForSoap.Location = new System.Drawing.Point(144, 93);
            this.btnReadXMLForSoap.Name = "btnReadXMLForSoap";
            this.btnReadXMLForSoap.Size = new System.Drawing.Size(130, 53);
            this.btnReadXMLForSoap.TabIndex = 1;
            this.btnReadXMLForSoap.Text = "파일 읽기 (SoapFormatter)";
            this.btnReadXMLForSoap.UseVisualStyleBackColor = true;
            this.btnReadXMLForSoap.Click += new System.EventHandler(this.btnReadXMLForSoap_Click);
            // 
            // btnWriteXMLForSoap
            // 
            this.btnWriteXMLForSoap.Location = new System.Drawing.Point(10, 93);
            this.btnWriteXMLForSoap.Name = "btnWriteXMLForSoap";
            this.btnWriteXMLForSoap.Size = new System.Drawing.Size(130, 53);
            this.btnWriteXMLForSoap.TabIndex = 2;
            this.btnWriteXMLForSoap.Text = "파일 쓰기 (SoapFormatter)";
            this.btnWriteXMLForSoap.UseVisualStyleBackColor = true;
            this.btnWriteXMLForSoap.Click += new System.EventHandler(this.btnWriteXMLForSoap_Click);
            // 
            // btnReadObjectForSerializedBinary
            // 
            this.btnReadObjectForSerializedBinary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReadObjectForSerializedBinary.Location = new System.Drawing.Point(144, 24);
            this.btnReadObjectForSerializedBinary.Name = "btnReadObjectForSerializedBinary";
            this.btnReadObjectForSerializedBinary.Size = new System.Drawing.Size(130, 53);
            this.btnReadObjectForSerializedBinary.TabIndex = 1;
            this.btnReadObjectForSerializedBinary.Text = "파일 읽기 (BinaryFormatter)";
            this.btnReadObjectForSerializedBinary.UseVisualStyleBackColor = false;
            this.btnReadObjectForSerializedBinary.Click += new System.EventHandler(this.btnReadBinary_Click);
            // 
            // btnWriteObjectForSerializedBinary
            // 
            this.btnWriteObjectForSerializedBinary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnWriteObjectForSerializedBinary.Location = new System.Drawing.Point(10, 24);
            this.btnWriteObjectForSerializedBinary.Name = "btnWriteObjectForSerializedBinary";
            this.btnWriteObjectForSerializedBinary.Size = new System.Drawing.Size(130, 53);
            this.btnWriteObjectForSerializedBinary.TabIndex = 2;
            this.btnWriteObjectForSerializedBinary.Text = "파일 쓰기 (BinaryFormatter)";
            this.btnWriteObjectForSerializedBinary.UseVisualStyleBackColor = false;
            this.btnWriteObjectForSerializedBinary.Click += new System.EventHandler(this.btnWriteBinary_Click);
            // 
            // grbxFileInfo
            // 
            this.grbxFileInfo.Controls.Add(this.btnDirectoryInfo);
            this.grbxFileInfo.Controls.Add(this.btnDirectory);
            this.grbxFileInfo.Controls.Add(this.btnFileInfoCopy);
            this.grbxFileInfo.Controls.Add(this.btnFileCopy);
            this.grbxFileInfo.Location = new System.Drawing.Point(9, 497);
            this.grbxFileInfo.Name = "grbxFileInfo";
            this.grbxFileInfo.Size = new System.Drawing.Size(283, 167);
            this.grbxFileInfo.TabIndex = 3;
            this.grbxFileInfo.TabStop = false;
            this.grbxFileInfo.Text = "시리얼라이즈";
            // 
            // btnDirectoryInfo
            // 
            this.btnDirectoryInfo.Location = new System.Drawing.Point(144, 93);
            this.btnDirectoryInfo.Name = "btnDirectoryInfo";
            this.btnDirectoryInfo.Size = new System.Drawing.Size(130, 53);
            this.btnDirectoryInfo.TabIndex = 1;
            this.btnDirectoryInfo.Text = "폴더 조회 (DirectoryInfo)";
            this.btnDirectoryInfo.UseVisualStyleBackColor = true;
            this.btnDirectoryInfo.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // btnDirectory
            // 
            this.btnDirectory.Location = new System.Drawing.Point(10, 93);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(130, 53);
            this.btnDirectory.TabIndex = 2;
            this.btnDirectory.Text = "폴더 조회 (Directory)";
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // btnFileInfoCopy
            // 
            this.btnFileInfoCopy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFileInfoCopy.Location = new System.Drawing.Point(144, 24);
            this.btnFileInfoCopy.Name = "btnFileInfoCopy";
            this.btnFileInfoCopy.Size = new System.Drawing.Size(130, 53);
            this.btnFileInfoCopy.TabIndex = 1;
            this.btnFileInfoCopy.Text = "파일 복사 (FileInfo.Copy)";
            this.btnFileInfoCopy.UseVisualStyleBackColor = false;
            this.btnFileInfoCopy.Click += new System.EventHandler(this.btnFileCopy_Click);
            // 
            // btnFileCopy
            // 
            this.btnFileCopy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFileCopy.Location = new System.Drawing.Point(10, 24);
            this.btnFileCopy.Name = "btnFileCopy";
            this.btnFileCopy.Size = new System.Drawing.Size(130, 53);
            this.btnFileCopy.TabIndex = 2;
            this.btnFileCopy.Text = "파일 복사 (File.Copy)";
            this.btnFileCopy.UseVisualStyleBackColor = false;
            this.btnFileCopy.Click += new System.EventHandler(this.btnFileCopy_Click);
            // 
            // fswFileWatcher
            // 
            this.fswFileWatcher.EnableRaisingEvents = true;
            this.fswFileWatcher.Path = "D:\\downloads\\temp";
            this.fswFileWatcher.SynchronizingObject = this;
            this.fswFileWatcher.Changed += new System.IO.FileSystemEventHandler(this.fswFileWatcher_Changed);
            this.fswFileWatcher.Created += new System.IO.FileSystemEventHandler(this.fswFileWatcher_Created);
            this.fswFileWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fswFileWatcher_Deleted);
            this.fswFileWatcher.Renamed += new System.IO.RenamedEventHandler(this.fswFileWatcher_Renamed);
            // 
            // FileStreamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 675);
            this.Controls.Add(this.grbxFileInfo);
            this.Controls.Add(this.grbxSerialize);
            this.Controls.Add(this.grbxFileStream);
            this.Controls.Add(this.txtData);
            this.Name = "FileStreamForm";
            this.Text = "FileStreamForm";
            this.Load += new System.EventHandler(this.Form_Load);
            this.grbxFileStream.ResumeLayout(false);
            this.grbxSerialize.ResumeLayout(false);
            this.grbxFileInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fswFileWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.GroupBox grbxFileStream;
        private System.Windows.Forms.Button btnReadForBinary;
        private System.Windows.Forms.Button btnReadForString;
        private System.Windows.Forms.Button btnWriteForBinary;
        private System.Windows.Forms.Button btnWriteForString;
        private System.Windows.Forms.Button btnReadForByte;
        private System.Windows.Forms.Button btnWriteForByte;
        private System.Windows.Forms.GroupBox grbxSerialize;
        private System.Windows.Forms.Button btnReadXMLForSoap;
        private System.Windows.Forms.Button btnWriteXMLForSoap;
        private System.Windows.Forms.Button btnReadObjectForSerializedBinary;
        private System.Windows.Forms.Button btnWriteObjectForSerializedBinary;
        private System.Windows.Forms.GroupBox grbxFileInfo;
        private System.Windows.Forms.Button btnDirectoryInfo;
        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.Button btnFileInfoCopy;
        private System.Windows.Forms.Button btnFileCopy;
        private System.IO.FileSystemWatcher fswFileWatcher;
        private System.Windows.Forms.Button btnReadCrypto;
        private System.Windows.Forms.Button btnWriteCrypto;
    }
}