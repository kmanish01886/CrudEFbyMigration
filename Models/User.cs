using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEFbyMigration.Models
{
    public class User
    {
        [Key]
        public int Id {get; set; }
        [Required(ErrorMessage ="Please Enter your First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Please Enter your Last Name")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please Enter Your Gender ")]
        [Display(Name ="Gender")]
        public string Gender { get; set; }
        [Required(AllowEmptyStrings =false ,ErrorMessage ="Please Enter your Email")]
        [DataType(DataType.EmailAddress)] 
        [Display(Name ="Email ")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter your Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage ="Minimum 6 character required")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please enter confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Confirm Password and Password do not match")]
        [Display(Name = "ConfirmPassword")]

        public string ConfirmPassword { get; set; }
        //[ForeignKey("userRoleId")]
        //public int userRoleId { get; set; }
        //public virtual UserRole userRoleName { get; set; }
    }
}
