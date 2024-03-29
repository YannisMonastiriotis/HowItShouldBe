﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HowItShouldBeDone.Models
{
    public class Artist
    {
        public int ID { get; set; }
        [Required(ErrorMessage= "FirstName is Required")]
        [StringLength(60,MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "FirstName is Required")]
        [StringLength(60, MinimumLength = 2)]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name ="Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public ICollection<Album> Albums { get; set; }
    }
}