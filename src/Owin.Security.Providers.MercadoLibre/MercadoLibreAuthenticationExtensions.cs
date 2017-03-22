using System;

namespace Owin.Security.Providers.MercadoLibre
{
    public static class MercadoLibreAuthenticationExtensions
    {
        public static IAppBuilder UseMercadoLibreAuthentication(this IAppBuilder app,
            MercadoLibreAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            app.Use(typeof(MercadoLibreAuthenticationMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseMercadoLibreAuthentication(this IAppBuilder app, string clientId, string clientSecret)
        {
            return app.UseMercadoLibreAuthentication(new MercadoLibreAuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });
        }
    }
}