using Castle.DynamicProxy;
using Castle_Windsor_AOP.Interceptors.Attributes;
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
            // We can use a custom attribute to block any permissions checks (eg for logins, public controller actions etc).
            // You can use attributes to pass conditions to the interceptor as well (eg if we wanted to check a specific role).
            // Note you can also inspect the parameters passed into the method, if the permissions are based on the data being acted on.
            else if (AttributeExistsOnMethod<DoNotPerformPermissionCheck>(invocation))
            {
                invocation.Proceed();
            }
            else if (PermissionsStub.IsUserPermittedToContinue)
            {
                invocation.Proceed();
            }
            else
            {
                throw new SecurityException("The user is not permitted to run this method");
            }
        }

        #endregion

        private static bool AttributeExistsOnMethod<AttributeToCheck>(IInvocation invocation)
        {
            var attribute = Attribute.GetCustomAttribute(invocation.Method, typeof(AttributeToCheck), true);

            return attribute != null;
        }
    }
}
