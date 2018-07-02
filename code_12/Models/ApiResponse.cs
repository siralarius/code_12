// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var apiResponse = ApiResponse.FromJson(jsonString);

namespace code_12.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ApiResponse
    {
        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("chartName")]
        public string ChartName { get; set; }

        [JsonProperty("bpi")]
        public Bpi Bpi { get; set; }
    }

    public partial class Bpi
    {
        [JsonProperty("USD")]
        public Eur Usd { get; set; }

        [JsonProperty("GBP")]
        public Eur Gbp { get; set; }

        [JsonProperty("EUR")]
        public Eur Eur { get; set; }
    }

    public partial class Eur
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rate_float")]
        public double RateFloat { get; set; }
    }

    public partial class Time
    {
        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("updatedISO")]
        public DateTimeOffset UpdatedIso { get; set; }

        [JsonProperty("updateduk")]
        public string Updateduk { get; set; }
    }

    public partial class ApiResponse
    {
        public static ApiResponse FromJson(string json) => JsonConvert.DeserializeObject<ApiResponse>(json, code_12.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ApiResponse self) => JsonConvert.SerializeObject(self, code_12.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

