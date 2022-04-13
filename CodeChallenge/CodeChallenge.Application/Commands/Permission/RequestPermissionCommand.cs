using CodeChallenge.Application.Interfaces.Mediator.Command;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Application.Commands.Permission
{
    public class RequestPermissionCommand : ICommand<string>
    {
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
