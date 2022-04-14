using System;

namespace CodeChallenge.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public CodeChallengeDbContext Context { get; }

        public UnitOfWork(CodeChallengeDbContext dbContext)
        {
            Context = dbContext;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }
    }
}
