﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Archive.API.Infrastructure;
using Archive.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tripod.Core;

namespace Archive.API.Controllers
{
    [ApiController]
    [Route("api/v1/branch")]
    public class BranchController : ControllerBase
    {
        private readonly ArchiveContext _archiveContext;
        private readonly ILogger<BranchController> _logger;

        public BranchController(ArchiveContext context, ILogger<BranchController> logger)
        {
            _archiveContext = context;
            _logger = logger;
        }

        /// <summary>
        /// 根据id获取机构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Branch>> GetBranchByIdAsync([FromRoute]string id)
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

        /// <summary>
        /// 获取机构分页数据
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="keyword">搜索关键字：编码或名称</param>
        /// <param name="parentId">父机构id</param>
        /// <param name="typeList">机构类型</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedItems<Branch>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBranchesAsync(
            int pageSize = 10,
            int pageIndex = 1,
            string keyword = "",
            string parentId = "",
            BranchType[] typeList = null)
        {
            var totalItems = await _archiveContext.Branches.LongCountAsync();

            var query = _archiveContext.Branches.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(b => b.Id.Contains(keyword) || b.Name.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(parentId))
            {
                query = query.Where(b => b.ParentId == parentId);
            }
            if (typeList != null)
            {
                query = query.Where(b => typeList.Contains(b.Type));
            }

            var itemsOnPage = await query
                .OrderByDescending(b => b.CreateTime)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            var model = new PaginatedItems<Branch>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        [HttpGet]
        [Route("tree")]
        [ProducesResponseType(typeof(TreeNode), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBranchTreeAsync()
        {
            var branches = await _archiveContext.Branches.ToListAsync();

            var root = new TreeNode();
            root.Id = "";
            root.Label = "全部机构";
            root.Children = new List<TreeNode>();
            BuildTree(root, branches);

            return Ok(root);
        }

        private void BuildTree(TreeNode node, IEnumerable<Branch> branchs)
        {
            var children = branchs.Where(b => b.ParentId == node.Id);
            foreach (var child in children)
            {
                var childNode = new TreeNode()
                {
                    Id = child.Id,
                    Label = $"[{child.Id}]{child.Name}",
                    Children = new List<TreeNode>()
                };
                node.Children.Add(childNode);
                BuildTree(childNode, branchs);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranchAsync([FromBody]Branch model)
        {
            //model.CreateOperId = CurrentUser.Id;
            //model.CreateOperName = CurrentUser.Name;
            //model.CreateTime = DateTime.Now.ToString();

            //model.LastUpdateOperId = CurrentUser.Id;
            //model.LastUpdateOperName = CurrentUser.Name;
            //model.LastUpdateTime = DateTime.Now.ToString();

            _archiveContext.Branches.Add(model);
            await _archiveContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBranchByIdAsync), new { id = model.Id }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBranchAsync([FromBody]Branch model)
        {
            var branch = await _archiveContext.Branches.FirstOrDefaultAsync(b => b.Id == model.Id);
            if (branch == null)
            {
                return NotFound();
            }

            _archiveContext.Branches.Update(branch);
            await _archiveContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBranchByIdAsync), new { id = model.Id }, null);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBranchAsync([FromRoute] string id)
        {
            var branch = await _archiveContext.Branches.FirstOrDefaultAsync(b => b.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            _archiveContext.Branches.Remove(branch);
            await _archiveContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("exists/{id}")]
        public async Task<ActionResult<bool>> IsExists([FromRoute]string id)
        {
            var exists = await _archiveContext.Branches.AnyAsync(b => b.Id == id);

            return Ok(exists);
        }

        [HttpGet]
        [Route("store/{branchId}")]
        public async Task<ActionResult<IList<BranchStore>>> GetStoresAsync([FromRoute]string branchId)
        {
            var branchStores = await _archiveContext.BranchStores.Where(bs => bs.BranchId == branchId).ToListAsync();

            return Ok(branchStores);
        }

        [HttpDelete]
        [Route("store/{id}")]
        public async Task<IActionResult> CreateBranchStore([FromRoute]int id)
        {
            var branchStore = await _archiveContext.BranchStores.FirstOrDefaultAsync(bs => bs.Id == id);
            if (branchStore == null)
            {
                return NotFound();
            }

            _archiveContext.BranchStores.Remove(branchStore);
            await _archiveContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("store")]
        public async Task<IActionResult> CreateOrUpdateBranchStore([FromBody]BranchStore model)
        {
            if (model.Id != 0)
            {
                _archiveContext.BranchStores.Update(model);
            }
            else
            {
                _archiveContext.BranchStores.Add(model);
            }
            await _archiveContext.SaveChangesAsync();

            return Ok();
        }
    }
}