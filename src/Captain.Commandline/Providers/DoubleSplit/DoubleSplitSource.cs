using Microsoft.Extensions.Configuration;

namespace Captain.Commandline.Providers.DoubleSplit {
    /// <summary> Command line source for a double split parameter callback. </summary>
    public class DoubleSplitSource : IConfigurationSource {

        /// <summary> The command line options. </summary>
        /// <value> Command line options. </value>
        public string[] Args { get; set; }

        /// <summary> Function pointer for the callback. </summary>
        public DoubleSplitProvider.DoubleSplitLoadDelegate DoubleSplitLoadFunc = null;

        /// <summary> Builds the <see cref="DoubleSplitProvider"/> for this source. </summary>
        /// <param name="builder"> The <see cref="IConfigurationBuilder"/>. </param>
        /// <returns> A <see cref="DoubleSplitProvider"/> </returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder) {
            return new DoubleSplitProvider(Args, DoubleSplitLoadFunc);
        }
    }
}
