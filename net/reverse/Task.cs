using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Task
    {
        struct dword
        {
            public string text;
            public int position;
            public bool novalid;
        };

        public void Execute()
        {
            string str = "hello world from maria Jupiter! hello hello tomorrow hello yes hello good maria";
            string[] words = str.Split(" ");

            dword d;

            List<dword> wordsx = new List<dword>();
            List<dword> wordsi = new List<dword>();

            int order = 0; //indicate words order from original sentence

            //iterating through words
            foreach (string w in words)
            {
                if (w.Length % 2 == 0) //even number of characters
                {
                    char[] ac = w.ToCharArray().Reverse<char>().ToArray();
                    string m = string.Join("", ac);

                    d.text = m; //word reversed
                    d.position = order;
                    d.novalid = false;

                    wordsi.Add(d);
                }
                else //uneven number of characters
                {
                    d.text = w;
                    d.position = order;
                    d.novalid = false;

                    wordsx.Add(d);
                }

                order++;
            }

            int count = 0;
            int current_index = 0;

            List<dword> wordsv = new List<dword>();

            //iterating through uneven number of characters
            foreach (dword ww in wordsx)
            {
                int var_index = 0;
                bool novalid = false;

                count = 0;

                foreach (dword wx in wordsx)
                {
                    var_index++;

                    if (ww.text == wx.text && var_index > (current_index + 1))
                    {
                        count++;

                        if (count >= 1) //word repeated ocurrence
                        {
                            novalid = true;
                        }
                    }
                }

                d.text = ww.text;
                d.position = ww.position;
                d.novalid = false;

                if (novalid)
                {
                    d.text = $"*{d.text}*";
                    d.novalid = novalid;
                }

                wordsv.Add(d);
                current_index++;
            }

            //wordsv contains unrepeated words 
            //which every length word contains even number of characters
            foreach (dword wi in wordsi)
            {
                wordsv.Add(wi);
            }

            string[] new_words = { };
            List<string> list = new List<string>();

            foreach (int i in Enumerable.Range(1, words.Length)) { list.Add(""); }

            new_words = list.ToArray();
            count = 0;

            foreach (dword ii in wordsv)
            {
                count++;

                if (!(ii.novalid))
                {
                    new_words[ii.position] = ii.text;
                }
            }

            string new_str = string.Join(" ", new_words);

            Console.WriteLine("original string: {0}", str);
            Console.WriteLine("new string: {0}", new_str);
            Console.WriteLine("new string sorted length: {0}", new_str.Length);
        }

        public void Pause()
        {
            Console.Read(); //make pause before quitting the program
        }

        public void Close()
        {
            Environment.Exit(0);
        }
    }


}
