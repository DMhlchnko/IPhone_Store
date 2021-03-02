using IPhoneStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPhoneStore.Domain.Context
{
    public class DbtInitializer : DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var phone1 = new IPhone
            {
                Model = "IPhone 11",
                Description = "Екран: 6.1', IPS(Liquid Retina HD), 1792x828." +
                               "Камери: основна подвійна камера: 12 Мп + 12 Мп, фронтальна камера: 12 Мп" +
                               "Пам'ять: 64 ГБ вбудованої пам'яті",
                Color = "Black",
                Price = 21999,
                Store = 64
            };
            var phone2 = new IPhone
            {
                Model = "IPhone 12",
                Description = "Екран: 6.1', OLED (Super Retina XDR), 2532x1170." +
                              "Камери: основна подвійна камера: 12 Мп + 12 Мп, фронтальна камера: 12 Мп" +
                              "Пам'ять: 64 ГБ вбудованої пам'яті",
                Color = "Black",
                Price = 28999,
                Store = 64
            };
            var phone3 = new IPhone
            {
                Model = "IPhone 11",
                Description = "Екран: 6.1', IPS(Liquid Retina HD), 1792x828." +
                              "Камери: основна подвійна камера: 12 Мп + 12 Мп, фронтальна камера: 12 Мп" +
                              "Пам'ять: 64 ГБ вбудованої пам'яті",
                Color = "White",
                Price = 21999,
                Store = 64
            };
            var phone4 = new IPhone
            {
                Model = "IPhone 12",
                Description = "Екран: 6.1', OLED (Super Retina XDR), 2532x1170." +
                              "Камери: основна подвійна камера: 12 Мп + 12 Мп, фронтальна камера: 12 Мп" +
                              "Пам'ять: 64 ГБ вбудованої пам'яті",
                Color = "White",
                Price = 28999,
                Store = 64
            };

            context.Phones.AddRange(new List<IPhone> { phone1, phone2, phone3, phone4 });
            context.SaveChanges();
        }
    }
}
