using System;
using System.Windows.Forms;
using ShulteGame;

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new SizeChoosingForm());
    }
}