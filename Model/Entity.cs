﻿using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Model
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; protected set; }
        public bool IsDeleted { get; set; }
    }
}
