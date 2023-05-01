using System.Reflection;

namespace Helpers
{
    public static class ReflectionExtensions
    {
        public static T? GetNonPublicPropertyValue<T>(this object instance, string propertyName)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            var type = instance.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var info = type.GetProperty(propertyName, bindingFlags);
            if (info is null) throw new ArgumentException($"Couldn't find property {propertyName} in type {type.FullName}");
            var value = info.GetValue(instance, null);
            T? result = value is null ? default : (T)value;
            return result;
        }

        public static void SetNonPublicPropertyValue<T>(this object instance, string propertyName, T value)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            var type = instance.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var info = type.GetProperty(propertyName, bindingFlags);
            if (info is null) throw new ArgumentException($"Couldn't find property {propertyName} in type {type.FullName}");
            info.SetValue(instance, value);
        }

        public static T? GetNonPublicField<T>(this object instance, string fieldName)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            var type = instance.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var info = type.GetField(fieldName, bindingFlags);
            if (info is null) throw new ArgumentException($"Couldn't find property {fieldName} in type {type.FullName}");
            var value = info.GetValue(instance);
            T? result = value is null ? default : (T)value;
            return result;
        }

        public static void SetNonPublicField<T>(this object instance, string fieldName , T value)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            var type = instance.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var info = type.GetField(fieldName, bindingFlags);
            if (info is null) throw new ArgumentException($"Couldn't find property {fieldName} in type {type.FullName}");
            info.SetValue(instance, value);
        }

        public static T? CallNonPublicMethod<T>(this object instance, string methodName, object[]? parameters)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            var type = instance.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var info = type.GetMethod(methodName, bindingFlags);
            if (info is null) throw new ArgumentException($"Couldn't find property {methodName} in type {type.FullName}");
            var value = info.Invoke(instance, parameters);
            T? result = value is null ? default : (T)value;
            return result;
        }
    }
}