using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ZenKube.KubeCtl.Wrapper
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Models.Kube.Version, Models.Zk.KubectlInfo>()
                .ForPath(dest => dest.Client.Minor, opt => opt.MapFrom(src =>  src.clientVersion.minor))
                .ForPath(dest => dest.Client.Major, opt => opt.MapFrom(src => src.clientVersion.major))
                .ForPath(dest => dest.Client.Version, opt => opt.MapFrom(src => src.clientVersion.gitVersion))
                .ForPath(dest => dest.Server.Minor, opt => opt.MapFrom(src => src.serverVersion.minor))
                .ForPath(dest => dest.Server.Major, opt => opt.MapFrom(src => src.serverVersion.major))
                .ForPath(dest => dest.Server.Version, opt => opt.MapFrom(src => src.serverVersion.gitVersion));


                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
