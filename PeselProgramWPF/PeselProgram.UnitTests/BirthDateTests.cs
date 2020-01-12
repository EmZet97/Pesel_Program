using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeselProgramWPF;

namespace PeselProgram.UnitTests
{
    [TestClass]
    public class BirthDateTests
    {
        [TestMethod]
        public void IsCorrect_IncorrectDay_ReturnsFalse()
        {
            BirthDate date = new BirthDate(32, 1, 1999);

            var result = date.IsCorrect();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCorrect_IncorrectMonth_ReturnsFalse()
        {
            BirthDate date = new BirthDate(12, 14, 1999);

            var result = date.IsCorrect();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToString_IncorrectDate_ReturnsNull()
        {
            BirthDate date = new BirthDate(32, 1, 1999);

            var result = date.ToString();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ToString_CorrectDate_ReturnsString()
        {
            BirthDate date = new BirthDate(13, 2, 1997);

            var result = date.ToString();

            Assert.IsNotNull(result);
        }
    }
}
