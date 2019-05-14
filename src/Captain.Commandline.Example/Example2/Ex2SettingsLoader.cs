using Captain.Commandline.Helpers;
using Captain.Commandline.Providers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Captain.Commandline.Example.Example2 {

    /// <summary> Example1 settings loader. </summary>
    public class Ex2SettingsLoader {

        /// <summary> Configuration Builder. </summary>
        /// <value> Configuration Builder. </value>
        public static IConfiguration Builder { get; set; }

        /// <summary> Global application configuration. </summary>
        /// <value> Global application configuration. </value>
        public static Ex2Settings Settings { get; set; }

        /// <summary> Loads the settings from the command line / configuration file. </summary>
        /// <param name="opts"> Command line options. </param>
        public static bool Load(string[] opts) {

            // Normally the config file is read in first then any command line options override it
            // We do an initial read first just to get the config file path if there is one
            var cfgfile = GetCfgFilePath(opts);

            // Read in the Json config file first, then override with arguments from the command line
            Builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(cfgfile, optional: true, reloadOnChange: true)
                .AddCmdLineSplitCallback(opts, Ex2Settings.Load)
                .Build();

            Settings = new Ex2Settings();
            return Settings.Bind(Builder);
        }


        /// <summary> Determine if someone has specified an alternative configuration file. </summary>
        /// <param name="opts"> Command line options. </param>
        /// <returns> The configuration file path. </returns>
        private static string GetCfgFilePath(IEnumerable<string> opts) {
            // Default path for configuration file
            var cfgfile = "Settings1.json";
            // search the switches for a cfgfile setting i.e. --cfgfile="Settings2.json"
            var switches = CmdLineHelper.FilterSwitches(opts);
            if (switches.ContainsKey("cfgfile")) {
                cfgfile = switches["cfgfile"];
                // If the user has specified one then warn if it doesn't exist
                if (!File.Exists(cfgfile)) 
                    Console.WriteLine($"Warning unable to locate configuration file: {cfgfile}");
            }
            return cfgfile;
        }
    }
}
