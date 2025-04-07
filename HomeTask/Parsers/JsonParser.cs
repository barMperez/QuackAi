#region uSing

using System.Text.Json;

#endregion

namespace HomeTask.Parsers
{
    internal class JsonParser
    {
        #region Memebers
        private JsonSerializerOptions _options { get; set; }

        #endregion

        #region Constructor

        public JsonParser(JsonSerializerOptions? serializerOptions = null)
        {
            try
            {
                _options = serializerOptions ?? new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred constructing {typeof(JsonParser).FullName}.", ex);
            }
        }

        #endregion

        #region Methods

        #region ParseJson

        public T? ParseJson<T>(string json)
        {
            try
            {
                var tickets = JsonSerializer.Deserialize<T>(json, _options);
                return tickets;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred parsing JSON.", ex);
            }
        }

        #endregion

        #endregion
    }
}
