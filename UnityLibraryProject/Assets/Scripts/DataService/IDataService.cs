using System.Threading.Tasks;
using System;

namespace DataService
{
    /// <summary>
    /// Interface to put on a class that can help load, save and delete save files
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Tries to save the data inside the given file
        /// </summary>
        /// <param name="fn">The file to save in</param>
        /// <param name="data">The data to save</param>
        /// <param name="createDir">Creates the directory if it doesn't exist yet</param>
        /// <returns>True if the data could be saved, else False</returns>
        Task Save(string fn, object data, bool createDir);

        /// <summary>
        /// Tries to load the data from the given file
        /// </summary>
        /// <param name="fn">The filea to load ressources from</param>
        /// <param name="type">The type of data to load</param>
        /// <returns>Tue if the data could be load, else False</returns>
        Task<object> Load(string fn, Type type);
    }
}