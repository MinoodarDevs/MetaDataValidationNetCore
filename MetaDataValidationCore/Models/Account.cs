using System;
using System.Collections.Generic;
using MetaDataValidationCore.Models.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace MetaDataValidationCore.Models
{
    [ModelMetadataType(typeof(AccountMetaData))]
    public partial class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public int Age { get; set; }
    }
}
