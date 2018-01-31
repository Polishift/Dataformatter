namespace Dataformatter.Dataprocessing.Entities
{
    //Exclude dictatorships somehow since the classifiers exclude them
    public class FutureRulerEntity : IEntity
    {
        public string CountryCode { get; set; }
        public string FutureRulingPartyClassification { get; set; }
    }
}