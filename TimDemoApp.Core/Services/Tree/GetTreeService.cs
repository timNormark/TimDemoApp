using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimDemoApp.Core.Repositories.Tree;
using TimDemoApp.Core.Services.Tree.Factories;
using TimDemoApp.Core.Services.Tree.Models;

namespace TimDemoApp.Core.Services.Tree
{
    public class GetTreeService : IGetTreeService
    {
        private readonly ITreeRepository _treeRepository;

        public GetTreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository ?? throw new ArgumentNullException(nameof(treeRepository));
        }

        public async Task<TreeServiceModel> GetTree()
        {
            var treeNodeRepoModels = await _treeRepository.GetAllTreeNodes().ConfigureAwait(false);
            if (treeNodeRepoModels?.Any() != true)
                return null;

            var treeNodes = treeNodeRepoModels.Select(n => TreeNodeServiceModelFactory.Create(n));
            treeNodes = treeNodes.OrderBy(n => n.NodeSortOrder).ThenBy(n => n.NodeName);
            var groupedNodes = treeNodes.GroupBy(r => r.ParentNodeId);

            var treeRoot = new TreeServiceModel(treeNodes.Single(r => r.ParentNodeId == null));
            BuildTree(treeRoot, groupedNodes);

            return treeRoot;
        }

        private void BuildTree(TreeServiceModel currentNode, IEnumerable<IGrouping<int?, TreeNodeServiceModel>> groupedNodes)
        {
            var nodeChildrenGroup = groupedNodes.SingleOrDefault(g => g.Key == currentNode.Node.NodeId);
            var nodeChildren = nodeChildrenGroup?.ToList() ?? new List<TreeNodeServiceModel>();
            foreach (var child in nodeChildren)
            {
                var newNode = new TreeServiceModel(child);
                currentNode.ChildNodes.Add(newNode);
                BuildTree(newNode, groupedNodes);
            }
        }
    }
}
