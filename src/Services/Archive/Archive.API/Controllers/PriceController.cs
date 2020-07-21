﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Archive.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly ILogger<PriceController> _logger;

        public PriceController(ILogger<PriceController> logger)
        {
            _logger = logger;
        }
    }
}
