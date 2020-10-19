using OCAirLines.Authentication.Services;
using OCAirLines.Authentication.Services.Intefaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCAirline.Testes
{
    public class InjectionContainer
    {
        private static Container container;
        public InjectionContainer()
        {
            container = new Container();

            container.Register<IAppAuthServices, AppAuthServices>(Lifestyle.Singleton);
        }

        public static T GetInstance<T>()
        {
            return (T)container.GetInstance(typeof(T));
        }
    }
}
