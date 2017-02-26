using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace TestLibrary2
{
    
    public class TreeTests
    {
        [Fact]
        public void When_Tree_Are_Same_Expect_True()
        {
            var t1=new TreeNode()
                   {
                       UniqueName = "n1",
                       Children = new List<TreeNode>()
                                  {
                                      new TreeNode() {UniqueName = "n11"},
                                      new TreeNode() {UniqueName = "n12"}
                                  }
                   };
            var t2 = new TreeNode()
            {
                UniqueName = "n1",
                Children = new List<TreeNode>()
                                  {
                                      new TreeNode() {UniqueName = "n12"},
                                      new TreeNode() {UniqueName = "n11"}
                                  }

            };
            t1.ShouldBeEquivalentTo(t2);
        }
        
    }
}
