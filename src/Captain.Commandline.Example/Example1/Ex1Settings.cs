using Captain.Commandline.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Captain.Commandline.Example.Example1 {


    /// <summary> Example1 settings. </summary>
    public class Ex1Settings {

        /// <summary> Path to the configuration file. </summary>
        /// <value> The full pathname of the configuration file. </value>
        public string ConfigFilePath { get; set; }

        /// <summary> If to show help. </summary>
        /// <value> True if show help, false if not. </value>
        public bool ShowHelp { get; set; }

        public string TestString { get; set; }






        /// <summary> Loads the given options into key value pairs. </summary>
        /// <param name="opts"> The Options to load. </param>
        /// <returns> The options in key / value pairs </returns>
        public static Dictionary<string, string> Load(string[] opts) {

            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // Get the arguments / switches
            var args_noswitches = CmdLineHelper.FilterArguments(opts);
            var switches = CmdLineHelper.FilterSwitches(opts);

            // Make a note of the configuration file path if there is one
            if (switches.ContainsKey("cfgfile"))
                data["cmdline:cfgfile"] = switches["cfgfile"];

            // If --help is asked for
            if (switches.ContainsKey("help"))
                data["cmdline:showhelp"] = "true";



            return data;
        }

        /// <summary> Binds the settings based on the builder. </summary>
        /// <param name="builder"> The configuration builder. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        public bool Bind(IConfiguration builder) {

            // Make a note of the configuration file path if there is one
            ConfigFilePath = builder["cmdline:cfgfile"];

            // If --help is asked for
            ShowHelp = (builder["cmdline:showhelp"] == "true");


            return true;
        }


    }
}
