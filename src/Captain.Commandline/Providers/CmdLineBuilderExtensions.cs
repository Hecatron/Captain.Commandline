using Captain.Commandline.Providers.Direct;
using Captain.Commandline.Providers.DoubleSplit;
using Captain.Commandline.Providers.Split;
using Microsoft.Extensions.Configuration;
using System;

namespace Captain.Commandline.Providers {

    /// <summary> Extension methods for <see cref="IConfigurationBuilder"/>. </summary>
    public static class CmdLineBuilderExtensions {

        /// <summary> Extension method for a direct callback. </summary>
        /// <param name="builder"> The configurationBuilder to act on. </param>
        /// <param name="args"> The command line options. </param>
        /// <param name="loadaction"> The function pointer for the callback. </param>
        /// <returns> An <see cref="IConfigurationBuilder"/>. </returns>
        public static IConfigurationBuilder AddCmdLineDirectCallback(this IConfigurationBuilder builder, string[] args, DirectProvider.DirectLoadDelegate loadaction) {
            builder.Add(new DirectSource { Args = args, DirectLoadFunc = loadaction });
            return builder;
        }

        /// <summary> Extension method for a direct callback. </summary>
        /// <param name="builder"> The builder to act on. </param>
        /// <param name="configureSource"> The configure source. </param>
        /// <returns> An <see cref="IConfigurationBuilder"/>. </returns>
        public static IConfigurationBuilder AddCmdLineDirectCallback(this IConfigurationBuilder builder, Action<DirectSource> configureSource)
            => builder.Add(configureSource);



        /// <summary> Extension method for a split parameter callback. </summary>
        /// <param name="builder"> The configurationBuilder to act on. </param>
        /// <param name="args"> The command line options. </param>
        /// <param name="loadaction"> The function pointer for the callback. </param>
        /// <returns> An <see cref="IConfigurationBuilder"/>. </returns>
        public static IConfigurationBuilder AddCmdLineSplitCallback(this IConfigurationBuilder builder, string[] args, SplitProvider.SplitLoadDelegate loadaction) {
            builder.Add(new SplitSource { Args = args, SplitLoadFunc = loadaction });
            return builder;
        }

        /// <summary> Extension method for a split parameter callback. </summary>
        /// <param name="builder"> The builder to act on. </param>
        /// <param name="configureSource"> The configure source. </param>
        /// <returns> An <see cref="IConfigurationBuilder"/>. </returns>
        public static IConfigurationBuilder AddCmdLineSplitCallback(this IConfigurationBuilder builder, Action<SplitSource> configureSource)
            => builder.Add(configureSource);



        /// <summary> Extension method for a double split parameter callback using -- as the separator. </summary>
        /// <param name="builder"> The configurationBuilder to act on. </param>
        /// <param name="args"> The command line options. </param>
        /// <param name="loadaction"> The function pointer for the callback. </param>
        /// <returns> An <see cref="IConfigurationBuilder"/>. </returns>
        public static IConfigurationBuilder AddCmdLineDoubleSplitCallback(this IConfigurationBuilder builder, string[] args, DoubleSplitProvider.DoubleSplitLoadDelegate loadaction) {
            builder.Add(new DoubleSplitSource { Args = args, DoubleSplitLoadFunc = loadaction });
            return builder;
        }

        /// <summary> Extension method for a split parameter callback. </summary>
        /// <param name="builder"> The builder to act on. </param>
        /// <param name="configureSource"> The configure source. </param>
        /// <returns> An <see cref="IConfigurationBuilder"/>. </returns>
        public static IConfigurationBuilder AddCmdLineDoubleSplitCallback(this IConfigurationBuilder builder, Action<DoubleSplitSource> configureSource)
            => builder.Add(configureSource);

    }
}
