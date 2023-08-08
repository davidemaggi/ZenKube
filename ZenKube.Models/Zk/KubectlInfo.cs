using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenKube.Models.Zk
{
    public class KubectlInfo
    {
        public kubectlVersion Client { get; set; }
        public kubectlVersion Server { get; set; }

        public bool IsInstalled() => Client?.Version != null;


        public KubectlInfo() {

            Client = new kubectlVersion();
            Server = new kubectlVersion();

        }



    }

    public class kubectlVersion {

        public string? Version { get; set; }
        public string? Major { get; set; }
        public string? Minor { get; set; }
        




    }

}
