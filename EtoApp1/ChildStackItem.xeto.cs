using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace EtoApp1
{
    public class ChildStackItem : Panel
    {
        public ChildStackItem()
        {
            XamlReader.Load(this);
        }
    }
}
