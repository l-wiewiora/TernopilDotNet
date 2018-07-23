using System.Linq;

namespace TernopilDotNetDatabase
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Get();
        Comment Create(Comment entity);
    }
}