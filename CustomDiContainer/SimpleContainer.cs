using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDiContainer
{
    public class SimpleContainer
    {
        private readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

        public void AddNew(Type abstractService, Type concreteService)
        {
            var obj = GetInstance(concreteService);
            Services.Add(abstractService, obj);
        }

        public object GetInstance(Type type)
        {
            if (Services.TryGetValue(type, out var obj))
            {
                return obj;
            }
            else if (!type.IsAbstract)
            {
                return CreateInstance(type);
            }
            throw new InvalidOperationException("No registration for " + type);
        }

        private object CreateInstance(Type implementationType)
        {
            var ctor = implementationType.GetConstructors().Single();
            var paramTypes = ctor.GetParameters().Select(p => p.ParameterType);
            var ctorParamObjects = new List<object>();

            foreach (var type in paramTypes)
            {
                ctorParamObjects.Add(GetInstance(type));
            }

            var result = Activator.CreateInstance(implementationType, ctorParamObjects.ToArray());
            return result;
        }
    }
}
