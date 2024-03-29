using BLL;
using DAL;
using DTO;
using GUI.DAL.IDAL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.BLLTest
{
    public class CategoryBLLTest
    {
        private Mock<ICategoryDAL> _mockCategoryDAL;
        private Category_FoodBLL _category_FoodBLL;

        [SetUp]
        public void Init()
        {
            _mockCategoryDAL = new Mock<ICategoryDAL>();

            _category_FoodBLL = new Category_FoodBLL(_mockCategoryDAL.Object);
          
        }

        [Test]
        public void Category_FoodBLL_hienThiDanhSachFoodCategory()
        {
            // setup method
            DataTable expectedDataTable = new DataTable();
            _mockCategoryDAL.Setup(m => m.hienThiDanhSachFoodCategory()).Returns(expectedDataTable);
            // call action
            DataTable actualDataTable = _category_FoodBLL.hienThiDanhSachFoodCategory();
            // compare
            Assert.AreEqual(expectedDataTable, actualDataTable);
        }

        [Test]
        [TestCase("", false)]
        [TestCase("Sinh tố", false)]
        [TestCase( "Nước ép", true)]
        public void Category_FoodBLL_xuLyThemCategoryFood(string name, bool expected)
        {
    
            List<string> _listTable = new List<string>()
            {
                "Sinh tố", "Nước ngọt","Cà phê"
            };
            _mockCategoryDAL.Setup(m => m.danhSachCategory()).Returns(_listTable);
            // call action
            string error = null;
            bool actual = _category_FoodBLL.xuLyThemCategoryFood(name, ref error);

            // compare
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Category_FoodBLL_themRow()
        {
            // setup method
            string name = "Category Name";
            _mockCategoryDAL.Setup(m => m.themRow(name)).Returns(true);
            // call action
            bool actual = _category_FoodBLL.themRow(name);
            // compare
            Assert.IsTrue(actual);
        }

        [Test]
        [TestCase(1,"", false)]
        [TestCase(1,"Sinh tố", false)]
        [TestCase(1, "Nước ép", true)]
        public void Category_FoodBLL_xuLyChinhSuaCategoryFood(int id, string name, bool expected)
        {
            // setup method
            List<string> _listTable = new List<string>()
            {
                "Sinh tố", "Nước ngọt","Cà phê"
            };
            _mockCategoryDAL.Setup(m => m.danhSachCategory()).Returns(_listTable);

            string er = "";
            // call action
            bool actual = _category_FoodBLL.xuLyChinhSuaCategoryFood(id, name, ref er);
            // compare
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Category_FoodBLL_chinhSuaRow()
        {
            // setup method
            CategoryDTO categoryDTO = new CategoryDTO();
            _mockCategoryDAL.Setup(m => m.chinhSuaRow(categoryDTO)).Returns(true);
            // call action
            bool actual = _category_FoodBLL.chinhSuaRow(categoryDTO);
            // compare
            Assert.IsTrue(actual);
        }

        [Test]
        public void Category_FoodBLL_TimKiemLoaiMonAn()
        {
            // setup method
            string n = "Search Query";
            DataTable expectedDataTable = new DataTable();
            _mockCategoryDAL.Setup(m => m.TimKiemLoaiMonAn(n)).Returns(expectedDataTable);
            // call action
            DataTable actualDataTable = _category_FoodBLL.TimKiemLoaiMonAn(n);
            // compare
            Assert.AreEqual(expectedDataTable, actualDataTable);
        }

        [Test]
        public void Category_FoodBLL_xoaLoaiMonAn()
        {
            // setup method
            int id = 1;
            _mockCategoryDAL.Setup(m => m.xoaLoaiMonAn(id)).Returns(true);
            // call action
            bool actual = _category_FoodBLL.xoaLoaiMonAn(id);
            // compare
            Assert.IsTrue(actual);
        }

    }
}
