using System.ComponentModel.DataAnnotations;

namespace CrudEFbyMigration.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter your RoleId ...")]
        [Display(Name ="userRoleId")]
        public int userRoleId { get; set; }
        [Required(ErrorMessage ="Please Enter your RoleName")]
        [Display(Name ="RoleName")]
        public string userRoleName { get; set; }
    }   
}
