using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park.Models
{
    public class area
    {
        //索引號 0:育賢樓 1:咖啡廣場
        public int ID { get; set; }
        //地圖名
        public string Name { get; set; }
        public string SeatNumber { get; set; }
    }
}