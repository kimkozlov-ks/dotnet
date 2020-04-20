using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModel
{
    public class Request
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Cookie { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
