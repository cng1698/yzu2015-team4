using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace user_good
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("Success", user_good.good.add_good("Tim", "Apple", "Face2Face"));
        }
    }
}
