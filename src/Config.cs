﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lykos
{
    class Config
    {
        public struct ConfigJson
        {
            [JsonProperty("token")]
            public string Token { get; private set; }

            [JsonProperty("prefixes")]
            public string[] Prefixes { get; private set; }

            [JsonProperty("gravatar")]
            public GravatarConfig Gravatar { get; private set; }

            [JsonProperty("s3")]
            public JsonCfgS3 S3 { get; private set; }

            [JsonProperty("owners")]
            public List<ulong> Owners { get; private set; }

            [JsonProperty("cloudflare")]
            public CloudflareConfig Cloudflare { get; private set; }

            [JsonProperty("emoji")]
            public EmojiConfig Emoji { get; private set; }

            [JsonProperty("hastebinEndpoint")]
            public string HastebinEndpoint { get; private set; }
        }

        public class CloudflareConfig
        {
            [JsonProperty("apiToken")]
            public string Token { get; private set; }

            [JsonProperty("zoneID")]
            public string ZoneID { get; private set; }

            [JsonProperty("urlPrefix")]
            public string UrlPrefix { get; private set; }
        }

        public class EmojiConfig
        {
            [JsonProperty("blobpats")]
            public string BlobPats { get; private set; }

            [JsonProperty("blobhug")]
            public string BlobHug { get; private set; }

            [JsonProperty("xmark")]
            public string Xmark { get; private set; }

            [JsonProperty("check")]
            public string Check { get; private set; }

            [JsonProperty("loading")]
            public string Loading { get; private set; }
        }

        public class JsonCfgS3
        {
            [JsonProperty("endpoint")]
            public string Endpoint { get; private set; }

            [JsonProperty("region")]
            public string Region { get; private set; }

            [JsonProperty("bucket")]
            public string Bucket { get; private set; }

            [JsonProperty("accessKey")]
            public string AccessKey { get; private set; }

            [JsonProperty("secretKey")]
            public string SecretKey { get; private set; }

            [JsonProperty("providerDisplayName")]
            public string displayName { get; private set; }
        }

        public class GravatarConfig
        {
            [JsonProperty("email")]
            public string Email { get; private set; }

            [JsonProperty("password")]
            public string Password { get; private set; }
        }

    }
}
