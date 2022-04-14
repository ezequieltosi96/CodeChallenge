using System;

namespace CodeChallenge.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        CodeChallengeDbContext Context { get; }

        void Commit();
    }
}
