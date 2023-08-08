using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenKube.Kubectl.Wrapper;
using ZenKube.Models;
using ZenKube.Models.Zk;

namespace ZenKube.Kubectl.Manager
{
    public class ZenKubeKubeCtlManager : IZenKubeKubeCtlManager
    {
        private readonly IZenKubeWrapper zkWrapper;


        public ZenKubeKubeCtlManager(IZenKubeWrapper w){
            zkWrapper = w;

        }


        public BaseResult<KubectlInfo> getFullKubeCtlInfo()
        {
            var ret= zkWrapper.getKubeCtlInfo(new Models.Kube.KubectlArguments() { });

            return ret;
        }

        public BaseResult<KubectlInfo> getKubeCtlInfo()
        {
            var ret = zkWrapper.getKubeCtlInfo(new Models.Kube.KubectlArguments() { Manual = "--Client" });

            return ret;
        }
    }
}
