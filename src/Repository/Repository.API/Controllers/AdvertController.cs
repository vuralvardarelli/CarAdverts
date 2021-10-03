using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Application.Interfaces;
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
        private readonly IUnitOfWork _unitOfwork;

        public AdvertController(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfwork.Adverts.GetAllAsync();
            return Ok(data);
        }
    }
}
