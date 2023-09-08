using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1444
{
    internal class Cipher
    {
        public static void makeCipher(int[] order, string path1, string path2)
        {
            string text = File.ReadAllText(path1).Trim().Replace(" ", "");
            string englishAlphabet = "abcdefghijklmnopqrstuvwxyz";
            int count = order.Count();
            if (text.Length % count != 0)
            {
                int paddingLength = count - (text.Length % count);
                StringBuilder result = new StringBuilder(text);
                for (int i = 0; i < paddingLength; i++)
                {
                    result.Append(englishAlphabet[i]);
                }
                text = result.ToString();
            }
            List<string> unmixed = new List<string>();
            List<string> mixed = new List<string>();
            for (int i = 0; i < text.Length / count; i++)
            {
                unmixed.Add(text.Substring(i * count, count));
            }
            foreach (string str in unmixed)
            {
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    strBuilder.Append(str[order[i] - 1]);
                }
                string s = strBuilder.ToString();
                mixed.Add(s);
            }
            File.WriteAllText(path2, string.Empty);
            foreach (string str in mixed)
            {
                File.AppendAllText(path2, str);
            }
            Console.WriteLine("Success!");
        }
    }
}
