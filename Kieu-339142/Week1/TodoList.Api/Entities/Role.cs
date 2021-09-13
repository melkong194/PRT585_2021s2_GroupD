﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Entities;

namespace TodoList.Api.Entities
{
    public class Role: IdentityRole<Guid>
    {
        [MaxLength(250)]
        [Required]
        public string Description { get; set; }
    }
}
