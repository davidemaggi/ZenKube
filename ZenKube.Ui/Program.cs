using Terminal.Gui;
using ZenKube.Core.Services;

namespace ZenKube.Ui
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;


            var zk = new ZenKubeCore();

            // Creates the top-level window to show
            var win = new MainView(top,zk);

            top.Add(win);

           
            



            Application.Run();
        }
    }
}