using System.Web.Mvc;
using TrackMateBackend.Controllers;
using TrackMateBackend.DataAccess;
using Unity;
using Unity.Mvc5;
using TrackMateBackend.Interfaces;
//using TrackMateBackend.DataAccess;

namespace TrackMateBackend
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register your interfaces and implementations
            container.RegisterType<IBusDetails, DABusDetails>();
            container.RegisterType<IDeviceDetails, DADeviceDetails>();
            container.RegisterType<IDriverDetails, DADriverDetails>();
            container.RegisterType<INotificationDetails, DANotificationDetails>();
            container.RegisterType<IOwnerDetails, DAOwnerDetails>();
            container.RegisterType<IParentDetails, DAParentDetails>();
            ///container.RegisterType<IRoutesDetails, DARoutesDetails>();
            container.RegisterType<ISchoolDetails, DASchoolDetails>();
            container.RegisterType<IStudentDetails, DAStudentDetails>();
            container.RegisterType<IUserDetails, DAUserDetails>();

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
