namespace TimDemoApp.Web.Models.Tree
{
    public record TreeNodeViewModel(int NodeId, int? ParentNodeId, string NodeName, int NodeSortOrder);
}
