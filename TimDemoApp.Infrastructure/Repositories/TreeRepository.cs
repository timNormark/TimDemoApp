using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TimDemoApp.Core.Repositories.Tree;
using TimDemoApp.Core.Repositories.Tree.Models;

namespace TimDemoApp.Infrastructure.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        private static readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

        public async Task<IEnumerable<TreeNodeRepoModel>> GetAllTreeNodes()
        {
            var allNodesStr = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/SimulatedDatabase.json");
            if (string.IsNullOrWhiteSpace(allNodesStr))
                return null;

            return JsonSerializer.Deserialize<IEnumerable<TreeNodeRepoModel>>(allNodesStr, _jsonOptions);
        }
    }
}
