using System.Threading.Tasks;
using TimDemoApp.Web.Models.Tree;

namespace TimDemoApp.Web.Services
{
    public interface ITreeViewService
    {
        Task<TreeViewModel> GetTree();
    }
}
