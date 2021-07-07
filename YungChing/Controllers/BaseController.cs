using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YungChing.Models;

namespace YungChing.Controllers
{
    public abstract class BaseController<TEntity, TRepository> : Controller
        where TEntity: class
        where TRepository : IRepository<TEntity>
    {
        public TRepository Repository { get; private set; }

        public BaseController(TRepository repository)
        {
            Repository = repository;
        }

    }
}
