using Code7.WeChip.Infra.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Code7.WeChip.Infra.Test
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void ConnectionDataBaseTest()
        {
            using (var ctx = WeChipContext.Context)
                Assert.IsTrue(ctx.State == System.Data.ConnectionState.Open);
        }
    }
}