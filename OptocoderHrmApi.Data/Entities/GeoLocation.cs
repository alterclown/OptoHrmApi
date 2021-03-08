using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class GeoLocation
    {
        public int GeoLocationId { get; set; }
        public string Ip { get; set; }
        public int? EmployeeId { get; set; }
        public string HostName { get; set; }
        public string Type { get; set; }
        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string GeonameId { get; set; }
        public string Capital { get; set; }
        public string CountryFlag { get; set; }
        public string CountryFlagEmoji { get; set; }
        public string CountryFlagEmojiUnicode { get; set; }
        public string CallingCode { get; set; }
        public bool? IsEu { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Native { get; set; }
        public string Id { get; set; }
        public DateTime CurrentTime { get; set; }
        public string GmtOffset { get; set; }
        public bool? IsDaylightSaving { get; set; }
        public string Plural { get; set; }
        public string Symbol { get; set; }
        public string SymbolNative { get; set; }
        public string Asn { get; set; }
        public string Isp { get; set; }
        public bool? IsProxy { get; set; }
        public string ProxyType { get; set; }
        public bool? IsCrawler { get; set; }
        public string CrawlerName { get; set; }
        public string CrawlerType { get; set; }
        public bool? IsTor { get; set; }
        public string ThreatLevel { get; set; }
        public string ThreatTypes { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
