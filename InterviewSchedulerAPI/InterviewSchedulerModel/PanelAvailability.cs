using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewSchedulerAPI.InterviewSchedulerModel
{
    public partial class PanelAvailability
    {
        public int Id { get; set; }
        public int PanelId { get; set; }
        public string AvailableDate { get; set; }
        public TimeSpan AvailableTimeFrom { get; set; }
        public TimeSpan AvailableTimeTo { get; set; }

        public virtual Panel Panel { get; set; }
    }
}
