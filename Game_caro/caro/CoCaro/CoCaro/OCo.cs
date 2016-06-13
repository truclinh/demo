using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro
{
    class OCo
    {
        public const int _ChieuRong = 20;
        public const int _ChieuCao = 20;
        private int _Dong;
        public int Dong
        {
            set { _Dong = value; }
            get { return _Dong; }
        }
        private int _Cot;
        public int Cot
        {
            set { _Cot = value; }
            get { return _Cot; }
        }
        private Point _ViTri;// lưu lại vị trí của ô cờ trên bàn cờ
        public Point ViTri
        {
            set { _ViTri = value; }
            get { return _ViTri;}
        }
        private int _SoHuu;
        public int SoHuu
        {
            set { _SoHuu = value; }
            get { return _SoHuu; }
        }
        public OCo()
        {
        }
        public OCo(int dong, int cot, Point vitri, int sohuu)
        {
            _Dong = dong;
            _Cot = cot;
            _ViTri = vitri;
            _SoHuu = sohuu;
        }
    }
}
