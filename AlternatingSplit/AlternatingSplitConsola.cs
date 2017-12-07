using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*For building the encrypted string:
Take every 2nd char from the string, then the other chars, that are not every 2nd char, and concat them as new String.
Do this n times!*/
namespace AlternatingSplit.Main
{
    class AlternatingSplitConsola
    {
        static void Main(string[] args)
        {
            int x = 1;
            string a = AlternatingSplit.Library.AlternatingSplit.Encrypt(
                "This kata is very interestingaaa!", x);
            Console.WriteLine(a);
            Console.WriteLine(
                Library.AlternatingSplit.Decrypt(
                    a, x));
            Console.WriteLine(a.Length);
            //Console.WriteLine(a.Length/2);
            Console.WriteLine(a.LastIndexOf('X')+1);
            Console.Read();
        }
    }
}
