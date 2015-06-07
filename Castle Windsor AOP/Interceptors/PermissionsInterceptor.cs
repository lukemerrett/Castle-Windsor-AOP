using Castle.DynamicProxy;
using Castle_Windsor_AOP.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Castle_Windsor_AOP.Interceptors
{
    public class PermissionsInterceptor : IInterceptor
    {
        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Checking Permissions");

            // We only want this inteception to apply to methods with public accessibility.
            if (!invocation.Method.IsPublic)
            {
                invocation.Proceed();
            }

            if (PermissionsStub.IsUserPermittedToContinue)
            {
                invocation.Proceed();
            }
            else
            {
                throw new SecurityException("The user is not permitted to run this method");
            }
        }

        #endregion
    }
}
