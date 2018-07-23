using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TernopilDotNetDatabase
{
    public class CommentRepository: ICommentRepository
    {
        protected DbSet<Comment> dbSet;
        protected CommentContext dbContext;

        public CommentRepository(CommentContext dataContext)
        {
            this.dbSet = dataContext.Set<Comment>();
            this.dbContext = dataContext;
        }

        public IQueryable<Comment> Get()
        {
            return this.dbSet;
        }

        public Comment Create(Comment entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Added;
            this.dbSet.Add(entity);

            this.dbContext.SaveChanges();

            return entity;
        }
    }
}
