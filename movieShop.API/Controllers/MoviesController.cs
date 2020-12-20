using Microsoft.AspNetCore.Authorization;
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
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);

            return movie is null ? NotFound("No movie found") : Ok(movie);
        }

        

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTopRevenueMovies();

            return movies.Any() ? Ok(movies) : NotFound("No Movies Found");
        }

        
    }
}
