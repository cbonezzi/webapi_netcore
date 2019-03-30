using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WACore.Data.Model
{
    public partial class UserCred
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(8)]
        public string Expire { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
    }
}
