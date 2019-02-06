using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Register.DataManager;
using Register.Model.DatabaseModel;

namespace Register.Tests
{
    [TestClass]
    public class Repository
    {
        [TestMethod]
        public void GetList()
        {
            var sut = new DataManagerHelper();

            var records = sut.List<Student>().ToList();

            Assert.AreEqual(1, records.Count);
        }
    }
}
