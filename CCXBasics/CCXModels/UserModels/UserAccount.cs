using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CCXModels.domain.UserModels
{
    public class UserAccount
    {
        [Required(ErrorMessage ="Login id is required.")]
        public string LoginId { get; set; }

        [Required(ErrorMessage ="Password is required.") ]
        public string Password { get; set; }
    }
}
