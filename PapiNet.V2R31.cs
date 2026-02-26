// -----------------------------------------------------------------------------
// PapiNet.V2R31.cs
// Author: Johan Krusing
//
// This file is an independent C# implementation based on the
// PapiNet V2R31 Data Dictionary specification.
//
// PapiNet and related specification content are the property of
// their respective owners. This project does not claim ownership
// of the PapiNet standard and is not affiliated with or endorsed by
// the PapiNet organization.
//
// This library provides a structural representation of the standard.
// -----------------------------------------------------------------------------

namespace PapiNet.V2R31;

using PapiNet.V2R31.Extensions;
using System.Xml.Linq;

public class Date
{
  public Year Year { get; set; } = new();
  public Month Month { get; set; } = new();
  public Day Day { get; set; } = new();

  internal string Localname = "Date";

  public Date() { }

  public Date(XElement root)
  {
    XElement? year  = root.Element("Year");
    XElement? month = root.Element("Month");
    XElement? day   = root.Element("Day");

    if (year  is null) throw new InvalidOperationException("Year missing");
    if (month is null) throw new InvalidOperationException("Month missing");
    if (day   is null) throw new InvalidOperationException("Day missing");

    Year  = new(year);
    Month = new(month);
    Day   = new(day);
  }

  public static implicit operator Date(DateTime dateTime)
  {
    return new()
    {
      Year  = dateTime.Year,
      Month = dateTime.Month,
      Day   = dateTime.Day
    };
  }

  public override string ToString()
  {
    return new XElement(Localname,
      (XElement) Year,
      (XElement) Month,
      (XElement) Day
    ).ToString();
  }
}

public class Day
{
  private int _value;

  public int Value
  {
    get => _value;
    set
    {
      if (value < 1 || value > 31)
        throw new ArgumentOutOfRangeException(nameof(value));
      _value = value;
    }
  }

  internal static string Localname = "Day";

  public Day() { }

  public Day(int value)
  {
    Value = value;
  }

  public Day(XElement root)
  {
    bool valid = int.TryParse(root.Value, out var value);
    if (valid is false)
      throw new FormatException($"Invalid {Localname} value.");
    Value = value;
  }

  public static implicit operator int(Day day)
  {
    return day.Value;
  }

  public static implicit operator Day(int value) 
  { 
    return new(value);
  }

  public static implicit operator XElement(Day day)
  {
    return new(Localname, day.Value.ToString("00"));
  }

  public override string ToString()
  {
    string value = Value.ToString("00");
    return new XElement(Localname, value).ToString();
  }
}

public class DeliveryMessageDate
{
  public Date Date { get; set; } = new();
  public Time? Time { get; set; }

  internal static string Localname = "DeliveryMessageDate";


}

public class DeliveryMessageNumber
{
  private string _value = "";
  public string Value
  {
    get => _value;
    set
    {
      if (value.Length < 1 || value.Length > 30)
        throw new ArgumentOutOfRangeException(nameof(value), Localname);
      _value = value;
    }
  }

  internal static string Localname = "DeliveryMessageNumber";

  public DeliveryMessageNumber() {}

  public DeliveryMessageNumber(string value)
  {
    Value = value;
  }

  public static implicit operator XElement(DeliveryMessageNumber deliveryMessageNumber)
  {
    return new(Localname, deliveryMessageNumber.Value);
  }

  public static implicit operator DeliveryMessageNumber(string value)
  {
    return new(value);
  }

  public override string ToString()
  {
    return new XElement(Localname, Value).ToString();
  }
}

public class DeliveryMessageShipment
{
  internal static string Localname = "DeliveryMessageShipment";

  public DeliveryMessageShipment()
  {
    
  }

  public DeliveryMessageShipment(XElement root)
  {
    
  }

  public static implicit operator XElement(DeliveryMessageShipment value)
  {
    return new XElement(Localname);
  }

  public override string ToString()
  {
    return ((XElement) this).ToString();
  }
}

public class DeliveryMessageWood
{
  public DeliveryMessageTypeWood DeliveryMessageType { get; set; } = DeliveryMessageTypeWood.DeliveryMessage;
  public DeliveryMessageStatusType DeliveryMessageStatusType { get; set; } = DeliveryMessageStatusType.Original;
  public DeliveryMessageContextType? DeliveryMessageContextType { get; set; }
  public YesNo? Reissued { get; set; }
  public Language? Language { get; set; }
  public DeliveryMessageWoodHeader DeliveryMessageWoodHeader { get; set; } = new();
  public List<DeliveryMessageShipment> DeliveryMessageShipment { get; set; } = [];
  public DeliveryMessageWoodSummary? DeliveryMessageWoodSummary { get; set; }

  internal string Localname = "DeliveryMessageWood";

  public DeliveryMessageWood()
  {
    
  }

  public DeliveryMessageWood(XElement root)
  {
    DeliveryMessageType        = root.GetEnumAttribute("DeliveryMessageType", DeliveryMessageType);
    DeliveryMessageStatusType  = root.GetEnumAttribute("DeliveryMessageStatusType", DeliveryMessageStatusType);
    DeliveryMessageContextType = root.GetEnumAttribute<DeliveryMessageContextType>("DeliveryMessageContextType");
    Reissued                   = root.GetEnumAttribute<YesNo>("Reissued");
    Language                   = root.GetEnumAttribute<Language>("Language");
    DeliveryMessageWoodHeader  = root.GetElement(DeliveryMessageWoodHeader);
    DeliveryMessageShipment    = root.GetElements(DeliveryMessageShipment);
    DeliveryMessageWoodSummary = root.GetElement(DeliveryMessageWoodSummary);
  }

  public static implicit operator XElement(DeliveryMessageWood value)
  {
    return new XElement(value.Localname,
      value.DeliveryMessageType.ToAttribute(),
      value.DeliveryMessageStatusType.ToAttribute(),
      value.DeliveryMessageContextType.ToAttribute(),
      value.Reissued.ToAttribute(),
      value.Language.ToAttribute(),
      value.DeliveryMessageWoodHeader is null ? null : (XElement)value.DeliveryMessageWoodHeader,
      value.DeliveryMessageShipment.Select(s => (XElement)s),
      value.DeliveryMessageWoodSummary is null ? null : (XElement)value.DeliveryMessageWoodSummary
    );
  }

  public override string ToString()
  {
    return ((XElement) this).ToString();
  }
}

public class DeliveryMessageWoodHeader
{
  public DeliveryMessageNumber DeliveryMessageNumber { get; set; } = new();
  public TransactionHistoryNumber? TransactionHistoryNumber { get; set; }

  internal static string Localname = "DeliveryMessageWoodHeader";

  public DeliveryMessageWoodHeader() { }

  public static implicit operator XElement(DeliveryMessageWoodHeader value)
  {
    return new XElement(Localname,
      value.DeliveryMessageNumber    is null ? null : (XElement) value.DeliveryMessageNumber,
      value.TransactionHistoryNumber is null ? null : (XElement) value.TransactionHistoryNumber
    );
  }

  public override string ToString()
  {
    return ((XElement) this).ToString();
  }
}

public class DeliveryMessageWoodSummary
{
  internal static string Localname = "DeliveryMessageWoodSummary";

  public DeliveryMessageWoodSummary()
  {
    
  }

  public DeliveryMessageWoodSummary(XElement root)
  {
    
  }

  public static implicit operator XElement(DeliveryMessageWoodSummary value)
  {
    return new XElement(Localname);
  }

  public override string ToString()
  {
    return ((XElement) this).ToString();
  }
}

public class Month
{
  private int _value;

  public int Value
  {
    get => _value;
    set
    {
      if (value < 1 || value > 12)
        throw new ArgumentOutOfRangeException(nameof(value));
      _value = value;
    }
  }

  internal static string Localname = "Month";

  public Month() { }

  public Month(int value)
  {
    Value = value;
  }

  public Month(XElement root)
  {
    bool valid = int.TryParse(root.Value, out var value);
    if (valid is false)
      throw new FormatException($"Invalid {Localname} value.");
    Value = value;
  }

  public static implicit operator int(Month month)
  {
    return month.Value;
  }

  public static implicit operator Month(int value)
  {
    return new(value);
  }

  public static implicit operator XElement(Month month)
  {
    return new(Localname, month.Value.ToString("00"));
  }

  public override string ToString()
  {
    string value = Value.ToString("00");
    return new XElement(Localname, value).ToString();
  }
}

public class Time
{
  private DateTimeOffset _value;

  internal static string Localname = "Time";

  public DateTimeOffset Value
  {
    get => _value;
    set => _value = value;
  }

  public Time() { }

  public Time(DateTimeOffset value)
  {
    Value = value;
  }

  public Time(XElement root)
  {
    if (!DateTimeOffset.TryParse(root.Value, out var value))
      throw new FormatException($"Invalid {Localname} value.");

    Value = value;
  }

  public static implicit operator Time(DateTimeOffset value)
  {
    return new(value);
  }

  public static implicit operator DateTimeOffset(Time time)
  {
    return time.Value;
  }

  public static implicit operator Time(DateTime value)
  {
    return value.Kind switch
    {
      DateTimeKind.Utc        => new Time(new DateTimeOffset(value, TimeSpan.Zero)),
      DateTimeKind.Local      => new Time(new DateTimeOffset(value)),
      DateTimeKind.Unspecified => new Time(new DateTimeOffset(value, DateTimeOffset.Now.Offset)),
      _ => new Time(new DateTimeOffset(value))
    };
  }

  public static implicit operator XElement(Time time)
  {
    string formatted;

    if (time.Value.Offset == TimeSpan.Zero)
      formatted = time.Value.ToString("HH:mm:ss'Z'");
    else if (time.Value.Offset == DateTimeOffset.Now.Offset)
      formatted = time.Value.ToString("HH:mm:ss");
    else
      formatted = time.Value.ToString("HH:mm:sszzz");

    return new(Localname, formatted);
  }

  public override string ToString()
  {
    return ((XElement) this).ToString();
  }
}

public class TransactionHistoryNumber
{
  private int _value;
  
  public int Value
  {
    get => _value;
    set
    {
      if (value < 0 || value > 999_999_999)
        throw new ArgumentOutOfRangeException(nameof(value), Localname);
      _value = value;
    }
  }

  internal static string Localname = "TransactionHistoryNumber";

  public TransactionHistoryNumber() { }

  public TransactionHistoryNumber(int value)
  {
    Value = value;
  }

  public TransactionHistoryNumber(XElement root)
  {
    bool valid = int.TryParse(root.Value, out var value);
    if (valid is false)
      throw new FormatException($"Invalid {Localname} value.");
    Value = value;
  }

  public static implicit operator int(TransactionHistoryNumber transactionHistoryNumber)
  {
    return transactionHistoryNumber.Value;
  }

  public static implicit operator TransactionHistoryNumber(int value)
  {
    return new(value);
  }

  public static implicit operator XElement(TransactionHistoryNumber transactionHistoryNumber)
  {
    return new(Localname, transactionHistoryNumber.Value.ToString());
  }

  public override string ToString()
  {
    string value = Value.ToString();
    return new XElement(Localname, value).ToString();
  }
}

public class Year
{
  private int _value;

  public int Value
  {
    get => _value;
    set
    {
      if (value < 0 || value > 9999)
        throw new ArgumentOutOfRangeException(nameof(value));
      _value = value;
    }
  }

  internal static string Localname = "Year";

  public Year() { }

  public Year(int value)
  {
    Value = value;
  }

  public Year(XElement root)
  {
    bool valid = int.TryParse(root.Value, out var value);
    if (valid is false)
      throw new FormatException($"Invalid {Localname} value.");
    Value = value;
  }

  public static implicit operator int(Year year)
  {
    return year.Value;
  }

  public static implicit operator Year(int value)
  {
    return new(value);
  }

  public static implicit operator XElement(Year year)
  {
    return new(Localname, year.Value.ToString("0000"));
  }

  public override string ToString()
  {
    string value = Value.ToString("0000");
    return new XElement(Localname, value).ToString();
  }
}
