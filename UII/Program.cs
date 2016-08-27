using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace UII
{
    class Program
    {
        public static string majorstart;
        public static List<KeyValuePair<string, int>> distlist = new List<KeyValuePair<string, int>>();
        public static List<string> seq = new List<string>();

        static void Main(string[] args)
        {
            Application oexcel = new Application();
            //Workbook owb = oexcel.Workbooks.Open(@"E:\DataStructure\DS_BG_1_0.xlsx");
            Workbook owb = oexcel.Workbooks.Open(@"E:\DataStructure\DS_sample1_simple1.xlsx");
            // Workbook owb = oexcel.Workbooks.Open(@"E:\DataStructure\DS_OD.xlsx");
            Worksheet ows = owb.Sheets[1];
            List<Node> NodeList = new List<Node>();
            int i = 2;
            do
            {
                int j = 2;
                Node TheNode = new UII.Node();
                TheNode.NodeName = ows.Cells[i, 1].Value.ToString();
                do
                {
                    if (String.Compare(ows.Cells[i, j].Value.ToString(), "") != 0)
                    {

                        string thisnode = ows.Cells[1, j].Value.ToString();
                        KeyValuePair<string, int> thekvp = new KeyValuePair<string, int>(thisnode, Convert.ToInt32(ows.Cells[i, j].Value.ToString()));
                        if (thekvp.Value != 0)
                        {
                            TheNode.nodedata.Add(thekvp);
                        }
                    }
                    j++;
                } while ((ows.Cells[i, j] as Range).Value != null);
                NodeList.Add(TheNode);
                i++;
            } while ((ows.Cells[i, 1] as Range).Value != null);

            //tying the tree view
            majorstart = Console.ReadLine();
            string start = majorstart;
            string stop = Console.ReadLine();

            int dist = 0;

            FindMinimumDistance(ref NodeList, start, stop, ref distlist, ref dist);

            foreach (var item in distlist)
            {

                Console.Write(start + "->" + item.Key + " : " + item.Value);
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.Write("The shortest Path is: ");
            distlist.Sort(Compare2);
            Console.Write(start + "->" + distlist[0].Key + " : " + distlist[0].Value);
            Console.ReadKey();

            owb.Close();
            oexcel.Quit();
        }

        static int Compare2(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            return a.Value.CompareTo(b.Value);
        }
       
        public static void FindMinimumDistance(ref List<Node> thenetwork, string start, string stop, ref List<KeyValuePair<string, int>> distances, ref int thedist)
        {

            IEnumerable<Node> node = from x in thenetwork
                                     where string.Equals(x.NodeName, start)
                                     select x;

            Node thenet = (Node)node.ToArray()[0];
            if (thenet.hasreached)
            {
                return;
            }

            thenet.hasreached = true;
            foreach (var item in thenet.nodedata)
            {
                IEnumerable<Node> n1 = from x in thenetwork
                                       where string.Equals(x.NodeName, item.Key)
                                       select x;
                if (!n1.ToArray()[0].hasreached)
                {
                    if (string.Compare(n1.ToArray()[0].NodeName, stop) == 0)
                    {
                        thedist = thedist + item.Value;
                        seq.Add(item.Key);
                        KeyValuePair<string, int> kp = new KeyValuePair<string, int>(string.Join("->", seq.ToArray()), thedist);
                        distances.Add(kp);
                    }
                    else
                    {
                        thedist = thedist + item.Value;
                        seq.Add(item.Key);
                        FindMinimumDistance(ref thenetwork, n1.ToArray()[0].NodeName, stop, ref distances, ref thedist);

                    }
                    seq.RemoveAt(seq.Count - 1);
                    thedist = thedist - item.Value;

                }
            }
            thenet.hasreached = false;
        }
    }
}

