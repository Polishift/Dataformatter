using System.Collections.Generic;
using System.Linq;

namespace Dataformatter.Data_accessing.Repositories
{
    public static class Iso3166Repository //rename
    {
        private static readonly HashSet<Iso3166Country> Collection = BuildCollection();

        /// <summary>
        /// Obtain ISO3166-1 Country based on its alpha3 code.
        /// </summary>
        /// <param name="alpha3"></param>
        /// <returns></returns>
        public static Iso3166Country FromAlpha3(string alpha3)
        {
            return Collection.FirstOrDefault(p => p.Alpha3 == alpha3);
        }

        public static Iso3166Country FromName(string name)
        {
            return Collection.FirstOrDefault(p => p.Name == name);
        }

        public static Iso3166Country FromAlpha2(string alpha2)
        {
            return Collection.FirstOrDefault(p => p.Alpha2 == alpha2);
        }

        public static Iso3166Country FromAlternativeName(string alternative)
        {
            for (var i = 0; i < Collection.Count; i++)
            {
                var item = Collection.ElementAt(i);
                if (item.AlternativeNames == null) continue;
                if (item.AlternativeNames.Contains(alternative))
                    return item;
            }
            return null;
        }

        #region Build Collection

        private static HashSet<Iso3166Country> BuildCollection()
        {
            var collection = new HashSet<Iso3166Country>();

            // This collection built from Wikipedia entry on ISO3166-1 on 9th Feb 2016
            collection.Add(new Iso3166Country("Afghanistan", "AF", "AFG", 4));
            collection.Add(new Iso3166Country("Åland Islands", "AX", "ALA", 248));
            collection.Add(new Iso3166Country("Albania", "AL", "ALB", 8));
            collection.Add(new Iso3166Country("Algeria", "DZ", "DZA", 12));
            collection.Add(new Iso3166Country("American Samoa", "AS", "ASM", 16));
            collection.Add(new Iso3166Country("Andorra", "AD", "AND", 20));
            collection.Add(new Iso3166Country("Angola", "AO", "AGO", 24));
            collection.Add(new Iso3166Country("Anguilla", "AI", "AIA", 660));
            collection.Add(new Iso3166Country("Antarctica", "AQ", "ATA", 10));
            collection.Add(new Iso3166Country("Antigua and Barbuda", "AG", "ATG", 28));
            collection.Add(new Iso3166Country("Argentina", "AR", "ARG", 32));
            collection.Add(new Iso3166Country("Armenia", "AM", "ARM", 51));
            collection.Add(new Iso3166Country("Aruba", "AW", "ABW", 533));
            collection.Add(new Iso3166Country("Australia", "AU", "AUS", 36));
            collection.Add(new Iso3166Country("Austria", "AT", "AUT", 40));
            collection.Add(new Iso3166Country("Azerbaijan", "AZ", "AZE", 31));
            collection.Add(new Iso3166Country("Bahamas", "BS", "BHS", 44));
            collection.Add(new Iso3166Country("Bahrain", "BH", "BHR", 48));
            collection.Add(new Iso3166Country("Bangladesh", "BD", "BGD", 50));
            collection.Add(new Iso3166Country("Barbados", "BB", "BRB", 52));
            collection.Add(new Iso3166Country("Belarus", "BY", "BLR", 112));
            collection.Add(new Iso3166Country("Belgium", "BE", "BEL", 56));
            collection.Add(new Iso3166Country("Belize", "BZ", "BLZ", 84));
            collection.Add(new Iso3166Country("Benin", "BJ", "BEN", 204));
            collection.Add(new Iso3166Country("Bermuda", "BM", "BMU", 60));
            collection.Add(new Iso3166Country("Bhutan", "BT", "BTN", 64));
            collection.Add(new Iso3166Country("Bolivia (Plurinational State of)", "BO", "BOL", 68));
            collection.Add(new Iso3166Country("Bolivia", "BO", "BOL", 68));
            collection.Add(new Iso3166Country("Bonaire, Sint Eustatius and Saba", "BQ", "BES", 535));
            collection.Add(new Iso3166Country("Bosnia and Herzegovina", "BA", "BIH", 70));
            collection.Add(new Iso3166Country("Botswana", "BW", "BWA", 72));
            collection.Add(new Iso3166Country("Bouvet Island", "BV", "BVT", 74));
            collection.Add(new Iso3166Country("Brazil", "BR", "BRA", 76));
            collection.Add(new Iso3166Country("British Indian Ocean Territory", "IO", "IOT", 86));
            collection.Add(new Iso3166Country("Brunei Darussalam", "BN", "BRN", 96));
           
            var bulAlternatives = new List<string> {"bul"};
            collection.Add(new Iso3166Country("Bulgaria", "BG", "BGR", 100, bulAlternatives));
            collection.Add(new Iso3166Country("Burkina Faso", "BF", "BFA", 854));
            collection.Add(new Iso3166Country("Burundi", "BI", "BDI", 108));
            collection.Add(new Iso3166Country("Cabo Verde", "CV", "CPV", 132));
            collection.Add(new Iso3166Country("Cape Verde", "CV", "CPV", 132));
            collection.Add(new Iso3166Country("Cambodia", "KH", "KHM", 116));
            collection.Add(new Iso3166Country("Cameroon", "CM", "CMR", 120));
            collection.Add(new Iso3166Country("Canada", "CA", "CAN", 124));
            collection.Add(new Iso3166Country("Cayman Islands", "KY", "CYM", 136));
            collection.Add(new Iso3166Country("Central African Republic", "CF", "CAF", 140));
            collection.Add(new Iso3166Country("Chad", "TD", "TCD", 148));
            collection.Add(new Iso3166Country("Chile", "CL", "CHL", 152));
            collection.Add(new Iso3166Country("China", "CN", "CHN", 156));
            collection.Add(new Iso3166Country("Christmas Island", "CX", "CXR", 162));
            collection.Add(new Iso3166Country("Cocos (Keeling) Islands", "CC", "CCK", 166));
            collection.Add(new Iso3166Country("Colombia", "CO", "COL", 170));
            collection.Add(new Iso3166Country("Comoros", "KM", "COM", 174));
            collection.Add(new Iso3166Country("Congo", "CG", "COG", 178));
            collection.Add(new Iso3166Country("Congo (Democratic Republic of the)", "CD", "COD", 180));
            collection.Add(new Iso3166Country("Cook Islands", "CK", "COK", 184));
            collection.Add(new Iso3166Country("Costa Rica", "CR", "CRI", 188));
            collection.Add(new Iso3166Country("Côte d'Ivoire", "CI", "CIV", 384));
            collection.Add(new Iso3166Country("Ivory Coast", "CI", "CIV", 384));
           
            var croAlternatives = new List<string> {"cro"};
            collection.Add(new Iso3166Country("Croatia", "HR", "HRV", 191, croAlternatives));
            collection.Add(new Iso3166Country("Cuba", "CU", "CUB", 192));
            collection.Add(new Iso3166Country("Curaçao", "CW", "CUW", 531));
            collection.Add(new Iso3166Country("Curacao", "CW", "CUW", 531));
            collection.Add(new Iso3166Country("Cyprus", "CY", "CYP", 196));
            collection.Add(new Iso3166Country("Czech Republic", "CZ", "CZE", 203));
            collection.Add(new Iso3166Country("Denmark", "DK", "DNK", 208));
            collection.Add(new Iso3166Country("Djibouti", "DJ", "DJI", 262));
            collection.Add(new Iso3166Country("Dominica", "DM", "DMA", 212));
            collection.Add(new Iso3166Country("Dominican Republic", "DO", "DOM", 214));
            collection.Add(new Iso3166Country("Ecuador", "EC", "ECU", 218));
            collection.Add(new Iso3166Country("Egypt", "EG", "EGY", 818));
            collection.Add(new Iso3166Country("El Salvador", "SV", "SLV", 222));
            collection.Add(new Iso3166Country("Equatorial Guinea", "GQ", "GNQ", 226));
            collection.Add(new Iso3166Country("Eritrea", "ER", "ERI", 232));
            collection.Add(new Iso3166Country("Estonia", "EE", "EST", 233));
            collection.Add(new Iso3166Country("Ethiopia", "ET", "ETH", 231));
            collection.Add(new Iso3166Country("Falkland Islands (Malvinas)", "FK", "FLK", 238));
            collection.Add(new Iso3166Country("Faroe Islands", "FO", "FRO", 234));
            collection.Add(new Iso3166Country("Fiji", "FJ", "FJI", 242));
            collection.Add(new Iso3166Country("Finland", "FI", "FIN", 246));
            collection.Add(new Iso3166Country("France", "FR", "FRA", 250));
            collection.Add(new Iso3166Country("French Guiana", "GF", "GUF", 254));
            collection.Add(new Iso3166Country("French Polynesia", "PF", "PYF", 258));
            collection.Add(new Iso3166Country("French Southern Territories", "TF", "ATF", 260));
            collection.Add(new Iso3166Country("Gabon", "GA", "GAB", 266));
            collection.Add(new Iso3166Country("Gambia", "GM", "GMB", 270));
            collection.Add(new Iso3166Country("Georgia", "GE", "GEO", 268));
            collection.Add(new Iso3166Country("Germany", "DE", "DEU", 276));
            collection.Add(new Iso3166Country("Ghana", "GH", "GHA", 288));
            collection.Add(new Iso3166Country("Gibraltar", "GI", "GIB", 292));
            collection.Add(new Iso3166Country("Greece", "GR", "GRC", 300));
            collection.Add(new Iso3166Country("Greenland", "GL", "GRL", 304));
            collection.Add(new Iso3166Country("Grenada", "GD", "GRD", 308));
            collection.Add(new Iso3166Country("Guadeloupe", "GP", "GLP", 312));
            collection.Add(new Iso3166Country("Guam", "GU", "GUM", 316));
            collection.Add(new Iso3166Country("Guatemala", "GT", "GTM", 320));
            collection.Add(new Iso3166Country("Guernsey", "GG", "GGY", 831));
            collection.Add(new Iso3166Country("Guinea", "GN", "GIN", 324));
            collection.Add(new Iso3166Country("Guinea-Bissau", "GW", "GNB", 624));
            collection.Add(new Iso3166Country("Guyana", "GY", "GUY", 328));
            collection.Add(new Iso3166Country("Haiti", "HT", "HTI", 332));
            collection.Add(new Iso3166Country("Heard Island and McDonald Islands", "HM", "HMD", 334));
            collection.Add(new Iso3166Country("Holy See", "VA", "VAT", 336));
            collection.Add(new Iso3166Country("Honduras", "HN", "HND", 340));
            collection.Add(new Iso3166Country("Hong Kong", "HK", "HKG", 344));
            collection.Add(new Iso3166Country("Hungary", "HU", "HUN", 348));
            collection.Add(new Iso3166Country("Iceland", "IS", "ISL", 352));
            collection.Add(new Iso3166Country("India", "IN", "IND", 356));
            collection.Add(new Iso3166Country("Indonesia", "ID", "IDN", 360));
            collection.Add(new Iso3166Country("Iran (Islamic Republic of)", "IR", "IRN", 364));
            collection.Add(new Iso3166Country("Iran", "IR", "IRN", 364));
            collection.Add(new Iso3166Country("Iraq", "IQ", "IRQ", 368));
            collection.Add(new Iso3166Country("Ireland", "IE", "IRL", 372));
            collection.Add(new Iso3166Country("Isle of Man", "IM", "IMN", 833));
            collection.Add(new Iso3166Country("Israel", "IL", "ISR", 376));
            collection.Add(new Iso3166Country("Italy", "IT", "ITA", 380));
            collection.Add(new Iso3166Country("Jamaica", "JM", "JAM", 388));
            collection.Add(new Iso3166Country("Japan", "JP", "JPN", 392));
            collection.Add(new Iso3166Country("Jersey", "JE", "JEY", 832));
            collection.Add(new Iso3166Country("Jordan", "JO", "JOR", 400));
            collection.Add(new Iso3166Country("Kazakhstan", "KZ", "KAZ", 398));
            collection.Add(new Iso3166Country("Kenya", "KE", "KEN", 404));
            collection.Add(new Iso3166Country("Kiribati", "KI", "KIR", 296));
            collection.Add(new Iso3166Country("Korea (Democratic People's Republic of)", "KP", "PRK", 408));
            collection.Add(new Iso3166Country("Korea (Republic of)", "KR", "KOR", 410));
            collection.Add(new Iso3166Country("Korea", "KR", "KOR", 410));
            collection.Add(new Iso3166Country("Kosovo", "KO", "KOS", 780));
            collection.Add(new Iso3166Country("Kuwait", "KW", "KWT", 414));
            collection.Add(new Iso3166Country("Kyrgyzstan", "KG", "KGZ", 417));
            collection.Add(new Iso3166Country("Lao People's Democratic Republic", "LA", "LAO", 418));
            
            var latAlternatives = new List<string> {"lat"};
            collection.Add(new Iso3166Country("Latvia", "LV", "LVA", 428, latAlternatives));
            collection.Add(new Iso3166Country("Lebanon", "LB", "LBN", 422));
            collection.Add(new Iso3166Country("Lesotho", "LS", "LSO", 426));
            collection.Add(new Iso3166Country("Liberia", "LR", "LBR", 430));
            collection.Add(new Iso3166Country("Libya", "LY", "LBY", 434));
            collection.Add(new Iso3166Country("Liechtenstein", "LI", "LIE", 438));
            
            var lithAlternatives = new List<string> {"lith"};
            collection.Add(new Iso3166Country("Lithuania", "LT", "LTU", 440, lithAlternatives));
            collection.Add(new Iso3166Country("Luxembourg", "LU", "LUX", 442));
            collection.Add(new Iso3166Country("Macao", "MO", "MAC", 446));
            
            var mkdAlternatives = new List<string> {"macedonia, former yugoslav republic (1993-)"};
            collection.Add(new Iso3166Country("Macedonia", "MK", "MKD", 807, mkdAlternatives));
            collection.Add(new Iso3166Country("Madagascar", "MG", "MDG", 450));
            collection.Add(new Iso3166Country("Malawi", "MW", "MWI", 454));
            collection.Add(new Iso3166Country("Malaysia", "MY", "MYS", 458));
            collection.Add(new Iso3166Country("Maldives", "MV", "MDV", 462));
            collection.Add(new Iso3166Country("Mali", "ML", "MLI", 466));
            
            var malAlternatives = new List<string> {"mal"};
            collection.Add(new Iso3166Country("Malta", "MT", "MLT", 470, malAlternatives));
            collection.Add(new Iso3166Country("Marshall Islands", "MH", "MHL", 584));
            collection.Add(new Iso3166Country("Martinique", "MQ", "MTQ", 474));
            collection.Add(new Iso3166Country("Mauritania", "MR", "MRT", 478));
            collection.Add(new Iso3166Country("Mauritius", "MU", "MUS", 480));
            collection.Add(new Iso3166Country("Mayotte", "YT", "MYT", 175));
            collection.Add(new Iso3166Country("Mexico", "MX", "MEX", 484));
            collection.Add(new Iso3166Country("Micronesia (Federated States of)", "FM", "FSM", 583));
            collection.Add(new Iso3166Country("Moldova (Republic of)", "MD", "MDA", 498));
            collection.Add(new Iso3166Country("Moldova, Republic of", "MD", "MDA", 498));
            collection.Add(new Iso3166Country("Moldova", "MD", "MDA", 498));
            collection.Add(new Iso3166Country("Monaco", "MC", "MCO", 492));
            collection.Add(new Iso3166Country("Mongolia", "MN", "MNG", 496));
            collection.Add(new Iso3166Country("Montenegro", "ME", "MNE", 499));
            collection.Add(new Iso3166Country("Montserrat", "MS", "MSR", 500));
            collection.Add(new Iso3166Country("Morocco", "MA", "MAR", 504));
            collection.Add(new Iso3166Country("Mozambique", "MZ", "MOZ", 508));
            collection.Add(new Iso3166Country("Myanmar", "MM", "MMR", 104));
            collection.Add(new Iso3166Country("Namibia", "NA", "NAM", 516));
            collection.Add(new Iso3166Country("Nauru", "NR", "NRU", 520));
            collection.Add(new Iso3166Country("Nepal", "NP", "NPL", 524));
            collection.Add(new Iso3166Country("Netherlands", "NL", "NLD", 528));
            collection.Add(new Iso3166Country("New Caledonia", "NC", "NCL", 540));
            collection.Add(new Iso3166Country("New Zealand", "NZ", "NZL", 554));
            collection.Add(new Iso3166Country("Nicaragua", "NI", "NIC", 558));
            collection.Add(new Iso3166Country("Niger", "NE", "NER", 562));
            collection.Add(new Iso3166Country("Nigeria", "NG", "NGA", 566));
            collection.Add(new Iso3166Country("Niue", "NU", "NIU", 570));
            collection.Add(new Iso3166Country("Norfolk Island", "NF", "NFK", 574));
            collection.Add(new Iso3166Country("Northern Mariana Islands", "MP", "MNP", 580));
            collection.Add(new Iso3166Country("Norway", "NO", "NOR", 578));
            collection.Add(new Iso3166Country("Oman", "OM", "OMN", 512));
            collection.Add(new Iso3166Country("Pakistan", "PK", "PAK", 586));
            collection.Add(new Iso3166Country("Palau", "PW", "PLW", 585));
            collection.Add(new Iso3166Country("Palestine, State of", "PS", "PSE", 275));
            collection.Add(new Iso3166Country("Panama", "PA", "PAN", 591));
            collection.Add(new Iso3166Country("Papua New Guinea", "PG", "PNG", 598));
            collection.Add(new Iso3166Country("Paraguay", "PY", "PRY", 600));
            collection.Add(new Iso3166Country("Peru", "PE", "PER", 604));
            collection.Add(new Iso3166Country("Philippines", "PH", "PHL", 608));
            collection.Add(new Iso3166Country("Pitcairn", "PN", "PCN", 612));
            collection.Add(new Iso3166Country("Poland", "PL", "POL", 616));
            
            var porAlternatives = new List<string> {"por"};
            collection.Add(new Iso3166Country("Portugal", "PT", "PRT", 620, porAlternatives));
            collection.Add(new Iso3166Country("Puerto Rico", "PR", "PRI", 630));
            collection.Add(new Iso3166Country("Qatar", "QA", "QAT", 634));
            collection.Add(new Iso3166Country("Réunion", "RE", "REU", 638));
            
            var romAlternatives = new List<string> {"rom"};
            collection.Add(new Iso3166Country("Romania", "RO", "ROU", 642, romAlternatives));
            collection.Add(new Iso3166Country("Russian Federation", "RU", "RUS", 643));
            collection.Add(new Iso3166Country("Rwanda", "RW", "RWA", 646));
            collection.Add(new Iso3166Country("Saint Barthélemy", "BL", "BLM", 652));
            collection.Add(new Iso3166Country("Saint Helena, Ascension and Tristan da Cunha", "SH", "SHN", 654));
            collection.Add(new Iso3166Country("Saint Kitts and Nevis", "KN", "KNA", 659));
            collection.Add(new Iso3166Country("Saint Lucia", "LC", "LCA", 662));
            collection.Add(new Iso3166Country("Saint Martin (French part)", "MF", "MAF", 663));
            collection.Add(new Iso3166Country("Saint Pierre and Miquelon", "PM", "SPM", 666));
            collection.Add(new Iso3166Country("Saint Vincent and the Grenadines", "VC", "VCT", 670));
            collection.Add(new Iso3166Country("St. Vincent and the Grenadines", "VC", "VCT", 670));
            collection.Add(new Iso3166Country("Samoa", "WS", "WSM", 882));
            collection.Add(new Iso3166Country("San Marino", "SM", "SMR", 674));
            collection.Add(new Iso3166Country("Sao Tome and Principe", "ST", "STP", 678));
            collection.Add(new Iso3166Country("Saudi Arabia", "SA", "SAU", 682));
            collection.Add(new Iso3166Country("Senegal", "SN", "SEN", 686));
            collection.Add(new Iso3166Country("Serbia", "RS", "SRB", 688));
            collection.Add(new Iso3166Country("Seychelles", "SC", "SYC", 690));
            collection.Add(new Iso3166Country("Sierra Leone", "SL", "SLE", 694));
            collection.Add(new Iso3166Country("Singapore", "SG", "SGP", 702));
            collection.Add(new Iso3166Country("Sint Maarten (Dutch part)", "SX", "SXM", 534));
            
            var sloAlternatives = new List<string> {"slo"};
            collection.Add(new Iso3166Country("Slovakia", "SK", "SVK", 703, sloAlternatives));
            collection.Add(new Iso3166Country("Slovenia", "SI", "SVN", 705));
            collection.Add(new Iso3166Country("Solomon Islands", "SB", "SLB", 90));
            collection.Add(new Iso3166Country("Somalia", "SO", "SOM", 706));
            //todo check this country
            collection.Add(new Iso3166Country("Somaliland", "SO", "SOM", 706));
            collection.Add(new Iso3166Country("South Africa", "ZA", "ZAF", 710));
            collection.Add(new Iso3166Country("South Georgia and the South Sandwich Islands", "GS", "SGS", 239));
            collection.Add(new Iso3166Country("South Sudan", "SS", "SSD", 728));
            collection.Add(new Iso3166Country("Spain", "ES", "ESP", 724));
            collection.Add(new Iso3166Country("Sri Lanka", "LK", "LKA", 144));
            collection.Add(new Iso3166Country("Sudan", "SD", "SDN", 729));
            collection.Add(new Iso3166Country("Suriname", "SR", "SUR", 740));
            collection.Add(new Iso3166Country("Svalbard and Jan Mayen", "SJ", "SJM", 744));
            collection.Add(new Iso3166Country("Swaziland", "SZ", "SWZ", 748));
            collection.Add(new Iso3166Country("Sweden", "SE", "SWE", 752));
            collection.Add(new Iso3166Country("Switzerland", "CH", "CHE", 756));
            collection.Add(new Iso3166Country("Syrian Arab Republic", "SY", "SYR", 760));
            collection.Add(new Iso3166Country("Taiwan, Province of China[a]", "TW", "TWN", 158));
            collection.Add(new Iso3166Country("Taiwan", "TW", "TWN", 158));
            collection.Add(new Iso3166Country("Tajikistan", "TJ", "TJK", 762));
            collection.Add(new Iso3166Country("Tanzania, United Republic of", "TZ", "TZA", 834));
            collection.Add(new Iso3166Country("Tanzania", "TZ", "TZA", 834));
            collection.Add(new Iso3166Country("Thailand", "TH", "THA", 764));
            collection.Add(new Iso3166Country("Timor-Leste", "TL", "TLS", 626));
            collection.Add(new Iso3166Country("Togo", "TG", "TGO", 768));
            collection.Add(new Iso3166Country("Tokelau", "TK", "TKL", 772));
            collection.Add(new Iso3166Country("Tonga", "TO", "TON", 776));
            collection.Add(new Iso3166Country("Trinidad and Tobago", "TT", "TTO", 780));
            collection.Add(new Iso3166Country("Tunisia", "TN", "TUN", 788));
            collection.Add(new Iso3166Country("Turkey", "TR", "TUR", 792));
            collection.Add(new Iso3166Country("Turkmenistan", "TM", "TKM", 795));
            collection.Add(new Iso3166Country("Turks and Caicos Islands", "TC", "TCA", 796));
            collection.Add(new Iso3166Country("Tuvalu", "TV", "TUV", 798));
            collection.Add(new Iso3166Country("Uganda", "UG", "UGA", 800));
            collection.Add(new Iso3166Country("Ukraine", "UA", "UKR", 804));
            collection.Add(new Iso3166Country("United Arab Emirates", "AE", "ARE", 784));
            collection.Add(new Iso3166Country("United Kingdom of Great Britain and Northern Ireland", "GB", "GBR",
                826));
            var ukAlternatives = new List<string> {"uk"};
            collection.Add(new Iso3166Country("United Kingdom", "GB", "GBR", 826, ukAlternatives));
            collection.Add(new Iso3166Country("United States of America", "US", "USA", 840));
            collection.Add(new Iso3166Country("United States Minor Outlying Islands", "UM", "UMI", 581));
            collection.Add(new Iso3166Country("Uruguay", "UY", "URY", 858));
            collection.Add(new Iso3166Country("Uzbekistan", "UZ", "UZB", 860));
            collection.Add(new Iso3166Country("Vanuatu", "VU", "VUT", 548));
            collection.Add(new Iso3166Country("Venezuela (Bolivarian Republic of)", "VE", "VEN", 862));
            collection.Add(new Iso3166Country("Venezuela", "VE", "VEN", 862));
            collection.Add(new Iso3166Country("Viet Nam", "VN", "VNM", 704));
            collection.Add(new Iso3166Country("Virgin Islands (British)", "VG", "VGB", 92));
            collection.Add(new Iso3166Country("British Virgin Islands", "VG", "VGB", 92));
            collection.Add(new Iso3166Country("Virgin Islands (U.S.)", "VI", "VIR", 850));
            collection.Add(new Iso3166Country("Wallis and Futuna", "WF", "WLF", 876));
            collection.Add(new Iso3166Country("Western Sahara", "EH", "ESH", 732));
            collection.Add(new Iso3166Country("Yemen", "YE", "YEM", 887));
            
            var yugAlternatives = new List<string>
            {
                "yugoslavia, sfr (1943-1992)",
                "yugoslavia fr/union of serbia and montenegro"
                //"yugoslavia, fr/union of serbia and montenegro"
            };
            collection.Add(new Iso3166Country("Yugoslavia", "YU", "YUG", 891, yugAlternatives));
            collection.Add(new Iso3166Country("Zambia", "ZM", "ZMB", 894));
            collection.Add(new Iso3166Country("Zimbabwe", "ZW", "ZWE", 716));

            return collection;
        }

        #endregion
    }

    /// <summary>
    /// Representation of an ISO3166-1 Country
    /// </summary>
    public class Iso3166Country
    {
        public Iso3166Country(string name, string alpha2, string alpha3, int numericCode)
        {
            Name = name.ToLower();
            Alpha2 = alpha2;
            Alpha3 = alpha3;
            NumericCode = numericCode;
        }

        public Iso3166Country(string name, string alpha2, string alpha3, int numericCode, List<string> alternatives)
        {
            Name = name.ToLower();
            Alpha2 = alpha2;
            Alpha3 = alpha3;
            NumericCode = numericCode;
            AlternativeNames = alternatives;
        }

        public string Name { get; }

        public string Alpha2 { get; }

        public string Alpha3 { get; }

        public int NumericCode { get; }

        public List<string> AlternativeNames { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}