﻿using Newtonsoft.Json;

namespace OneBuck.Models.MP
{
    public class MPJsSignature
    {
        [JsonProperty("noncestr")]
        public string NonceString { get; set; }

        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}