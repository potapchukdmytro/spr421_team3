using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Team_Job.Infrastructure
{
    public static class ConfigureStaticFiles
    {
        public static void AddStaticFiles(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            string rootPath = environment.ContentRootPath;
            string storagePath = Path.Combine(rootPath, "storage");

            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/storage",
                FileProvider = new PhysicalFileProvider(storagePath)
            });

            string folder = "images";

           
                string path = Path.Combine(storagePath, folder);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                app.UseStaticFiles(new StaticFileOptions
                {
                    RequestPath = $"/{folder}",
                    FileProvider = new PhysicalFileProvider(path)
                });
            }
    }
}
