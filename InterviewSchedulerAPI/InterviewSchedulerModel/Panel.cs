﻿using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewSchedulerAPI.InterviewSchedulerModel
{
    public partial class Panel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public int LevelId { get; set; }
        public int JobId { get; set; }

        public virtual Job Job { get; set; }
        public virtual InterviewLevel Level { get; set; }
    }
}