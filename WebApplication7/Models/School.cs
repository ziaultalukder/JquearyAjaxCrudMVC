﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}