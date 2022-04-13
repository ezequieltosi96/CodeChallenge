using AutoMapper;
using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Domain.DTO.Permission;
using CodeChallenge.Domain.Entities;
using System;

namespace CodeChallenge.Tools.Automapper.Profiles
{
    public partial class AutomapperProfile : Profile
    {
        public void PermissionAutomapperProfile()
        {
            CreateMapPermissionPermissionDto();
            CreateMapModifyPermissionCommandPermission();
            CreateMapRequestPermissionCommandPermission();
        }

        private void CreateMapRequestPermissionCommandPermission()
        {
            CreateMap<RequestPermissionCommand, Permission>()
                .ForMember(dest => dest.PermissionDate, opts => opts.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.PermissionType, opts => opts.MapFrom(src => src.IdPermissionType.Value));
        }

        private void CreateMapModifyPermissionCommandPermission()
        {
            CreateMap<ModifyPermissionCommand, Permission>()
                .ForMember(dest => dest.PermissionType, opts => opts.MapFrom(src => src.IdPermissionType.Value));
        }

        private void CreateMapPermissionPermissionDto()
        {
            CreateMap<Permission, PermissionDto>()
                .ForMember(dest => dest.EmployeeFullName, opts => opts.MapFrom(src => $"{src.EmployeeForename} {src.EmployeeSurname}"))
                .ForMember(dest => dest.PermissionDate, opts => opts.MapFrom(src => src.PermissionDate.ToShortDateString()))
                .ForMember(dest => dest.PermissionType, opts => opts.MapFrom(src => src.Type.Description));
        }
    }
}
