using System;

namespace Captain.Commandline.Helpers {

    /// <summary> String helper class. </summary>
    public static class StringHelper {

        /// <summary> Replace the first occurrence of a string </summary>
        /// <param name="Source">  Source for the replacement. </param>
        /// <param name="Find">    string to find. </param>
        /// <param name="Replace"> replacement string. </param>
        /// <returns> A string. </returns>
        public static string ReplaceFirstString(string Source, string Find, string Replace) {
            var Place = Source.IndexOf(Find, StringComparison.Ordinal);
            var result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

        /// <summary> String extension method that replace first occurrence. </summary>
        /// <param name="Source">  Source for the replacement. </param>
        /// <param name="Find">    string to find. </param>
        /// <param name="Replace"> replacement string. </param>
        /// <returns> A string. </returns>
        public static string ReplaceFirst(this string Source, string Find, string Replace) {
            return ReplaceFirstString(Source, Find, Replace);
        }
    }
}
