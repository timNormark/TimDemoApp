using System.Threading.Tasks;
using TimDemoApp.Core.Services.Tree.Models;

namespace TimDemoApp.Core.Services.Tree
{
    public interface IGetTreeService
    {
        Task<TreeServiceModel> GetTree();
    }
}
