using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CostControlWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string code = "lja3xBpuOiRBbmwrn/mfqVFCaCRzePReUo/QK6ozvK6SFuvD6Ozxsp7P1xXYPFV5";
            BingoX.Security.SecurityAES des = new BingoX.Security.SecurityAES(new BingoX.Security.SymmetricAlgorithmConfig
            {
                Key = "S9u978Q31NGPGc5H",
                IV = "X83yESM9iShLqfwS",
                CipherMode = System.Security.Cryptography.CipherMode.CBC,
                PaddingMode = System.Security.Cryptography.PaddingMode.Zeros,
                ByteTo = BingoX.ByteTo.Base64
            });
            var info = des.Decrypt(code).Replace("\u0004",string.Empty);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
