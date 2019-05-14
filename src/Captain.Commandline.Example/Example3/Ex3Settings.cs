using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Captain.Commandline.Example.Example3 {


    /// <summary> Example3 settings. </summary>
    public class Ex3Settings {

        /// <summary> Path to the configuration file. </summary>
        /// <value> The full pathname of the configuration file. </value>
        public string ConfigFilePath { get; set; }

        /// <summary> If to show help. </summary>
        /// <value> True if show help, false if not. </value>
        public bool ShowHelp { get; set; }

        public string TestString { get; set; }




        /// <summary> Loads the given options into key value pairs. </summary>
        /// <param name="args1">     List of arguments before the --. </param>
        /// <param name="switches1"> Dictionary of switches before the --. </param>
        /// <param name="args2">     List of arguments after the --. </param>
        /// <param name="switches2"> Dictionary of switches after the --. </param>
        /// <returns> The options in key / value pairs. </returns>
        public static Dictionary<string, string> Load(
            List<string> args1, Dictionary<string, string> switches1,
            List<string> args2, Dictionary<string, string> switches2) {

            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // Make a note of the configuration file path if there is one
            if (switches1.ContainsKey("cfgfile"))
                data["cmdline:cfgfile"] = switches1["cfgfile"];

            // If --help is asked for
            if (switches1.ContainsKey("help"))
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
