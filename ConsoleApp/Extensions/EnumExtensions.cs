using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Enums.Attributes;
using ConsoleApp.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConsoleApp.Extensions
{
    public static class EnumExtensions
    {
        public static bool isHaveInDirectionEnum(this char outDirection)
        {
            foreach (var item in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                var charValue = item.GetAttribute<CharValue>().value;
                if (charValue == outDirection) return true;
            }
            return false;
        }

        public static Direction GetDirectionEnum(this char outDirection)
        {
            foreach (var item in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                var charValue = item.GetAttribute<CharValue>().value;
                if (charValue == outDirection) return item;
            }
            throw new RobotException("Sanırım yönümü bulamadım");
        }
        public static bool isHaveInDirectionEnum(this string outDirection)
        {
            foreach (var item in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                var charValue = item.GetAttribute<CharValue>().value.ToString();
                if (charValue == outDirection) return true;
            }
            return false;
        }

        public static Direction GetDirectionEnum(this string outDirection)
        {
            foreach (var item in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                var charValue = item.GetAttribute<CharValue>().value.ToString();
                if (charValue == outDirection) return item;
            }
            throw new RobotException("Sanırım yönümü bulamadım");
        }

        public static string GetExceptionEnum(this ExceptionEnum value)
        {
            return $"#{value.GetHashCode()}# : {value.GetAttribute<DisplayAttribute>().Name}";
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value)
                where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name) // I prefer to get attributes this way
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}
