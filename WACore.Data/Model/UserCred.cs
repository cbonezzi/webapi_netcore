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
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string Firstname { get; set; }
        [StringLength(20)]
        public string Lastname { get; set; }
    }
}
