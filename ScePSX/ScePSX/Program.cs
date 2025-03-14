using System;
using System.Windows.Forms;
using ScePSX.UI;

namespace ScePSX;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new FrmMain());
	}
}
