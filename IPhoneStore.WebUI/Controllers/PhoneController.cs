using IPhoneStore.Domain.Abstract;
using IPhoneStore.Domain.Concrete;
using IPhoneStore.Domain.Entities;
using IPhoneStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPhoneStore.WebUI.Controllers
{
    public class PhoneController : Controller
    {
        private IStoreRepository<IPhone> _repo;
        public int pageSize = 2;
      
        public PhoneController(IStoreRepository<IPhone> repository)
        {
            _repo = repository;
        }

        public ViewResult List(string modelCategory,int page = 1)
        {
            var model = new IPhoneListViewModel
            {
                Phones = _repo.Get(p => modelCategory == null||p.Model == modelCategory)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList(),
                Pagination = new Pagination
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Count
                },
                CurrentModel = modelCategory
            };
            return View(model);
        }
    }
}