using Captain.Commandline.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Captain.Commandline.Providers.Split {

    /// <summary> Command line provider with a split parameter callback. </summary>
    public class SplitProvider : ConfigurationProvider {

        /// <summary> The command line options. </summary>
        /// <value> Command line options. </value>
        protected string[] Args { get; }

        /// <summary> Delegate type for a split callback when parsing command line options. </summary>
        /// <param name="args"> The arguments. </param>
        /// <param name="switches"> The switches. </param>
        /// <returns> A Dictionary of key value pairs to use. </returns>
        public delegate Dictionary<string, string> SplitLoadDelegate(
            List<string> args, Dictionary<string, string> switches);

        /// <summary> Function pointer for the callback. </summary>
        public SplitLoadDelegate SplitLoadFunc;

        /// <summary> Initializes a new instance. </summary>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        /// <param name="opts"> The command line options. </param>
        /// <param name="loadfunc"> A delegate pointer to a function to call back to</param>
        public SplitProvider(string[] opts, SplitLoadDelegate loadfunc) {
            Args = opts ?? throw new ArgumentNullException(nameof(opts));
            SplitLoadFunc = loadfunc ?? throw new ArgumentNullException(nameof(loadfunc));
        }

        /// <summary> Callback to parse the command line options. </summary>
        public override void Load() {
            var args = CmdLineHelper.FilterArguments(Args);
            var switches = CmdLineHelper.FilterSwitches(Args);

            // with the above we split up all the switches and arguments into separate variables
            // switches - contains anything starting with a / - --
            // args - contains everything else

            Data = SplitLoadFunc(args, switches);
        }
    }
}
