using System.Collections.Generic;
using System.Threading.Tasks;
using TimDemoApp.Core.Repositories.Tree.Models;

namespace TimDemoApp.Core.Repositories.Tree
{
    public interface ITreeRepository
    {
        Task<IEnumerable<TreeNodeRepoModel>> GetAllTreeNodes();
    }
}
