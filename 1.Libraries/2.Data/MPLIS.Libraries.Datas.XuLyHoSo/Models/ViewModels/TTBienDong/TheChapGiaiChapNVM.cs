using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using Newtonsoft.Json;
using AutoMapper;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class TheChapGiaiChapGCNVM
    {
        //Danh sách quyền SD đất trên GCN
        public List<QuyenSDDatVM> DSQuyenSuDungDat { get; set; }
        //Danh sách quyền SHTS trên GCN
        public List<QuyenSHTSVM> DSQuyenSoHuuTaiSan { get; set; }
        //Danh sách quyền QL đất trên GCN
        public List<QuyenQLDatVM> DSQuyenQuanLyDat { get; set; }
        //public List<QuyenSDDVM> DSQuyenSuDungDat { get; set; }
        //Chuỗi Json phục vụ cho việc thế chấp hoặc giải chấp quyền trên GCN
        public QuyenDatQuyenSHTSJson quyenDatQuyenSHTSJson { get; set; }
        private string _JSONTheChapGCNVM = "";
        public TheChapGiaiChapGCNVM()
        {
            this.quyenDatQuyenSHTSJson = new QuyenDatQuyenSHTSJson();
            this.DSQuyenSuDungDat = new List<QuyenSDDatVM>();
            this.DSQuyenSoHuuTaiSan = new List<QuyenSHTSVM>();
            this.DSQuyenQuanLyDat = new List<QuyenQLDatVM>();
        }
        public string JSONTheChapGCNVM
        {
            get
            {
                if (_JSONTheChapGCNVM.Equals(""))
                    return JsonConvert.SerializeObject(quyenDatQuyenSHTSJson);
                return _JSONTheChapGCNVM;
            }
            set
            {
                _JSONTheChapGCNVM = value;
            }
        }

        //Hàm sử dụng để lấy trạng thái cho phép Thế Chấp hoặc Giải Chấp hay không, cho những quyền không phải là lần đầu tham gia biến động
        //Hàm nhận hai tham số là loaiBienDongID và trangThaiPL của quyền ở lần biến động trước
        //TrangThaiPL = "T" là thế chấp
        public bool getStateCheck(string loaiBienDongID, string trangThaiPL)
        {
            bool stateCheck = false;
            switch (loaiBienDongID)
            {
                //BĐ là thế chấp
                case "444444":
                    //Nếu lần BĐ trước quyền chưa bị Thế Chấp thì lần này cho phép Thế Chấp ngược lại thì không
                    if (trangThaiPL == null || trangThaiPL == "")
                    {
                        stateCheck = true;
                    }
                    else
                    {
                        stateCheck = false;
                    }
                    break;
                //BĐ là giải chấp
                case "45555555":
                    //Nếu lần BĐ trước quyền chưa bị Thế Chấp thì lần này không cho phép Giải Chấp ngược lại thì cho phép Giải Chấp
                    if (trangThaiPL == null || trangThaiPL == "")
                    {
                        stateCheck = false;
                    }
                    else
                    {
                        stateCheck = true;
                    }
                    break;
                default:
                    break;
            }
            return stateCheck;
        }

        //Hàm sử dụng để lấy trạng thái cho phép Thế Chấp hoặc Giải Chấp hay không, cho những quyền lần đầu tham gia biến động
        //Tham số truyền vào loaiBienDongID
        //Trả về trạng thái cho phép Thế Chấp hoặc Giải Chấp hay không
        public bool getStateCheckFirst(string loaiBienDongID)
        {
            bool stateCheck = false;
            switch (loaiBienDongID)
            {
                //BĐ là thế chấp cho phép thế chấp thoải mái
                case "444444":
                    stateCheck = true;
                    break;
                //BĐ là giải chấp không cho phép giải chấp
                case "45555555":
                    stateCheck = false;
                    break;
                default:
                    break;
            }
            return stateCheck;
        }
        //Mỗi lần chọn một GCN trong DropList GCN đầu ra thì hàm được gọi để khởi tạo hai danh sách quyền phục vụ cho việc TC/GC trên GCN đầu ra được chọn
        //Hàm nhận 3 tham số BoHoSoModel, GCNID của GCN đầu ra được chọn, loaiBienDongID (TC/GC: "444444"/"45555555")
        public void initData(BoHoSoModel bhs, string giayChungNhanID, string loaiBienDongID)
        {
            //Hai đối tượng được sử dụng để Add vào List tương ứng sử dụng cho View
            QuyenSHTSVM objTS;
            QuyenSDDatVM objQSD;
            QuyenQLDatVM objQQL;
            //Duyệt qua toàn bộ dSGCN trong Biến Động tìm gCN theo giayChungNhanID
            foreach (var gcnXL in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (gcnXL.GIAYCHUNGNHANID.Equals(giayChungNhanID))
                {
                    //Set GiayChungNhanID cho JSon
                    this.quyenDatQuyenSHTSJson.GiayChungNhanID = giayChungNhanID;
                    #region Quyền sử dụng đất
                    //Duyệt qua DSQuyenDat trên GCN vừa tìm được (*)
                    foreach (var objQDHT in gcnXL.GiayChungNhan.DSQuyenSDDat)
                    {
                        //Map data cho objQD
                        objQSD = Mapper.Map<DC_QUYENSUDUNGDAT, QuyenSDDatVM>(objQDHT);
                        //Nếu là lần đầu tham gia biến động (QUYENSDDGOCID == null || QUYENSDDGOCID == "") thì cho thế chấp không cho phép giải chấp
                        //Ngược lại không phải lần đầu thì xét xem ở lần biến động trước quyền đang ở trạng thái nào:
                        //  +Nếu đang thế chấp thì chỉ cho phép giải chấp không cho phép thế chấp
                        //  +Nếu chưa thế chấp thì chỉ cho phép thế chấp không cho phép giải chấp
                        if (objQDHT.QUYENSDDGOCID == null || objQDHT.QUYENSDDGOCID.Equals(""))
                        {
                            objQSD.EnableCheck = getStateCheckFirst(loaiBienDongID);
                        }
                        else
                        {
                            //Duyệt qua toàn bộ dSGCN trong Biến Động với mỗi GCN thực hiện duyệt qua DSQuyenSDDat tìm:
                            //  QSDDat có  QUYENSUDUNGDATID khớp với QUYENSDDGOCID của QSDDat trên GCN vừa tìm được ở (*)
                            foreach (var gcn in bhs.HoSoTN.BienDong.DSGcn)
                            {
                                //Chỉ tìm trên các GCN khác GCN đang xử lý và GCN phải là GCN vào
                                if (gcnXL.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID) || gcn.LAGCNVAO.Equals("N"))
                                    continue;
                                foreach (var objQDQK in gcn.GiayChungNhan.DSQuyenSDDat)
                                {
                                    if (objQDHT.QUYENSDDGOCID.Equals(objQDQK.QUYENSUDUNGDATID))
                                    {
                                        objQSD.EnableCheck = getStateCheck(loaiBienDongID, objQDQK.TRANGTHAIPL);
                                        break;
                                    }
                                }
                            }
                        }
                        //Nếu cho phép thao tác trên checkBox thì gửi chuỗi Json về Client ngược lại thì không cần gửi về
                        if (objQSD.EnableCheck)
                            this.quyenDatQuyenSHTSJson.DSQuyen.Add(new QuyenSH("QSDDAT", objQDHT.QUYENSUDUNGDATID, objQDHT.TRANGTHAIPL != null ? (objQDHT.TRANGTHAIPL == "T" ? true : false) : false));
                        this.DSQuyenSuDungDat.Add(objQSD);
                    }
                    #endregion
                    #region Quyền sở hữu tài sản
                    foreach (var objQTSHT in gcnXL.GiayChungNhan.DSQuyenSHTS)
                    {
                        objTS = Mapper.Map<DC_QUYENSOHUUTAISAN, QuyenSHTSVM>(objQTSHT);
                        if(objTS.QUYENSHTSGOCID == null || objTS.QUYENSHTSGOCID.Equals(""))
                        {
                            objTS.EnableCheck = getStateCheckFirst(loaiBienDongID);
                        } else
                        {
                            foreach (var gcn in bhs.HoSoTN.BienDong.DSGcn)
                            {
                                if (gcnXL.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID) || gcn.LAGCNVAO.Equals("N"))
                                    continue;
                                foreach (var objQTSQK in gcn.GiayChungNhan.DSQuyenSHTS)
                                {
                                    if (objQTSHT.QUYENSHTSGOCID.Equals(objQTSQK.QUYENSOHUUTAISANID))
                                    {
                                        objTS.EnableCheck = getStateCheck(loaiBienDongID, objQTSQK.TRANGTHAIPL);
                                        break;
                                    }
                                }
                            }
                        }
                        if (objTS.EnableCheck)
                            this.quyenDatQuyenSHTSJson.DSQuyen.Add(new QuyenSH("QTS", objQTSHT.QUYENSOHUUTAISANID, objQTSHT.TRANGTHAIPL != null ? (objQTSHT.TRANGTHAIPL == "T" ? true : false) : false));
                        this.DSQuyenSoHuuTaiSan.Add(objTS);
                    }
                    #endregion
                    #region Quyền quản lý đất
                    foreach (var objQQLDHT in gcnXL.GiayChungNhan.DSQuyenQLDat)
                    {
                        objQQL = Mapper.Map<DC_QUYENQUANLYDAT, QuyenQLDatVM>(objQQLDHT);
                        if (objQQLDHT.QUYENQLDATGOCID == null || objQQLDHT.QUYENQLDATGOCID.Equals(""))
                        {
                            objQQL.EnableCheck = getStateCheckFirst(loaiBienDongID);
                        }
                        else
                        {
                            foreach (var gcn in bhs.HoSoTN.BienDong.DSGcn)
                            {
                                if (gcnXL.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID) || gcn.LAGCNVAO.Equals("N"))
                                    continue;
                                foreach (var objQQLDQK in gcn.GiayChungNhan.DSQuyenQLDat)
                                {
                                    if (objQQLDHT.QUYENQLDATGOCID.Equals(objQQLDQK.QUYENQUANLYDATID))
                                    {
                                        objQQL.EnableCheck = getStateCheck(loaiBienDongID, objQQLDQK.TRANGTHAIPL);
                                        break;
                                    }
                                }
                            }
                        }
                        if (objQQL.EnableCheck)
                            this.quyenDatQuyenSHTSJson.DSQuyen.Add(new QuyenSH("QQLDAT", objQQL.QUYENQUANLYDATID, objQQL.TRANGTHAIPL != null ? (objQQL.TRANGTHAIPL == "T" ? true : false) : false));
                        this.DSQuyenQuanLyDat.Add(objQQL);
                    }
                    #endregion
                    break;
                }
            }
        }
    }
    //Hai lớp dùng để tạo chuổi JSon gửi về Client
    public class QuyenSH
    {
        public QuyenSH(string ISQuyen, string IDQuyen, bool TrangThaiPL)
        {
            this.ISQuyen = ISQuyen;
            this.IDQuyen = IDQuyen;
            this.TrangThaiPL = TrangThaiPL;
        }
        public string ISQuyen { get; set; }
        public string IDQuyen { get; set; }
        public bool TrangThaiPL { get; set; }
    }
    public class QuyenDatQuyenSHTSJson
    {
        public QuyenDatQuyenSHTSJson()
        {
            this.DSQuyen = new List<QuyenSH>();
        }
        public string GiayChungNhanID { get; set; }
        public List<QuyenSH> DSQuyen { get; set; }
    }
}