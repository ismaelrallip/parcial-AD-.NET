using System;
using System.Windows.Forms;

namespace Rallip.WindowsForms
{
    internal static class Program
    {
        
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormListado());
        }
    }
}