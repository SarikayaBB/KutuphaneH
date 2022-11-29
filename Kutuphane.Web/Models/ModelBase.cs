﻿using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Web.Models
{
    public class ModelBase
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; }= DateTime.Now;
        public DateTime DateModified { get; set; }=DateTime.Now;

    }
}
