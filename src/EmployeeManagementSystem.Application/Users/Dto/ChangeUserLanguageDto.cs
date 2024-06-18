using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}