using System;

namespace WebApp
{

    public class Volunteer : Person
    {
        // HumanityRoad info
        public string Team { get; set; }
        public string Employer { get; set; }
        public Boolean EmployerOffersMatch { get; set; }
        public string State { get; set; }
        public DateTime? OrientationDate { get; set; }
        public DateTime? MediaOrientationDate { get; set; }
        public DateTime? GoogleDocsOrientationDate { get; set; }
        public DateTime? SdwtOrientationDate { get; set; }
        public DateTime? ToolbarOrientationDate { get; set; }
        public DateTime? CaseMgmtOrientationDate { get; set; }
        public DateTime? EarthquakeOrientationDate { get; set; }
        public DateTime? GoogleEarthOrientationDate { get; set; }
        public DateTime? PublishingOrientationDate { get; set; }
        public string TshirtSize { get; set; }
    }
}
