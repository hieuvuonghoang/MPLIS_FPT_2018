using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSGCNBDVM
    {
        public List<GCNBDVM> DSGcn { get; set; }
        public Hashtable DSGCNCha { get; set; }
        private string _JSONCha = "";
        public string JSONCha
        {
            get
            {
                if (_JSONCha.Equals(""))
                    return JsonConvert.SerializeObject(DSGCNCha);
                else return _JSONCha;
            }

            set
            {
                _JSONCha = value;
            }
        }

        public DSGCNBDVM()
        {
            DSGcn = new List<Models.GCNBDVM>();
            DSGCNCha = new Hashtable();
        }

        public void initData(BoHoSoModel bhs)
        {
            GCNBDVM gCNBDVM;
            List<string> DSCha;
            foreach (var it in bhs.HoSoTN.BienDong.DSGcn)
            {
                gCNBDVM = Mapper.Map<DC_BD_GCN, GCNBDVM>(it);
                DSGcn.Add(gCNBDVM);
                if (it.LAGCNVAO.Equals("N"))
                {
                    if (!DSGCNCha.Contains(it.GIAYCHUNGNHANID))
                    {
                        DSCha = new List<string>();
                        if (it.GiayChungNhan.QHGcn_Gcn != null)
                        {
                            for (int i = 0; i < it.GiayChungNhan.QHGcn_Gcn.Count; i++)
                            {
                                DSCha.Add(it.GiayChungNhan.QHGcn_Gcn[i].GCNCHAID);
                            }
                        }
                        DSGCNCha.Add(it.GIAYCHUNGNHANID, DSCha);
                    }
                }
            }
        }
    }
}
