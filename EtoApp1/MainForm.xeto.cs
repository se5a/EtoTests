﻿using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace EtoApp1
{    
    public class MainForm : Form
    {
        protected TabControl TabCtrl;

        public MainForm()
        {
            XamlReader.Load(this);
        }

        protected void HandleClickMe(object sender, EventArgs e)
        {
            NewTabVM tabvm = new NewTabVM();

            var newPanel = new Newtab();
            newPanel.DataContext = tabvm;

            TabPage tp = new TabPage();
            TabCtrl.Pages.Add(tp);

            tp.Content = newPanel;
            tp.Text = "list tests";
            TabCtrl.SelectedPage = tp; 
        }

        protected void HandleQuit(object sender, EventArgs e)
        {
            Application.Instance.Quit();
        }
    }
}
