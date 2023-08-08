using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenKube.Models.Kube
{
    public class KubectlArguments
    {
        public string? Kubeconfig;
        public string? Context;
        public string? Cluster;
        public string? Manual;

    }
}
