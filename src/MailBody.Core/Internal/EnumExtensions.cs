using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace MailBody.Core.Internal;

internal static class EnumExtensions
{
    /// <summary>
    /// Get the Description from the DescriptionAttribute.
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    internal static string GetDescription<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        return typeof(TEnum).GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DescriptionAttribute>()?
                            .Description!;
    }
}