using Captain.Commandline.Example.Example1;
using Captain.Commandline.Example.Example2;
using Captain.Commandline.Example.Example3;
using System;

namespace Captain.Commandline.Example {

    /// <summary> Main example program. </summary>
    public class Program {

        /// <summary> Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        public static void Main(string[] args) {

            // Example1 - Direct callback
            Ex1SettingsLoader.Load(args);
            var setts1 = Ex1SettingsLoader.Settings;
            Console.WriteLine("Example1:");
            Console.WriteLine($"  ConfigurationFile: ${setts1.ConfigFilePath}");
            Console.WriteLine($"  ShowHelp: ${setts1.ShowHelp}");
            Console.WriteLine("");

            // Example2 - split callback
            var setts2 = Ex2SettingsLoader.Settings;
            Console.WriteLine("Example2:");
            // TODO
            Console.WriteLine("");

            // Example3 - split callback
            var setts3 = Ex3SettingsLoader.Settings;
            Console.WriteLine("Example3:");
            // TODO
            Console.WriteLine("");

        }
    }
}
