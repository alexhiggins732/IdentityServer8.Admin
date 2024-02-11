/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.ComponentModel.DataAnnotations;

namespace IdentityServer8.STS.Identity.ViewModels.Manage
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
        [MaxLength(255)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Display(Name = "Website")]
        public string Website { get; set; }

        [MaxLength(255)]
        [Display(Name = "Profile")]
        public string Profile { get; set; }

        [MaxLength(255)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [MaxLength(255)]
        [Display(Name = "City")]
        public string Locality { get; set; }

        [MaxLength(255)]
        [Display(Name = "Region")]
        public string Region { get; set; }

        [MaxLength(255)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [MaxLength(255)]
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
}
