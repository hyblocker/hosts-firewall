namespace HostsFirewall
{
	/// <summary>
	/// A simple data structure containing all the properties a line can have in the HOSTS file, i.e.:
	/// <para></para>
	/// The destination IP
	/// <para></para>
	/// The domain we are redirecting
	/// <para></para>
	/// Whether the line is commented out or not (i.e. enabled or disabled)
	/// <para></para>
	/// The comment after the rule
	/// </summary>
	public struct HostsEntry
	{
		/// <summary>
		/// Empty string cuz <see cref="string.Empty"/> isnt a fucking constant
		/// </summary>
		private const string EmptyStr = "";

		public string RedirectIp;
		public string Domain;
		public string Comment;
		public bool Enabled;

		/// <summary>
		/// A simple primitive
		/// </summary>
		/// <param name="redirectIp">The IP this entry is redirecting to</param>
		/// <param name="domain">The domain this is redirecting</param>
		/// <param name="enabled">Whether the rule is commented out or not</param>
		/// <param name="comment">The comment if any</param>
		public HostsEntry(string redirectIp, string domain, bool enabled = true, string comment = EmptyStr)
		{
			this.RedirectIp = redirectIp;
			this.Domain = domain;
			this.Comment = comment;
			this.Enabled = enabled;
		}

		/// <summary>
		/// Converts this rule to a HOSTS rule
		/// </summary>
		/// <returns>The HOSTS rule as a string which may be inputted to a HOSTS file</returns>
		public override string ToString()
		{
			var output = (Enabled ? "" : "# ")  // Comments out the entire rule if its a comment
				+ RedirectIp                    // The redirecting IP
				+ "\t\t"                        // Indentation duh
				+ Domain;                       // The domain
			output += (Comment.Trim().Length > 0 ?
				(output.Length < 48 ? new string(' ', 48 - output.Length) : "\t")	// indentation black magic lol. idk it should align or something
				+ "# " + Comment : string.Empty);                                   // The comment, doesn't get added if its empty

			return output;
		}
	}
}
