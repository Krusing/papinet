namespace PapiNet.V2R31.Enums;
using System.Runtime.Serialization;

public enum DeliveryMessageContextType
{
  [EnumMember(Value = "Return")]
  Return
}

public enum DeliveryMessageStatusType
{
  [EnumMember(Value = "Cancelled")]
  Cancelled,

  [EnumMember(Value = "Original")]
  Original,

  [EnumMember(Value = "Replaced")]
  Replaced
}

public enum DeliveryMessageTypeBook
{
  [EnumMember(Value = "DeliveryMessage")]
  DeliveryMessage,

  [EnumMember(Value = "InitialShipmentAdvice")]
  InitialShipmentAdvice,

  [EnumMember(Value = "LoadedSpecification")]
  LoadedSpecification,

  [EnumMember(Value = "ShipmentAdvice")]
  ShipmentAdvice,

  [EnumMember(Value = "ThirdPartyShipmentAdvice")]
  ThirdPartyShipmentAdvice,

  [EnumMember(Value = "Waybill")]
  Waybill
}

public enum DeliveryMessageTypePaper
{
  [EnumMember(Value = "DeliveryMessage")]
  DeliveryMessage,

  [EnumMember(Value = "InitialShipmentAdvice")]
  InitialShipmentAdvice,

  [EnumMember(Value = "LoadedSpecification")]
  LoadedSpecification,

  [EnumMember(Value = "ShipmentAdvice")]
  ShipmentAdvice,

  [EnumMember(Value = "Waybill")]
  Waybill
}

public enum DeliveryMessageTypeWood
{
  [EnumMember(Value = "DeliveryMessage")]
  DeliveryMessage,

  [EnumMember(Value = "InitialShipmentAdvice")]
  InitialShipmentAdvice,

  [EnumMember(Value = "LoadingOrder")]
  LoadingOrder,

  [EnumMember(Value = "PackingSpecification")]
  PackingSpecification,

  [EnumMember(Value = "ShipmentAdvice")]
  ShipmentAdvice
}

public enum Language
{  
    [EnumMember(Value = "aar")] Afar,
    [EnumMember(Value = "abk")] Abkhazian,
    [EnumMember(Value = "afr")] Afrikaans,
    [EnumMember(Value = "aka")] Akan,
    [EnumMember(Value = "sqi")] Albanian,
    [EnumMember(Value = "amh")] Amharic,
    [EnumMember(Value = "ara")] Arabic,
    [EnumMember(Value = "arg")] Aragonese,
    [EnumMember(Value = "hye")] Armenian,
    [EnumMember(Value = "asm")] Assamese,
    [EnumMember(Value = "ava")] Avaric,
    [EnumMember(Value = "ave")] Avestan,
    [EnumMember(Value = "aym")] Aymara,
    [EnumMember(Value = "aze")] Azerbaijani,
    [EnumMember(Value = "bak")] Bashkir,
    [EnumMember(Value = "bam")] Bambara,
    [EnumMember(Value = "eus")] Basque,
    [EnumMember(Value = "bel")] Belarusian,
    [EnumMember(Value = "ben")] Bengali,
    [EnumMember(Value = "bis")] Bislama,
    [EnumMember(Value = "bod")] Tibetan,
    [EnumMember(Value = "bos")] Bosnian,
    [EnumMember(Value = "bre")] Breton,
    [EnumMember(Value = "bul")] Bulgarian,
    [EnumMember(Value = "mya")] Burmese,
    [EnumMember(Value = "cat")] Catalan,
    [EnumMember(Value = "ces")] Czech,
    [EnumMember(Value = "cha")] Chamorro,
    [EnumMember(Value = "che")] Chechen,
    [EnumMember(Value = "zho")] Chinese,
    [EnumMember(Value = "chu")] ChurchSlavic,
    [EnumMember(Value = "chv")] Chuvash,
    [EnumMember(Value = "cor")] Cornish,
    [EnumMember(Value = "cos")] Corsican,
    [EnumMember(Value = "cre")] Cree,
    [EnumMember(Value = "cym")] Welsh,
    [EnumMember(Value = "dan")] Danish,
    [EnumMember(Value = "deu")] German,
    [EnumMember(Value = "div")] Divehi,
    [EnumMember(Value = "nld")] Dutch,
    [EnumMember(Value = "dzo")] Dzongkha,
    [EnumMember(Value = "ell")] Greek,
    [EnumMember(Value = "eng")] English,
    [EnumMember(Value = "epo")] Esperanto,
    [EnumMember(Value = "est")] Estonian,
    [EnumMember(Value = "ewe")] Ewe,
    [EnumMember(Value = "fao")] Faroese,
    [EnumMember(Value = "fas")] Persian,
    [EnumMember(Value = "fij")] Fijian,
    [EnumMember(Value = "fin")] Finnish,
    [EnumMember(Value = "fra")] French,
    [EnumMember(Value = "fry")] WesternFrisian,
    [EnumMember(Value = "ful")] Fulah,
    [EnumMember(Value = "kat")] Georgian,
    [EnumMember(Value = "gla")] ScottishGaelic,
    [EnumMember(Value = "gle")] Irish,
    [EnumMember(Value = "glg")] Galician,
    [EnumMember(Value = "glv")] Manx,
    [EnumMember(Value = "grn")] Guarani,
    [EnumMember(Value = "guj")] Gujarati,
    [EnumMember(Value = "hat")] Haitian,
    [EnumMember(Value = "hau")] Hausa,
    [EnumMember(Value = "heb")] Hebrew,
    [EnumMember(Value = "her")] Herero,
    [EnumMember(Value = "hin")] Hindi,
    [EnumMember(Value = "hmo")] HiriMotu,
    [EnumMember(Value = "hrv")] Croatian,
    [EnumMember(Value = "hun")] Hungarian,
    [EnumMember(Value = "ibo")] Igbo,
    [EnumMember(Value = "isl")] Icelandic,
    [EnumMember(Value = "ido")] Ido,
    [EnumMember(Value = "iii")] SichuanYi,
    [EnumMember(Value = "iku")] Inuktitut,
    [EnumMember(Value = "ile")] Interlingue,
    [EnumMember(Value = "ina")] Interlingua,
    [EnumMember(Value = "ind")] Indonesian,
    [EnumMember(Value = "ipk")] Inupiaq,
    [EnumMember(Value = "ita")] Italian,
    [EnumMember(Value = "jav")] Javanese,
    [EnumMember(Value = "jpn")] Japanese,
    [EnumMember(Value = "kal")] Kalaallisut,
    [EnumMember(Value = "kan")] Kannada,
    [EnumMember(Value = "kas")] Kashmiri,
    [EnumMember(Value = "kaz")] Kazakh,
    [EnumMember(Value = "khm")] Khmer,
    [EnumMember(Value = "kik")] Kikuyu,
    [EnumMember(Value = "kin")] Kinyarwanda,
    [EnumMember(Value = "kir")] Kyrgyz,
    [EnumMember(Value = "kom")] Komi,
    [EnumMember(Value = "kon")] Kongo,
    [EnumMember(Value = "kor")] Korean,
    [EnumMember(Value = "kua")] Kuanyama,
    [EnumMember(Value = "kur")] Kurdish,
    [EnumMember(Value = "lao")] Lao,
    [EnumMember(Value = "lat")] Latin,
    [EnumMember(Value = "lav")] Latvian,
    [EnumMember(Value = "lim")] Limburgan,
    [EnumMember(Value = "lin")] Lingala,
    [EnumMember(Value = "lit")] Lithuanian,
    [EnumMember(Value = "ltz")] Luxembourgish,
    [EnumMember(Value = "lub")] LubaKatanga,
    [EnumMember(Value = "lug")] Ganda,
    [EnumMember(Value = "mkd")] Macedonian,
    [EnumMember(Value = "mlg")] Malagasy,
    [EnumMember(Value = "msa")] Malay,
    [EnumMember(Value = "mal")] Malayalam,
    [EnumMember(Value = "mlt")] Maltese,
    [EnumMember(Value = "mri")] Maori,
    [EnumMember(Value = "mar")] Marathi,
    [EnumMember(Value = "mah")] Marshallese,
    [EnumMember(Value = "mon")] Mongolian,
    [EnumMember(Value = "nau")] Nauru,
    [EnumMember(Value = "nav")] Navajo,
    [EnumMember(Value = "nde")] NorthNdebele,
    [EnumMember(Value = "nbl")] SouthNdebele,
    [EnumMember(Value = "ndo")] Ndonga,
    [EnumMember(Value = "nep")] Nepali,
    [EnumMember(Value = "nno")] NorwegianNynorsk,
    [EnumMember(Value = "nob")] NorwegianBokmal,
    [EnumMember(Value = "nor")] Norwegian,
    [EnumMember(Value = "nya")] Chichewa,
    [EnumMember(Value = "oci")] Occitan,
    [EnumMember(Value = "oji")] Ojibwa,
    [EnumMember(Value = "ori")] Oriya,
    [EnumMember(Value = "orm")] Oromo,
    [EnumMember(Value = "oss")] Ossetian,
    [EnumMember(Value = "pan")] Punjabi,
    [EnumMember(Value = "pli")] Pali,
    [EnumMember(Value = "pol")] Polish,
    [EnumMember(Value = "por")] Portuguese,
    [EnumMember(Value = "pus")] Pashto,
    [EnumMember(Value = "que")] Quechua,
    [EnumMember(Value = "roh")] Romansh,
    [EnumMember(Value = "ron")] Romanian,
    [EnumMember(Value = "run")] Rundi,
    [EnumMember(Value = "rus")] Russian,
    [EnumMember(Value = "sag")] Sango,
    [EnumMember(Value = "san")] Sanskrit,
    [EnumMember(Value = "sin")] Sinhala,
    [EnumMember(Value = "slk")] Slovak,
    [EnumMember(Value = "slv")] Slovenian,
    [EnumMember(Value = "sme")] NorthernSami,
    [EnumMember(Value = "smo")] Samoan,
    [EnumMember(Value = "sna")] Shona,
    [EnumMember(Value = "snd")] Sindhi,
    [EnumMember(Value = "som")] Somali,
    [EnumMember(Value = "sot")] SouthernSotho,
    [EnumMember(Value = "spa")] Spanish,
    [EnumMember(Value = "srd")] Sardinian,
    [EnumMember(Value = "srp")] Serbian,
    [EnumMember(Value = "ssw")] Swati,
    [EnumMember(Value = "sun")] Sundanese,
    [EnumMember(Value = "swa")] Swahili,
    [EnumMember(Value = "swe")] Swedish,
    [EnumMember(Value = "tah")] Tahitian,
    [EnumMember(Value = "tam")] Tamil,
    [EnumMember(Value = "tat")] Tatar,
    [EnumMember(Value = "tel")] Telugu,
    [EnumMember(Value = "tgk")] Tajik,
    [EnumMember(Value = "tgl")] Tagalog,
    [EnumMember(Value = "tha")] Thai,
    [EnumMember(Value = "tir")] Tigrinya,
    [EnumMember(Value = "ton")] Tonga,
    [EnumMember(Value = "tsn")] Tswana,
    [EnumMember(Value = "tso")] Tsonga,
    [EnumMember(Value = "tuk")] Turkmen,
    [EnumMember(Value = "tur")] Turkish,
    [EnumMember(Value = "twi")] Twi,
    [EnumMember(Value = "uig")] Uighur,
    [EnumMember(Value = "ukr")] Ukrainian,
    [EnumMember(Value = "urd")] Urdu,
    [EnumMember(Value = "uzb")] Uzbek,
    [EnumMember(Value = "ven")] Venda,
    [EnumMember(Value = "vie")] Vietnamese,
    [EnumMember(Value = "vol")] Volapuk,
    [EnumMember(Value = "wln")] Walloon,
    [EnumMember(Value = "wol")] Wolof,
    [EnumMember(Value = "xho")] Xhosa,
    [EnumMember(Value = "yid")] Yiddish,
    [EnumMember(Value = "yor")] Yoruba,
    [EnumMember(Value = "zha")] Zhuang,
    [EnumMember(Value = "zul")] Zulu
}

public enum YesNo
{
  [EnumMember(Value = "Yes")]
  Yes,

  [EnumMember(Value = "No")]
  No
}
