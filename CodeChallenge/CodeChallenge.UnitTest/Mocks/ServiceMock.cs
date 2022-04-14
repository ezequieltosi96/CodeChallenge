using CodeChallenge.Application.Exceptions;
using CodeChallenge.Application.Interfaces.Services;
using CodeChallenge.Domain.DTO.Permission;
using CodeChallenge.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.UnitTest.Mocks
{
    public static class ServiceMock
    {
        public static Mock<IPermissionService> GetPermissionService()
        {
            var permissionTypes = new List<PermissionType>
            {
                new PermissionType
                {
                    Id = 1,
                    Description = "Admin"
                },
                new PermissionType
                {
                    Id = 2,
                    Description = "Sales"
                },
                new PermissionType
                {
                    Id = 3,
                    Description = "Shop"
                },
            };

            var permissions = new List<Permission>
            {
                new Permission
                {
                    Id = 1,
                    EmployeeForename = "Ezequiel",
                    EmployeeSurname = "Tosi",
                    PermissionType = 1,
                    PermissionDate = DateTime.UtcNow,
                    Type = permissionTypes.Find(p => p.Id == 1)
                },
                new Permission
                {
                    Id = 2,
                    EmployeeForename = "Juan",
                    EmployeeSurname = "Tosi",
                    PermissionType = 2,
                    PermissionDate = DateTime.UtcNow,
                    Type = permissionTypes.Find(p => p.Id == 2)
                },
                new Permission
                {
                    Id = 3,
                    EmployeeForename = "Bernarda",
                    EmployeeSurname = "Tosi",
                    PermissionType = 3,
                    PermissionDate = DateTime.UtcNow,
                    Type = permissionTypes.Find(p => p.Id == 3)
                },
            };

            var permissionDtos = new List<PermissionDto>
            {
                new PermissionDto
                {
                    Id = 1,
                    EmployeeFullName = "Ezequiel Tosi",
                    PermissionDate = DateTime.UtcNow.ToShortDateString(),
                    PermissionType = "Admin"
                },
                new PermissionDto
                {
                    Id = 2,
                    EmployeeFullName = "Juan Tosi",
                    PermissionDate = DateTime.UtcNow.ToShortDateString(),
                    PermissionType = "Admin"
                },
                new PermissionDto
                {
                    Id = 3,
                    EmployeeFullName = "Bernarda Tosi",
                    PermissionDate = DateTime.UtcNow.ToShortDateString(),
                    PermissionType = "Admin"
                }
            };

            var permissionService = new Mock<IPermissionService>();

            permissionService.Setup(service => service.GetAll()).Returns(Map(permissions));

            permissionService.Setup(service => service.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).Returns((int x, string y, string z) =>
            {
                if(!permissionTypes.Any(pt => pt.Id == x))
                {
                    throw new NotFoundException(nameof(PermissionType), x);
                }

                var permission = new Permission
                {
                    Id = permissions.Count + 1,
                    EmployeeForename = y,
                    EmployeeSurname = z,
                    PermissionDate = DateTime.UtcNow,
                    PermissionType = x
                };
                permissions.Add(permission);
                return permission.Id;
            });
            
            permissionService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).Returns((int x, int y, string z, string t) =>
            {
                if (!permissionTypes.Any(pt => pt.Id == y) || !permissions.Any(p => p.Id == x))
                {
                    throw new NotFoundException(nameof(PermissionType), x);
                }

                var permission = permissions.Find(p => p.Id == x);

                permission.PermissionType = y;
                permission.EmployeeForename = z;
                permission.EmployeeSurname = t;

                return permission.Id;
            });

            return permissionService;
        }

        private static List<PermissionDto> Map(List<Permission> permissions)
        {
            return permissions.Select(p => new PermissionDto { Id = p.Id, EmployeeFullName = $"{p.EmployeeForename} {p.EmployeeSurname}", PermissionDate = p.PermissionDate.ToShortDateString(), PermissionType = p.Type.Description }).ToList();
        }

    }
}
