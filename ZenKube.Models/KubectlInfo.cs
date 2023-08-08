using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenKube.Models
{
    public class KubectlInfo
    {
        public string? Version {  get; set; }
        public string? Path {  get; set; }

        public bool IsInstalled() => Version != null && Path !=null;

    }
}
