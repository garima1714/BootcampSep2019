using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examportal.Custom_Models
{
    public class CandidatePerformanceCustomModel
    {
        public string Email { get; set; }
        public int? TotalScore { get; set; }
        public string TestCode { get; set; }
        public byte? SubmitExam { get; set; }
        public string Answers { get; set; }
    }
}
