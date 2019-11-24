using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using DemoQLNhanVien_BTL_;
using System.Windows.Forms;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
       
        private DataProvider daP;
        private ChucNang cn;
        private DataSet ds;
        // private DataTable daT;
        [TestInitialize]
        public void SetUp()
        {
            daP = new DataProvider();
            cn = new ChucNang();
            ds = cn.GetData(); 
        }
        [TestMethod]
        public void TestLoginGiamDoc()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "Admin";
            string pass = "admin@123";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLoginQuanLy()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "Client";
            string pass = "client@123";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLoginNullID()
        {
            SetUp();
            bool expected = false;

            string user = " ";
            string pass = "sasa";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLoginNullPass()
        {
            SetUp();
            bool expected = false;

            string user = "Admin";
            string pass = " ";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLoginEmpty()
        {
            SetUp();
            bool expected = false;

            string user = " ";
            string pass = " ";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLoginFail()
        {
            SetUp();
            bool expected = false;
            string user = "asn";
            string pass = "sajhj";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThem()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            Assert.AreEqual(0, daTs.Rows.Count);
            cn.Them(daTs, "123", "Nguyen Van A", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "1234178", "Nguyen Van A", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "123421", "Nguyen Van B", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "123452", "Nguyen Van C", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "12345634", "Nguyen Van D", "31 NK", "0123465789", "Nhan Vien");
            Assert.AreEqual(5, daTs.Rows.Count);

        }
        [TestMethod]
        public void TestThemNullID()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, " ", "Nguyen Van A", "31 NK", "0123465789", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);
        }

        [TestMethod]
        public void TestThemNullHoTen()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", " ", "31 NK", "0123465789", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemNullDiaChi()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", "Nguyen Van A", " ", "0123465789", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);
        }

        [TestMethod]
        public void TestThemNullSDT()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", "Nguyen Van A", "31 NK", " ", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemNullChucVu()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", "Nguyen Van A", "31 NK", "0123465789", " ");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemEmpty()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, " ", " ", " ", " ", " ");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestSuaID()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("12", "Nguyen Van A", "acb", "0123", "Nhân Viên");

            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("12", daTs.Rows[0][0]);
        }
        [TestMethod]
        public void TestSuaHoTen()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("123", "Nguyen Van B", "acb", "0123", "Nhân Viên");

            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("Nguyen Van B", daTs.Rows[0][1]);
        }


        [TestMethod]
        public void TestSuaDiaChi()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("123", "Nguyen Van A", "3711 NK", "0123", "Nhân Viên");
            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("3711 NK", daTs.Rows[0][2]);
        }

        [TestMethod]
        public void TestSuaSDT()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("123", "Nguyen Van A", "3711 NK", "0123456789", "Nhân Viên");
            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("0123456789", daTs.Rows[0][3]);
        }

        [TestMethod]
        public void TestSuaChucVu()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("123", "Nguyen Van A", "3711 NK", "0123456789", "Giam Doc");
            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("Giam Doc", daTs.Rows[0][4]);
        }
        [TestMethod]
        public void TestXoa_DongDau()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            
            cn.Them(daTs, "123", "Nguyen Van A", "31 NK", "0123465789", "Nhan Vien");  
            cn.Del(0, daTs);
            Assert.AreEqual(0, daTs.Rows.Count);
        }
        [TestMethod]
        public void TestXoa_DongBatKy()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            Assert.AreEqual(0, daTs.Rows.Count);
            cn.Them(daTs, "1234178", "Nguyen Van A", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "123421", "Nguyen Van B", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "123452", "Nguyen Van C", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "12345634", "Nguyen Van D", "31 NK", "0123465789", "Nhan Vien");
            cn.Del(2, daTs);
            Assert.AreEqual(3, daTs.Rows.Count);
        }
        [TestMethod]
        public void TestXoa_DongCuoiCung()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "1234178", "Nguyen Van A", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "123421", "Nguyen Van B", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "123452", "Nguyen Van C", "31 NK", "0123465789", "Nhan Vien");
            cn.Them(daTs, "12345634", "Nguyen Van D", "31 NK", "0123465789", "Nhan Vien");
            cn.Del(3, daTs);
            Assert.AreEqual(3, daTs.Rows.Count);

        }
        
      
    }
}

