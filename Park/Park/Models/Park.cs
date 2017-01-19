using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park.Models
{
    public class Park
    {
        //管理者
        public string Manager { get; set; }  
        //用戶
        public string Users { get; set; }     
        //地圖
        public string Map { get; set; }
        //停車格
        public string Number { get; set; }  

    }
}