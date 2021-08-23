using System.Collections.Generic;

namespace TimDemoApp.Web.Models.Tree
{
    public class TreeViewModel
    {
        public TreeNodeViewModel Node { get; set; }
        public List<TreeViewModel> ChildNodes { get; set; } = new List<TreeViewModel>();

        public TreeViewModel()
        {

        }

        public TreeViewModel(TreeNodeViewModel node)
        {
            Node = node;
        }

        public TreeViewModel(TreeNodeViewModel node, List<TreeViewModel> childNodes)
        {
            Node = node;
            ChildNodes = childNodes ?? new List<TreeViewModel>();
        }
    }
}
