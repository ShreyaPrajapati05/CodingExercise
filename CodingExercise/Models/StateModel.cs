using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingExercise.Models
{
    public class StateModel
    {
        [Required]
        public int id { get; set; }
        public String StateName { get; set; }
    }
}