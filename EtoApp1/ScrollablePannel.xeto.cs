using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace EtoApp1
{
    public class ScrollablePannel : Panel
    {
        StackLayout Items;
        Button AddItem;

        public ScrollablePannel()
        {
            XamlReader.Load(this);
            for (int i = 0; i < 5; i++)
            {
                Items.Items.Add(new ChildStackItem());
            }
            AddItem.Click += AddItem_Click;
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            Items.Items.Add(new ChildStackItem());
        }
    }
}
