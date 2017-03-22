using System;
using System.Threading.Tasks;

namespace Owin.Security.Providers.MercadoLibre
{
    /// <summary>
    /// Default <see cref="IMercadoLibreAuthenticationProvider"/> implementation.
    /// </summary>
    public class MercadoLibreAuthenticationProvider : IMercadoLibreAuthenticationProvider
    {
        /// <summary>
        /// Initializes a <see cref="MercadoLibreAuthenticationProvider"/>
        /// </summary>
        public MercadoLibreAuthenticationProvider()
        {
            OnAuthenticated = context => Task.FromResult<object>(null);
            OnReturnEndpoint = context => Task.FromResult<object>(null);
        }

        /// <summary>
        /// Gets or sets the function that is invoked when the Authenticated method is invoked.
        /// </summary>
        public Func<MercadoLibreAuthenticatedContext, Task> OnAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets the function that is invoked when the ReturnEndpoint method is invoked.
        /// </summary>
        public Func<MercadoLibreReturnEndpointContext, Task> OnReturnEndpoint { get; set; }

        /// <summary>
        /// Invoked whenever MercadoLibre successfully authenticates a user
        /// </summary>
        /// <param name="context">Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task Authenticated(MercadoLibreAuthenticatedContext context)
        {
            return OnAuthenticated(context);
        }

        /// <summary>
        /// Invoked prior to the <see cref="System.Security.Claims.ClaimsIdentity"/> being saved in a local cookie and the browser being redirected to the originally requested URL.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task ReturnEndpoint(MercadoLibreReturnEndpointContext context)
        {
            return OnReturnEndpoint(context);
        }
    }
}