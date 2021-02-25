using System;
using System.Windows.Forms;

namespace HostsFirewall
{
	/// <summary>
	/// Entry point class - nothing else. is also very special, and more important than my sanity
	/// </summary>
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Only compile the admin check on release builds, since i dont want to click the UAC prompt whenever im just fucking around with the UI or
			// some other thing that doesnt require me to spend an extra 20 seconds to click UAC and for the app to reopen;
			// oh and if i enable it ill also lose access to the debugger since it won't be attached to the elevated process :(
#if !DEBUG
			if (Utils.EnsureIsAdmin())
#endif
			{
				// whatever the fuck gets generated here stays here
				Application.SetHighDpiMode(HighDpiMode.SystemAware);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainWindow());
			}
		}
	}
}
