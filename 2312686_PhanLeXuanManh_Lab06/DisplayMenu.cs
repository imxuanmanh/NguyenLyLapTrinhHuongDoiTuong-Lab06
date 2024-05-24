using System;
using System.Text;

namespace _2312686_PhanLeXuanManh_Lab06
{
    public class DisplayMenu
    {
        DanhSachAnPham ds = new DanhSachAnPham();
        DanhSachAnPham kq = new DanhSachAnPham();
        private enum Menu
        {
            Thoat,
            XuatDanhSach,
            TimAnPhamCoGiaLonNhat,
            TimAnPhamTheoNhaXuatBan,
            HienThiAnPhamTheoGia,
            TongGiaTien,
            SapXepDanhSach, 
            TimAnPhamCoGiaThapNhat,
            XoaAnPhamCoGiaThapNhat,
            ChenAnPhamTruocViTriI,
            LuuDanhSach
        }
        
        private void XuatMenu()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n               CHƯƠNG TRÌNH QUẢN LÝ ẤN PHẨM");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Danh sách chức năng:");
            Console.ResetColor();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("0.  Thoát chương trình");
            Console.WriteLine("1.  Xuất danh sách ấn phẩm");
            Console.WriteLine("2.  Tìm ấn phẩm có giá lớn nhất");
            Console.WriteLine("3.  Tìm danh sách ấn phẩm theo nhà xuất bản");
            Console.WriteLine("4.  Hiển thị ấn phẩm theo giá");
            Console.WriteLine("5.  Tính tổng giá tiền của danh sách ấn phẩm");
            Console.WriteLine("6.  Sắp xếp danh sách ấn phẩm");
            Console.WriteLine("7.  Tìm các ấn phẩm có giá thấp nhất");
            Console.WriteLine("8.  Xóa các ấn phẩm có giá thấp nhất");
            Console.WriteLine("9.  Chèn ấn phẩm vào danh sách");
            Console.WriteLine("10. Lưu danh sách");
        }

        private Menu ChonMenu()
        {
            int chon;
            do
            {
                Console.WriteLine(new string('-', 60));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nhập chức năng cần thực hiện: ");
                Console.ResetColor();
                Console.WriteLine(new string('=', 60));
                for (int i = 3; i < 18; i++)
                {
                    Console.SetCursorPosition(59, i);
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition(30, 17);
                Console.ForegroundColor = ConsoleColor.Red;
                chon = int.Parse(Console.ReadLine());
                Console.ResetColor();
                if ((int)Menu.Thoat <= chon && chon <= (int)Menu.LuuDanhSach)
                    break;
            } while (true);
            return (Menu)chon;
        }

        private void XuLyMenu(Menu chon)
        {
            Console.Clear();
            switch (chon)
            {
                case Menu.XuatDanhSach:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0, 52}", "DANH SÁCH ẤN PHẨM");
                    Console.ResetColor();
                    ds.XuatDanhSach();
                    break;

                case Menu.TimAnPhamCoGiaLonNhat:
                    kq = ds.AnPhamCoGiaLonNhat();
                    Console.WriteLine("Danh sách ấn phẩm có giá lớn nhất:");
                    kq.XuatDanhSach();
                    break;
                
                case Menu.TimAnPhamTheoNhaXuatBan:
                    Color.Green("Nhập tên nhà xuất bản cần tìm: ");
                    string nxb = Console.ReadLine();
                    Console.Clear();
                    kq = ds.TimAnPhamTheoNhaXuatBan(nxb);
                    if (kq.Count == 0)
                        Console.WriteLine("Không có ấn phẩm nào thuộc nhà xuất bản " + nxb);
                    else
                    {
                        Console.WriteLine("Có tổng cộng {0} ấn phẩm thuộc nhà xuất bản {1}\nDanh sách:", kq.Count, nxb);
                        kq.XuatDanhSach();
                    } 
                        
                    break;

                case Menu.HienThiAnPhamTheoGia:
                    Color.Green("Nhập mức giá thấp nhất: ");
                    float min = float.Parse(Console.ReadLine());
                    Color.Green("Nhập mức giá cao nhất: ");
                    float max = float.Parse(Console.ReadLine());
                    Console.Clear();
                    kq = ds.HienThiAnPhamTheoGia(min, max);
                    if (kq.Count == 0)
                        Console.WriteLine("Không có ấn phẩm nào có giá nằm trong khoang [{0}, {1}]", min, max);
                    else
                    {
                        Console.WriteLine("Danh sách ấn phẩm có giá nằm trong khoảng [{0}, {1}]:", min, max);
                        kq.XuatDanhSach();
                        Console.WriteLine("Có tổng cộng {0} ấn phẩm có giá tiền phù hợp!", kq.Count);
                    } 

                    break;

                case Menu.TongGiaTien:
                    Console.WriteLine("Danh sách ấn phẩm:");
                    ds.XuatDanhSach();
                    Console.WriteLine(new String('-', 60));
                    Console.WriteLine("Tổng giá tiền của danh sách ấn phẩm: " + ds.TongGiaTien());
                    break;

                case Menu.SapXepDanhSach:
                    int loaisx;
                    do
                    {
                        Color.Green("Chọn kiểu sắp xếp\n");
                        Console.WriteLine(new String('-', 20));
                        Console.WriteLine("1. Tăng theo tên");
                        Console.WriteLine("2. Giảm theo tên");
                        Console.WriteLine("3. Tăng theo giá");
                        Console.WriteLine("4. Giảm theo giá");
                        Console.WriteLine(new String('-', 20));
                        Color.Green("Nhập 1 số để chọn: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        loaisx = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                        Console.Clear();
                        if (loaisx == 0)
                        {
                            Color.Green("Nhấn phím bất kì để tiếp tục!");
                            break;
                        }    
                        if (loaisx < 0 || loaisx > 4)
                        {
                            Color.Red("Lựa chọn không hợp lệ. Vui lòng chon lại hoặc chọn 0 để thoát!");
                            continue;
                        }
                        else
                        {
                            ds.SapXepDanhSach(loaisx);
                            break;
                        } 
                            
                    } while (true);

                    break;

                case Menu.TimAnPhamCoGiaThapNhat:
                    kq = ds.AnPhamCoGiaThapNhat();
                    Console.WriteLine("Danh sách ấn phẩm có giá thấp nhất:");
                    kq.XuatDanhSach();
                    Console.WriteLine("Số lượng: " + kq.Count);
                    break;

                case Menu.XoaAnPhamCoGiaThapNhat:
                    ds.XoaAnPhamCoGiaThapNhat();
                    Console.WriteLine("Đã xóa các ấn phẩm có giá thấp nhất!");
                    Console.WriteLine("Danh sách ấn phẩm sau khi xóa:");
                    ds.XuatDanhSach();
                    break;

                case Menu.ChenAnPhamTruocViTriI:
                    Console.Write("Nhập vị trí cần chèn: ");
                    int vt = int.Parse(Console.ReadLine());
                    Console.Clear();
                    int n;
                    do
                    {
                        Color.Green("Loại ấn phẩm muốn chèn\n");
                        Console.WriteLine(new String('-', 20));
                        Console.WriteLine("0. Thoát");
                        Console.WriteLine("1. Sách");
                        Console.WriteLine("2. Tạp chí");
                        Console.WriteLine("3. Báo");
                        Console.WriteLine(new String('-', 20));
                        Color.Green("Nhập 1 số để chọn: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        n = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                        Console.Clear();
                        if (n == 0)
                        {
                            Color.Green("Nhấn phím bất kì để tiếp tục!");
                            break;
                        }
                        if (n < 0 || n > 3)
                        {
                            Color.Red("Lựa chọn không hợp lệ. Vui lòng chon lại hoặc chọn 0 để thoát!");
                            continue;
                        }
                        else
                        {
                            string loai = n == 1 ? "Sach" : n == 2 ? "TapChi" : "Bao";
                            ds.ChenAnPham(vt, loai);
                            break;
                        }

                    } while (true);
                    break;
                case Menu.LuuDanhSach:
                    ds.LuuDanhSach();
                    Console.WriteLine("Danh sách đã được lưu lại!");
                    break;
            }
        }

        public void ChayChuongTrinh()
        {
            Menu chon;
            ds.NhapTuFile();
            do
            {

                Console.Clear();
                XuatMenu();
                chon = ChonMenu();
                if (chon == Menu.Thoat)
                    break;
                XuLyMenu(chon);
                Console.ReadKey();
            } while (true);
        }
    }
}
