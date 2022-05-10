using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeLine.Abstractions;

namespace TimeLine.Actions
{
    public class JsonSerialization : IJsonSerialization
    {
        private readonly ILogger<JsonSerialization> _logger;
        private readonly JsonSerializerOptions _serializerOptions;
        public JsonSerialization(ILogger<JsonSerialization> logger)
        {
            _logger = logger;
            _serializerOptions = SerializeOptions();
        }
        public string Serialize<T>(T toSerialize)
        {
            try
            {
                string str = JsonSerializer.Serialize<T>(toSerialize, _serializerOptions);

                return str;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems during serialization: {ex.Message}", ex.StackTrace);
                throw;
            }
        }

        private JsonSerializerOptions SerializeOptions()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true
                };
                options.Converters.Add(new JsonStringEnumConverter());

                return options;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
