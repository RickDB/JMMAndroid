using JMMAndroid;
using Org.Apache.Commons.Logging;

namespace JMMAndroid
{
    public static class BaseConfig
    {
        private static AnimePluginSettings settingsLocal = null;
        private static ILog log = null;
        public static AnimePluginSettings Settings
        {
            get
            {
                if ((Utils.IsRunningFromConfig()) || (MainActivity.settings == null))
                {
                    if (settingsLocal == null)
                        settingsLocal = new AnimePluginSettings();
                    return settingsLocal;
                }
                return MainActivity.settings;
            }
        }
        public static ILog MyAnimeLog
        {
            get
            {
                if (log==null)
                    log=new MyAnimeLog();
                return log;
            }
            set
            {

                log = value;
            }
        }
    }
}
