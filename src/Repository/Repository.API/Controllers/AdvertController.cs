using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Application.Interfaces;
using Repository.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public AdvertController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repositoryService.GetAllAsync());
        }
    }
}
