using System;

namespace Serialization
{
    /// <summary>
    /// Interface to put on any serializer
    /// </summary>
    /// <remarks>A serializer converts a class to text</remarks>
    public interface ISerializer
    {
        /// <summary>
        /// Transform the objects value into text
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <returns>The object converted to a string</returns>
        public string Serialize(object obj);

        /// <summary>
        /// Transform texts into an object
        /// </summary>
        /// <param name="serilizedString">The string that contains the information about the object</param>
        /// <param name="type">The type of object</param>
        /// <returns>The deserialized object</returns>
        public object Deserialize(string serilizedString, Type type);
    }
}