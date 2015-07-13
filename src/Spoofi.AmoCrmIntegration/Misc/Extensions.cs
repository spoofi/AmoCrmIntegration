using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Spoofi.AmoCrmIntegration.Misc
{
    internal static class StringExtensions
    {
        internal static bool HasValue(this string str)
        {
            return !string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str);
        }
    }

    internal static class EnumExtensions
    {
        internal static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var memberInfo = value.GetType().GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof (T), false);
            return (T) attributes[0];
        }

        internal static string GetDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }

    internal static class SerializationExtensions
    {
        internal static string ToJson(this object self)
        {
            return JsonConvert.SerializeObject(self);
        }

        internal static T DeserializeTo<T>(this string self) where T : class
        {
            return JsonConvert.DeserializeObject<T>(self);
        }
    }
}