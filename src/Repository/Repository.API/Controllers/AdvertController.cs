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
    [Route("/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;


        public AdvertController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10, string sortByColumn = "", bool isDescending = false, string categoryId = "", string price = "", string gear = "", string fuel = "")
        {
            return Ok(await _repositoryService.GetAllAsync(page, pageSize, sortByColumn, isDescending, categoryId, price, gear, fuel));
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _repositoryService.GetByIdAsync(Convert.ToInt32(id)));
        }
    }
}
