using System.Collections.Generic;

namespace TimDemoApp.Core.Services.Tree.Models
{
    public class TreeServiceModel
    {
        public TreeNodeServiceModel Node { get; set; }
        public List<TreeServiceModel> ChildNodes { get; set; } = new List<TreeServiceModel>();

        public TreeServiceModel(TreeNodeServiceModel node)
        {
            Node = node;
        }

        public TreeServiceModel(TreeNodeServiceModel node, List<TreeServiceModel> childNodes)
        {
            Node = node;
            ChildNodes = childNodes ?? new List<TreeServiceModel>();
        }
    }
}
