using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Archive.API.Infrastructure;
using Microsoft.Extensions.Logging;
using Tripod.Core;
using Archive.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Archive.API.Controllers
{
    /// <summary>
    /// 机构组
    /// </summary>
    [ApiController]
    [Route("/api/branch-group")]
    public class BranchGroupController : ControllerBase
    {
        private readonly ArchiveContext _context;
        private ILogger<BranchGroupController> _logger;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public BranchGroupController(ArchiveContext context, ILogger<BranchGroupController> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int pageIndex = 1, int pageSize = 20, string keyword = "")
        {
            var query = _context.BranchGroups.AsQueryable();
            if (string.IsNullOrEmpty(keyword))
            {
                query = query.Where(i => i.Name.Contains(keyword));
            }

            var data = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(i => i.Id);
            var response = new PaginatedItems<BranchGroup>(
                pageIndex: pageIndex,
                pageSize: pageSize,
                count: query.Count(),
                data: data.ToList());
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var entity = _context.BranchGroups.FirstOrDefault(i => i.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post(BranchGroup model)
        {
            _context.BranchGroups.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(BranchGroup model)
        {
            _context.Update(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var category = _context.BranchGroups.FirstOrDefault(i => i.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.BranchGroups.Remove(category);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("{id}/branch")]
        public IActionResult GetBranches(int id)
        {
            var branchGroup = _context.BranchGroups
                    .Include(bg => bg.BranchGroupBranches)
                    .ThenInclude(bgb => bgb.Branch)
                    .FirstOrDefault();

            if (branchGroup == null)
            {
                return BadRequest();
            }

            return Ok(branchGroup.BranchGroupBranches.Select(i => i.Branch));
        }

        [HttpPut]
        [Route("{id}/branch")]
        public IActionResult UpdateBranches([FromRoute] int id, [FromBody] List<string> branchIdList)
        {
            var branchGroup = _context.BranchGroups.Include(bg => bg.BranchGroupBranches).FirstOrDefault();
            if (branchGroup == null)
            {
                return BadRequest();
            }

            branchGroup.BranchGroupBranches.Clear();
            foreach (var branchId in branchIdList)
            {
                branchGroup.BranchGroupBranches.Add(new BranchGroupBranch()
                {
                    BranchGroupId = id,
                    BranchId = branchId,
                });
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}