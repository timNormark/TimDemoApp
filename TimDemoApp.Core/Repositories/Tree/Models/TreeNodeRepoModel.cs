namespace TimDemoApp.Core.Repositories.Tree.Models
{
    public record TreeNodeRepoModel(int NodeId, int? ParentNodeId, string NodeName, int NodeSortOrder);
}
