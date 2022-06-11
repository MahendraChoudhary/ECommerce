using System;

namespace ECommerce.Helpers.Configuration
{
    public class PostgresSettings
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Database { get; set; }

        public override string ToString()
        {
            var settings = string.Join(Environment.NewLine,
                $"{nameof(Host)}: {Host}",
                $"{nameof(Database)}: {Database}",
                $"{nameof(Username)}: {Username}",
                //$"{nameof(Password)}: {Password}",
                $"{nameof(Port)}: {Port}"
                );
            return settings;
        }
    }
}
