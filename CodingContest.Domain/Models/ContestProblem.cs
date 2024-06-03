using System;

namespace CodingContest.Domain.Models
{
    public class ContestProblem
    {
        public Guid ContestId { get; private set; }
        public Guid ProblemId { get; private set; }

        private ContestProblem() { }

        public ContestProblem(Guid contestId, Guid problemId)
        {
            ContestId = contestId;
            ProblemId = problemId;
        }
    }
}
