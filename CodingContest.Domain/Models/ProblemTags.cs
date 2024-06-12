using System;

namespace CodingContest.Domain.Models
{
    public class ProblemTag
    {
        public Guid ProblemId { get; private set; }
        public Guid TagId { get; private set; }

        public Problem Problem { get; private set; }
        public Tag Tag { get; private set; }

        private ProblemTag() { }

        public ProblemTag(Guid problemId, Guid tagId)
        {
            ProblemId = problemId;
            TagId = tagId;
        }
    }
}
