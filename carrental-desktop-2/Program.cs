using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace carrental_desktop_2
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Contains("--stat"))
            {
                Statisztika.Run();
            } else
            {
                Application application = new Application();
                application.Run(new MainWindow());
            }
        }
    }
}
