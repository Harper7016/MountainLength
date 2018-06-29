using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 1, 1, 2, 2, 4, 4, 5, 5, 3, 3, 2, 3, 4, 6, 6, 7, 7, 2, 1, 1 };
            List<List<int>> result = new List<List<int>>();
            List<int> equal = new List<int>();
            List<int> temp = new List<int>();
            var compare = true;
            for (int i = 0; i < list.Count(); i++)
            {
                if (temp.Count == 0)
                {
                    equal.Add(list[i]);
                    temp.Add(list[i]);
                    continue;
                }
                else
                {
                    if (list[i] == temp.Last())
                    {
                        temp.Add(list[i]);
                        equal.Add(list[i]);
                        if (i == list.Count() - 1)
                        {
                            result.Add(temp.ToList());
                        }
                        continue;
                    }
                    if ((list[i] > temp.Last()) == compare)
                    {
                        temp.Add(list[i]);
                    }
                    else
                    {
                        compare = !compare;
                        if (temp.Count() > 1)
                        {
                            result.Add(temp.ToList());
                        }
                        temp = new List<int>();
                        temp.AddRange(equal.ToList());
                        temp.Add(list[i]);
                    }
                    equal.Clear();
                    equal.Add(list[i]);
                }
                if (i == list.Count() - 1)
                {
                    result.Add(temp.ToList());
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
            }

            List<List<int>> listResult = new List<List<int>>();
            var listTemp = new List<int>();
            for (int i = 0; i < result.Count; i++)
            {
                if (i == 0)
                {
                    listTemp = result[i];
                    continue;
                }
                listResult.Add(MergeList(listTemp, result[i]));
                listTemp = result[i];
            }
            listResult = listResult.OrderByDescending(i => i.Count()).ToList();
            Console.WriteLine("************************************************");
            foreach (var item in listResult)
            {
                Console.WriteLine(string.Join(",", item));
            }
            Console.ReadKey();
        }

        static List<int> MergeList(List<int> l1, List<int> l2)
        {
            var listTemp = l1.ToList();
            for (int i = 0; i < l2.Count; i++)
            {
                l1.Remove(l2[i]);
                if (l2[i] == l2[i + 1])
                {
                    l1.Remove(l2[i + 1]);
                }
                else
                {
                    break;
                }
            }
            l1.AddRange(l2);
            return l1;
        }
    }
}
