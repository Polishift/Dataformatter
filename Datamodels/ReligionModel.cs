namespace Dataformatter.Datamodels
{
    public class ReligionModel : IModel
    {
        public string CountryName { get; set; }
        public int Year { get; set; }

        // Christianity
        public int ChrstProt { get; set; }
        public int ChrstCat { get; set; }
        public int ChrstOrth { get; set; }
        public int ChrstAng { get; set; }
        public int ChrstOther { get; set; }
        public int ChrstTotal { get; set; }

        // Judaism
        public int JudOrth { get; set; }
        public int JudCons { get; set; }
        public int JudRef { get; set; }
        public int JudOther { get; set; }
        public int JudTotal { get; set; }

        // Islam
        public int IslmSun { get; set; }
        public int IslmShi { get; set; }
        public int IslmIbd { get; set; }
        public int IslmNat { get; set; }
        public int IslmAlw { get; set; }
        public int IslmAhm { get; set; }
        public int IslmOther { get; set; }
        public int IslmTotal { get; set; }

        // Budism
        public int BudMah { get; set; }
        public int BudThr { get; set; }
        public int BudOther { get; set; }
        public int BudTotal { get; set; }
        
        // Zoroastrian
        public int ZoroTotal { get; set; }

        // Hindu
        public int HindTotal { get; set; }

        // Sikh
        public int SikhTotal { get; set; }

        // Shinto
        public int ShntTotal { get; set; }

        // Baha'i
        public int BahTotal { get; set; }

        // Taoism
        public int TaoTotal { get; set; }

        // Confucianism
        public int ConfTotal { get; set; }

        // Jainism
        public int JainTotal { get; set; }

        // Syncretic Religions
        public int SyncTotal { get; set; }

        // Animist Religions
        public int AnmTotal { get; set; }

        // Non. religious
        public int NonTotal { get; set; }

        // Other Religions
        public int OtherTotal { get; set; }

        // Total 
        public int SumTotal { get; set; }
    }
}

