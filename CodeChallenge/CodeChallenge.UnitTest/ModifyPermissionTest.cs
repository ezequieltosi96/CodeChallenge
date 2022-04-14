using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Application.Exceptions;
using CodeChallenge.Application.Handlers.Permission;
using CodeChallenge.Application.Interfaces.Services;
using CodeChallenge.UnitTest.Mocks;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace CodeChallenge.UnitTest
{
    public class ModifyPermissionTest
    {
        private readonly Mock<IPermissionService> _permissionService = ServiceMock.GetPermissionService();

        [Fact]
        public void ModifyPermission_returns_modified_id()
        {
            var handler = new ModifyPermissionHandler(_permissionService.Object);

            var result = handler.Handle(new ModifyPermissionCommand() { Id = 1, IdPermissionType = 1, EmployeeSurname = "Perez", EmployeeForename = "José" });

            result.Should().Be(1);
        }

        [Fact]
        public void ModifyPermission_with_invalid_permission_throws_notFound()
        {
            var handler = new ModifyPermissionHandler(_permissionService.Object);

            Action act = () => handler.Handle(new ModifyPermissionCommand() { Id = 5, IdPermissionType = 3, EmployeeSurname = "Perez", EmployeeForename = "José" });

            act.Should().Throw<NotFoundException>();
        }

        [Fact]
        public void ModifyPermission_with_invalid_permissionType_throws_notFound()
        {
            var handler = new ModifyPermissionHandler(_permissionService.Object);

            Action act = () => handler.Handle(new ModifyPermissionCommand() { Id = 1, IdPermissionType = 4, EmployeeSurname = "Perez", EmployeeForename = "José" });

            act.Should().Throw<NotFoundException>();
        }
    }
}
