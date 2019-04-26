using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Enums.Attributes;
using System;
using System.Linq;

namespace ConsoleApp
{
    public static class Extensions
    {
        public static bool isHaveInDirectionEnum(this char outDirection)
        {
            foreach (var item in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                var charValue = GetAttribute<CharValue>(item).value;
                if (charValue == outDirection) return true;
            }
            return false;
        }

        public static Direction GetDirectionEnum(this char outDirection)
        {
            foreach (var item in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                var charValue = GetAttribute<CharValue>(item).value;
                if (charValue == outDirection) return item;
            }
            throw new RobotException("Sanırım yönümü bulamadım");
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
