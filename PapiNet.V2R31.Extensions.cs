namespace PapiNet.V2R31.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

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

  public static T GetEnumAttribute<T>(this XElement element, string name, T fallback) where T : struct, Enum
  {
    var attr = element.Attribute(name);
    return attr is null ? fallback : attr.Value.ToEnum<T>();
  }

  public static T? GetEnumAttribute<T>(this XElement element, string name) where T : struct, Enum
  {
    var attr = element.Attribute(name);
    return attr is null ? null : attr.Value.ToEnum<T>();
  }
  
  [return: NotNullIfNotNull(nameof(fallback))]
  public static T? GetElement<T>(this XElement root, T? fallback) where T : class
  {
    var name = typeof(T).Name;
    var element = root.Element(name);
    return element is null ? fallback : (T)Activator.CreateInstance(typeof(T), element)!;
  }

  public static List<T> GetElements<T>(this XElement root, List<T> fallback) where T : class
  {
    var name = typeof(T).Name;
    return [.. root.Elements(name).Select(e => (T)Activator.CreateInstance(typeof(T), e)!)];
  }

  public static XAttribute? ToAttribute<T>(this T? value) where T : struct, Enum
  {
    if (!value.HasValue) return null;
    return new XAttribute(typeof(T).Name, value.GetMemberValue());
  }

  public static XAttribute ToAttribute<T>(this T value) where T : struct, Enum
  {
    return new XAttribute(typeof(T).Name, value.GetMemberValue());
  }
}
