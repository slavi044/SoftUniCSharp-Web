using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(string description, string creatorId, string repId)
        {
            Commit commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = creatorId,
                RepositoryId = repId
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();

            return commit.Id;
        }

        public IEnumerable<AllCommitViewModel> GetAll()
        {
            return null;
        }
    }
}
