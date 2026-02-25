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

using PapiNet.V2R31.Enums;
using PapiNet.V2R31.Extensions;
using System.Xml.Linq;

public class Date
{
  public Year Year { get; set; }
  public Month Month { get; set; }
  public Day Day { get; set; }

  public Date()
  {
    Year  = new();
    Month = new();
    Day   = new();
  }

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

  public override string ToString()
  {
    return new XElement("Date",
      Year,
      Month,
      Day
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

  public Day() { }

  public Day(int value)
  {
    Value = value;
  }

  public Day(XElement root)
  {
    bool pass = int.TryParse(root.Value, out var value);
    if (pass is false)
      throw new FormatException("Invalid Day");
    
    Value = value;
  }

  public static implicit operator int(Day day)
  {
    return day._value;
  }

  public static implicit operator Day(int value) 
  { 
    return new Day(value);
  }

  public override string ToString()
  {
    string value = _value.ToString("00");
    return new XElement("Day",
      value
    ).ToString();
  }
}

public class DeliveryMessageShipment
{
  public DeliveryMessageShipment()
  {
    
  }

  public DeliveryMessageShipment(XElement root)
  {
    
  }

  public override string ToString()
  {
    var root = new XElement("DeliveryMessageShipment");

    return root.ToString();
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

  public DeliveryMessageWood()
  {
    
  }

  public DeliveryMessageWood(XElement root)
  {
    XAttribute? 
      deliveryMessageType        = root.Attribute("DeliveryMessageType"),
      deliveryMessageStatusType  = root.Attribute("DeliveryMessageStatusType"),
      deliveryMessageContextType = root.Attribute("DeliveryMessageContextType"),
      reissued                   = root.Attribute("Reissued"),
      language                   = root.Attribute("Language");
    
    DeliveryMessageType        = deliveryMessageType?.Value.ToEnum<DeliveryMessageTypeWood>() ?? DeliveryMessageType;
    DeliveryMessageStatusType  = deliveryMessageStatusType?.Value.ToEnum<DeliveryMessageStatusType>() ?? DeliveryMessageStatusType;
    DeliveryMessageContextType = deliveryMessageContextType?.Value.ToEnum<DeliveryMessageContextType>() ?? DeliveryMessageContextType;
    Reissued                   = reissued?.Value.ToEnum<YesNo>() ?? Reissued;
    Language                   = language?.Value.ToEnum<Language>() ?? Language;

    DeliveryMessageWoodHeader = root.Element("DeliveryMessageWoodHeader") is { } deliveryMessageWoodHeader ? new(deliveryMessageWoodHeader) : DeliveryMessageWoodHeader;
    DeliveryMessageShipment = [.. root.Elements("DeliveryMessageShipment").Select(e => new DeliveryMessageShipment(e))];

    // XElement? element = null;

    // element = root.Element("DeliveryMessageWoodHeader");
    // if (element is not null)
    //     DeliveryMessageWoodHeader = new DeliveryMessageWoodHeader(element);

    // foreach (var shipment in root.Elements("DeliveryMessageShipment"))
    //     DeliveryMessageShipment.Add(new DeliveryMessageShipment(shipment));

    // element = root.Element("DeliveryMessageWoodSummary");
    // if (element is not null)
    //     DeliveryMessageWoodSummary = new DeliveryMessageWoodSummary(element);
  }

  public override string ToString()
  {
    var root = new XElement("DeliveryMessageWood");

    root.Add(new XAttribute("DeliveryMessageType", DeliveryMessageType.GetMemberValue()));
    root.Add(new XAttribute("DeliveryMessageStatusType", DeliveryMessageStatusType.GetMemberValue()));

    if (DeliveryMessageContextType.HasValue)
      root.Add(new XAttribute("DeliveryMessageContextType", DeliveryMessageContextType.Value.GetMemberValue()));

    if (Reissued.HasValue)
      root.Add(new XAttribute("Reissued", Reissued.Value.GetMemberValue()));

    if (Language.HasValue)
      root.Add(new XAttribute("Language", Language.Value.GetMemberValue()));
            
    root.Add(XElement.Parse(DeliveryMessageWoodHeader.ToString()));
    
    foreach (var shipment in DeliveryMessageShipment)
      root.Add(XElement.Parse(shipment.ToString()));
        
    if (DeliveryMessageWoodSummary is not null)
      root.Add(XElement.Parse(DeliveryMessageWoodSummary.ToString()));

    return root.ToString();
  }
}

public class DeliveryMessageWoodHeader
{
  public string DeliveryMessageNumber { get; set; }
  public int? TransactionHistoryNumber { get; set; }

  public DeliveryMessageWoodHeader()
  {
    
  }

  public DeliveryMessageWoodHeader(XElement root)
  {
    
  }

  public override string ToString()
  {
    var root = new XElement("DeliveryMessageWoodHeader");

    return root.ToString();
  }
}

public class DeliveryMessageWoodSummary
{
  public DeliveryMessageWoodSummary()
  {
    
  }

  public DeliveryMessageWoodSummary(XElement root)
  {
    
  }

  public override string ToString()
  {
    var root = new XElement("DeliveryMessageWoodSummary");

    return root.ToString();
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

  public Month() { }

  public Month(int value)
  {
    Value = value;
  }

  public Month(XElement root)
  {
    bool passParse = int.TryParse(root.Value, out var value);
    if (passParse is false)
      throw new FormatException("Invalid Month value.");
    
    Value = value;
  }

  public static implicit operator int(Month month)
  {
    return month._value;
  }

  public static implicit operator Month(int value)
  {
    return new Month(value);
  }

  public override string ToString()
  {
    string value = _value.ToString("00");
    XElement element = new XElement("Month", value);

    return element.ToString();
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

  public Year() { }

  public Year(int value)
  {
    Value = value;
  }

  public Year(XElement root)
  {
    bool passParse = int.TryParse(root.Value, out var value);
    if (passParse is false)
      throw new FormatException("Invalid Year value.");
    
    Value = value;
  }

  public static implicit operator int(Year year)
  {
    return year._value;
  }

  public static implicit operator Year(int value)
  {
    return new Year(value);
  }

  public override string ToString()
  {
    string value = _value.ToString("0000");
    XElement element = new XElement("Year", value);

    return element.ToString();
  }
}
