using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalluffVisionConfigurator
{
    class Helper
    {
        public static int getIntFromString(string text)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int intresult = 0;
            
            Byte[] encodedBytes = ascii.GetBytes(text);
            int length = encodedBytes.Length;
            int base10 = 1;

            for (int i =length-1; i>=0; i--)
            {
                int temp = ((int)encodedBytes[i] -48 )*base10;
                
                intresult = intresult + temp;
                base10 = base10 * 10;

            }    

            return intresult;
        }

        public static double getFloatFromString(string text)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            double  floatresult = 0;

            Byte[] encodedBytes = ascii.GetBytes(text);
            int length = encodedBytes.Length;
            Int64 base10 = 1;

            int index = text.IndexOf(".");
            double Basekomma;
            if (index != -1)
            { Basekomma = Math.Pow(10, length - 1 - index); }
            else
            {  Basekomma = 1; }

                for (int i = length - 1; i >= 0; i--)
                {
                    if (encodedBytes[i] >= 48 & encodedBytes[i] <= 57)
                    {
                        double temp = ((double)encodedBytes[i] - 48) * base10;

                        floatresult = floatresult + temp;
                        base10 = base10 * 10;
                    }
                }
            floatresult = floatresult / Basekomma;

            return floatresult;
        }


    }
}
