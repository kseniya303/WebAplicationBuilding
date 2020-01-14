using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Building.Menu;
using Common.Attributes;

namespace Building.UiManager
{
    public abstract class UiManager : IUiManager
    {
        public abstract void Process(MenuItem menuItem);

        protected T Read<T>() 
            where T : class
        {
            var type = typeof(T);
            var properties = type
                .GetProperties()
                .Where(prop => !prop.CustomAttributes
                    .Any(attr => attr.AttributeType == typeof(DatabaseGeneratedAttribute)) &&
                    !prop.CustomAttributes
                    .Any(attr => attr.AttributeType == typeof(UiManagerIgnoreAttribute)));

            var result = (T)Activator.CreateInstance(type);

            foreach (PropertyInfo prop in properties)
            {
                Console.WriteLine($"Введите {prop.Name}:");
                var isCorrect = false;
                while (!isCorrect)
                {
                    try
                    {
                        var strValue = Console.ReadLine();

                        if (prop.PropertyType.BaseType == typeof(Enum))
                        {
                            var propValue = Enum.Parse(prop.PropertyType, strValue);
                            prop.SetValue(result, propValue);
                        }
                        else
                        {
                            var propValue = Convert.ChangeType(strValue, prop.PropertyType);
                            prop.SetValue(result, propValue);
                        }

                        isCorrect = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }

            return result;
        }

        protected int ReadKey<T>()
        {
            var type = typeof(T);
            var properties = type
                .GetProperties()
                .Where(prop => prop.CustomAttributes
                    .Any(attr => attr.AttributeType == typeof(KeyAttribute)));
            foreach (PropertyInfo prop in properties)
            {
                Console.WriteLine($"Введите {prop.Name}:");
                var isCorrect = false;
                while (!isCorrect)
                {
                    try
                    {
                        var strValue = Console.ReadLine();
                        var propValue = int.Parse(strValue);
                        return propValue;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }
            return 0;
        }

        protected void Write<T>(T entity) 
            where T : class
        {
            var type = typeof(T);
            var properties = type
                .GetProperties()
                .Where(prop => !prop.CustomAttributes
                    .Any(attr => attr.AttributeType == typeof(UiManagerIgnoreAttribute)));

            foreach (var prop in properties)
            {
                Console.Write($"{ prop.Name} { prop.GetValue(entity)} ");
            }
        }

        protected void WriteAll<T>(IQueryable<T> items) 
            where T : class
        {
            foreach (var item in items)
            {
                Write<T>(item);
                Console.WriteLine();
            }
        }
    }
}
