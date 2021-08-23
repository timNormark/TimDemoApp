using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimDemoApp.Web.Services;

namespace TimDemoApp.Web.Views.Shared.Components.Tree
{
    public class TreeViewComponent : ViewComponent
    {
        private readonly ITreeViewService _treeViewService;

        public TreeViewComponent(ITreeViewService treeViewService)
        {
            _treeViewService = treeViewService ?? throw new ArgumentNullException(nameof(treeViewService));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var treeViewModel = await _treeViewService.GetTree().ConfigureAwait(false);
            return View(treeViewModel);
        }
    }
}
