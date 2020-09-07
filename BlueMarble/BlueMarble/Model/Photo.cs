using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BlueMarble.Model
{
    public class Photo
    {
        public string Identifier { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
        public string Version { get; set; }

        [JsonProperty("centroid_coordinates")]
        public Coordinates CentroidCoordinates { get; set; }

        [JsonProperty("dscovr_j2000_position")]
        public Position DscvrPosition { get; set; }

        [JsonProperty("lunar_j2000_position")]
        public Position LunarPosition { get; set; }

        [JsonProperty("sun_j2000_position")]
        public Position SunPosition { get; set; }

        [JsonProperty("attitude_quaternions")]
        public Attitude AttitudeQuaternions { get; set; }

        public string Date { get; set; }
        
        public DateTime ParsedDate
        {
            get
            {                
                return DateTime.Parse(Date);
            }
        }
              

        public string MapUrl
        {
            get
            {
                string lat = Convert.ToString(CentroidCoordinates.Lat, new CultureInfo("en-US"));
                string lon = Convert.ToString(CentroidCoordinates.Lon, new CultureInfo("en-US"));           

               
                string urlPart = $"{lat},{lon}";
                
                return $"https://www.google.com/maps/search/?api=1&query={urlPart}";
            }
        }
    }
}
