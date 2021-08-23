using TimDemoApp.Core.Services.Tree.Models;
using TimDemoApp.Web.Models.Tree;

namespace TimDemoApp.Web.Factories
{
    public static class TreeNodeViewModelFactory
    {
        public static TreeNodeViewModel Create(TreeNodeServiceModel n) =>
            new(n.NodeId, n.ParentNodeId, n.NodeName, n.NodeSortOrder);
    }
}
