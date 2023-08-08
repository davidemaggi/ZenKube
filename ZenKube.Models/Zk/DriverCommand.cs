using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenKube.Models.Zk
{
    public class DriverCommand
    {
        public string Name;
        public string Description;
        public string Command;
        public List<CommandOverride> Overrides=new List<CommandOverride>();
    }
}
