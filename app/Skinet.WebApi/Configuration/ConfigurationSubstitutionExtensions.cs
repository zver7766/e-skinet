using Microsoft.Extensions.Configuration;
using Placeholders.Configuration;

namespace API.Configuration
{
    public static class ConfigurationSubstitutionExtensions
    {
        public static IConfigurationBuilder AddPlaceholdersProcessing(this IConfigurationBuilder builder)
        {
            return builder.EnableSubstitutions("${", "}");
        }
    }
}