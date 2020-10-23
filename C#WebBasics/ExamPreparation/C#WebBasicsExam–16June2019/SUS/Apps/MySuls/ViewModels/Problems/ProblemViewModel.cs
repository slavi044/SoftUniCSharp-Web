using MySuls.ViewModels.Submissions;
using System.Collections.Generic;

namespace MySuls.ViewModels.Problems
{
    public class ProblemViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
