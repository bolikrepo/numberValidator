using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace numberValidator
{
    public class VehicleVinOperations
    {

        private static int CHK_POSITION = 8;

        private static String VIN_CHAR_DICT = "A B C D E F G H J K L M N P R S T U V W X Y Z";
        private static String VIN_DIGIT_DICT = "1 2 3 4 5 6 7 8 1 2 3 4 5 7 9 2 3 4 5 6 7 8 9";
        
        private static String VIN_WEIGHT = "87654321298765432";

        private static readonly Regex regWS = new Regex(@"\s+");
        public static string remoteWS(string input, string replacement)
        {
            return regWS.Replace(input, replacement);
        }

        private String changeVinToDigitVin(String vin)
        {
            StringBuilder digitVin = new StringBuilder();

            foreach (char c in vin)
            {

                int char_pos = VIN_CHAR_DICT.IndexOf(c);

                if (char_pos != -1)
                {
                    digitVin.Append(VIN_DIGIT_DICT[char_pos]);
                }
                else
                {
                    digitVin.Append(c);
                }
            }
            return digitVin.ToString();
        }

        public int convertVinToCHK(String digitVin)
        {
            String vinW = remoteWS(VIN_WEIGHT, "");

            int chk = 0;

            for (int i = 0; i < digitVin.Length; i++)
            {
                int val = (int)Char.GetNumericValue(digitVin[i]);

                int charVal = 0;

                if (i != 7)
                {
                    charVal = (int)Char.GetNumericValue(vinW[i]);
                }
                else
                {

                    charVal = 10;
                }

                if (i != CHK_POSITION)
                {
                    chk += val * charVal;
                }
            }

            float temp = chk / 11;

            int output = (int)Math.Round(temp, 0);

            output *= 11;

            chk -= output;

            return chk;
        }

        private int addCHKToVin(String vin, int CHK)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < vin.Length; i++)
            {
                if (i != CHK_POSITION)
                {
                    builder.Append(vin[i]);
                }
                else
                {
                    if (CHK == 10)
                    {
                        builder.Append("X");
                    }
                    else
                    {
                        builder.Append(CHK);
                    }
                }
            }

            Console.WriteLine(builder.ToString());

            return 0;
        }


        public bool CheckVIN(String vin)
        {
            String dVin = changeVinToDigitVin(vin);
            int chk = convertVinToCHK(dVin);

            addCHKToVin(vin, chk);

            return false;
        }
        public String GetVINCountry(String vin)
        {
            return null;
        }

        public int GetTransportYear(String vin)
        {
            return 0;
        }
    }
}
