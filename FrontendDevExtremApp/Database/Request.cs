using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database
{
    public class Request
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Cookie { get; set; }
    }
}
