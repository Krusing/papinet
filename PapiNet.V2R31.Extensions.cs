namespace PapiNet.V2R31.Extensions;
using System.Reflection;
using System.Runtime.Serialization;

internal static class Extensions
{
  public static string GetMemberValue<T>(this T value) where T : struct, Enum
  {
      var name = Enum.GetName(typeof(T), value);
      if (name == null)
          return value.ToString();

      var member = typeof(T).GetMember(name).FirstOrDefault();
      var attr = member?.GetCustomAttribute<EnumMemberAttribute>();

      return attr?.Value ?? name;
  }

  public static string GetMemberValue<T>(this T? t) where T : struct, Enum
  {
    if (!t.HasValue)
      return string.Empty;

    var value = t.Value;

    var name = Enum.GetName(typeof(T), value);
    if (name == null)
      return value.ToString();

    var member = typeof(T).GetMember(name).FirstOrDefault();
    var attr = member?.GetCustomAttribute<EnumMemberAttribute>();

    return attr?.Value ?? name;
  }

  public static T ToEnum<T>(this string t) where T : struct, Enum
  {
    foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
    {
      var attr = field.GetCustomAttribute<EnumMemberAttribute>();
      if (attr?.Value == t)
        return (T)field.GetValue(null)!;
    }
    try
    {
      return Enum.Parse<T>(t, true);
    }
    catch
    {
      return default;
    }
  }
}
