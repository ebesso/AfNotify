using System;
using System.Text.Json.Serialization;
using Core.Enums;

namespace BackgroundWorker.Model
{
    public class AFEntity
    {
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("shortDescription")]
        public string ShortDescription { get; set; }


        [JsonPropertyName("area")]
        public string Area { get; set; }

        [JsonPropertyName("address")]
        public string Adress { get; set; }

        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("floor")]
        public string Floor { get; set; }

        [JsonPropertyName("sqrMtrs")]
        public string Size { get; set; }

        [JsonPropertyName("rentalPeriods")]
        public string RentalPeriods { get; set; }

        [JsonPropertyName("reserveUntilDate")]
        public string ReservationDeadline { get; set; }

        [JsonPropertyName("priority")]
        public string Priority { get; set; }

        [JsonPropertyName("rent")]
        public string Rent { get; set; }
    }
}
