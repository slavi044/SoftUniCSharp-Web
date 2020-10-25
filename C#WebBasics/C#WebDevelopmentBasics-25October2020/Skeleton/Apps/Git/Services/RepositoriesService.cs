using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(string name, bool repositoryType, string ownerId)
        {
            Repository repository = new Repository
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = repositoryType,
                OwnerId = ownerId
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();

            return repository.Id;
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            var repositories = this.db.Repositories
                .Select(x => new RepositoryViewModel
                {
                    Name = x.Name,
                    DateTime = x.CreatedOn,
                    Commits = x.Commits.Count(),
                    Owner = x.Owner.Username
                })
                .ToList();

            return repositories;
        }

        public string GetIdByName(string name)
        {
            return this.db.Repositories
                .Where(x => x.Name == name)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public string GetNameById(string id)
        {
            return this.db.Repositories
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }
    }
}
