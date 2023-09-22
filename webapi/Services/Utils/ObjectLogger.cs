using System.Collections;
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

            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                // If obj is a collection (e.g., List), iterate through its elements
                int index = 0;
                foreach (var item in (IEnumerable)obj)
                {
                    Console.WriteLine($"Element {index} of collection:");

                    PropertyInfo[] itemProperties = item.GetType().GetProperties();
                    foreach (PropertyInfo property in itemProperties)
                    {
                        object value = property.GetValue(item);
                        Console.WriteLine($"{property.Name}: {value}");
                    }

                    index++;
                }
            }
            else
            {
                // Handle the case when obj is a single object
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(obj);
                    Console.WriteLine($"{property.Name}: {value}");
                }
            }
        }
    }
}
