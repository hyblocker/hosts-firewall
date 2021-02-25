using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace HostsFirewall
{
	/// <summary>
	/// Utilities class of black magic bullshit
	/// </summary>
	public class Utils
	{
		/// <summary>
		/// Converts all tabs in the given string to spaces
		/// </summary>
		/// <param name="input">The input string</param>
		/// <param name="markerSpacing">The tab size</param>
		/// <returns>The modified string</returns>
		public static string TabsToSpaces(string input, int markerSpacing = 4)
		{
			return new string(tabEnumerable(input, markerSpacing).ToArray());
		}

		// idk i stole this from stack overflow like any other programmer would for something like this :OMEGALUL:
		private static IEnumerable<char> tabEnumerable(
			IEnumerable<char> input,
			int markerSpacing)
		{
			var n = 0;
			using (var e = input.GetEnumerator())
				while (e.MoveNext())
				{
					if (e.Current == '\t')
					{
						// at least one
						yield return ' ';
						n++;

						// then fill to next marker
						while (n % markerSpacing != 0)
						{
							yield return ' ';
							n++;
						}
					}
					else
					{
						yield return e.Current;
						n++;
					}
				}
		}

		/// <summary>
		/// Forces the app to run as administrator
		/// </summary>
		/// <returns>Whether this instance is running as an administrator</returns>
		public static bool EnsureIsAdmin()
		{
			if (!IsRunningAsAdmin())
			{
				// Create a process start info
				ProcessStartInfo proc = new ProcessStartInfo();
				proc.UseShellExecute = true;
				proc.WorkingDirectory = Environment.CurrentDirectory;
				proc.FileName = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location) + ".exe";

				// UAC
				proc.Verb = "runas";

				// Try running as admin
				try
				{
					Process.Start(proc);
				}
				catch (Exception ex)
				{
					// If we failed, tell the user
					Debug.WriteLine("This program must be run as an administrator (the HOSTS file is read-only for standard users)! \n\n" + ex.ToString());
					MessageBox.Show("This program is required to run as Administrator. Please restart the program as an administrator to use this program.", "Unable to statup", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return false;
			}
			return true;
		}

		/// <summary>
		/// Checks if we are running as administrator
		/// </summary>
		/// <returns>Whether this <see cref="Process"/> is running as an admin or not</returns>
		private static bool IsRunningAsAdmin()
		{
			WindowsIdentity id = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(id);

			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		/// <summary>
		/// Whether the URL is valid
		/// </summary>
		/// <param name="uri">the url</param>
		/// <returns>whether it is valid or not</returns>
		public static bool IsValidDomain(string uri)
		{
			// yup. this is all i do. abstracted in case i ever decide to do proper checking by pining or something so that its a small refactor
			return uri.Contains('.');
		}

	}
}
