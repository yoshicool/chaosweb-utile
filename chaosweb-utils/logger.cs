using System;
using System.IO;
using System.Diagnostics;

namespace chaosweb.utils
{
	public class logger
	{
		public static string logDirectory;
		public static string logFile;
		private Boolean console = false;

		StreamWriter writer;

		public logger()
		{
			logDirectory = Directory.GetCurrentDirectory ();
			logFile = logDirectory + "\\" + Process.GetCurrentProcess().ProcessName + ".txt";

			if (!System.IO.Directory.Exists(logDirectory))
				System.IO.Directory.CreateDirectory(logDirectory);

			writer = File.AppendText(logFile);

			WriteEntry("LogFile Opened");
		}
			
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

		public void WriteEntry(string message)
		{
			String CompleteLog = string.Format("[{0} {1}] {2}: {3}", DateTime.Now.ToLongDateString (), DateTime.Now.ToLongTimeString (), Process.GetCurrentProcess().ProcessName, message);

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