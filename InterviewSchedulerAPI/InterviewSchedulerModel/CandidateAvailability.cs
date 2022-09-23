using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewSchedulerAPI.InterviewSchedulerModel
{
    public partial class CandidateAvailability
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string AvailableDate { get; set; }
        public TimeSpan AvailableTimeFrom { get; set; }
        public TimeSpan AvailableTimeTo { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
