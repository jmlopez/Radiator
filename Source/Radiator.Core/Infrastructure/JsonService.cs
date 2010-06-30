using System;
using System.Web.Script.Serialization;
using Radiator.Infrastructure;

namespace Radiator.Core.Infrastructure
{
    public class JsonService : IJsonService
    {
        private readonly JavaScriptSerializer _javaScriptSerializer;
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonService"/> class.
        /// </summary>
        public JsonService()
        {
            _javaScriptSerializer = new JavaScriptSerializer();
        }
        public string Serialize<T>(T input)
        {
            return _javaScriptSerializer.Serialize(input);
        }

        public T Deserialize<T>(string input)
        {
            return _javaScriptSerializer.Deserialize<T>(input);
        }

        public object Deserialize(string input, Type targetType)
        {
            return _javaScriptSerializer.Deserialize(input, targetType);
        }
    }
}