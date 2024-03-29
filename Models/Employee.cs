﻿using System.ComponentModel.DataAnnotations;

namespace CrudEFbyMigration.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }       
        public string? Image { get; set; }

    }
}
