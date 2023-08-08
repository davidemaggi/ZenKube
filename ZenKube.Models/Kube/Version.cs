using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenKube.Models.Kube
{



    public class Version
    {
        public VersionDetails clientVersion { get; set; }
        public string kustomizeVersion { get; set; }
        public VersionDetails serverVersion { get; set; }
    }

    public class VersionDetails
    {
        public string major { get; set; }
        public string minor { get; set; }
        public string gitVersion { get; set; }
        public string gitCommit { get; set; }
        public string gitTreeState { get; set; }
        public DateTime buildDate { get; set; }
        public string goVersion { get; set; }
        public string compiler { get; set; }
        public string platform { get; set; }
    }

    

}
