

namespace Libraries.Common.Event.Helper
{
    public static class MessageBrokerSettings
    {
        public static IConfigurationSection settings;

        public static string RabbitMQManagementUrl
        {
            get
            {
                return settings?["RabbitMQManagementUrl"]!;
            }
        }
        public static string MessageBrokerService
        {
            get
            {
                return settings?["MessageBrokerService"];
            }
        }

        public static string RabbitMQConnectionString
        {
            get
            {
                return settings?["RabbitMQConnectionString"]!;
            }
        }

        public static string RabbitMQUserName
        {
            get
            {
                return settings?["RabbitMQUserName"]!;
            }
        }

        public static string RabbitMQPassword
        {
            get
            {
                return settings?["RabbitMQPassword"]!;
            }
        }
    }
}
