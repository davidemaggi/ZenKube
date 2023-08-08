using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenKube.Models.Kube;
using ZenKube.Models.Zk;

namespace ZenKube.Kubectl.Wrapper
{
    public class ZenKubeWrapperDriver: IZenKubeWrapperDriver
    {

        
        DriverCommand IZenKubeWrapperDriver.Version => new DriverCommand()
        {
            Name = "Version",
            Description = "Get the Version of the Kubectl instance",
            Command = "version",
           
        };

        DriverCommand IZenKubeWrapperDriver.NameSpaces => new DriverCommand()
        {
            Name = "NameSpaces",
            Description = "Get available namespaces on the cluste.",
            Command = "get namespaces",
        };
    }
}
