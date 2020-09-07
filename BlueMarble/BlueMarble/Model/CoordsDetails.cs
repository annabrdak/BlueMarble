using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueMarble.Model
{
    public class CoordsDetails
    {
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
    }
}
