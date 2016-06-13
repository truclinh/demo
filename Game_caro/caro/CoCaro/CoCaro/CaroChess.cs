using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
namespace CoCaro
{
    
    public enum KETTHUC
    {
        HoaCo,
        Player1,
        Player2
    }
    class CaroChess
    {
        public static Pen pen;
       /* public static SolidBrush sbRed;
        public static SolidBrush sbBlack;*/
        public static Image imgX;
        public static Image imgO;
        public static SolidBrush sbWhite;
        public OCo[,] _MangOCo;
        private BanCo _BanCo;
        private int __LuotDi;
        private int _CheDoChoi;
        private bool _SanSang;
        private Stack<OCo> stack_CacNuocDaDi;
        private Stack<OCo> stack_CacNuocUndo;
        private KETTHUC _ketThuc;
        SoundPlayer nhacvotay = new SoundPlayer(Properties.Resources.votay);
        public bool SanSang
        {
            get { return _SanSang; }
        }
        public int CheDoChoi
        {
            get{return _CheDoChoi;}
        }
        public CaroChess()
        {
            pen = new Pen(Color.Green);
            imgX = Properties.Resources.x;
            imgO = Properties.Resources.o;
            sbWhite = new SolidBrush(Color.White);
            _BanCo = new BanCo(20, 20);
            _MangOCo = new OCo[_BanCo.SoDong, _BanCo.SoCot];
            stack_CacNuocDaDi = new Stack<OCo>();
            stack_CacNuocUndo = new Stack<OCo>();
            __LuotDi = 1;
        }
        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }
        public void KhoiTaoMangOCo()
        {
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    _MangOCo[i, j] = new OCo(i,j,new Point(j*OCo._ChieuRong,i*OCo._ChieuCao),0);
                }
            }
        }
        #region Danh co
        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            if(MouseX % OCo._ChieuRong==0 || MouseY % OCo._ChieuCao==0)
            {
                return false;
            }
            int Cot = MouseX / OCo._ChieuRong;
            int Dong = MouseY / OCo._ChieuCao;
            if (_MangOCo[Dong, Cot].SoHuu != 0)
                return false;
            switch (__LuotDi)
            {
                case 1:
                    _MangOCo[Dong, Cot].SoHuu = 1;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong, Cot].ViTri, imgX);
                    __LuotDi = 2;
                    break;
                case 2:
                    _MangOCo[Dong, Cot].SoHuu = 2;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong, Cot].ViTri,imgO);
                    __LuotDi = 1;
                    break;
                default:
                    MessageBox.Show("Có Lỗi");
                    break;
            }
            stack_CacNuocUndo = new Stack<OCo>();
            OCo oco = new OCo(_MangOCo[Dong, Cot].Dong, _MangOCo[Dong, Cot].Cot, _MangOCo[Dong, Cot].ViTri, _MangOCo[Dong, Cot].SoHuu);
            stack_CacNuocDaDi.Push(oco);
            return true;
        }
        #endregion
        #region Ve lai quan co
        public void VeLaiQuanCo(Graphics g)
        {
            foreach (OCo oco in stack_CacNuocDaDi)
            {
                if (oco.SoHuu == 1)
                    _BanCo.VeQuanCo(g, oco.ViTri, imgX);
                else if (oco.SoHuu == 2)
                    _BanCo.VeQuanCo(g, oco.ViTri, imgO);
            }
        }
        #endregion
        #region PVsP
        public void StartPlayervsPlayer(Graphics g)
        {
            _SanSang = true;
            stack_CacNuocDaDi = new Stack<OCo>();
            stack_CacNuocUndo = new Stack<OCo>();
            __LuotDi = 1;
            _CheDoChoi = 1;
            KhoiTaoMangOCo();
            VeBanCo(g);
        }
        #endregion
        #region PVsC
        public void StartPlayervsCom(Graphics g)
        {
            _SanSang = true;
            stack_CacNuocDaDi = new Stack<OCo>();
            stack_CacNuocUndo = new Stack<OCo>();
            __LuotDi = 1;
            _CheDoChoi = 2;
            KhoiTaoMangOCo();
            VeBanCo(g);
            KhoiDongComputer(g);
        }
        #endregion
        #region Undo/Redo
        public void Undo(Graphics g)
        {
            if (stack_CacNuocDaDi.Count != 0)
            {
                OCo oco = stack_CacNuocDaDi.Pop();
                stack_CacNuocUndo.Push(new OCo(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                _MangOCo[oco.Dong, oco.Cot].SoHuu = 0;
                _BanCo.XoaQuanCo(g, oco.ViTri, sbWhite);
                if (__LuotDi == 1)
                    __LuotDi = 2;
                else
                    __LuotDi = 1;

            }
        }
        public void Redo(Graphics g)
        {
            if (stack_CacNuocUndo.Count != 0)
            {
                OCo oco = stack_CacNuocUndo.Pop();
                stack_CacNuocDaDi.Push(new OCo(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                _MangOCo[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                _BanCo.VeQuanCo(g, oco.ViTri,oco.SoHuu ==1 ? imgX : imgO);
                if (__LuotDi == 1)
                    __LuotDi = 2;
                else
                    __LuotDi = 1;
            }
        }
        #endregion
        public void Save()
        {
            string path = @"D:\save.txt";
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(f);
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    sw.Write(_MangOCo[i, j].SoHuu); //+ " ");
                }
                sw.WriteLine("\n");
            }
            sw.Flush();
            sw.Close();
            f.Close();
            MessageBox.Show("Đã lưu");

        }

        public void Load(Graphics g)
        {
            string path = @"D:\save.txt";
            FileStream f = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(f);
          // int [,] s = new int[20, 20];
           for (int i = 0; i < _BanCo.SoDong; i++)           
            {            
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                   // s[i, j] = sr.Read();
                   //_MangOCo[i, j].SoHuu = s[i,j];
                    if (_MangOCo[i, j].SoHuu != 0)
                    { _BanCo.VeQuanCo(g, _MangOCo[i, j].ViTri, _MangOCo[i, j].SoHuu == 1 ? imgX : imgO); }

                }

            }
            f.Close();
            sr.Close();
            
        }
        

        #region DuyetChienThang
        public void KetThucTroChoi()
        {
            switch(_ketThuc)
            {
                case KETTHUC.HoaCo:                 
                    MessageBox.Show("Hoa co");                 
                    break;
                case KETTHUC.Player1:
                    nhacvotay.Play();
                    MessageBox.Show("Nguoi choi quan X thang..!!");
                    nhacvotay.Stop();                   
                    break;
                case KETTHUC.Player2:
                    nhacvotay.Play();
                    MessageBox.Show("Nguoi choi quan O thang..!!");
                    nhacvotay.Stop();                   
                    break;

            }
            _SanSang =false;
        }
        public bool KiemTraChienThang()
        {
            if (stack_CacNuocDaDi.Count == _BanCo.SoCot * _BanCo.SoDong)
            {
                _ketThuc = KETTHUC.HoaCo;
                return true;
            }
            foreach (OCo oco in stack_CacNuocDaDi)
            {
                if (DuyetDoc(oco.Dong, oco.Cot, oco.SoHuu) || DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoNguoc(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoXuoi(oco.Dong, oco.Cot, oco.SoHuu))
                {
                   
                    _ketThuc =oco.SoHuu ==1 ? KETTHUC.Player1:KETTHUC.Player2;
                    return true;
                }
            }
            return false;
        }
        private bool DuyetDoc(int currDong, int currCot, int CurrSoHuu)
        {
            if (currDong > _BanCo.SoDong - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu != CurrSoHuu)
                    return false;
            }
            if (currDong == 0 || currDong +Dem ==_BanCo.SoDong)
                return true;
            if (_MangOCo[currDong - 1, currCot].SoHuu == 0||_MangOCo[currDong +Dem,currCot].SoHuu==0)
                return true;
            return false;
        }
        private bool DuyetNgang(int currDong, int currCot, int CurrSoHuu)
        {
            if (currCot > _BanCo.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong, currCot + Dem].SoHuu != CurrSoHuu)
                    return false;
            }
            if (currCot == 0 || currCot + Dem == _BanCo.SoCot)
                return true;
            if (_MangOCo[currDong, currCot - 1].SoHuu == 0 || _MangOCo[currDong, currCot + Dem].SoHuu == 0)
                return true;
            return false;
        }
        private bool DuyetCheoNguoc(int currDong, int currCot, int CurrSoHuu)
        {
            if (currDong <4 || currCot > _BanCo.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong-Dem, currCot + Dem].SoHuu != CurrSoHuu)
                    return false;
            }
            if (currDong == 4 || currDong == _BanCo.SoDong -1||currCot==0||currCot+Dem==_BanCo.SoCot)
                return true;
            if (_MangOCo[currDong +1, currCot - 1].SoHuu == 0 || _MangOCo[currDong-Dem, currCot + Dem].SoHuu == 0)
                return true;
            return false;
        }
        private bool DuyetCheoXuoi(int currDong, int currCot, int CurrSoHuu)
        {
            if (currDong > _BanCo.SoDong - 5 ||currCot >_BanCo.SoCot-5 )
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong+Dem, currCot + Dem].SoHuu != CurrSoHuu)
                    return false;
            }
            if (currDong == 0 || currDong + Dem == _BanCo.SoDong || currCot == 0 || currCot + Dem == _BanCo.SoCot)
                return true;
            if (_MangOCo[currDong-1, currCot - 1].SoHuu == 0 || _MangOCo[currDong+Dem, currCot + Dem].SoHuu == 0)
                return true;
            return false;
        }
        #endregion
        #region AI
        private long[] MangDiemTanCong = new long[7] { 0,3,27,99,729,6561,59049};
        private long[] MangDiemPhongNgu = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        public void KhoiDongComputer(Graphics g)
        {
            if (stack_CacNuocDaDi.Count == 0)
            {
                DanhCo(_BanCo.SoCot / 2 * OCo._ChieuRong + 1, _BanCo.SoDong / 2 * OCo._ChieuCao + 1, g);
            }
            else
            {
                OCo oco =TimKiemNuocDi();
                DanhCo(oco.ViTri.X+1,oco.ViTri.Y+1,g); 
            }
        }
         private OCo TimKiemNuocDi() 
         {
             OCo oCoResult=new OCo();
             long DiemMax =0;
             for (int i = 0; i < _BanCo.SoDong; i++)
             {
                 for (int j = 0; j < _BanCo.SoCot; j++)
                 {
                     if (_MangOCo[i, j].SoHuu == 0)
                     {
                         long DiemTanCong = DiemTC_DuyetDoc(i,j) + DiemTC_DuyetNgang(i,j) + DiemTC_DuyetCheoNguoc(i,j) + DiemTC_DuyetCheoXuoi(i,j);
                         long DiemPhongNgu = DiemPN_DuyetDoc(i, j) + DiemPN_DuyetNgang(i, j) + DiemPN_DuyetCheoNguoc(i, j) + DiemPN_DuyetCheoXuoi(i, j);
                         long DiemTam = DiemTanCong > DiemPhongNgu ? DiemTanCong : DiemPhongNgu;
                         if (DiemMax < DiemTam)
                         {
                             DiemMax = DiemTam;
                             oCoResult = new OCo(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].ViTri, _MangOCo[i, j].SoHuu);
                         }
                     }
                 }
             }
            return oCoResult;
         }
        private long DiemTC_DuyetDoc(int currDong,int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem =1; Dem < 6 && currDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[currDong + Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            for (int Dem =1; Dem < 6 && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[currDong - Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich+1]*2;
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetNgang(int currDong, int currCot)  
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem =1; Dem < 6 && currCot + Dem < _BanCo.SoCot; Dem++)
            {
                if (_MangOCo[currDong,currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[currDong, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            for (int Dem =1; Dem < 6 && currCot - Dem >=0; Dem++)
            {
                if (_MangOCo[currDong, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[currDong , currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++; 
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1]*2;
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem =1; Dem < 6 && currCot + Dem < _BanCo.SoCot && currDong - Dem >=0; Dem++)
            {
                if (_MangOCo[currDong -Dem, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            for (int Dem =1; Dem < 6 && currCot - Dem >= 0 && currDong+Dem <_BanCo.SoDong; Dem++)
            {
                if (_MangOCo[currDong +Dem, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[currDong +Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1]*2;
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetCheoXuoi(int currDong, int currCot)
        {
            {
                long DiemTong = 0;
                int SoQuanTa = 0;
                int SoQuanDich = 0;
                for (int Dem =1; Dem < 6 && currCot + Dem < _BanCo.SoCot && currDong + Dem <_BanCo.SoDong; Dem++)
                {
                    if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 1)
                    {
                        SoQuanTa++;
                    }
                    else if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 2)
                    {
                        SoQuanDich++;
                        break;
                    }
                    else
                        break;
                }
                for (int Dem =1; Dem < 6 && currCot - Dem >= 0 && currDong - Dem >=0; Dem++)
                {
                    if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 1)
                    {
                        SoQuanTa++;
                    }
                    else if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 2)
                    {
                        SoQuanDich++;
                        break;
                    }
                    else
                        break;
                }
                if (SoQuanDich == 2)
                    return 0;
                DiemTong -= MangDiemPhongNgu[SoQuanDich + 1]*2;
                DiemTong += MangDiemTanCong[SoQuanTa];
                return DiemTong;
            }
        }


        //
        private long DiemPN_DuyetDoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem =1; Dem < 6 && currDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int Dem =1; Dem < 6 && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }
        private long DiemPN_DuyetNgang(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem =1; Dem < 6 && currCot + Dem < _BanCo.SoCot; Dem++)
            {
                if (_MangOCo[currDong, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int Dem =1; Dem < 6 && currCot - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }
        private long DiemPN_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem =1; Dem < 6 && currCot + Dem < _BanCo.SoCot && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int Dem =1; Dem < 6 && currCot - Dem >= 0 && currDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }
        private long DiemPN_DuyetCheoXuoi(int currDong, int currCot)
        {
            {
                long DiemTong = 0;
                int SoQuanTa = 0;
                int SoQuanDich = 0;
                for (int Dem =1; Dem < 6 && currCot + Dem < _BanCo.SoCot && currDong + Dem < _BanCo.SoDong; Dem++)
                {
                    if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 1)
                    {
                        SoQuanTa++;
                        break;
                    }
                    else if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 2)
                    {
                        SoQuanDich++;
                    }
                    else
                        break;
                }
                for (int Dem =1; Dem < 6 && currCot - Dem >= 0 && currDong - Dem >= 0; Dem++)
                {
                    if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 1)
                    {
                        SoQuanTa++;
                        break;
                    }
                    else if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 2)
                    {
                        SoQuanDich++;
                    }
                    else
                        break;
                }
                if (SoQuanTa == 2)
                    return 0;
                DiemTong += MangDiemPhongNgu[SoQuanDich];
                return DiemTong;
            }
        }
         
        #endregion
    }

    
}
