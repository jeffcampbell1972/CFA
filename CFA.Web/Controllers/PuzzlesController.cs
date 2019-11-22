using System;
using Microsoft.AspNetCore.Mvc;
using CFA.Service;

namespace CFA.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuzzlesController : ControllerBase
    {
        private readonly IPuzzleService _puzzleService;
        public PuzzlesController(IPuzzleService puzzleService)
        {
            _puzzleService = puzzleService;
        }
        [HttpGet]
        public int Get(string stream)
        {
            int score = -1;
            try
            {
                score = _puzzleService.Solve(stream);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return score;
        }
    }
}