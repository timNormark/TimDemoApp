using System;
using System.Threading.Tasks;
using TimDemoApp.Core.Services.Tree;
using TimDemoApp.Web.Factories;
using TimDemoApp.Web.Models.Tree;

namespace TimDemoApp.Web.Services
{
    public class TreeViewService : ITreeViewService
    {
        private readonly IGetTreeService _getTreeService;

        public TreeViewService(IGetTreeService getTreeService)
        {
            _getTreeService = getTreeService ?? throw new ArgumentNullException(nameof(_getTreeService));
        }

        public async Task<TreeViewModel> GetTree()
        {
            var treeServiceModel = await _getTreeService.GetTree().ConfigureAwait(false);
            return treeServiceModel != null ? TreeViewModelFactory.Create(treeServiceModel) : null;
        }
    }
}
