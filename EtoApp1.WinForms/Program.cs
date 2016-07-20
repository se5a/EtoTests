using System;
using Eto;
using Eto.Forms;

namespace EtoApp1.WinForms
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Platforms.WinForms).Run(new MainForm());
        }
    }
}
