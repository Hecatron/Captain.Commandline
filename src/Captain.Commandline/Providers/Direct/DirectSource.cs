using Microsoft.Extensions.Configuration;

namespace Captain.Commandline.Providers.Direct {

    /// <summary> Command line source for a direct callback. </summary>
    public class DirectSource : IConfigurationSource {

        /// <summary> The command line options. </summary>
        /// <value> Command line options. </value>
        public string[] Args { get; set; }

        /// <summary> Function pointer for the callback. </summary>
        public DirectProvider.DirectLoadDelegate DirectLoadFunc = null;

        /// <summary> Builds the <see cref="DirectProvider"/> for this source. </summary>
        /// <param name="builder"> The <see cref="IConfigurationBuilder"/>. </param>
        /// <returns> A <see cref="DirectProvider"/> </returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder) {
            return new DirectProvider(Args, DirectLoadFunc);
        }
    }
}
