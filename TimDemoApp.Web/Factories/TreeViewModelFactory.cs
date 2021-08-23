using TimDemoApp.Core.Services.Tree.Models;
using TimDemoApp.Web.Models.Tree;

namespace TimDemoApp.Web.Factories
{
    public static class TreeViewModelFactory
    {
        public static TreeViewModel Create(TreeServiceModel treeServiceModelRoot)
        {
            var treeViewModelRoot = new TreeViewModel();
            mapTree(treeServiceModelRoot, treeViewModelRoot);

            static void mapTree(TreeServiceModel currentTreeServiceModel, TreeViewModel currentTreeViewModel)
            {
                currentTreeViewModel.Node = TreeNodeViewModelFactory.Create(currentTreeServiceModel.Node);
                foreach(var currentTreeServiceModelChild in currentTreeServiceModel.ChildNodes)
                {
                    var newTreeViewModelChild = new TreeViewModel();
                    currentTreeViewModel.ChildNodes.Add(newTreeViewModelChild);
                    mapTree(currentTreeServiceModelChild, newTreeViewModelChild);
                }
            }

            return treeViewModelRoot;
        }
    }
}
