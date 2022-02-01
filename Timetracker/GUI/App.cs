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
        private  Window _navbar;
        private Window _dashboard;
        private Window _caseView;
        private readonly Toplevel _top;
        public App() : base()
        {
            Application.Init();
            _top = Application.Top;
            InitViews();
           // InitCallBacks();
            Application.Run();
        }

        private void InitCallBacks()
        {
            throw new NotImplementedException();
        }

        private void InitViews()
        {

            InitNavigation();
            InitDashBoard();
            InitCasesView();


        }

        private void InitNavigation()
        {
            _navbar = new Window("Navigation")
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
            _navbar.Add(nav);
            _top.Add(_navbar);
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
                    break;

            }
        }

        private void ITemChangedNav(ListViewItemEventArgs obj)
        {
            switch (obj.Value)
            {
                case "Dashboard":
                    _top.BringSubviewToFront(_dashboard);
                    break;                   
                case "My cases":
                    _top.BringSubviewToFront(_caseView);
                    break;
                default:
                    break;

            }
        }

        private void InitCasesView()
        {
            _caseView = new Window("Cases")
            {
                X = Pos.Right(_navbar),
                Y = 0,
                Width = Dim.Percent(80),
                Height = Dim.Percent(100)
            };
            _top.Add(_caseView);
        }

        private void InitDashBoard()
        { //Fix we should not create a new view every time
            _dashboard = new Window("Dashboard")
            {
                X = Pos.Right(_navbar),
                Y = 0,
                Width = Dim.Percent(80),
                Height = Dim.Percent(100)
            };
            _top.Add(_dashboard);


        }
    }
}
