#region Using

using System.Text.Json.Serialization;

#endregion

namespace HomeTask.Models
{
    internal class TicketObject
    {
        #region Properties

        [JsonPropertyName("tickets")]
        public List<Ticket>? Tickets { get; set; }

        #endregion
    }
}
