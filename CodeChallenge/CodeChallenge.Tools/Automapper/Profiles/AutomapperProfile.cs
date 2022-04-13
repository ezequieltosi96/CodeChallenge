using AutoMapper;

namespace CodeChallenge.Tools.Automapper.Profiles
{
    public partial class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            PermissionAutomapperProfile();
            PermissionTypeAutomapperProfile();
        }
    }
}
