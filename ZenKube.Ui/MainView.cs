using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using ZenKube.Core.Services;

namespace ZenKube.Ui
{
    public  class MainView : Toplevel
    {
       

        static ColorScheme _colorScheme; 

        public MainView(IZenKubeCore zk) {


            X = 0;
            Y = 0; // Leave one row for the toplevel menu

            // By using Dim.Fill(), it will automatically resize without manual intervention
            Width = Dim.Fill();
            Height = Dim.Fill();



            ColorScheme = _colorScheme = Colors.Base;
            var mainMenu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_ZenKube", new MenuItem [] {
                        new MenuItem ("_Preferences", "Quit UI Catalog", () => { }),
                        new MenuItem ("_About", "Quit UI Catalog", () => { }),
                new MenuItem ("_Quit", "", () => { if (Quit ()) Running = false; })
                    }),
                   
                    new MenuBarItem ("Clusters", CreateClustersMenuItems().ToArray()),
                    //new MenuBarItem ("Diag_nostics", CreateDiagnosticMenuItems()),
                    
                });

            Add(mainMenu);


            var 




        }

        private List<MenuItem> CreateClustersMenuItems()
        {
           
                List<MenuItem> menuItems = new List<MenuItem>();
                menuItems.Add(new MenuItem("AAAAAAA", "AAAAAAA", () => { }));
            menuItems.Add(new MenuItem("BBBBBBB", "BBBBBBB", () => { }));
            menuItems.Add(new MenuItem("CCCCCCC", "CCCCCCC", () => { }));
            menuItems.Add(new MenuItem("DDDDDDD", "DDDDDDD",() => { }));

            return menuItems;
            
        }

        public bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit application", "Are you sure you want to quit this app?", "Yes", "No");
            return n == 0;
        }

        
    }
}
