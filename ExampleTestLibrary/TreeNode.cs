using System.Collections.Generic;

namespace ExampleTestLibrary
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
