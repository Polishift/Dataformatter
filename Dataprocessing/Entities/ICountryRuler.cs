using System.Collections.Generic;

namespace Dataformatter.Dataprocessing.Entities
{
    public enum RulerType
    {
        Dictator,
        Elected
    }

    public static class PrettifiedPartyClassifications
    {
        public static readonly Dictionary<string, string> prettifiedPartyClassifications = new Dictionary<string, string>()
        {
            {"unknown", "Unknown"}, 
            {"no family", "No family"}, 
            {"christdem", "Christian Democrats"}, 
            {"libdem", "Liberal Democrats"}, 
            {"cons", "Conservative"}, 
            {"confessional", "Confessional"}, 
            {"socialist", "Socialist"}, 
            {"liberal", "Liberal"},
            {"rad left", "Radical Left"}, 
            {"rad right", "Radical Right"}, 
            {"green", "Green/Environmentalists"}, 
            {"agrarian/center", "Center"}, 
            {"regionalist", "Regionalist/Separatist"}
        };
    }
    
    public interface ICountryRuler
    {
        string CountryCode { get; set; }
        string PartyClassification { get; set; }

        RulerType GetRulerType();
    }
}