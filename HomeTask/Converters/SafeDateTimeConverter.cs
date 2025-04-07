#region Using

using System.Text.Json;
using System.Text.Json.Serialization;

#endregion

namespace HomeTask.Converters
{
    public class SafeDateTimeConverter : JsonConverter<DateTime?>
    {
        #region Methods

        #region Read

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            if (DateTime.TryParse(str, out var result))
                return result;

            return null;
        }

        #endregion

        #region Write

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                writer.WriteStringValue(value.Value.ToString("o"));
            else
                writer.WriteNullValue();
        }

        #endregion

        #endregion
    }
}

