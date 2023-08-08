using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ZenKube.Models;

namespace ZenKube.Kubectl.Wrapper
{
    public class ZenKubeWrapper : IZenKubeWrapper
    {
        public ZenKubeWrapperDriver zkDriver=new ZenKubeWrapperDriver();

        private readonly string kubeCtlPath;

        private readonly string OUTPUT = "--output=json";




            public ZenKubeWrapper(string p="kubectl") {
            kubeCtlPath = p;
        }


            public BaseResult<KubectlInfo> getKubeCtlInfo()
        {
            try {

                return BaseResult<KubectlInfo>.NewSuccess(new KubectlInfo());
            
            }catch(Exception e) {

                return BaseResult<KubectlInfo>.NewError("Error Getting KubeCtlInfo!");


            }
        }
        private BaseResult<T> runKubeCtlCommand<T>() {
            try
            {
                var ret = JsonConvert.DeserializeObject<T>("{}");

                if (ret == null) {
                    return BaseResult<T>.NewError("Error Deserialzing");
                }

                return BaseResult<T>.NewSuccess(ret);
            }
            catch {
                return BaseResult<T>.NewError("Exception Deserialzing");

            }
           
        
        }

      
    }
}
