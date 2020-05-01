using Bertoni.CodingChallenge.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bertoni.CodingChallenge.Web.Controllers
{
    public class PhotoAlbumController : Controller
    {
        private readonly PhotoAlbumService _service;
        public PhotoAlbumController(PhotoAlbumService photoAlbumService)
        {
            _service = photoAlbumService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Albums = await _service.GetAlbums();
            return View();
        }

        [HttpGet("Comments/{photoId}")]
        public async Task<IActionResult> Comments(int photoId)
        {
            return View(await _service.GetCommentsByPhotoId(photoId));
        }

        [HttpGet("GetPhotosByAlbumId/{albumId}")]
        public async Task<IActionResult> Photos(int albumId)
        {
            var photos = await _service.GetPhotosByAlbumId(albumId);
            return PartialView(photos);
        }
    }
}