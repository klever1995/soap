using soap.BusinessLogic;
using SoapCore;

namespace soap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registra SoapCore y el servicio SOAP
            builder.Services.AddSoapCore();
            builder.Services.AddScoped<ISoapService, SoapService>();

            // Agrega Razor Pages (si estás usando vistas Razor)
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configuración para SOAP
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // Configura la ruta para el servicio SOAP (aquí expone el servicio en "/Service.asmx")
                endpoints.UseSoapEndpoint<ISoapService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });

            // Configuración para la aplicación web
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
    }
}
