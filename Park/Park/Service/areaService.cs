using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Park.Models;

namespace Park.Service
{
    public class areaService
    {
        public List<Models.area> GETAll()
        {
            List<Models.area> result = new List<Models.area>();

            List<Models.Park> list = new List<Models.Park>();

            var item = new Models.area();

            item.ID = 0;
            item.Name = "育賢樓";
            result.Add(item);

            var item2 = new Models.area();

            item2.ID = 1;
            item2.Name = "咖啡廣場";
            result.Add(item2);

            return result;
        }
    }
}