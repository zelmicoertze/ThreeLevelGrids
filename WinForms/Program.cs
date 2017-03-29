using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuctingGrids.Frontend;
using DuctingGrids.Frontend.Forms;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace DuctingGrids
{
    [Test_IgnoreCoverage(enTestIgnore.ConstructorIsPrivate)]
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form4());
        }
    }
}
