using System;
using System.IO;
using System.Diagnostics;

namespace chaosweb.utils
{
	public class logger
	{
		public static string logDirectory;
		public static string logFile;

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
			logDirectory = Directory.GetCurrentDirectory ();
			logFile = filename;

			if (!System.IO.Directory.Exists(logDirectory))
				System.IO.Directory.CreateDirectory(logDirectory);

			writer = File.AppendText(logFile);

			WriteEntry("LogFile Opened");	
		}

		public logger (string dir, string filename)
		{
			logDirectory = dir;
			logFile = filename;

			if (!System.IO.Directory.Exists(logDirectory))
				System.IO.Directory.CreateDirectory(logDirectory);

			writer = File.AppendText(logFile);

			WriteEntry("LogFile Opened");
		}

		public void WriteEntry(string message)
		{
			writer.WriteLine("[{0} {1}] {2}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), message);
			writer.Flush();
		}

	}
}