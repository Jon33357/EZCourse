using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyEZCourse.Models.Entities
{

    [ModelMetadataType(typeof(UserMetadataType))]
    public partial class User
    {


    }

    public partial class UserMetadataType
    {
        [Required, StringLength(50, MinimumLength =2)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

    }
}
