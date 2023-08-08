using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenKube.Models.Zk;

namespace ZenKube.Kubectl.Wrapper
{
    internal interface IZenKubeWrapperDriver
    {
        public DriverCommand Version{ get; }
        public DriverCommand NameSpaces { get; }
    }
}
