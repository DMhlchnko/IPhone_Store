using IPhoneStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPhoneStore.WebUI.Models
{
    public class IPhoneListViewModel
    {
        public List<IPhone> Phones { get; set; }
        public Pagination Pagination { get; set; }
        public string CurrentModel { get; set; }
    }
}