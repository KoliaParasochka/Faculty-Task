﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int Grade { get; set; }

        public int? CourseId { get; set; }
        public int? StudentId { get; set; }
    }
}
