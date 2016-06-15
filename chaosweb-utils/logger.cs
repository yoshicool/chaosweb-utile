using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace chaosweb.utils
{
	/// <summary>
	/// Logging class that allows you to build a logger
	/// </summary>
	public class logger
	{
		public static string logDirectory;
		public static string logFile;
		private Boolean console = false;

		StreamWriter writer;

		/// <summary>
		/// Initializes a new instance of the <see cref="chaosweb.utils.logger"/> class.  Defaults to logging to Console.
		/// </summary>
		public logger()
		{
			console = true;
			WriteEntry ("Console Log Opened");
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="chaosweb.utils.logger"/> class.
		/// </summary>
		/// <param name="filename">Filename to log to, if set to "console" it logs to default Console</param>
		public logger(string filename)
		{
			logFile = filename;

			if (logFile == "console") {
				console = true;
				WriteEntry ("Console Log Opened");
			} else {

				if (!System.IO.Directory.Exists (Path.GetDirectoryName (logFile))) {
					System.IO.Directory.CreateDirectory (Path.GetDirectoryName (logFile).ToString());
				}

				writer = File.AppendText (logFile);

				WriteEntry ("LogFile Opened");
			}

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="chaosweb.utils.logger"/> class.
		/// </summary>
		/// <param name="filename">Filename to log to</param>
		/// <param name="console">If set to <c>true</c> logs to Console as well.</param>
		public logger(string filename, Boolean console)
		{
			logDirectory = Directory.GetCurrentDirectory ();
			logFile = filename;
			console = this.console;

			if (!System.IO.Directory.Exists(logDirectory))
				System.IO.Directory.CreateDirectory(logDirectory);

			writer = File.AppendText(logFile);

			WriteEntry("LogFile Opened");
		}

		/// <summary>
		/// Writes the log entry.
		/// </summary>
		/// <param name="message">Message to log (use string.Format() to include params).</param>
		public void WriteEntry(string message, [CallerFilePath] string callerSourceFile = null, [CallerMemberName] string callerMember = null, [CallerLineNumber] int callerLineNumber = 0)
		{
			DateTime datetime = DateTime.Now;
			string timestamp = datetime.ToString ("MMM dd yyyy hh:mm:ss");
			callerSourceFile = Path.GetFileName (callerSourceFile);
			string source = callerMember + "(" + callerSourceFile + ";" + callerLineNumber + ")";

			String CompleteLog = string.Format("[{0}] {1}: {2}", timestamp, source, message);

			if (String.IsNullOrEmpty(logFile)) {
				writer.WriteLine (CompleteLog);
				writer.Flush ();
			}

			if (console) {
				Console.WriteLine (CompleteLog);
			}
		}

	}
}