using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeManagementSystem.Data
{
    
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string City { get; set; }
        public string Qualifications { get; set; }
        public string ExperienceDetails { get; set; }
    }
}
