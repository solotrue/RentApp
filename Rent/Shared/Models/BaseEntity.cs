﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
    public abstract class BaseEntity
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Введите название")]
        [StringLength(60, ErrorMessage = "Название не может быть более 60 символов")]    
        public string Title { get; set; }
    }
}
