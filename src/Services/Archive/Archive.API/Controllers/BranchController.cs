using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.API.Infrastructure;
using Archive.API.Model;
using Archive.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Archive.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly ArchiveContext _archiveContext;
        private readonly ILogger<BranchController> _logger;

        public BranchController(ArchiveContext context, ILogger<BranchController> logger)
        {
            _archiveContext = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("branch/{id}")]
        public async Task<ActionResult<Branch>> BranchByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var item = await _archiveContext.Branches.SingleOrDefaultAsync(b => b.Id == id);

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("branches")]
        public async Task<IActionResult> BranchesAsync([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 1)
        {
            var totalItems = await _archiveContext.Branches.LongCountAsync();

            var itemsOnPage = await _archiveContext.Branches
                .OrderByDescending(b => b.CreateTime)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            var model = new PaginatedItemsViewModel<Branch>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }
    }
}
