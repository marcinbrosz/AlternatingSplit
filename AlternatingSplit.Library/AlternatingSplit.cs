using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*For building the encrypted string:
Take every 2nd char from the string, then the other chars, that are not every 2nd char, and concat them as new String.
Do this n times!*/
namespace AlternatingSplit.Library
{
    public class AlternatingSplit
    {
        public static string Encrypt(string text, int n)
        {
            //simple solution
            /*for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                        if ((j%2)>0 && j>0)
                        {
                            result1 += text[j];
                        }
                        else
                        {
                            result2 += text[j];
                        }
                }
            }
             */

            //with linq
            /*if (text != null)
            {
                for (int j = 0; j < n; j++)
                {
                    text =  string.Join("", text
                        .Select((x, i) => new { x, i })
                        .Where(y => y.i % 2 > 0 && y.i > 0)
                        .Select(res => res.x.ToString()))
                        +string.Join("", text
                        .Select((x, i) => new { x, i })
                        .Where(y => y.i % 2 == 0 | y.i == 0)
                        .Select(res => res.x.ToString()));
                }
            }
            return text;
            //*/

            //with concat
            if (string.IsNullOrEmpty(text)||n<1)
                return text;

            while (n > 0)
            {
                text = string.Concat(text.Where((c, i) => i % 2 == 1).
                    Concat(text.Where((c, i) => i % 2 == 0)));
                n--;
            }

            return text;
        }

        public static string Decrypt(string encryptedText, int n)
        {
            //first solution
            /*
            if (encryptedText != null)
            {
                int count = (encryptedText.Length / 2);//first position
                string result = string.Empty;
                int count_temp = 0;

                for (int i = 0; i < n; i++)
                {
                    count_temp = count;
                    result = string.Empty;

                    for (int j = 0; j < encryptedText.Length && count_temp < encryptedText.Length; j++)
                    {
                        if ((count_temp + 1) == encryptedText.Length && (encryptedText.Length % 2) > 0)
                        {
                            result += encryptedText[count_temp].ToString();
                            break;
                        }
                        else
                        {
                            result += encryptedText[count_temp].ToString() + encryptedText[j].ToString();
                            count_temp++;
                        }
                    }
                    encryptedText = result;
                    result = string.Empty;
                }
            }
            return encryptedText;*/

            if (string.IsNullOrEmpty(encryptedText) || n < 1)
                return encryptedText;

            while (n > 0)
            {
                string left = string.Join("", encryptedText.Take(encryptedText.Length / 2));
                string right = string.Join("", encryptedText.Skip(encryptedText.Length / 2));
                
                encryptedText = string.Join("", Enumerable.Range(0, encryptedText.Length)
                    .Select(i => i % 2 == 0 ? right[i/2] : left[i/2]));
                n--;
            }

            return encryptedText;
        }
    }
}
