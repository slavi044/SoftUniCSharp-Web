using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        string Create(string name, bool repositoryType, string ownerId);

        IEnumerable<RepositoryViewModel> GetAll();

        string GetNameById(string id);

        string GetIdByName(string name);
    }
}
