using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle_Windsor_AOP.Interceptors;
using Castle_Windsor_AOP.ServiceLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Castle_Windsor_AOP
{
    [TestFixture]
    public class InterceptionTests
    {
        private WindsorContainer _container;

        private ITradeManager _tradeManager;

        [SetUp]
        public void TestSetUp()
        {
            _container = new WindsorContainer();

            RegisterDynamicInterceptor();

            RegisterAllTypesInAssembly();

            // Get the current implementation of ITradeManager from the IoC container.
            // We must use DI in order to add the dynamic proxy to the methods.
            _tradeManager = _container.Resolve<ITradeManager>();
        }

        [Test]
        public void GetTodaysTrades_UserIsPermittedToViewTrades_TradesAreReturned()
        {
            PermissionsStub.IsUserPermittedToContinue = true;

            var trades = _tradeManager.GetTodaysTrades();

            Assert.IsNotNull(trades);
            Assert.IsTrue(trades.Any());
        }

        [Test]
        public void GetTodaysTrades_UserIsNotPermittedToViewTrades_SecurityExceptionThrown()
        {
            PermissionsStub.IsUserPermittedToContinue = false;

            Assert.Throws<SecurityException>(() => _tradeManager.GetTodaysTrades());
        }

        /// <summary>
        /// Registers our custom permissions interceptor.
        /// </summary>
        private void RegisterDynamicInterceptor() 
        {
            _container.Register(
                    Component.For<IInterceptor>()
                    .ImplementedBy<PermissionsInterceptor>());
        }

        /// <summary>
        /// Registers all the public types in the current assembly 
        /// and adds the permissions interceptor to all public methods.
        /// </summary>
        private void RegisterAllTypesInAssembly()
        {
            var classesToRegister = Classes.FromThisAssembly()
                    .Where(type => type.IsPublic)
                    .WithService
                    .FirstInterface();

            _container.Register(
                classesToRegister
                .Configure(delegate(ComponentRegistration c) 
                {
                    var x = c.Interceptors(InterceptorReference.ForType<IInterceptor>()).Anywhere; 
                }));
        }
    }
}
