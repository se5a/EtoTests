using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EtoApp1
{
    public class Newtab : Panel
    {
        protected ComboBox CB;
        protected DropDown DD;
        protected ListBox LB;

        public Newtab()
        {
            XamlReader.Load(this);
            CB.BindDataContext(c => c.DataStore, (ListVM m) => m.ListOfItems);
            CB.SelectedIndexBinding.BindDataContext((ListVM m) => m.SelectedIndex);

            DD.BindDataContext(c => c.DataStore, (ListVM m) => m.ListOfItems);
            DD.SelectedIndexBinding.BindDataContext((ListVM m) => m.SelectedIndex);

            LB.BindDataContext(c => c.DataStore, (ListVM m) => m.ListOfItems);
            LB.SelectedIndexBinding.BindDataContext((ListVM m) => m.SelectedIndex);

        }
    }

    public class ListVM : INotifyPropertyChanged
    {
        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value == -1)
                    throw new Exception("selected index set to -1");
                else
                {
                    _selectedIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> ListOfItems { get; } = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class NewTabVM
    {
        public ListVM ComboList { get; } = new ListVM();
        public ListVM DropList { get; } = new ListVM();
        public ListVM BoxList { get; } = new ListVM();

        public NewTabVM()
        {
            ComboList.ListOfItems.Add("Alpha");
            ComboList.ListOfItems.Add("Beta");
            ComboList.ListOfItems.Add("Gama");

            DropList.ListOfItems.Add("Alpha");
            DropList.ListOfItems.Add("Bravo");
            DropList.ListOfItems.Add("Charlie");

            BoxList.ListOfItems.Add("One");
            BoxList.ListOfItems.Add("Two");
            BoxList.ListOfItems.Add("Three");

            ComboList.SelectedIndex = 0;
            DropList.SelectedIndex = 1;
            BoxList.SelectedIndex = 2;
        }
    }
}
