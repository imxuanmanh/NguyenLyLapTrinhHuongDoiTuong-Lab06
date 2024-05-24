using System;

namespace _2312686_PhanLeXuanManh_Lab06
{
    internal class Bao : IAnPham
    {
        private float giaTien;
        private string nhaXuatBan;
        private string ten;

        public float GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; }
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

        public Bao()
        {
            Console.WriteLine("Nhập thông tin báo!");
            Console.Write("Tên: ");
            Ten = Console.ReadLine();
            Console.Write("Nhà xuất bản: ");
            NhaXuatBan = Console.ReadLine();
            Console.Write("Giá tiền: ");
            GiaTien = float.Parse(Console.ReadLine());
        }

        public Bao(string ten, string nhaXuatBan, float giaTien)
        {
            Ten = ten;
            NhaXuatBan = nhaXuatBan;
            GiaTien = giaTien;
        }

        public Bao(string line)
        {
            string[] s = line.Split(',');
            Ten = s[1];
            NhaXuatBan = s[2];

            GiaTien = float.Parse(s[3]);
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", "Bao", Ten, NhaXuatBan, GiaTien);
        }

        public void XuatThongTinAnPham()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|{0, -7}|{1, -20}|{2, -12}|{3, 8}|{4, -35}|", "Báo", Ten, NhaXuatBan, GiaTien, "");
            Console.ResetColor();
        }
    }
}