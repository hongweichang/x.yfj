﻿using System.Linq;
using X.Web;

namespace X.App.Views.mgr.city
{
    public class edit : xmg
    {
        public int id { get; set; }
        public int pid { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "id-pid";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            if (id > 0)
            {
                var ent = DB.x_dict.FirstOrDefault(o => o.dict_id == id);
                if (ent == null) throw new XExcep("0x0005");
                dict.Add("item", ent);
                var up = DB.x_dict.FirstOrDefault(o => o.code == "sys.city" && o.value == ent.upval.Split('-').Last());
                if (up == null) dict.Add("up", "0|无");
                else dict.Add("up", up.value + "|" + up.name);
            }
            else if (pid > 0)
            {
                var ent = DB.x_dict.FirstOrDefault(o => o.dict_id == pid);
                if (ent != null) dict.Add("up", ent.value + "|" + ent.name);
            }
            else
            {
                dict.Add("up", "0|无");
            }
        }
    }
}
