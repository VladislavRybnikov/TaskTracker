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
    using TaskTracker.Bll.Abstract.Services;
    using TaskTracker.Bll.Impl.Messaging;
    using TaskTracker.Bll.Impl.Messaging.Factory;
    using TaskTracker.Bll.Impl.Services;
    using TaskTracker.Common.Configuration.Smtp;
    using TaskTracker.Dal.Abstract.Repositories;
    using TaskTracker.Dal.Abstract.Uof;
    using TaskTracker.Dal.Impl.Ef.Repositories;
    using TaskTracker.Dal.Impl.Ef.Uof;
    using TaskTracker.Dto;
    using TaskTracker.Entities;
    using TaskTracker.Mapping.Base;
    using TaskTracker.Mapping.Configuration;
    using TaskTracker.Mapping.Configuration.Base;
    using TaskTracker.Mapping.Dto;
    using TaskTracker.Mapping.Messaging;
    using TaskTracker.Mapping.ViewModel;
    using TaskTracker.Messaging.Base;
    using TaskTracker.Messaging.Builders;
    using TaskTracker.Messaging.Smtp;
    using TaskTracker.ViewModels.Json.Auth;
    using TaskTracker.ViewModels.Json.User;
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
            #region Messaging bindings

            kernel.Bind<ISmtpConfiguration>().ToConstant(
                new SmtpConfiguration
                {
                    MailAddress = "mail@gmail.com",
                    EnableSsl = true,
                    Password = "password",
                    Port = 587,
                    SmtpProvider = "smtp.googlemail.com"
                });
            kernel.Bind<IMailEntityToMailMessageMapper>()
                .To<MailEntityToMailMessageMapper>();
            kernel.Bind<IMailSender>().To<SmtpMailSender>();
            kernel.Bind<IMailBuilder>().To<MailBuilder>();
            kernel.Bind<IMessageTemplateFactory>().To<MessageFactory>();
            kernel.Bind<ITemplateSender>().To<TemplateSender>();

            #endregion

            #region Repositories and UOF bindings

            kernel.Bind<ILocationRepository>().To<LocationRepository>();
            kernel.Bind<IUserContactsRepository>()
                .To<UserContactsRepository>();
            kernel.Bind<IWorkTaskCategoryRepository>()
                .To<WorkTaskCategoryRepository>();
            kernel.Bind<IWorkTaskDateInfoRepository>()
                .To<WorkTaskDateInfoRepository>();
            kernel.Bind<IWorkTaskPointProgressRepository>()
                .To<WorkTaskPointProgressRepository>();
            kernel.Bind<IWorkTaskPointRepository>()
                .To<WorkTaskPointRepository>();
            kernel.Bind<IWorkTaskProgressRepository>()
                .To<WorkTaskProgressRepository>();
            kernel.Bind<IWorkTaskRepository>().To<WorkTaskRepository>();
            kernel.Bind<IWorkTaskUserRepository>()
                .To<WorkTaskUserRepository>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            #endregion

            #region Mapping bindings

            kernel.Bind<IMapperConfiguration>().To<AutomapperConfiguration>();
            kernel.Bind<IMapper<WorkTask, WorkTaskDto>>()
                .To<WorkTaskDtoMapper>();
            kernel.Bind<IMapper<WorkTaskPoint, WorkTaskPointDto>>()
                .To<WorkTaskPointDtoMapper>();
            kernel.Bind<IMapper<WorkTaskUser, WorkTaskUserDto>>()
                .To<WorkTaskUserDtoMapper>();
            kernel.Bind<ILeftSideMapper<RegisterUserViewModel,
                WorkTaskUserDto>>().To<RegisterUserViewModelMapper>();
            kernel.Bind<IMapper<WorkTaskUserDto, WorkTaskUserViewModel>>()
                .To<WorkTaskUserViewModelMapper>();

            #endregion

            #region Services bindings

            kernel.Bind<IWorkTaskPointService>().To<WorkTaskPointService>();
            kernel.Bind<IWorkTaskService>().To<WorkTaskService>();
            kernel.Bind<IWorkTaskUserService>().To<WorkTaskUserService>();

            #endregion

        }        
    }
}