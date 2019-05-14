using Microsoft.Extensions.Configuration;

namespace Captain.Commandline.Providers.Split {

    /// <summary> Command line source for a split parameter callback. </summary>
    public class SplitSource : IConfigurationSource {

        /// <summary> The command line options. </summary>
        /// <value> Command line options. </value>
        public string[] Args { get; set; }

        /// <summary> Function pointer for the callback. </summary>
        public SplitProvider.SplitLoadDelegate SplitLoadFunc = null;

        /// <summary> Builds the <see cref="SplitProvider"/> for this source. </summary>
        /// <param name="builder"> The <see cref="IConfigurationBuilder"/>. </param>
        /// <returns> A <see cref="SplitProvider"/> </returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder) {
            return new SplitProvider(Args, SplitLoadFunc);
        }
    }

}
