using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string? UserName {  get; set; }
        public string? UserAddress { get; set; }
        public string? UserCity { get; set; }
        public string? UserState { get; set; }
        public string? UserPostCode { get; set; }
    }
}
