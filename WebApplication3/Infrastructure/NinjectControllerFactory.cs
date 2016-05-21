using System;

using System.Web.Mvc;

using System.Web.Routing;

using Ninject;
using WebApplication3.Models.EF;
using WebApplication3.Models.Repository;


namespace WebApplication3.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {



private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {

            ninjectKernel = new StandardKernel();

            AddBindings();

        }

        protected override IController GetControllerInstance(RequestContext

        requestContext, Type controllerType)
        {

            return controllerType == null

            ? null

            : (IController)ninjectKernel.Get(controllerType);

        }

        private void AddBindings()
        {

            ninjectKernel.Bind<EfDbContext>().To<EfDbContext>();
            ninjectKernel.Bind<IProductRepository>().To<ProductRepository>();
             ninjectKernel.Bind<ICheckOutOrderRepository>().To<CheckOutOrderRepository>();
            ninjectKernel.Bind<IPostRepository>().To<PostRepository>();
             ninjectKernel.Bind<IPaymentRepository>().To<PaymentRepository>();


        }

    }

}