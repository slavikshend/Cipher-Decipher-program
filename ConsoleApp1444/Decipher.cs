using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1444
{
    internal class Decipher
    {
        public static void doDecipher(int[] order, string path1, string path2)
        {
            string text = File.ReadAllText(path1).Trim().Replace(" ", "");
            List<string> unmixed = new List<string>();
            List<string> mixed = new List<string>();
            int count = order.Count();
            for (int i = 0; i < text.Length / count; i++)
            {
                unmixed.Add(text.Substring(i * count, count));
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < order.Length; i++)
            {
                dict.Add(i, order[i]);
            }
            dict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int[] keyArray = dict.Keys.ToArray();
            foreach (string str in unmixed)
            {
                StringBuilder strBuilder = new StringBuilder();
                for(int i = 0; i < count; i++)
                {
                    strBuilder.Append(str[keyArray[i]]);
                }
                string s = strBuilder.ToString();
                mixed.Add(s);
            }
            File.WriteAllText(path2, string.Empty);
            foreach (string str in mixed)
            {
                File.AppendAllText(path2, str + " ");
            }
            Console.WriteLine("Success!");
        }
    }
}
