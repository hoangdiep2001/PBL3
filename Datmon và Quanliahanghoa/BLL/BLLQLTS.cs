﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlybantrasua.DTO;

namespace Quanlybantrasua.BLL
{
    public class BLLQLTS
    {
        QUANLYBANTRASUAEntities db = new QUANLYBANTRASUAEntities();
        private static BLLQLTS _Instance;
        public static BLLQLTS Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLLQLTS();
                }
                return _Instance;
            }
            private set { }
        }
        private BLLQLTS()
        {

        }
        public List<CbbLKH> GetCBBLKH()
        {
            List<CbbLKH> data = new List<CbbLKH>();
            foreach (LOAI_KHACH_HANG i in db.LOAI_KHACH_HANG)
            {
                data.Add(new CbbLKH
                {
                    ID_LKH = i.ID_LKH,
                    Ten_KH = i.Ten_LKH


                });
            }
            return data;
        }
        public List<CbbItems> GetCBB()
        {
            List<CbbItems> data = new List<CbbItems>();
            foreach (Loai_HANGHOA i in db.Loai_HANGHOA)
            {
                data.Add(new CbbItems
                {
                    IDLHH = i.ID_LHH,
                    TenLHH = i.Ten_LHH

                });
            }
            return data;
        }
        public List<HANGHOA> GetAllHH()
        {
            List<HANGHOA> data = new List<HANGHOA>();
            data = db.HANGHOA.ToList();
            return data;
        }
        public List<Hanghoa_View> GetAllHH_View()
        {
            List<Hanghoa_View> data = new List<Hanghoa_View>();
            data = db.HANGHOA.Select(p => new Hanghoa_View { ID_HH = p.ID_HH,Ten_HH = p.Ten_HH, Gia = (int)p.Gia }).ToList();

            return data;
        }
        public List<Hanghoa_View> GetHH_ViewbyIDLHH(int ID_LHH)
        {
            List<Hanghoa_View> data = new List<Hanghoa_View>();
            foreach(HANGHOA i in GetAllHH())
            {
                if (i.ID_LHH == ID_LHH)
                {
                    data.Add(new Hanghoa_View
                    {
                        ID_HH= i.ID_HH,
                        Ten_HH=i.Ten_HH,
                        Gia = (int)i.Gia
                    }
                    );
                }
            }
            return data;
        }
        public List<Hanghoa_View> GetHH_ViewByTenHH(string TenHH)
        {
            List<Hanghoa_View> data = new List<Hanghoa_View>();
            foreach(HANGHOA i in GetAllHH())
            {
                if (i.Ten_HH.Contains(TenHH))
                {
                    data.Add(new Hanghoa_View
                    {
                        ID_HH = i.ID_HH,
                        Ten_HH = i.Ten_HH,
                        Gia = (int)i.Gia
                    });
                }
            }
            return data;
        }
        public void AddUpDetailBill(CHI_TIET_HOA_DON b)
        {
            if (CheckCTHD((int)b.ID_HD,(int)b.ID_HH))
            {
                db.CHI_TIET_HOA_DON.Add(b);
            }
            else
            {
                CHI_TIET_HOA_DON s = db.CHI_TIET_HOA_DON.Where(p => p.ID_HH == b.ID_HH && p.ID_HD==b.ID_HD).FirstOrDefault();
                s.soluong += b.soluong.Value;
            }
            db.SaveChanges();
        }
        public bool CheckCTHD(int ID_HD, int ID_HH)
        {
            //true->add,false->update
            foreach(CHI_TIET_HOA_DON i in db.CHI_TIET_HOA_DON)
            {
                if (i.ID_HD == ID_HD & i.ID_HH==ID_HH)
                {
                    return false;
                }
            }
            return true;
            
        }
        public List<ChitiethoadonView> GetDetailBill(int IDHD)
        {
            List<ChitiethoadonView> data = new List<ChitiethoadonView>();
            data = db.CHI_TIET_HOA_DON.Where(p=>p.HOA_DON.ID_HD==IDHD).Select(p => new ChitiethoadonView {Ten_HH = p.HANGHOA.Ten_HH, soluong = (int)p.soluong }).ToList();
            return data;
        }
        public bool CheckKH(int PhoneNB)
        {
            //true->add;false->up
            foreach(KHACHHANG i in db.KHACHHANG)
            {
                if (i.PhoneNumber == PhoneNB)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddUpdateKH(KHACHHANG k)
        {
            if (CheckKH(k.PhoneNumber))
            {
                k.ID_LKH = 2;
                k.Diemtichluy = 0;
                db.KHACHHANG.Add(k);
            }
            else
            {
                KHACHHANG s = db.KHACHHANG.Where(p => p.PhoneNumber == k.PhoneNumber).FirstOrDefault();
                s.Ten_KH = k.Ten_KH;
                s.Diemtichluy += k.Diemtichluy;
                if (s.Diemtichluy > 500)
                {
                    s.ID_LKH = 2;
                }
            }
            db.SaveChanges();
        }
        public List<BAN> GetState()
        {
            List<BAN> data = new List<BAN>();
            foreach(HOA_DON i in db.HOA_DON) 
            {
                if (i.Thanhtoan != false)
                {
                    BAN s = db.BAN.Where(p => p.ID_BAN == i.ID_BAN).FirstOrDefault();
                    s.Tinhtrang = false;
                }
                else
                {
                    BAN s = db.BAN.Where(p => p.ID_BAN == i.ID_BAN).FirstOrDefault();
                    s.Tinhtrang = true;
                }

            }
            db.SaveChanges();
            data = db.BAN.ToList();
            return data;
        }
        public LOAI_KHACH_HANG GetLKHByPhone(int Phone)
        {
            LOAI_KHACH_HANG data = new LOAI_KHACH_HANG();
            KHACHHANG s = db.KHACHHANG.Where(p => p.PhoneNumber == Phone).Select(p => p).FirstOrDefault();
            data = db.LOAI_KHACH_HANG.Where(p => p.ID_LKH == s.ID_LKH).Select(p => p).FirstOrDefault();
            return data;
        }
        public List<BAN> GetAllBan()
        {
            List<BAN> data = new List<BAN>();
            data = db.BAN.ToList();
            return data;
        }
        public bool CheckHoadon(HOA_DON b)
        {
           
            foreach (HOA_DON i in db.HOA_DON)
            {
                if (i.ID_BAN == b.ID_BAN&&i.Thanhtoan==false)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddUpHD(HOA_DON  b)
        {
            if (CheckHoadon(b))
            {
                db.HOA_DON.Add(b);
            }
            else
            {
                HOA_DON s = db.HOA_DON.Where(p => p.ID_BAN == b.ID_BAN).Select(p => p).FirstOrDefault();
                s.PhoneNumber = b.PhoneNumber;
            }
            //db.HOA_DON.Add(b);
            db.SaveChanges();
        }
        public List<HOA_DON> GetAllHD()
        {
            List<HOA_DON> data = new List<HOA_DON>();
            data = db.HOA_DON.ToList();
            return data;
        }
        public List<CHI_TIET_HOA_DON> GetAllCTHD()
        {
            List<CHI_TIET_HOA_DON> data = new List<CHI_TIET_HOA_DON>();
            data = db.CHI_TIET_HOA_DON.ToList();
            return data;
        }
        public bool CheckAccount(string Name,string pass)
        {
            foreach(NHANVIEN i in db.NHANVIEN)
            {
                if(i.Ten_NV==Name && i.password == pass)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckPhanquyen(string Name)
        {
            foreach (NHANVIEN i in db.NHANVIEN)
            {
                if (i.Ten_NV == Name &&i.Phanquyen==true)
                {
                    return true;
                }
            }
            return false;
        }
        public List<ChitiethoadonView> DellCTHD(int ID_CTHD)
        {
            List<ChitiethoadonView> data = new List<ChitiethoadonView>();
            return data;
        }

    }
}
