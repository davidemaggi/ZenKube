using ZenKube.Models;
using ZenKube.Models.Zk;

namespace ZenKube.Kubectl.Manager
{
    public interface IZenKubeKubeCtlManager
    {

        public BaseResult<KubectlInfo> getKubeCtlInfo();
        public BaseResult<KubectlInfo> getFullKubeCtlInfo();

    }
}