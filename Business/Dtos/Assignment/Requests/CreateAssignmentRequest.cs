﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Assignment.Requests
{
    public class CreateAssignmentRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
