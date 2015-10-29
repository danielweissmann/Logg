using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logg.Test
{
    /// <summary> Summary description for UnitTest_Log </summary>
    [TestClass]
    public class UnitTest_Log
    {
        [TestMethod]
        public void TestMethod1()
        {
            Logger logger = new Logger();

            LogEntry entry = logger.GetLogEntry("@test logic error teste numero 1562!", LogEntryType.Warning);

            logger.WriteTo(entry);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod2()
        {
            new MyObject();

            Assert.Fail("exception thrown");
        }
    }

    public class MyObject
    {
        public MyObject()
        {
            throw new UnitTestException("logic error @Exception.");
        }
    }
}
