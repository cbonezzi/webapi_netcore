using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WACore.Data.Model
{
    public partial class UserInfo
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(1)]
        public string Middle { get; set; }
        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
    }
}
