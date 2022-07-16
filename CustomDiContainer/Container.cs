using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDiContainer
{
    public class Container
    {
        private readonly Dictionary<Type, Func<object>> regs = new();

        public void Register<TService, TImpl>() where TImpl : TService =>
            regs.Add(typeof(TService), () => this.GetInstance(typeof(TImpl)));

        public void Register<TService>(Func<TService> factory) =>
            regs.Add(typeof(TService), () => factory());

        public void RegisterInstance<TService>(TService instance) =>
            regs.Add(typeof(TService), () => instance);

        public void RegisterSingleton<TService>(Func<TService> factory)
        {
            var lazy = new Lazy<TService>(factory);
            Register(() => lazy.Value);
        }

        public object GetInstance(Type type)
        {
            if (regs.TryGetValue(type, out Func<object> fac)) return fac();
            else if (!type.IsAbstract) return this.CreateInstance(type);
            throw new InvalidOperationException("No registration for " + type);
        }

        private object CreateInstance(Type implementationType)
        {
            var ctor = implementationType.GetConstructors().Single();
            var paramTypes = ctor.GetParameters().Select(p => p.ParameterType);
            var dependencies = paramTypes.Select(GetInstance).ToArray();
            return Activator.CreateInstance(implementationType, dependencies);
        }
    }
}
