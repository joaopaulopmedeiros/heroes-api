using System;

namespace WebApi.Cache
{
    public class RedisCacheSettings
    {
        public RedisCacheSettings(string connectionString, string enabled)
        {
            ConnectionString = connectionString;
            Enabled = Convert.ToBoolean(enabled);
        }

        public bool Enabled { get; set; }
        public string ConnectionString { get; set; }
    }
}