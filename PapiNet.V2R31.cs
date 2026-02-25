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
  public DeliveryMessageTypeWood DeliveryMessageType { get; set; }
  public DeliveryMessageStatusType DeliveryMessageStatusType { get; set; }
  public DeliveryMessageContextType? DeliveryMessageContextType { get; set; }
  public YesNo? Reissued { get; set; }
  public Language? Language { get; set; }
  public DeliveryMessageWoodHeader DeliveryMessageWoodHeader { get; set; }
  public List<DeliveryMessageShipment> DeliveryMessageShipment { get; set; }
  public DeliveryMessageWoodSummary? DeliveryMessageWoodSummary { get; set; }

  public DeliveryMessageWood()
  {
    DeliveryMessageType = DeliveryMessageTypeWood.DeliveryMessage;
    DeliveryMessageStatusType = DeliveryMessageStatusType.Original;
    DeliveryMessageWoodHeader = new();
    DeliveryMessageShipment = [];
  }

  public DeliveryMessageWood(XElement root)
  {
    DeliveryMessageType = DeliveryMessageTypeWood.DeliveryMessage;
    DeliveryMessageStatusType = DeliveryMessageStatusType.Original;
    DeliveryMessageWoodHeader = new();
    DeliveryMessageShipment = [];
    
    XAttribute? attr = null;

    attr = root.Attribute("DeliveryMessageType");
    if (attr is not null)
        DeliveryMessageType = attr.Value.ToEnum<DeliveryMessageTypeWood>();

    attr = root.Attribute("DeliveryMessageStatusType");
    if (attr is not null)
        DeliveryMessageStatusType = attr.Value.ToEnum<DeliveryMessageStatusType>();

    attr = root.Attribute("DeliveryMessageContextType");
    if (attr is not null)
        DeliveryMessageContextType = attr.Value.ToEnum<DeliveryMessageContextType>();

    attr = root.Attribute("Reissued");
    if (attr is not null)
        Reissued = attr.Value.ToEnum<YesNo>();

    attr = root.Attribute("Language");
    if (attr is not null)
        Language = attr.Value.ToEnum<Language>();

    XElement? element = null;

    element = root.Element("DeliveryMessageWoodHeader");
    if (element is not null)
        DeliveryMessageWoodHeader = new DeliveryMessageWoodHeader(element);

    foreach (var shipment in root.Elements("DeliveryMessageShipment"))
        DeliveryMessageShipment.Add(new DeliveryMessageShipment(shipment));

    element = root.Element("DeliveryMessageWoodSummary");
    if (element is not null)
        DeliveryMessageWoodSummary = new DeliveryMessageWoodSummary(element);
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
          
      if (DeliveryMessageWoodSummary != null)
          root.Add(XElement.Parse(DeliveryMessageWoodSummary.ToString()));

      return root.ToString();
  }
}

public class DeliveryMessageWoodHeader
{
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