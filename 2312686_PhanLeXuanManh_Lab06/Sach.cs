using System;

namespace _2312686_PhanLeXuanManh_Lab06
{
    public class Sach : IAnPham
    {
        private float giaTien;
        private string nhaXuatBan;
        public int soTrang;
        private string ten;

        public float GiaTien
        {
            get { return giaTien; }
            set { giaTien = value;}
        }

        public string NhaXuatBan
        {
            get { return nhaXuatBan; }
            set { nhaXuatBan = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public int SoTrang
        {
            get { return soTrang; }
            set { soTrang = value;}
        }

        public Sach()
        {
            Console.WriteLine("Nhập thông tin sách!");
            Console.Write("Tên: ");
            Ten = Console.ReadLine();
            Console.Write("Nhà xuất bản: ");
            NhaXuatBan = Console.ReadLine();
            Console.Write("Giá tiền: ");
            GiaTien = float.Parse(Console.ReadLine());
            Console.Write("Số trang: ");
            SoTrang = int.Parse(Console.ReadLine());
        }

        public Sach(string ten, string nhaXuatBan, float giaTien, int soTrang)
        {
            Ten = ten;
            NhaXuatBan = nhaXuatBan;
            GiaTien = giaTien;
            SoTrang = soTrang;
        }

        public Sach(string line)
        {
            string[] s = line.Split(',');
            Ten = s[1];
            NhaXuatBan = s[2];
            SoTrang = int.Parse(s[3]);
            GiaTien = float.Parse(s[4]);
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4}", "Sach", Ten, NhaXuatBan, SoTrang, GiaTien);
        }

        public void XuatThongTinAnPham()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("|{0, -7}|{1, -20}|{2, -12}|{3, 8}|Số trang: {4, -25}|", "Sách", Ten, NhaXuatBan,GiaTien, SoTrang);
            Console.ResetColor();
        }
    }
}
