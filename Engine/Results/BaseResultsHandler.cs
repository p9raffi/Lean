using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using QuantConnect.Configuration;

namespace QuantConnect.Lean.Engine.Results
{
    /// <summary>
    /// Provides base functionality to the implementations of <see cref="IResultHandler"/>
    /// </summary>
    public class BaseResultsHandler
    {
        /// <summary>
        /// Returns the location of the logs
        /// </summary>
        /// <param name="id">Id that will be incorporated into the algorithm log name</param>
        /// <param name="logs">The logs to save</param>
        /// <returns>The path to the logs</returns>
        public virtual string SaveLogs(string id, IEnumerable<string> logs)
        {
            var path = string.IsNullOrEmpty(Config.LogFile) ? Path.Combine(Directory.GetCurrentDirectory(), $"{id}-log.txt") : Config.LogFile;
            File.WriteAllLines(path, logs);
            return path;
        }

        /// <summary>
        /// Save the results to disk
        /// </summary>
        /// <param name="name">The name of the results</param>
        /// <param name="result">The results to save</param>
        public virtual void SaveResults(string name, Result result)
        {
            var path = string.IsNullOrEmpty(Config.ResultsFile) ? Path.Combine(Directory.GetCurrentDirectory(), name) : Config.ResultsFile;
            File.WriteAllText(path, JsonConvert.SerializeObject(result));
        }
    }
}
