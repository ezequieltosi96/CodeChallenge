using CodeChallenge.Domain.Base;
using System;

namespace CodeChallenge.Domain.Entities
{
    public class Permission : EntityBase
    {
        public string EmployeeForename { get; set; }

        public string EmployeeSurname { get; set; }

        public DateTime PermissionDate { get; set; }

        public int PermissionType { get; set; }

        public virtual PermissionType Type { get; set; }
    }
}
