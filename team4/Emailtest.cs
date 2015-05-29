using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace team4
{
    [TestClass]
    public class Emailtest
    {
        [TestMethod]
        public void 驗證碼產生測試()
        {
            Assert.AreEqual("abcd",Email_Varify.produce_code());
            Assert.IsTrue(Email_Varify.if_same("a","a") );
        }
    }
}
