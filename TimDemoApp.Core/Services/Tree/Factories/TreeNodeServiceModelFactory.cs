using TimDemoApp.Core.Repositories.Tree.Models;
using TimDemoApp.Core.Services.Tree.Models;

namespace TimDemoApp.Core.Services.Tree.Factories
{
    public static class TreeNodeServiceModelFactory
    {
        public static TreeNodeServiceModel Create(TreeNodeRepoModel n) =>
            new(n.NodeId, n.ParentNodeId, n.NodeName, n.NodeSortOrder);
    }
}
