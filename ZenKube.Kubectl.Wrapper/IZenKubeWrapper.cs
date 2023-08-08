using ZenKube.Models;
using ZenKube.Models.Kube;
using ZenKube.Models.Zk;

namespace ZenKube.Kubectl.Wrapper
{
    public interface IZenKubeWrapper
    {
        public BaseResult<KubectlInfo> getKubeCtlInfo(KubectlArguments? args);
    }
}