﻿using System.Reflection;
using System.Web.Mvc;
using AngularTutorial.Repository;
using AngularTutorial.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace AngularTutorial.Web
{
    public static class DependencyInjectionConfig
    {
        internal static Container DependencyInjectionContainer;

        public static void Register()
        {
            DependencyInjectionContainer = new Container();
            DependencyInjectionContainer.RegisterTypes();
            DependencyInjectionContainer.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyInjectionContainer.RegisterMvcAttributeFilterProvider();
            DependencyInjectionContainer.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(DependencyInjectionContainer));
        }

        static void RegisterTypes(this Container container)
        {
            container.Register<ICacheRepository, InMemoryCacheRepository>();
            container.Register<ICourseService, CourseService>();
        }
    }
}