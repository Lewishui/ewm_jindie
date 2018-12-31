using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDZdb
{
    public class clsuserinfo
    {
        public string Order_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string Btype { get; set; }
        public string denglushijian { get; set; }
        public string Createdate { get; set; }
        public string AdminIS { get; set; }
        public string jigoudaima { get; set; }
        public string userTime { get; set; }
        public string mibao { get; set; }
        
    }
    public class clCard_info
    {
        public string Order_id { get; set; }//=FItemID
        public string daima_gonghao { get; set; }
        public string mingcheng { get; set; }
        public string quanming { get; set; }
        public string xingbie { get; set; }
        public string minzu { get; set; }
        public string chushengriqi { get; set; }
        public string zhengjianleixing { get; set; }
        public string zhengjianhaoma { get; set; }
        public string jiatingzhuzhi { get; set; }
        public string zhengjianyouxiao { get; set; }
        public string jiguan { get; set; }
        public string shenheren { get; set; }
        public string fujian { get; set; }
        public string tupian { get; set; }
        public string CardType { get; set; }    
        
        //PIC
        public string FTypeID { get; set; }
        public string FItemID { get; set; }
        //public string FFileName { get; set; }//=tupian
        public string FData { get; set; }
        public string FVersion { get; set; }
        public string FSaveMode { get; set; }
        public string FPage { get; set; }
        public string FEntryID { get; set; }


        public byte[] imagebytes { get; set; }     
      
        //
        public string zhengjianyouxiaoStart { get; set; }
    }
}
