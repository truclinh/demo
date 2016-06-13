using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
namespace CoCaro
{
    public partial class FrmCoCaro : Form
    {
        private CaroChess carochess;
        private Graphics grs;
        // tạo âm thanh
        SoundPlayer nhacnen= new SoundPlayer(Properties.Resources.NhacNen);          
        public FrmCoCaro()
        {
            InitializeComponent();
            // sử dụng bộ lắng nghe sự kiện để tạo tự kiện cho các button và MenuStrip
            btnPlayerVsPlayer.Click += new EventHandler(PvsP);
            btnPlayerVsCom.Click += new EventHandler(PvsC);
            btnUndo.Click += new EventHandler(undoToolStripMenuItem_Click);
            btnRedo.Click += new EventHandler(redoToolStripMenuItem_Click);
            editToolStripMenuItem.Click += new EventHandler(btnThoat_Click); 
            carochess = new CaroChess();
            carochess.KhoiTaoMangOCo();
            grs = panel1.CreateGraphics();
            nhacnen.Play();
            
        }
        // tạo hiệu ứng chạy chữ 
        private void FrmCoCaro_Load(object sender, EventArgs e)
        {

            
            lblChuoiChu.Text = " - Hai bên lần lượt đánh vào từng ô \n- Bên nào đạt 5 con trên 1 hàng ngang, \nhàng dọc, chéo xuôi, chéo ngược mà không \nbị chặn 2 đầu thì chiến thắng\n - Nếu bàn cờ đầy thì hoà cờ \n-  Không được đi trùng với nước đã được \nđi trước";
            tmChuChay.Enabled = true;
            lblChu.Text = "Chào mừng bạn đến với game Caro";
            tmChu.Enabled = true;
            carochess.VeBanCo(grs);
        }
        private void tmChuChay_Tick(object sender, EventArgs e)
        {

            lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, lblChuoiChu.Location.Y - 1);
            if (lblChuoiChu.Location.Y + lblChuoiChu.Height < 0)
            {
                lblChuoiChu.Location = new Point(lblChuoiChu.Location.X, panelChuChay.Height);
                

            }
        }
        //tạo hiệu ứng chạy chữ 
        int i = 10;
        private void tmChu_Tick(object sender, EventArgs e)
        {
            lblChu.Left += i;
            if (lblChu.Left < 0 || lblChu.Left > 230)
            {
                i =- i;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            carochess.VeBanCo(grs);
            carochess.VeLaiQuanCo(grs);

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!carochess.SanSang)
                return; 
            carochess.DanhCo(e.X, e.Y, grs);
            if (carochess.KiemTraChienThang())
                carochess.KetThucTroChoi();
            else
            {
                if (carochess.CheDoChoi == 2)
                {
                    carochess.KhoiDongComputer(grs);
                    if (carochess.KiemTraChienThang())
                        carochess.KetThucTroChoi();
                }
            }
        }
        //----------------------------------------------------
        #region PvsP va PvsC trên MenuStrip
        private void PvsP(object sender, EventArgs e)
        {
           
            grs.Clear(panel1.BackColor);
            carochess.StartPlayervsPlayer(grs);
        }

        private void PvsC(object sender, EventArgs e)
        {
            grs.Clear(panel1.BackColor);
            carochess.StartPlayervsCom(grs);
        }
        #endregion
        //--------------------------------------------------------
        #region Undo và Redo trên MenuStrip
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carochess.Undo(grs);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carochess.Redo(grs);
        }
        #endregion
        //-----------------------------------------------------------
        //button Chơi mới
        private void btnChoiMoi_Click(object sender, EventArgs e)
        {
            grs.Clear(panel1.BackColor);
            carochess.VeBanCo(grs);
        }
        //about trên MenuStrip
        private void abaoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHuongDan frm = new frmHuongDan();
            frm.Show();
        }  
        //button Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
               DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không???","Thông báo",MessageBoxButtons.YesNo );
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }            
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            carochess.Save();
        }
        private void btnChoiTiep_Click(object sender, EventArgs e)
        {
           
            carochess.VeBanCo(grs);
            //carochess.VeLaiQuanCo(grs);
            carochess.Load(grs);
        }
        // Âm thanh
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Application.DoEvents();
            if (btnAmThanh.Text == "Tắt nhạc")
            {
                btnAmThanh.Text = "Bật nhạc";
                nhacnen.Stop();
               
            }
            else
            {
                btnAmThanh.Text = "Tắt nhạc";
                nhacnen.PlayLooping();
            }
        }
        

       

       
    }
}
