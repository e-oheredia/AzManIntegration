using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web;
using Microsoft.Interop.Security.AzRoles;

namespace AzManAuthApi.Services
{
    public class AzAuthService
    {
        IAzAuthorizationStore authorizationStore;
        string azManPath;
        string applicationName;

        public AzAuthService(string azManPath, string applicationName)
        {
            this.azManPath = azManPath;
            this.applicationName = applicationName;
            authorizationStore = new AzAuthorizationStore();
        }

        public bool checkAccess(string name, int operationId, out string username)
        {
            IAzClientContext context = null;

            try
            {
                context = getContext();
            }
            catch (COMException)
            {
                throw;
            }
            
            object[] operationIds = new object[1];
            operationIds[0] = operationId;
            object[] results = context.AccessCheck(name, new object[1], operationIds, null, null, null, null, null);
            username = WindowsIdentity.GetCurrent().Name;
            return results[0].ToString() == "0";
        }

        public IAzClientContext getContext()
        {
            authorizationStore.Initialize(0, azManPath);
            try
            {
                IAzApplication azApplication = authorizationStore.OpenApplication(applicationName);
                return azApplication.InitializeClientContextFromToken((ulong)WindowsIdentity.GetCurrent().Token.ToInt64());
            }
            catch (COMException)
            {
                throw;
            }         

        }


    }
}