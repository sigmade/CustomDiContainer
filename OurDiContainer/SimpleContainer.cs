namespace OurDiContainer
{
    public class SimpleContainer
    {
        // Словарь интерфейсов+экземпляров сервисов для построения графа зависимостей
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        // Регистрация нового сервиса
        public void AddNewService(Type interfaceServiceType, Type serviceType)
        {
            // Получение экземляра класса по его типу
            var instanceService = GetInstance(serviceType);
            // Добавляем тип интерфейс и экземпляр класс в словарь 
            _services.Add(interfaceServiceType, instanceService);
        }

        // Получение экземпляра из словаря или за счет создания нового
        public object GetInstance(Type type)
        {
            // Смотрим есть ли уже экземпляр в словаре если нет то создаем его
            if (_services.TryGetValue(type, out var instance))
            {
                return instance;
            }
            else if (!type.IsAbstract)
            {
                return CreateInstance(type);
            }
            throw new InvalidOperationException("No registration for " + type);
        }

        // Метод принимает тип, возвращает экземпляр со всеми зависимостями
        private object CreateInstance(Type type)
        {
            // Получаем конструктор
            var ctor = type.GetConstructors().Single();
            // Получаем информацию параметров конструктора
            var ctorParamsInfo = ctor.GetParameters();
            // Из инфо получаем типы параметров
            var ctorParamTypes = ctorParamsInfo.Select(p => p.ParameterType);
            // Создаем коллекцию экземпляров параметров к-ра
            var ctorParamInstances = new List<object>();

            // На каждый тип параметра создаем экземпляр и добавляем его в колллекцию выше
            foreach (var ctorParamType in ctorParamTypes)
            {
                // !!! Рекурсивно вызывается GetInstance
                // т.к. у объекта параметра могут быть так же объекты параметры ...
                var ctorParamInstance = GetInstance(ctorParamType);
                ctorParamInstances.Add(ctorParamInstance);
            }

            // С помощью рефлексии создаем экземпляр класса по его типу, и передаем массив параметров
            // которые необходимы конструктору нашего класса
            var instance = Activator.CreateInstance(type, ctorParamInstances.ToArray());
            return instance;
        }
    }
}
