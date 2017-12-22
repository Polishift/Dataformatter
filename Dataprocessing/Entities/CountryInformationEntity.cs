namespace Dataformatter.Dataprocessing.Entities
{
    public class CountryInformationEntity : IEntity
    {
        public int Year { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public double EmployedPercentage { get; set; }

        public int GdpTotal { get; set; }
        public int GdpPerCapita { get; set; }

        public int Population { get; set; }

        // Christianity
        public int ChrstProt { get; set; }

        public int ChrstCat { get; set; }
        public int ChrstOther { get; set; }
        public int ChrstTotal { get; set; }

        // Judaism
        public int JudTotal { get; set; }

        // Islam
        public int IslmTotal { get; set; }

        // Budism
        public int BudTotal { get; set; }

        // Non. religious
        public int NonTotal { get; set; }

        public int Other { get; set; }

        public double Tv { get; set; }

        public int MilitairPop { get; set; }
        public int UrbanPop { get; set; }

        public int Interest { get; set; }
    }
}