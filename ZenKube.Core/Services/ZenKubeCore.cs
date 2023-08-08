using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenKube.Kubectl.Manager;
using ZenKube.Kubectl.Wrapper;

namespace ZenKube.Core.Services
{
    public class ZenKubeCore : IZenKubeCore
    {
        public IZenKubeKubeCtlManager manager;
        public IZenKubeWrapper wrapper;

        public ZenKubeCore() {



            wrapper = new ZenKubeWrapper();
            manager = new ZenKubeKubeCtlManager(wrapper);


        }

        IZenKubeKubeCtlManager IZenKubeCore.Manager => manager;

        IZenKubeWrapper IZenKubeCore.Wrapper => wrapper;
    }
}
