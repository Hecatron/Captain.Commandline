using Captain.Commandline.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Captain.Commandline.Providers.DoubleSplit {

    /// <summary> Command line provider with a double split parameter callback. </summary>
    public class DoubleSplitProvider : ConfigurationProvider {

        /// <summary> The command line options. </summary>
        /// <value> Command line options. </value>
        protected string[] Args { get; }

        /// <summary>Delegate type for a double split callback when parsing command line options.</summary>
        /// <param name="args1">     The arguments before the first occurrence of --. </param>
        /// <param name="switches1"> The switches before the first occurrence of --. </param>
        /// <param name="args2">     The arguments after the first occurrence of --. </param>
        /// <param name="switches2"> The switches after the first occurrence of --. </param>
        /// <returns> A Dictionary of key value pairs to use. </returns>
        public delegate Dictionary<string, string> DoubleSplitLoadDelegate(
            List<string> args1, Dictionary<string, string> switches1,
            List<string> args2, Dictionary<string, string> switches2);

        /// <summary> Function pointer for the callback. </summary>
        public DoubleSplitLoadDelegate DoubleSplitLoadFunc;

        /// <summary> Initializes a new instance. </summary>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        /// <param name="opts"> The command line options. </param>
        /// <param name="loadfunc"> A delegate pointer to a function to call back to</param>
        public DoubleSplitProvider(string[] opts, DoubleSplitLoadDelegate loadfunc) {
            Args = opts ?? throw new ArgumentNullException(nameof(opts));
            DoubleSplitLoadFunc = loadfunc ?? throw new ArgumentNullException(nameof(loadfunc));
        }

        /// <summary> Callback to parse the command line options. </summary>
        public override void Load() {

            var splitindex = Array.IndexOf(Args, "--");
            var arr1 = Args.Take(splitindex).ToList();
            var arr2 = Args.Skip(splitindex).ToList();

            var args1 = CmdLineHelper.FilterArguments(arr1);
            var switches1 = CmdLineHelper.FilterSwitches(arr1);

            var args2 = CmdLineHelper.FilterArguments(arr2);
            var switches2 = CmdLineHelper.FilterSwitches(arr2);

            // This is the same as the split provider
            // However we split the arguments and switches into two groups
            // seperated by wherever -- shows up on the command line
            // This is often used by apps that launch / act as a proxy for other apps and need to pass options across to them

            Data = DoubleSplitLoadFunc(args1, switches1, args2, switches2);
        }
    }
}
