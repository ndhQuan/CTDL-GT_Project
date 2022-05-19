using System;
using System.Collections;
using System.IO;

namespace _21880109_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string myDir = Environment.CurrentDirectory;
            Console.WriteLine(myDir);
            StreamReader reader = new StreamReader($"{myDir}\\BIEUTHUC.INP.txt");
            int n = int.Parse(reader.ReadLine());
            Console.WriteLine("Lấy dữ liệu lên từ file BIEUTHUC.INP");
            double[] listKq = new double[n];
            for(int i =0; i < n; i++)
            {
                string s = reader.ReadLine();
                listKq[i] = XuLyBieuThucTrungTo.TinhGiaTriBieuThucTrungTo(s);
                Console.WriteLine(s);
            }
            reader.Close();

            Console.WriteLine();
            Console.WriteLine("##############################################################");
            Console.WriteLine("");
            StreamWriter writer = new StreamWriter($"{myDir}\\KETQUA.OUT.txt");
            Console.WriteLine("Danh Sach ket qua:");
            foreach(double Kq in listKq)
            {
                Console.WriteLine(Kq);
                writer.WriteLine(Kq);
            }
            writer.Close();
        }
    }
}
