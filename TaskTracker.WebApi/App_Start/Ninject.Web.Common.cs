[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TaskTracker.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TaskTracker.WebApi.App_Start.NinjectWebCommon), "Stop")]

namespace TaskTracker.WebApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using TaskTracker.Bll.Abstract.Messaging.Factory;
    using TaskTracker.Bll.Abstract.Messaging.Notifications;
    using TaskTracker.Bll.Impl.Messaging;
    using TaskTracker.Bll.Impl.Messaging.Factory;
    using TaskTracker.Common.Configuration.Smtp;
    using TaskTracker.Mapping.Messaging;
    using TaskTracker.Messaging.Base;
    using TaskTracker.Messaging.Builders;
    using TaskTracker.Messaging.Smtp;
    using TaskTracker.WebApi.Controllers;
    using WebApiContrib.IoC.Ninject;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISmtpConfiguration>().ToConstant(
                new SmtpConfiguration
                {
                    MailAddress = "vladislavcepes98@gmail.com",
                    EnableSsl = true,
                    Password = "qwertygoogledracula",
                    Port = 587,
                    SmtpProvider = "smtp.googlemail.com"
                });
            kernel.Bind<IMailEntityToMailMessageMapper>()
                .To<MailEntityToMailMessageMapper>();
            kernel.Bind<IMailSender>().To<SmtpMailSender>();
            kernel.Bind<IMailBuilder>().To<MailBuilder>();
            kernel.Bind<IMessageTemplateFactory>().To<MessageFactory>();
            kernel.Bind<ITemplateSender>().To<TemplateSender>();
        }        
    }
}