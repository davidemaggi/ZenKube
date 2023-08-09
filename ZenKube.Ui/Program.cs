using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Terminal.Gui;
using ZenKube.Core.Services;

namespace ZenKube.Ui
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            var zk = new ZenKubeCore();

            Application.Run(new MainView(zk));

        }
    }

       
}