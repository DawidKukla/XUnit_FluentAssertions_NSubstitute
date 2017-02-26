using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary2
{
    public class TreeNode
    {
        public string UniqueName { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode()
        {
            Children=new List<TreeNode>();
        }
        
    }


}
