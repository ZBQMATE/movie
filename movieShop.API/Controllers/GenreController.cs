using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Route("genre")]
        public async Task<IActionResult> GetUserInfo()
        {
            var genres = await _genreService.GetAllGenres();
            return genres is null ? BadRequest(new { message = "No user found" }) : Ok(genres);
        }
    }
}
