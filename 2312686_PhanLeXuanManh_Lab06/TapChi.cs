using System;

namespace _2312686_PhanLeXuanManh_Lab06
{
    public class TapChi : IAnPham
    {
        public string diaChi;
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

        public TapChi()
        {
            Console.WriteLine("Nhập thông tin sách!");
            Console.Write("Tên: ");
            Ten = Console.ReadLine();
            Console.Write("Nhà xuất bản: ");
            NhaXuatBan = Console.ReadLine();
            Console.Write("Giá tiền: ");
            GiaTien = float.Parse(Console.ReadLine());
            Console.Write("Địa chỉ: ");
            diaChi = Console.ReadLine();
        }

        public TapChi(string ten, string nhaXuatBan, float giaTien, string diaChi)
        {
            Ten = ten;
            NhaXuatBan = nhaXuatBan;
            GiaTien = giaTien;
            this.diaChi = diaChi;
        }

        public TapChi(string line)
        {
            string[] s = line.Split(',');
            Ten = s[1];
            NhaXuatBan = s[2];
            GiaTien = int.Parse(s[3]);
            diaChi = s[4];
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4}", "Tap chi", Ten, NhaXuatBan, GiaTien, diaChi);
        }

        public void XuatThongTinAnPham()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|{0, -7}|{1, -20}|{2, -12}|{3, 8}|Địa chỉ: {4, -26}|", "Tạp chí", Ten, NhaXuatBan, GiaTien, diaChi);
            Console.ResetColor();
        }
    }
}
