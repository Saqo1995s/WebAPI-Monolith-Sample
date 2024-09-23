using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IUniversity.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public static class BuildConfiguration
        {
            /// <summary>
            /// Gets a value indicating whether the assembly was built in debug mode.
            /// </summary>
            public static bool IsDebug
            {
                get
                {
                    bool isDebug = true;
#if !DEBUG
                isDebug = false;
#endif
                    return isDebug;
                }
            }

            /// <summary>
            /// Gets a value indicating whether the assembly was built in release mode.
            /// </summary>
            public static bool IsRelease
            {
                get
                {
                    return !IsDebug;
                }
            }
        }
    }
}
