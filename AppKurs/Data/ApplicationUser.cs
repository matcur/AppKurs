﻿using AppKurs.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppKurs.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string customUserName { get; set; }

        public ICollection<SolvedTask> SolvedTasks { get; set; }
    }
}
