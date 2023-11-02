using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AppForm.AllocConsole();
            Cypher UA = new("אבגד´הו÷זחט³¿יךכלםמןנסעףפץצקרשü‏ÿ", 1);
            UA.Name = "UA";
            Cypher EN = new("abcdefghijklmnopqrstuvwxyz", 1);
            EN.Name = "EN";
            BruteCracker Cracker_EN = new(EN, "../../../../en.txt");
            BruteCracker Cracker_UA = new(UA, "../../../../ua.txt");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppForm(new List<ICypher> { UA, EN }, new List<ICracker> { Cracker_UA, Cracker_EN }, "1"));
        }
    }
}
