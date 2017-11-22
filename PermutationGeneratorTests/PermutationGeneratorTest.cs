using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermutationGenerator;

namespace PermutationGeneratorTests
{ 
    [TestClass]
    public class PermutationGeneratorTest
    {
        [TestMethod]
        public void getPermutation_PermIndexZero_returnCorrectlyOrderedArray()
        {
            CollectionAssert.AreEqual(factoradicPermutationGenerator.getPermutation(0, new int[] { 1, 2, 3, 4, 5 }), new int[] { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void getPermutation_PermIndexOne_returnLastTwoElementsSwapped()
        {
            CollectionAssert.AreEqual(factoradicPermutationGenerator.getPermutation(1, new int[] { 1, 2, 3, 4, 5 }), new int[] { 1, 2, 3, 5, 4 });
        }

        [TestMethod]
        public void getPermIndex_AllElementsInOrder_returnZero()
        {
            Assert.AreEqual(factoradicPermutationGenerator.getPermIndex(new int[] { 1, 2, 3, 4, 5 }), 0); 
        }

        [TestMethod]
        public void getPermIndex_LastTwoElementsSwapped_ReturnOne()
        {
            Assert.AreEqual(factoradicPermutationGenerator.getPermIndex(new int[] { 1, 2, 3, 5, 4 }), 1);
        }

        [TestMethod]
        public void getPermIndex_ScrambledElements_Return463()
        {
            Assert.AreEqual(factoradicPermutationGenerator.getPermIndex(new int[] { 3, 5, 1, 0, 4, 2 }), 463);
        }
    }
}
