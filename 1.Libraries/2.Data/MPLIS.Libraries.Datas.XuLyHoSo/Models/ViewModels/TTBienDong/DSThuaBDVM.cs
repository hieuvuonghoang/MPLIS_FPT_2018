using AppCore.Models;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSThuaBDVM
    {
        public List<ThuaBDVM> DSThua { get; set; }
        public Hashtable DSThuaCha { get; set; }
        public bool isCOTHUAXL { get; set; }
        private string _JSONCha = "";
        public string JSONThuaCha
        {
            get
            {
                if (_JSONCha.Equals(""))
                    return JsonConvert.SerializeObject(DSThuaCha);
                else return _JSONCha;
            }

            set
            {
                _JSONCha = value;
            }
        }

        public DSThuaBDVM()
        {
            DSThua = new List<ThuaBDVM>();
            DSThuaCha = new Hashtable();
        }

        public void initData(BoHoSoModel bhs)
        {
            ThuaBDVM ch;
            List<string> DSCha;
            isCOTHUAXL = bhs.HoSoTN.BienDong.COTHUAXULY == null ? false : bhs.HoSoTN.BienDong.COTHUAXULY.Equals("Y");
            foreach (var it in bhs.HoSoTN.BienDong.DSThua)
            {
                ch = Mapper.Map<DC_BD_THUA, ThuaBDVM>(it);
                DSThua.Add(ch);
                if (!it.LOAITHUABD.Equals("V"))
                    if (!DSThuaCha.Contains(it.THUADATID))
                    {
                        DSCha = new List<string>();
                        if (it.Thua.QHThua != null)
                            for (int i = 0; i < it.Thua.QHThua.Count; i++)
                            {
                                DSCha.Add(it.Thua.QHThua[i].THUACHAID);
                            }
                        DSThuaCha.Add(it.THUADATID, DSCha);
                    }
            }
        }
    }
}
