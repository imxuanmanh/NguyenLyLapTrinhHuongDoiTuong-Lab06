using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2312686_PhanLeXuanManh_Lab06
{
    public delegate int SoSanh(object a, object b);

    enum KieuSapXep
    {
        TangTheoTen,
        TangTheoGia
    }

    public class DanhSachAnPham : List<IAnPham>, IComparer<IAnPham>
    {
        DanhSachAnPham dskq;
        KieuSapXep kieu;
        public int Compare(IAnPham x, IAnPham y)
        {
            if (kieu == KieuSapXep.TangTheoTen)
                return x.Ten.CompareTo(y.Ten);
            return x.GiaTien.CompareTo(y.GiaTien);
        }
        
        public void NhapTuFile()
        {
            string path = @"dsanpham.txt";
            StreamReader sr = new StreamReader(path);
            string str = "";
            while ((str = sr.ReadLine()) != null)
            {
                string[] s = str.Split(',');
                if (s[0] == "Sach")
                    Add(new Sach(str));
                if (s[0] == "Bao")
                    Add(new Bao(str));
                if (s[0] == "Tap chi")
                    Add(new TapChi(str));
            }
        }

        private float GiaMax
        {
            get
            {
                float max = this[0].GiaTien;
                foreach (IAnPham ap in this)
                    if (ap.GiaTien > max)
                        max = ap.GiaTien;
                return max;
            }
        }
        public DanhSachAnPham AnPhamCoGiaLonNhat()
        {
            dskq = new DanhSachAnPham();
            foreach (IAnPham ap in this)
            {
                if (ap.GiaTien == GiaMax)
                    dskq.Add(ap);
            }
            return dskq;
        }

        public DanhSachAnPham TimAnPhamTheoNhaXuatBan(string nxb)
        {
            dskq = new DanhSachAnPham();
            foreach (IAnPham ap in this)
                if (ap.NhaXuatBan.CompareTo(nxb) == 0)
                    dskq.Add(ap);
            return dskq;
        }

        public DanhSachAnPham HienThiAnPhamTheoGia(float min, float max)
        {
            dskq = new DanhSachAnPham();
            foreach (IAnPham ap in this)
                if((ap.GiaTien >= min) && (ap.GiaTien <= max))
                { 
                    dskq.Add(ap); 
                }
            return dskq;
        }

        public float TongGiaTien()
        {
            float s = 0;
            foreach (IAnPham ap in this)
                s += ap.GiaTien;
            return s;
        }

        public void SapXepDanhSach(int loai)
        {
            switch (loai)
            {
                case 1:
                    kieu = KieuSapXep.TangTheoTen;
                    Sort(this);
                    Console.WriteLine("\nDanh sách đã được sắp xếp tăng theo tên!");
                    this.XuatDanhSach();
                    break;

                case 2:
                    int SoSanhGiamTen(object a, object b)
                    {
                        IAnPham ap1 = (IAnPham)a;
                        IAnPham ap2 = (IAnPham)b;
                        return -ap1.Ten.CompareTo(ap2.Ten);
                    }
                    this.SapXep(SoSanhGiamTen);
                    Console.WriteLine("\nDanh sách đã được sắp xếp giảm theo tên!");
                    this.XuatDanhSach();
                    break;

                case 3:
                    kieu = KieuSapXep.TangTheoGia;
                    Sort(this);
                    Console.WriteLine("\nDanh sách đã được sắp xếp tăng theo giá!");
                    this.XuatDanhSach();
                    break;

                case 4:
                    int SoSanhGiamGia(object a, object b)
                    {
                        IAnPham ap1 = (IAnPham)a;
                        IAnPham ap2 = (IAnPham)b;
                        return -ap1.GiaTien.CompareTo(ap2.GiaTien);
                    }
                    this.SapXep(SoSanhGiamGia);
                    Console.WriteLine("\nDanh sách đã được sắp xếp giảm theo giá!");
                    this.XuatDanhSach();
                    break;
            }    
        }

        public float Min
        {
            get { return this.Min(ap => ap.GiaTien); }
        }

        public DanhSachAnPham AnPhamCoGiaThapNhat()
        {
            dskq = new DanhSachAnPham();
            foreach (IAnPham ap in this)
                if (ap.GiaTien == Min)
                    dskq.Add(ap);
            return dskq;
        }

        public void XoaAnPhamCoGiaThapNhat()
        {
            for (int i = 0; i < this.Count; i++) 
            {
                if (this[i].GiaTien == Min)
                        this.Remove(this[i]);
            }
        }

        public void ChenAnPham(int vt, string loai)
        {
            switch (loai)
            {
                case "Sach":
                    this.Insert(vt-1, new Sach());
                    break;
                case "TapChi":
                    this.Insert(vt-1, new TapChi());
                    break;
                case "Bao":
                    this.Insert(vt-1, new Bao());
                    break;
            }
        }

        public void LuuDanhSach()
        {
            using (FileStream fs = new FileStream("dsanpham.txt", FileMode.Open)) // Mở file trong chế độ open
            {
                fs.SetLength(0); // Xóa nội dung cũ bằng cách set độ dài file về 0
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (IAnPham ap in this)
                    {
                        sw.WriteLine(ap.ToString());
                    }    
                }
            }
        }

        public void SapXep(SoSanh ss)
        {
            for (int i = 0; i < this.Count - 1; i++)
                for (int j = i + 1; j < this.Count; j++)
                    if (ss(this[i], this[j]) == 1)
                    {
                        IAnPham a = this[i];
                        this[i] = this[j];
                        this[j] = a;
                    }
        }

        public void XuatDanhSach()
        {
            Console.WriteLine(new String('=', 87) + '|');
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("|{0, -7}|{1, -20}|{2, -12}|{3, 8}|{4, -35}|", "Ấn phẩm", "       Tên", "Nhà xuất bản", "Giá tiền", "         Thông tin khác");
            Console.ResetColor();
            Console.WriteLine(new String('-', 87) + '|');
            foreach (IAnPham ap in this)
            {
                ap.XuatThongTinAnPham();
            }
            Console.WriteLine(new String('=', 87) + '|');
            Color.Green("\nNhấn phím bất kì để tiếp tục!");
        }
    }
}
