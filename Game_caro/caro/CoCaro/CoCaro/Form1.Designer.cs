namespace CoCaro
{
    partial class FrmCoCaro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCoCaro));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abaoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlayerVsPlayer = new System.Windows.Forms.Button();
            this.btnPlayerVsCom = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tmChuChay = new System.Windows.Forms.Timer(this.components);
            this.pnlChuChay = new System.Windows.Forms.Panel();
            this.lblChu = new System.Windows.Forms.Label();
            this.tmChu = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelChuChay = new System.Windows.Forms.Panel();
            this.lblChuoiChu = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnAmThanh = new System.Windows.Forms.Button();
            this.btnChoiTiep = new System.Windows.Forms.Button();
            this.btnChoiMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.pnlChuChay.SuspendLayout();
            this.panelChuChay.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.playerVsComToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.playerVsPlayerToolStripMenuItem.Text = "2 người chơi";
            this.playerVsPlayerToolStripMenuItem.Click += new System.EventHandler(this.PvsP);
            // 
            // playerVsComToolStripMenuItem
            // 
            this.playerVsComToolStripMenuItem.Name = "playerVsComToolStripMenuItem";
            this.playerVsComToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.playerVsComToolStripMenuItem.Text = "1 người chơi với máy";
            this.playerVsComToolStripMenuItem.Click += new System.EventHandler(this.PvsC);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.editToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem1.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abaoutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // abaoutToolStripMenuItem
            // 
            this.abaoutToolStripMenuItem.Name = "abaoutToolStripMenuItem";
            this.abaoutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.abaoutToolStripMenuItem.Text = "&About";
            this.abaoutToolStripMenuItem.Click += new System.EventHandler(this.abaoutToolStripMenuItem_Click);
            // 
            // btnPlayerVsPlayer
            // 
            this.btnPlayerVsPlayer.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnPlayerVsPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayerVsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerVsPlayer.ForeColor = System.Drawing.Color.Red;
            this.btnPlayerVsPlayer.Location = new System.Drawing.Point(71, 429);
            this.btnPlayerVsPlayer.Name = "btnPlayerVsPlayer";
            this.btnPlayerVsPlayer.Size = new System.Drawing.Size(182, 32);
            this.btnPlayerVsPlayer.TabIndex = 3;
            this.btnPlayerVsPlayer.Text = "2 người chơi";
            this.btnPlayerVsPlayer.UseVisualStyleBackColor = false;
            // 
            // btnPlayerVsCom
            // 
            this.btnPlayerVsCom.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnPlayerVsCom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayerVsCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerVsCom.ForeColor = System.Drawing.Color.Red;
            this.btnPlayerVsCom.Location = new System.Drawing.Point(71, 469);
            this.btnPlayerVsCom.Name = "btnPlayerVsCom";
            this.btnPlayerVsCom.Size = new System.Drawing.Size(182, 32);
            this.btnPlayerVsCom.TabIndex = 4;
            this.btnPlayerVsCom.Text = "1 người chơi với máy";
            this.btnPlayerVsCom.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1456750394_Delete.ico");
            this.imageList1.Images.SetKeyName(1, "1456750425_Synchronize.ico");
            this.imageList1.Images.SetKeyName(2, "load.ico");
            this.imageList1.Images.SetKeyName(3, "save.ico");
            this.imageList1.Images.SetKeyName(4, "sound.ico");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(353, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 401);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // tmChuChay
            // 
            this.tmChuChay.Tick += new System.EventHandler(this.tmChuChay_Tick);
            // 
            // pnlChuChay
            // 
            this.pnlChuChay.Controls.Add(this.lblChu);
            this.pnlChuChay.Location = new System.Drawing.Point(137, 27);
            this.pnlChuChay.Name = "pnlChuChay";
            this.pnlChuChay.Size = new System.Drawing.Size(560, 47);
            this.pnlChuChay.TabIndex = 8;
            // 
            // lblChu
            // 
            this.lblChu.AutoSize = true;
            this.lblChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChu.ForeColor = System.Drawing.Color.Red;
            this.lblChu.Location = new System.Drawing.Point(3, 9);
            this.lblChu.Name = "lblChu";
            this.lblChu.Size = new System.Drawing.Size(0, 20);
            this.lblChu.TabIndex = 0;
            // 
            // tmChu
            // 
            this.tmChu.Tick += new System.EventHandler(this.tmChu_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Magneto", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(107, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "Luật chơi";
            // 
            // panelChuChay
            // 
            this.panelChuChay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelChuChay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelChuChay.Controls.Add(this.lblChuoiChu);
            this.panelChuChay.Location = new System.Drawing.Point(21, 277);
            this.panelChuChay.Name = "panelChuChay";
            this.panelChuChay.Size = new System.Drawing.Size(324, 143);
            this.panelChuChay.TabIndex = 11;
            // 
            // lblChuoiChu
            // 
            this.lblChuoiChu.AutoSize = true;
            this.lblChuoiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuoiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblChuoiChu.Location = new System.Drawing.Point(7, 113);
            this.lblChuoiChu.Name = "lblChuoiChu";
            this.lblChuoiChu.Size = new System.Drawing.Size(40, 20);
            this.lblChuoiChu.TabIndex = 0;
            this.lblChuoiChu.Text = "caro";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnAmThanh);
            this.panel2.Controls.Add(this.btnChoiTiep);
            this.panel2.Controls.Add(this.btnChoiMoi);
            this.panel2.Controls.Add(this.btnThoat);
            this.panel2.Location = new System.Drawing.Point(752, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(93, 381);
            this.panel2.TabIndex = 13;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLuu.ImageKey = "save.ico";
            this.btnLuu.ImageList = this.imageList1;
            this.btnLuu.Location = new System.Drawing.Point(3, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 56);
            this.btnLuu.TabIndex = 17;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnAmThanh
            // 
            this.btnAmThanh.BackColor = System.Drawing.Color.White;
            this.btnAmThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmThanh.ForeColor = System.Drawing.Color.Blue;
            this.btnAmThanh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAmThanh.ImageKey = "sound.ico";
            this.btnAmThanh.ImageList = this.imageList1;
            this.btnAmThanh.Location = new System.Drawing.Point(3, 302);
            this.btnAmThanh.Name = "btnAmThanh";
            this.btnAmThanh.Size = new System.Drawing.Size(91, 66);
            this.btnAmThanh.TabIndex = 14;
            this.btnAmThanh.Text = "Tắt nhạc";
            this.btnAmThanh.UseVisualStyleBackColor = false;
            this.btnAmThanh.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChoiTiep
            // 
            this.btnChoiTiep.BackColor = System.Drawing.Color.White;
            this.btnChoiTiep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoiTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoiTiep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnChoiTiep.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChoiTiep.ImageKey = "load.ico";
            this.btnChoiTiep.ImageList = this.imageList1;
            this.btnChoiTiep.Location = new System.Drawing.Point(3, 74);
            this.btnChoiTiep.Name = "btnChoiTiep";
            this.btnChoiTiep.Size = new System.Drawing.Size(90, 56);
            this.btnChoiTiep.TabIndex = 16;
            this.btnChoiTiep.Text = "Chơi tiếp";
            this.btnChoiTiep.UseVisualStyleBackColor = false;
            this.btnChoiTiep.Click += new System.EventHandler(this.btnChoiTiep_Click);
            // 
            // btnChoiMoi
            // 
            this.btnChoiMoi.BackColor = System.Drawing.Color.White;
            this.btnChoiMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoiMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoiMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnChoiMoi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChoiMoi.ImageKey = "1456750425_Synchronize.ico";
            this.btnChoiMoi.ImageList = this.imageList1;
            this.btnChoiMoi.Location = new System.Drawing.Point(3, 150);
            this.btnChoiMoi.Name = "btnChoiMoi";
            this.btnChoiMoi.Size = new System.Drawing.Size(87, 58);
            this.btnChoiMoi.TabIndex = 6;
            this.btnChoiMoi.Text = "Chơi Mới";
            this.btnChoiMoi.UseVisualStyleBackColor = false;
            this.btnChoiMoi.Click += new System.EventHandler(this.btnChoiMoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThoat.ImageKey = "1456750394_Delete.ico";
            this.btnThoat.ImageList = this.imageList1;
            this.btnThoat.Location = new System.Drawing.Point(3, 228);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 56);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnRedo
            // 
            this.btnRedo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRedo.BackgroundImage")));
            this.btnRedo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRedo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRedo.Location = new System.Drawing.Point(560, 487);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(63, 52);
            this.btnRedo.TabIndex = 10;
            this.btnRedo.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            this.btnUndo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUndo.BackgroundImage")));
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndo.Location = new System.Drawing.Point(442, 487);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(61, 52);
            this.btnUndo.TabIndex = 9;
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 156);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmCoCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(846, 551);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelChuChay);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.pnlChuChay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPlayerVsCom);
            this.Controls.Add(this.btnPlayerVsPlayer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmCoCaro";
            this.Text = "Cờ Caro";
            this.Load += new System.EventHandler(this.FrmCoCaro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlChuChay.ResumeLayout(false);
            this.pnlChuChay.PerformLayout();
            this.panelChuChay.ResumeLayout(false);
            this.panelChuChay.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsComToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abaoutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPlayerVsPlayer;
        private System.Windows.Forms.Button btnPlayerVsCom;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChoiMoi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmChuChay;
        private System.Windows.Forms.Panel pnlChuChay;
        private System.Windows.Forms.Label lblChu;
        private System.Windows.Forms.Timer tmChu;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelChuChay;
        private System.Windows.Forms.Label lblChuoiChu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnChoiTiep;
        private System.Windows.Forms.Button btnAmThanh;
    }
}

