using System.Reflection;

namespace webapi.Services.Utils
{
    public class ObjectLogger
    {
        public static void LogObject(object obj)
        {
            Console.WriteLine($"Checking object: {obj} ");
            if (obj == null)
            {
                Console.WriteLine("Object is null");
                return;
            }

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                Console.WriteLine($"{property.Name}: {value}");
            }
        }
    }
}
