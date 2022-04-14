using CodeChallenge.Application.Interfaces.Mediator.Command;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Application.Commands.Permission
{
    public class ModifyPermissionCommand : ICommand<int>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmployeeForename { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmployeeSurname { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? IdPermissionType { get; set; }
    }
}
