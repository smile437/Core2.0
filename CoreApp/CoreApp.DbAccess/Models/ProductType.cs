﻿using System.ComponentModel.DataAnnotations;

namespace CoreApp.DbAccess.Models
{
    public class ProductType
    {
        [Key]
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
