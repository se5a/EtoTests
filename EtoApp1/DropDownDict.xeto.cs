using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using System.Collections.ObjectModel;

namespace EtoApp1
{
    public class DropDownDict : Panel
    {
        protected DropDown DD;
        protected DropDown DDObsCol;
        public DropDownDict()
        {
            XamlReader.Load(this);
            DD.BindDataContext(c => c.DataStore, (DictionaryVM<object,string> m) => m.DisplayList);
            DD.SelectedIndexBinding.BindDataContext((DictionaryVM<object, string> m) => m.SelectedIndex);

            DataContextChanged += DropDownDict_DataContextChanged;
        }

        private void DropDownDict_DataContextChanged(object sender, EventArgs e)
        {
            if (DataContext is DropDownDictVM)
            {
                var vm = (DropDownDictVM)DataContext;
                //DD.DataContext = vm.DdVM;
                //DDObsCol.DataStore = vm.ObsCol;
            }
        }
    }


    public class DropDownDictVM
    {
       public DictionaryVM<POCO, string> DdVM = new DictionaryVM<POCO, string>();
       public ObservableCollection<string> ObsCol = new ObservableCollection<string>();
       public DropDownDictVM()
        {
            for (int i = 0; i < 5; i++)
            {
                var poco = new POCO() { Name = i.ToString(), ID = Guid.NewGuid() };
                DdVM.Add(poco, poco.Name);
                ObsCol.Add(poco.Name);
            }
        }
    }

    public class POCO
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
    }
}
