namespace App.Domain.Models.Tree
{
    public interface INode
    {
        int Id { get; }
        string Path { get; set; }
    }
}
