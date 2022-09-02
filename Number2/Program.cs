
using System.Collections;

namespace Number1
{
    public class Number1
    {
        public static void Main(string[] agrs)
        {
            
            // Câu 1: chuyển 12.625 sang nhị phân floating point
            double num = 12.625;
            Cau1(num);
           
            // Câu 2: chuyển đổi từ 32 bit sang thập phân chấm động (-3050)
            string allstr = "11000101001111101010000000000000";
           
            Cau2(allstr);

        }
        public static void Cau2(string allstr)
        {
            string kq = "1";
            
            int exponentInt = binToInt(allstr.Substring(1, 8)) - 127;
            for (int i = 9; i < allstr.Length; i++)
            {
                if (i == 9 + exponentInt)
                {
                    kq += ".";
                }
                kq += allstr[i];
            }
           
            kq = shortedstr(kq);
            
            string[] kqA = kq.Split(".");
            
            double floatPart = FloatToInt(kqA[1]);
            double intpart = binToInt(kqA[0]);
            if(allstr[0] == '1') {
                Console.WriteLine(-1 *intpart + floatPart);
            }
            else
            {
                Console.WriteLine(intpart + floatPart);
            }
           
        }
        public static string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
        public static double FloatToInt(string str)
        {
            double kq = 0;
            for(int i = 0; i<str.Length;i++)
            {
                if (str[i] == '1')
                {
                    kq += Math.Pow(2, -i-1);
                }
            }
            return kq;
        }
        public static string shortedstr(string str)
        {
            
            for(int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == '1')
                {
                    str = str.Substring(0, i+1);
                    break;

                }
                else if (str[i] == '.')
                {
                    break;
                }

            }
            
            return str;
        }
        public static int binToInt(string str)
        {
            int kq = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '1')
                {
                    kq += Convert.ToInt32(Math.Pow(2, str.Length-1 - i));
                }
            }
            return kq;
        }
        public static int FindE(int num)
        {
            return num - 127;
        }
        public static void Cau1(double num)
        {

            
            Console.WriteLine(num);
            string sign = num < 0 ? "1" : "0";
            num = Math.Abs(num);
            string exponent = Exponent(num);
            string intpart = ConvertIntToBin(Convert.ToInt32(Math.Floor(num)));
            string floatpart = ConvertFloatToBin(num - Math.Floor(num));
            string significant = intpart.Substring(1, intpart.Length - 1) + floatpart;

            while (significant.Length < 23)
            {
                significant = significant + "0";
            }
            string kq = sign + exponent + significant;
            //Console.WriteLine(kq.Length);
            PrintFloatingBin(kq);
        }
        public static void PrintFloatingBin(string bin)
        {
            string kq = "";
            for(int i = 0; i < 32; i++)
            {
                if(i == 1 || i == 9)
                {
                    kq += " ";
                }
                
                kq += bin[i];
                
            }
            Console.WriteLine(kq);
        }
        public static string Exponent(double num)
        {
            string kq = "";
            string temp = ConvertIntToBin(Convert.ToInt32(Math.Floor(num)));
            
            kq = ConvertIntToBin(127 + (temp.Length - 1));
            return kq;
        }
        public static string FloatToBin(double num)
        {
            string kq= "";
            
           
            string Numb = ConvertIntToBin(Convert.ToInt32(Math.Floor(num)));
           
            string floats = ConvertFloatToBin(num - Convert.ToInt32(Math.Floor(num)));
            kq = Numb +"." + floats;
            return kq;

        }
        public static string ConvertFloatToBin(double num)
        {
            string kq="";
            int i = 0;
            while(num>0 && i< 23)
            {
                num = num * 2;
                if (num  >= 1)
                {
                    kq += "1";
                    num = num - 1;
                }
                else
                {
                    kq += "0";
                        }
            }
            return kq;

        }
        public static string ConvertIntToBin(int num)
        {
            string str = "";
            while(num > 0)
            {
                string temp = Convert.ToString(num % 2);
                str =  temp+str;
                num /= 2;
            }
            return str;
        }


        //public static BitArray ConvertDecimal2Bin(double num, BitArray bin)
        //{
        //    int i = 0;
        //    while (num > 0 && i < bin.Length)
        //    {
        //        num = num * 2;
        //        if (num >= 1)
        //        {
        //            bin[i] = true;
        //            num = num - 1;
        //        }
        //        else
        //        {
        //            bin[i] = false;
        //        }
        //        i += 1;
        //    }
        //    return bin;
        //}
        //public static BitArray ConvertIntToBin(int a, BitArray bin)
        //{
        //    int i = 0;
        //    while (a>0)
        //    {
        //        int b = a  & 1;
        //        if(b == 1 ) {
        //            bin[bin.Length - i-1] = true; 
        //        }
        //        else { bin[bin.Length - i-1] = false; }
        //        i += 1;
        //        a = a >> 1;
        //    }
        //    return bin;
        //}
        //public static int FindIndexArray(BitArray bin)
        //{
        //    int kq = 0;
        //    for (int i = 0; i < bin.Length; i++)
        //    {
        //        if (bin[i] == true)
        //        {
        //            kq = bin.Length - i-1;
        //            break;
        //        }
        //    }
        //    return kq;
        //}
        //public static BitArray Exponent(BitArray BinaryF)
        //{
        //    BitArray bin = new BitArray(8);
        //    int num = FindIndexArray(BinaryF) + 127;
        //    bin = ConvertIntToBin(num, bin);
        //    return bin;
        //}
        //public static int ConvertBinToInt(BitArray bin)
        //{
        //    double kq = 0;
        //    int len = bin.Length;
            
        //    for (int i = 0; i < bin.Length; i++)
        //    {
        //        if(bin[i] == true)
        //        {
        //            double v = Math.Pow(2, len - i - 1);
        //            kq += v;
        //        }
        //    }
        //    return Convert.ToInt32(kq);
        //}
        //public static void PrintBinary(BitArray bin)
        //{
        //    foreach (bool b in bin)
        //    {
        //        if(b == true)
        //        {
        //            Console.Write(1);
        //        }
        //        else { Console.Write(0); }
        //    }
        //}

    }
}