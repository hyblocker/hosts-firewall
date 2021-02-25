using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace HostsFirewall
{
	public class HostsFirewall
	{
		public readonly string HostsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows) , "System32", "drivers", "etc", "hosts");
		private List<HostsEntry> hostsTree;

		// The entire default HOSTS FILE
		const string HOSTS_PREFIX = "# Copyright (c) 1993-2009 Microsoft Corp.\r\n#\r\n# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.\r\n#\r\n# This file contains the mappings of IP addresses to host names. Each\r\n# entry should be kept on an individual line. The IP address should\r\n# be placed in the first column followed by the corresponding host name.\r\n# The IP address and the host name should be separated by at least one\r\n# space.\r\n#\r\n# Additionally, comments (such as these) may be inserted on individual\r\n# lines or following the machine name denoted by a '#' symbol.\r\n#\r\n# For example:\r\n#\r\n#      102.54.94.97     rhino.acme.com          # source server\r\n#       38.25.63.10     x.acme.com              # x client host\r\n\r\n# localhost name resolution is handled within DNS itself.\r\n#\t127.0.0.1       localhost\r\n#\t::1             localhost\r\n";
		private const string NEW_LINE = "\r\n";

		private string redirectIp = "127.0.0.1";
		private const char COMMENT_CHAR = '#';
		private const char CHAR_PERIOD = '.';

		public int Length
		{
			get
			{
				return hostsTree.Count;
			}
		}

		public HostsEntry this[int i]
		{
			get
			{
				return hostsTree[i];
			}
			set
			{
				hostsTree[i] = value;
			}
		}

		public HostsFirewall()
		{
			hostsTree = new List<HostsEntry>();
		}

		public void LoadHosts()
		{
			// Reset HOSTS File in RAM
			hostsTree.Clear();
			Debug.WriteLine($"Reading HOSTS from \"{HostsFilePath}\"");

			string[] HostsFile = File.ReadAllLines(HostsFilePath);

			// Parse the HOSTS File:
			for (int i = 0; i < HostsFile.Length; i++)
			{
				// If NOT a comment
				if (!HostsFile[i].Trim().StartsWith(COMMENT_CHAR))
				{
					// Trim whitespace
					HostsFile[i] = HostsFile[i].Trim();
					ParseHostsLine(HostsFile[i], true);
				}
				else
				{
					// Commented
					// Trim after removing the first #
					HostsFile[i] = HostsFile[i].Substring(HostsFile[i].IndexOf("#") + 1).Trim();
					ParseHostsLine(HostsFile[i], false);
				}
			}

			// DEBUG DUMP
			Debug.WriteLine("Dumping HOSTS Parse Tree!");
			for (int i = 0; i < hostsTree.Count; i++)
			{
				Debug.WriteLine(hostsTree[i]);
			}
		}

		public void WriteHosts()
		{
			string Hosts = HOSTS_PREFIX + NEW_LINE;

			// Add config
			for (int i = 0; i < hostsTree.Count; i++)
			{
				// Defaults get ignored cuz they're already in the hosts file in the prefix
				if ((hostsTree[i].Domain == "rhino.acme.com" && hostsTree[i].RedirectIp == "102.54.94.97" && hostsTree[i].Enabled == false && hostsTree[i].Comment == " source server")
					|| (hostsTree[i].Domain == "x.acme.com" && hostsTree[i].RedirectIp == "38.25.63.10" && hostsTree[i].Enabled == false && hostsTree[i].Comment == " x client host"))
				{
					continue;
				}
				Hosts += hostsTree[i] + NEW_LINE;
			}

			// Append New line at the end
			Hosts += NEW_LINE;

			Debug.WriteLine(Hosts);

			File.WriteAllText(HostsFilePath, Hosts);
		}

		private void ParseHostsLine(string line, bool active)
		{
			// If not empty
			if (line.Length > 0 && line.Contains(CHAR_PERIOD) && line.Split(null).Length > 1)
			{
				// Convert Tabs to spaces
				//HostsFile[i].Replace("\t", "    ");
				line = Utils.TabsToSpaces(line, 8);

				// Handle comments
				string comment = string.Empty;
				if (line.Contains(COMMENT_CHAR))
				{
					comment = line.Substring(line.IndexOf(COMMENT_CHAR) + 1);
					line = line.Substring(0, line.IndexOf(COMMENT_CHAR)).Trim();
				}

				// Extract the ips and domains
				string redirIp = line.Substring(0, line.IndexOf(' '));
				string domain = line.Substring(line.LastIndexOf(' ') + 1);

				// Needs at least one period, to identify at least the domain type, or IP
				if (redirIp.Contains(CHAR_PERIOD) && domain.Contains(CHAR_PERIOD))
				{
					HostsEntry entry = new HostsEntry(redirIp, domain, active, comment);
					hostsTree.Add(entry);
				}
			}
		}

		public void Add(string domain, string comment, bool active)
		{
			HostsEntry entry = new HostsEntry(redirectIp, domain, active, comment);
			hostsTree.Add(entry);
		}

		#region DNS Flushing Native bullshit because fuck cmd

		[DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
		private static extern uint DnsFlushResolverCache();

		public void FlushDNSCache()
		{
			_ = DnsFlushResolverCache();
		}

		#endregion
	}
}
