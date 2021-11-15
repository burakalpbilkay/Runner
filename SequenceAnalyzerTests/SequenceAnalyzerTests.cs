using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceAnalysis;
using System;

namespace SequenceAnalyzerTests
{
    [TestClass]
    public class SequenceAnalyzerTests
    {
        private ISequenceAnalyzer _sequenceAnalyzer;

        [TestInitialize]
        public void Setup()
        {
            _sequenceAnalyzer = new SequenceAnalyzer();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrderUpperCaseWords_Null_ThrowsException()
        {
            _sequenceAnalyzer.OrderCharactersInUpperCaseWords(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrderUpperCaseWords_EmptyString_ThrowsException()
        {
            _sequenceAnalyzer.OrderCharactersInUpperCaseWords(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrderUpperCaseWords_NonUpperCaseWord_ThrowsException()
        {
            _sequenceAnalyzer.OrderCharactersInUpperCaseWords("TeNeT");
        }

        [TestMethod]
        public void OrderUpperCaseWords_ReturnsCorrectData()
        {
            Assert.AreEqual("ESTT", _sequenceAnalyzer.OrderCharactersInUpperCaseWords("TEST"));
        }

        [TestMethod]
        public void OrderUpperCaseWords_MultipleWordsReturnsCorrectData()
        {
            Assert.AreEqual("GIINRSST", _sequenceAnalyzer.OrderCharactersInUpperCaseWords("This IS a STRING"));
        }

        [TestMethod]
        public void OrderUpperCaseWords_MultipleWordsWithMultipleSpacesReturnsCorrectData()
        {
            Assert.AreEqual("GIINRSST", _sequenceAnalyzer.OrderCharactersInUpperCaseWords("This   IS   a   STRING"));
        }

        [TestMethod]
        public void OrderUpperCaseWords_InputWithSpecialCharactersReturnsCorrectData()
        {
            Assert.AreEqual("IS", _sequenceAnalyzer.OrderCharactersInUpperCaseWords("T@is$%^ IS a ST%^&*RING"));
        }

        [TestMethod]
        public void OrderUpperCaseWords_InputWithSpecialCharactersThatCanAppearInAWordReturnsCorrectData()
        {
            Assert.AreEqual("BCEEGHHNOORSST", _sequenceAnalyzer.OrderCharactersInUpperCaseWords("Gemeente 'S-HERTOGENBOSCH"));
        }
    }
}
