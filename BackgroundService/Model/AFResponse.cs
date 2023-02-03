using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackgroundWorker.Model
{
    public class AFResponse
    {
        [JsonPropertyName("product")]
        public List<AFEntity> Items { get; set; }
    }
}
