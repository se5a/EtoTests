﻿using System;
using Eto;
using Eto.Forms;

namespace EtoApp1.Gtk3
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Platforms.Gtk3).Run(new MainForm());
        }
    }
}
