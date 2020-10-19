using SulsExamPrep.ViewModels.Problems;
using System.Collections.Generic;

namespace SulsExamPrep.Services
{
    public interface IProblemService
    {
        void Create(string name, ushort points);

        IEnumerable<HomePageProblemViewModel> GetAll();

        string GetNameById(string id);

        ProblemViewModel GetById(string id);
    }
}
