namespace Dataformatter.Datamodels
{
    public class ReligionModel : IModel
    {
        public string CountryName { get; set; }
        public int Year { get; set; }

        // Christianity
        public int ChrstProt { get; set; }

        public int ChrstCat { get; set; }
        public int ChrstTotal { get; set; }

        // Judaism
        public int JudTotal { get; set; }

        // Islam
        public int IslmTotal { get; set; }

        // Budism
        public int BudTotal { get; set; }

        // Non. religious
        public int NonTotal { get; set; }

        // Total 
        public int SumTotal { get; set; }
    }
}