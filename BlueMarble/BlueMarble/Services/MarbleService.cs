using BlueMarble.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlueMarble.Services
{
    public class MarbleService
    {
        
        private HttpClient _client = new HttpClient();

            
        public async Task<IEnumerable<Photo>> GetPhotos(string url = null)
        {     
            
            //todo obsluga błędów jak w netflix roulette

            var content = await _client.GetStringAsync(url ?? Url.DefaultUrl);

            var photos = JsonConvert.DeserializeObject<List<Photo>>(content);

            return photos;           
        }


        


    }
}
