using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenKube.Kubectl.Manager;
using ZenKube.Kubectl.Wrapper;

namespace ZenKube.Core.Services
{
    public interface IZenKubeCore
    {

        public IZenKubeKubeCtlManager Manager { get; }
        public IZenKubeWrapper Wrapper { get; }

    }
}
