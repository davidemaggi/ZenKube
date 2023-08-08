using ZenKube.Models;

namespace ZenKube.Kubectl.Wrapper
{
    public interface IZenKubeWrapper
    {
        public BaseResult<KubectlInfo> getKubeCtlInfo();
    }
}