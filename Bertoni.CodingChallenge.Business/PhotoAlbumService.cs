using Bertoni.CodingChallenge.Common.Configurations;
using Bertoni.CodingChallenge.Common.Entities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bertoni.CodingChallenge.Business
{
    public class PhotoAlbumService
    {
        private readonly ApiOptions _apiOptions;
        
        public PhotoAlbumService(IOptions<ApiOptions> apiOptions)
        {
            _apiOptions = apiOptions.Value;
        }

        public async Task<List<Album>> GetAlbums()
        {
            var httpClient = new HttpClient();
            var albumsJson = await httpClient.GetStringAsync(_apiOptions.Album);
            return JsonConvert.DeserializeObject<List<Album>>(albumsJson);
        }

        public async Task<List<Photo>> GetPhotosByAlbumId(int albumId)
        {
            var httpClient = new HttpClient();
            var photosJson = await httpClient.GetStringAsync(_apiOptions.Photos);
            var photos = JsonConvert.DeserializeObject<List<Photo>>(photosJson);            
            return photos.Where(x => x.AlbumId == albumId).ToList();
        }

        public async Task<List<Comment>> GetCommentsByPhotoId(int photoId)
        {
            var httpClient = new HttpClient();
            var commentsJson = await httpClient.GetStringAsync(_apiOptions.Comments);
            var comments = JsonConvert.DeserializeObject<List<Comment>>(commentsJson);
            return comments.Where(x => x.PostId == photoId).ToList();
        }
    }
}
