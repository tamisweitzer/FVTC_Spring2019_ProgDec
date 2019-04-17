using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSS.ProgDec.BL;
using System.Linq;

namespace TSS.ProgDec.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void SeedTest()
        {
            User user = new User();
            user.Seed();
            Assert.IsTrue(true);
        }
    }
}
