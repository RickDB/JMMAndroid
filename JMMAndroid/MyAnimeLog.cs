using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Android.Util;
using Java.Lang;
using Org.Apache.Commons.Logging;
using Exception = System.Exception;
using Object = Java.Lang.Object;
using String = System.String;
using Thread = System.Threading.Thread;

namespace JMMAndroid
{
	public class MyAnimeLog
	{
		private static string m_filename = GetLogName();
		private static string logNameBackup = GetLogNameBackup();
		static StreamWriter m_LogStream;
		delegate void Log_WriteCallback(string input);

		public static string GetLogName()
		{
		    return "";
		    //return Path.Combine(Config.GetFolder(Config.Dir.Log), "MyAnime3.log");
		}

		public static string GetLogNameBackup()
		{
			return GetLogName() + ".bak";
		}

		public MyAnimeLog()
        {
            try
            {
				Log.Warn("XXXFILENAMR: {0}", m_filename);

                if (File.Exists(m_filename))
                {
					if (File.Exists(logNameBackup)) File.Delete(logNameBackup);
                    File.Move(m_filename, logNameBackup);
                }
            }
            catch (Exception e)
            {
				//Log.Warn("Problem backing up Log file: " + e.Message);
                Write("Problem backing up Log file: " + e.Message);
            }
            try
            {
                m_LogStream = File.CreateText(m_filename);
                m_LogStream.Close();
                m_LogStream.Dispose();
            }
            catch (Exception ex)
            {
                // oopps, can't create file
				Log.Warn("Error in myanime2.log: {0}", ex.ToString());
            }

			Write("-------------------- SYSTEM INFO -----------------------");

			System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
			try
			{
				if (a != null)
				{
					Write(string.Format("Plugin Version: v{0}", Utils.GetApplicationVersion(a)));
				}
			}
			catch (Exception ex)
			{
				// oopps, can't create file
				Log.Warn("Error in myanime2.log: {0}", ex.ToString());
			}

			Write(string.Format("Operating System: {0}", Utils.GetOSInfo()));
			//Write(string.Format("Current Skin: {0}", GUIGraphicsContext.Skin));


			//string screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString() + "x" +
			//	System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
			//Write(string.Format("Screen Size: {0}", screenSize));

			Utils.CheckRequiredFiles(this);

			Write("-------------------------------------------------------");

			//Write(string.Format("Database Version: v{0}", Utils.GetApplicationVersion(a)));
        }

		

		#region Public Write Methods
		/// <summary>
		/// Use this for Std. Log entries, only show up in LogLevel.Normal
		/// </summary>
		/// <param name="entry"></param>
		public void Write(string entry)
		{
			Write(entry, true);
		}

		public void Write(string entry, params object[] args)
		{
			Write(string.Format(entry, args), true);
		}

		/// <summary>
		/// Use this for Log entries with many lines (e.g. StackTrace), only show up in LogLevel.Normal
		/// </summary>
		/// <param name="entry"></param>
		public void WriteMultiLine(string entry)
		{
			Write(entry, false);
		}


		/// <summary>
		/// To avoid having to join values if not needed in lower LogLevels use this
		/// </summary>
		/// <param name="entry"></param>
		/// <param name="param"></param>
		/// <param name="level"></param>
		public void Write(string entry, int param)
		{
			Write(entry + param.ToString());
		}

		public void Write(string entry, bool singleLine)
		{
		    Log.Debug("Default", entry);

		    /*
			if (m_LogStream != null)
			{
				lock (m_LogStream)
				{
					try
					{
						if (File.Exists(m_filename))
							m_LogStream = File.AppendText(m_filename);
						else
							m_LogStream = File.CreateText(m_filename);

						String sPrefix = String.Format("{0:D8} - {1} - ", Thread.CurrentThread.ManagedThreadId, DateTime.Now);

						if (singleLine)
							m_LogStream.WriteLine(sPrefix + entry);
						else
							m_LogStream.Write(sPrefix + "\n" + entry);

						m_LogStream.Flush();
						m_LogStream.Close();
						m_LogStream.Dispose();

					}
					catch (Exception ex)
					{
						// well we can't write...maybe no file access or something....and we can't even log the error
						//Log_Write(entry);
						//Log_Write(ex.Message);
					}
				}
			}*/
		}

		#endregion

	    public void Dispose()
	    {
	        throw new NotImplementedException();
	    }

	    public IntPtr Handle { get; }

	    public bool IsDebugEnabled { get; }
	    public bool IsErrorEnabled { get; }
	    public bool IsFatalEnabled { get; }
	    public bool IsInfoEnabled { get; }
	    public bool IsTraceEnabled { get; }
	    public bool IsWarnEnabled { get; }
	}
}
