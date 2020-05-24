using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MetaDataValidationCore.Models.MetaData
{
    public class AccountMetaData
    {
        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(150)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Url]
        [MaxLength(250)]
        public string WebSite { get; set; }

        [Required]
        public int Age { get; set; }
    }

}
