using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdminWebUI.Controllers
{
    public abstract class ContextController : Controller
    {

        internal readonly BiesterlanDbContext _context;
        public IConfiguration Configuration { get; }
        public ContextController(BiesterlanDbContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            _context = context;
        }
        
    }
}