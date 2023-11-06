using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lab1;

namespace Lab2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AppForm.AllocateConsole();
            TrithemiusCypher UA = new("אבגד´הו÷זחט³¿יךכלםמןנסעףפץצקרשü‏ÿ");
            UA.Name = "UA";
            TrithemiusCypher EN = new("abcdefghijklmnopqrstuvwxyz");
            EN.Name = "EN";
            VigenereCracker Cracker_UA = new(UA);
            VigenereCracker Cracker_EN = new(EN);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppForm(new List<ICypher> { UA, EN }, new List<ICracker> { Cracker_UA, Cracker_EN }));
        }
    }
}
