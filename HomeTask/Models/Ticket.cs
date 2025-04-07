#region Using

using HomeTask.Converters;
using System.Text.Json.Serialization;

#endregion

namespace HomeTask.Models
{
    internal class Ticket
    {
        #region Properties

        [JsonPropertyName("ticketId")]
        public string? TicketId { get; set; }

        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(SafeDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        #endregion
    }
}
