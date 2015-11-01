using ProjetoDeBloco.Api.App_Start;
using ProjetoDeBloco.Aplicacao.AutoMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ProjetoDeBloco.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityWebApiActivator.Start();
            AutoMapperConfig.Inicializar();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
