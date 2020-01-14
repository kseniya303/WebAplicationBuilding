using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Common.Extensions
{
    public static class EnumExtension
    {
        public static void SeedEnumValues<T, TEnum>(this IDbSet<T> dbSet, Func<TEnum, T> converter)
            where T : class
            => Enum.GetValues(typeof(TEnum))
                                .Cast<object>()
                                .Select(value => converter((TEnum)value))
                                .ToList()
                                .ForEach(instance => dbSet.AddOrUpdate(instance));

        public static String GetEnumText(this Enum e)
        {
            var type = e.GetType();

            var memberInfos = type.GetMember(e.ToString());

            if (memberInfos.Length <= 0)
                return e.ToString();

            var attributes = memberInfos[0]
                .GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.Length <= 0)
                return e.ToString();

            return ((DisplayAttribute)attributes[0]).Name;
        }

    }
}
