using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeselProgramWPF;

namespace PeselProgram.UnitTests
{
    [TestClass]
    public class PeselDataReaderTests
    {
        [TestMethod]
        public void IsCorrect_IncorrectLenght_ReturnsFalse()
        {
            PeselDataReader reader = new PeselDataReader("123456");

            var result = reader.IsCorrect();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCorrect_NotNumeric_ReturnsFalse()
        {
            PeselDataReader reader = new PeselDataReader("12t33123125");

            var result = reader.IsCorrect();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetBirthDate_PeselIncorrect_ReturnsNull()
        {
            PeselDataReader reader = new PeselDataReader("990316080");

            var result = reader.GetBirthDate();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetBirthDate_DateIncorrect_ReturnsNull()
        {
            PeselDataReader reader = new PeselDataReader("99033208031");

            var result = reader.GetBirthDate();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetBirthDate_DateCorrect_ReturnsNotNull()
        {
            PeselDataReader reader = new PeselDataReader("99032008031");

            var result = reader.GetBirthDate();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetGender_PeselIncorrect_ReturnsUnknowGender()
        {
            PeselDataReader reader = new PeselDataReader("9903200801");

            var result = reader.GetGender();

            Assert.AreEqual(result, Gender.Unknown);
        }

        [TestMethod]
        public void GetGender_PeselCorrect_ReturnsMaleGender()
        {
            PeselDataReader reader = new PeselDataReader("97021308031");

            var result = reader.GetGender();

            Assert.AreEqual(result, Gender.Male);
        }

        [TestMethod]
        public void GetGender_PeselCorrect_ReturnsFemaleGender()
        {
            PeselDataReader reader = new PeselDataReader("97021308041");

            var result = reader.GetGender();

            Assert.AreEqual(result, Gender.Female);
        }

        [TestMethod]
        public void IsChecksumCorrect_PeselIncorrect_ReturnsFalse()
        {
            PeselDataReader reader = new PeselDataReader("970213041");

            var result = reader.IsChecksumCorrect();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsChecksumCorrect_ChecksumIncorrect_ReturnsFalse()
        {
            PeselDataReader reader = new PeselDataReader("97021308032");

            var result = reader.IsChecksumCorrect();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsChecksumCorrect_ChecksumCorrect_ReturnsTrue()
        {
            PeselDataReader reader = new PeselDataReader("97021308031");

            var result = reader.IsChecksumCorrect();

            Assert.IsTrue(result);
        }
    }
}
