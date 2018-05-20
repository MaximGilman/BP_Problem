using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace МВИГ
{
    class Program
    {

        static public Info[] ReadInfo(string input)
        {
            string[] s;
            int N;
            Info[] objs;

            s = File.ReadAllLines(input);

       

        
            Info.MaxMass = int.Parse(s[0]);

             string[] m = s[1].Split(' ');

            N = m.Length;
             string[] c = s[2].Split(' ');

            objs = new Info[N];


            for (int i = 0; i < N; i++)
            {
                objs[i].N = i;
                objs[i].Mass = int.Parse(m[i]);
                objs[i].Cost = int.Parse(c[i]);
                objs[i].E = ((double)objs[i].Cost / (double)objs[i].Mass);

            }

            return objs;
        }

        static public TreeNode Solution(Info[] input)
        {
            TreeNode result = new TreeNode(input.Length);
            Tree tree = new Tree(input, result);

            bool ok = false;
            while (!ok)
            {
                Tree.AddLeafs(result);

                result = Tree.MaxCostLeaf();

                ok = (result.Level == Tree.Infos.Length);
            }


            return result;
        }

        static void Main(string[] args)
        {

            Info[] info = ReadInfo("input.txt");

            Array.Sort(info);

            Console.WriteLine(Solution(info).ToString());
            Console.ReadLine();
        }
    }
}
