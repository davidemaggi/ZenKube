using ZenKube.Models;

namespace ZenKube.Kubectl.Manager
{
    public interface IZenKubeKubeCtlManager
    {

        public BaseResult<KubectlInfo> getKubeCtlInfo();

    }
}