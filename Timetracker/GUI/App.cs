using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using NStack;
namespace Timetracker.GUI
{
    internal class App : Window
    {
        private readonly Toplevel _top;
        public App() : base()
        {
            Application.Init();
            _top = Application.Top;
            BuildMenu();
            Application.Run();
        }

        private void BuildMenu()
        {
            Window window = InitNavigation();
            _top.Add(window);

        }

        private Window InitNavigation()
        {
            var window = new Window("Navigation")
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(20),
                Height = Dim.Percent(100f)
            };

            var nav = new ListView(new List<string> { "Dashboard", "My cases", "Quit" })
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(100),
                Height = Dim.Percent(100),
            };

            nav.SelectedItemChanged += ITemChangedNav;
            nav.OpenSelectedItem += SelctedNav;
            window.Add(nav);
            return window;
        }

        private void SelctedNav(ListViewItemEventArgs obj)
        {
            switch (obj.Value)
            {
                case "Dashboard":
                    break;
                case "My cases":
                    break;
                default:      
                    _top.Running = false;
                    //Application.Shutdown();
                    break;

            }
        }

        private void ITemChangedNav(ListViewItemEventArgs obj)
        {
            switch (obj.Value)
            {
                case "Dashboard":
                    InitDashBoard();
                    break;                   
                case "My cases":
                    InitCasesView();
                    break;
                default:
                    break;

            }
        }

        private void InitCasesView()
        {
           
        }

        private void InitDashBoard()
        { //Fix we should not create a new view every time
            var window = new Window("Dashboard")
            {
                X = _top.Subviews.Where(v => v.),
                Y = 0,
                Width = Dim.Percent(80),
                Height = Dim.Percent(100)
            };



       
           _top.Add(window);
        }
    }
}
