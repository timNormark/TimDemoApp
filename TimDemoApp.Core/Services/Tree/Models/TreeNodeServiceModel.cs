namespace TimDemoApp.Core.Services.Tree.Models
{
    public record TreeNodeServiceModel(int NodeId, int? ParentNodeId, string NodeName, int NodeSortOrder);
}
