using Microsoft.Extensions.Configuration;
using System;

namespace mvcdemo.Extensions{
    public static class EnvironmentVariableExtensions
    {
        public static string GetConnectionStringFromEnvironment(this IConfiguration configuration, string name = null){
            if(string.IsNullOrEmpty(name)){
                return Environment.GetEnvironmentVariable("ConnectionStringsMvcDemo");
            } else {
                return Environment.GetEnvironmentVariable(name);
            }
        }
    }
}