using System;
using System.API.Infrastructure;
using System.API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tripod.Core;

namespace System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly SystemContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public MenuController(ILogger<MenuController> logger, SystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("tree")]
        public async Task<IActionResult> GetTree()
        {
            var menus = await _context.Menus.ToListAsync();

            var root = new TreeNode();
            root.Id = string.Empty;
            root.Children = new List<TreeNode>();
            BuildMenuTree(menus, root);

            return Ok(root.Children);
        }

        private void BuildMenuTree(List<Menu> menus, TreeNode node)
        {
            foreach (var menu in menus.Where(m => m.ParentCode == node.Id))
            {
                TreeNode sub = new TreeNode();
                sub.Id = menu.Code;
                sub.Label = menu.Name;
                sub.Children = new List<TreeNode>();
                node.Children.Add(sub);
                BuildMenuTree(menus, sub);
            }
        }
    }
}
