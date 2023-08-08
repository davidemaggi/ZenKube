using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using ZenKube.Core.Services;

namespace ZenKube.Ui
{
    public  class MainView : Window
    {
        public MainView(Toplevel top, IZenKubeCore zk) {

            Title = "🧘 ZenKube";

            X = 0;
            Y = 1;

            // By using Dim.Fill(), it will automatically resize without manual intervention
            Width = Dim.Fill();
            Height = Dim.Fill();
            Console.WriteLine($"KubeCtl is installed: {zk.Manager.getKubeCtlInfo().Content.IsInstalled              ()}");

            var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_New", "Creates new file", null),
                new MenuItem ("_Close", "",null),
                new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; })
            }),
            new MenuBarItem ("_Edit", new MenuItem [] {
                new MenuItem ("_Copy", "", null),
                new MenuItem ("C_ut", "", null),
                new MenuItem ("_Paste", "", null)
            })
        });
            top.Add(menu);


            var listView = new ListView()
            {
                X = 1,
                Y = 2,
                Height = Dim.Fill(),
                Width = Dim.Fill(1),
                //ColorScheme = Colors.TopLevel,
                AllowsMarking = false,
                AllowsMultipleSelection = false
            };

            var currentDirectory = Environment.CurrentDirectory;
            var files = Directory.GetFiles(currentDirectory);
            listView.SetSource(files);

            Add(
                listView,
                new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar")
            );

            var scrollBar = new ScrollBarView(listView, true);

            scrollBar.ChangedPosition += () => {
                listView.TopItem = scrollBar.Position;
                if (listView.TopItem != scrollBar.Position)
                {
                    scrollBar.Position = listView.TopItem;
                }
                listView.SetNeedsDisplay();
            };

            scrollBar.OtherScrollBarView.ChangedPosition += () => {
                listView.LeftItem = scrollBar.OtherScrollBarView.Position;
                if (listView.LeftItem != scrollBar.OtherScrollBarView.Position)
                {
                    scrollBar.OtherScrollBarView.Position = listView.LeftItem;
                }
                listView.SetNeedsDisplay();
            };

            listView.DrawContent += (e) => {
                scrollBar.Size = listView.Source.Count - 1;
                scrollBar.Position = listView.TopItem;
                scrollBar.OtherScrollBarView.Size = listView.Maxlength - 1;
                scrollBar.OtherScrollBarView.Position = listView.LeftItem;
                scrollBar.Refresh();
            };


        }
        static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit application", "Are you sure you want to quit this app?", "Yes", "No");
            return n == 0;
        }
    }
}
