using System.Web.Http;
using WebActivatorEx;
using Hive.WebApi;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System;
using System.IO;
using System.Reflection;
using System.Web.Http.Description;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Hive.WebApi
{
    internal class SwaggerConfig
    {
        internal static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.MultipleApiVersions((apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                        (vc) => {
                            vc.Version("V2", "Hive.WebApi V2");
                            vc.Version("V1", "Hive.WebApi V1");
                        });

                        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", xmlFile);
                        c.IncludeXmlComments(xmlPath);

                        c.MapType<int?>(() => new Schema { type = "integer, null", format = "int32", @default = 0 });
                        c.MapType<decimal?>(() => new Schema { type = "decimal, null", format = "double", @default = 0.0 });
                        c.MapType<bool?>(() => new Schema { type = "boolean, null", @default = false });
                        c.MapType<TimeSpan?>(() => new Schema { type = "string, null", @default = "00:00:00" });
                        c.MapType<TimeSpan>(() => new Schema { type = "string, null", @default = "00:00:00" });
                        c.MapType<byte>(() => new Schema { type = "byte", @default = 0 });
                        c.MapType<byte?>(() => new Schema { type = "byte, null", @default = 0 });
                    })
                .EnableSwaggerUi();
        }
        private static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            return apiDesc.ActionDescriptor.ControllerDescriptor.ControllerType.FullName.Contains($"{targetApiVersion}");
        }
    }
}
