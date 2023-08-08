using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ZenKube.KubeCtl.Wrapper;
using ZenKube.Models;
using ZenKube.Models.Kube;
using ZenKube.Models.Zk;

namespace ZenKube.Kubectl.Wrapper
{
    public class ZenKubeWrapper : IZenKubeWrapper
    {
        public IZenKubeWrapperDriver zkDriver=new ZenKubeWrapperDriver();

        private readonly string kubeCtlPath;

        private readonly string OUTPUT = "--output=json";

        private readonly Mapper mapper = MapperConfig.InitializeAutomapper();




            public ZenKubeWrapper(string p="kubectl") {
            kubeCtlPath = p;
        }


        private KubectlArguments ifArgsNotExist(KubectlArguments args) {

            if (args == null)
            {
                args = new KubectlArguments();
            }

            return args;

        }


            public BaseResult<KubectlInfo> getKubeCtlInfo(KubectlArguments? args)
        {

            args = ifArgsNotExist(args);

            

            try {

                var tmp = runKubeCtlCommand<Models.Kube.Version, KubectlInfo>(zkDriver.Version, args);

                return BaseResult<KubectlInfo>.NewSuccess(new KubectlInfo());
            
            }catch(Exception e) {

                return BaseResult<KubectlInfo>.NewError("Error Getting KubeCtlInfo!");


            }
        }

        

        private BaseResult<U> runKubeCtlCommand<T,U>(DriverCommand command, KubectlArguments args) {
            try
            {

                
                var cmdsi = new ProcessStartInfo(kubeCtlPath);
                cmdsi.Arguments = buildKubeCtlCommand(command, args);
                cmdsi.RedirectStandardOutput = true;
                cmdsi.UseShellExecute = false;
                var cmd = Process.Start(cmdsi);
                var output = cmd.StandardOutput.ReadToEnd();

                cmd.WaitForExit();

                


                var tmp = JsonConvert.DeserializeObject<T>(output);

                var ret= mapper.Map<U>(tmp);

                if (ret == null) {
                    return BaseResult<U>.NewError("Error Deserialzing");
                }

                return BaseResult<U>.NewSuccess(ret);
            }
            catch(Exception e) {
                return BaseResult<U>.NewError("Exception Deserialzing");

            }
           
        
        }


        private string buildKubeCtlCommand(DriverCommand command, KubectlArguments args) {

            var append = "";

            if (args?.Kubeconfig!=null) {
                append = $"{append} --kubeconfig {args.Kubeconfig}";
            }

            if (args?.Context != null)
            {
                append = $"{append} --context {args.Context}";
            }

            if (args?.Cluster != null)
            {
                append = $"{append} --cluster {args.Cluster}";
            }

            if (args?.Manual != null)
            {
                append = $"{append} {args.Cluster}";
            }

            var fullCMD = $"{command.Command} {append} {OUTPUT}";
            return fullCMD;

        }
      
    }
}
