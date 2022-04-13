using CodeChallenge.Domain.Base;

namespace CodeChallenge.Domain.DTO.Permission
{
    public class PermissionDto : DtoBase
    {
        public string EmployeeFullName { get; set; }

        public string PermissionDate { get; set; }

        public string PermissionType { get; set; }
    }
}
