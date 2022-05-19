using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21880109_Project
{
    public class XuLyBieuThucTrungTo
    {
        public static int BacToanTu(char ToanTu)
        {
            int BacToanTu = 0;
            if (ToanTu == '+' || ToanTu == '-')
                return BacToanTu = 1;
            if (ToanTu == '*' || ToanTu == '/')
                return BacToanTu = 2;
            if (ToanTu == '^')
                return BacToanTu = 3;
            if (ToanTu == '!')
                return BacToanTu = 4;
            return BacToanTu;
        }
        public static double SuDungToanTu(double b, double a, char c)
        {
            switch (c)
            {
                case '+': 
                    return a + b;
                case '-': 
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        Exception myException = new Exception("Số chia phải khác 0");
                        throw myException;
                    }
                    return a / b;
                case '^':
                    return Math.Pow(a, b);
                case '!':
                    int h = Convert.ToInt32(b);
                    return TinhGiaiThua(h);
            }
            return 0;
        }
        public static int TinhGiaiThua(int n)
        {
            int i = 1;
            while (n > 0)
            {
                i *= n;
                n--;
            }
            return i;
        }
        public static double TinhGiaTriBieuThucTrungTo(string infix)
        {
            Stack ToanTu = new Stack();            //Stack chứa các toán tử của biểu thức 
            Stack KetQuaHauTo = new Stack();       //Stack chứa các toán hạng và kết quả của biểu thức
            for (int i = 0; i < infix.Length; i++)    //Duyệt từng char trong biểu thức infix
            {
                if(infix[i] == ' ')
                {
                    continue;
                }
                else if(infix[i] >= '0' && infix[i] <= '9')   //Nếu infix[i] là toán hạng
                {
                    StringBuilder number = new StringBuilder();
                    //Xét các số có nhiều hơn 2 chữ số hoặc số thập phân có dấu '.'
                    while (i < infix.Length && infix[i] >= '0' && infix[i] <= '9' || i < infix.Length && infix[i] == '.')
                    {
                        number.Append(infix[i]);
                        i++;
                        
                    }
                    KetQuaHauTo.PushNumber(double.Parse(number.ToString()));
                    i--;    //trừ đi chỉ số i một đơn vị
                }
                else if(infix[i] == '(')
                {
                    ToanTu.PushCharacter(infix[i]);
                }
                else if(infix[i] == ')')
                {
                    while(ToanTu.PeekChar() != '(' )
                    {
                        KetQuaHauTo.PushNumber(SuDungToanTu(KetQuaHauTo.PopNumber(), KetQuaHauTo.PopNumber(), ToanTu.PopCharacter()));
                    }
                    ToanTu.PopCharacter();
                }
                else if(infix[i] == '+' ||
                        infix[i] == '-' || 
                        infix[i] == '*' ||
                        infix[i] == '/' ||
                        infix[i] == '!' ||
                        infix[i] == '^')
                {
                    if(infix[i] == '-')
                    {
                        if (i == 0 || infix[i - 1] == '(')
                        {
                            KetQuaHauTo.PushNumber(0);
                        }
                    }
                    while (!ToanTu.isEmpty() && BacToanTu(infix[i]) <= BacToanTu(ToanTu.PeekChar()))
                    {
                        if (ToanTu.PeekChar() == '!')   //Giai thừa là toán tử 1 ngôi
                            {
                                KetQuaHauTo.PushNumber(SuDungToanTu(KetQuaHauTo.PopNumber(), 0, ToanTu.PopCharacter()));
                            }
                        else
                            {
                                KetQuaHauTo.PushNumber(SuDungToanTu(KetQuaHauTo.PopNumber(), KetQuaHauTo.PopNumber(), ToanTu.PopCharacter()));
                            }

                    }
                    ToanTu.PushCharacter(infix[i]);
                }
                
            }
            while(!ToanTu.isEmpty())
            {
                if (ToanTu.PeekChar() == '!')   //Giai thừa là toán tử 1 ngôi
                {
                    KetQuaHauTo.PushNumber(SuDungToanTu(KetQuaHauTo.PopNumber(), 0, ToanTu.PopCharacter()));
                }
                else
                {
                    KetQuaHauTo.PushNumber(SuDungToanTu(KetQuaHauTo.PopNumber(), KetQuaHauTo.PopNumber(), ToanTu.PopCharacter()));
                }
            }
            return KetQuaHauTo.PopNumber();
        }
    }
}
