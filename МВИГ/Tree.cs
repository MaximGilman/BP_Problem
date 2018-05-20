using System.Collections.Generic;

namespace МВИГ
{
    class Tree
    {
        static public List<TreeNode> Leafs;

        static public Info[] Infos;

        static public void AddLeafs(TreeNode root)
        {
            if (root.Level == Infos.Length)
            {
                root.Cost = 0;

                for (int i = 0; i < Infos.Length; i++)
                    if (root.ChoosenInfos[i])
                        root.Cost += Infos[i].Cost;
            }
            else
            {
                TreeNode left = new TreeNode(Infos, root, true);//+

                TreeNode right = new TreeNode(Infos, root, false);//-

                if (left.Mass <= Info.MaxMass)
                    Leafs.Add(left);

                Leafs.Add(right);

                Leafs.Remove(root);
            }
        }

        static public TreeNode MaxCostLeaf()
        {
            TreeNode leafResult = new TreeNode(1);
            leafResult.Cost = -1;
            for (int i = 0; i < Leafs.Count; i++)
                if (Leafs[i] > leafResult)
                    leafResult = Leafs[i];

            return leafResult;
        }

        public Tree(Info[] infos, TreeNode start)
        {
            Infos = infos;
            Leafs = new List<TreeNode>(infos.Length * 2);
            Leafs.Add(start);
        }
    }
    class TreeNode
    {
        public int Mass;
        public double Cost;
        public int Level;

        public bool[] ChoosenInfos;

        public TreeNode(Info[] infos, TreeNode prevNode, bool taken = false)
        {
            Level = prevNode.Level+1;

            //++ пройденный путь 
            ChoosenInfos = (bool[])prevNode.ChoosenInfos.Clone();

            for (int i = 0; i < infos.Length; i++)
                if (ChoosenInfos[i])
                    Cost += infos[i].Cost;

            Mass = prevNode.Mass;

            if (!taken)
            {

                if (Level < infos.Length)
                    Cost += (Info.MaxMass - Mass) * infos[Level].E;
            }
            else
            {
                ChoosenInfos[Level - 1] = true;
                Mass += infos[Level - 1].Mass;
                Cost += infos[Level - 1].Cost;

                if (Level < infos.Length)
                    Cost += (Info.MaxMass - Mass) * infos[Level].E
                        ;
            }
        }

        public TreeNode(int N)
        {
            Mass = 0;
            Cost = 0;
            Level = 0;
            ChoosenInfos = new bool[N];
        }

        static public implicit operator double(TreeNode node)
        {
            return node.Cost;
        }

        public override string ToString()
        {
            string str = " Вещи: ";
            for (int i = 0; i < ChoosenInfos.Length; i++)
                if (ChoosenInfos[i])
                {
                    Tree.Infos[i].N++;
                    str += " " + Tree.Infos[i].N.ToString() + " ,"; }
                   
          str=  str.Remove(str.Length - 2,2);
            str += "\nСтоимость: " + this.Cost.ToString();
            return str.Remove(0, 1);
        }
    }
}
