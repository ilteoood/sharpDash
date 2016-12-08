using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharpDash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpDash.Tests
{
    [TestClass()]
    public class _Tests
    {

        public bool jaggedAreEquals<T>(T[][] expected, T[][] manipulated)
        {
            bool assert = true;
            for (int i = 0; i < expected.Length; i++)
                for (int k = 0; k < expected[i].Length; k++)
                    assert &= expected[i][k].Equals(manipulated[i][k]);
            return assert;
        }
        [TestMethod()]
        public void chunkTest()
        {
            char[] testArray = new char[] { 'a','b','c','d' };
            char[][] expected = new char[][]{
                new char[]{ 'a', 'b' },
                new char[]{ 'c', 'd' }
            };
            Assert.IsTrue(jaggedAreEquals<char>(expected, _.chunk<char>(testArray, 2)));
            expected = new char[][]{
                new char[]{ 'a', 'b', 'c' },
                new char[]{ 'd', }
            };
            Assert.IsTrue(jaggedAreEquals<char>(expected, _.chunk<char>(testArray, 3)));
        }

        [TestMethod()]
        public void compactTest()
        {
            var testArray = new Object[] { 0, 1, false, 2, "", 3 };
            Object[] expected = new Object[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expected, _.compact(testArray));
        }

        [TestMethod()]
        public void concatTest()
        {
            int[] expected = new int[] { 1, 2, 3, 4 };
            CollectionAssert.AreEqual(expected, _.concat<int>(1, 2, 3, 4));
        }

        [TestMethod()]
        public void differenceTest()
        {
            CollectionAssert.AreEqual(new int[]{ 1 }, _.difference(new int[] { 2, 1 }, new int[] { 2, 3 }));
        }

        [TestMethod()]
        public void dropTest()
        {
            CollectionAssert.AreEqual(new int[] {2,3}, _.drop(new int[] { 1, 2, 3 }));
            CollectionAssert.AreEqual(new int[] { 3 }, _.drop(new int[] { 1, 2, 3 }, 2));
            CollectionAssert.AreEqual(new int[] { }, _.drop(new int[] { 1, 2, 3 }, 5));
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, _.drop(new int[] { 1, 2, 3 }, 0));
        }

        [TestMethod()]
        public void dropRightTest()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2}, _.dropRight(new int[] { 1, 2, 3 }));
            CollectionAssert.AreEqual(new int[] { 1 }, _.dropRight(new int[] { 1, 2, 3 }, 2));
            CollectionAssert.AreEqual(new int[] { }, _.dropRight(new int[] { 1, 2, 3 }, 5));
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, _.dropRight(new int[] { 1, 2, 3 }, 0));
        }

        [TestMethod()]
        public void fillTest()
        {
            CollectionAssert.AreEqual(new char[] {'a','a','a'}, _.fill(new Object[] { 1, 2, 3 }, 'a'));
            CollectionAssert.AreEqual(new int[] { 2, 2, 2 }, _.fill(new int[3], 2));
            CollectionAssert.AreEqual(new Object[] { 4, '*', '*', 10 }, _.fill(new Object[] { 4, 6, 8, 10 }, '*', 1, 3));
        }

        [TestMethod()]
        public void headTest()
        {
            Assert.AreEqual(1, _.head(new int[] { 1, 2, 3 }));
            Assert.AreEqual(0, _.head(new int[] {}));
        }

        [TestMethod()]
        public void indexOfTest()
        {
            int[] tempArray = new int[] { 1, 2, 1, 2 };
            Assert.AreEqual(1, _.indexOf(tempArray, 2));
            Assert.AreEqual(3, _.indexOf(tempArray, 2, 2));
        }

        [TestMethod()]
        public void initialTest()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2 }, _.initial(new int[] { 1, 2, 3 }));
        }

        [TestMethod()]
        public void intersectTest()
        {
            CollectionAssert.AreEqual(new int[] { 2 }, _.intersect(new int[] { 2, 1 }, new int[] { 2, 3 }));
        }

        [TestMethod()]
        public void joinTest()
        {
            String manipulated = _.join(new char[] { 'a', 'b', 'c' }, "~");
            Assert.AreEqual("a~b~c", manipulated);
        }

        [TestMethod()]
        public void lastTest()
        {
            Assert.AreEqual(3, _.last(new int[] { 1, 2, 3 }));
        }

        [TestMethod()]
        public void lastIndexOfTest()
        {
            int[] tempArray = new int[] { 1, 2, 1, 2 };
            Assert.AreEqual(3, _.lastIndexOf(tempArray, 2));
            Assert.AreEqual(1, _.lastIndexOf(tempArray, 2, 2));
        }

        [TestMethod()]
        public void nthTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'd' };
            Assert.AreEqual('b', _.nth(tempArray, 1));
            Assert.AreEqual('c', _.nth(tempArray, -2));
        }

        [TestMethod()]
        public void pullTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            CollectionAssert.AreEqual(new char[] { 'b', 'b' }, _.pull(tempArray, 'a', 'c'));
        }

        [TestMethod()]
        public void pullAllTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            CollectionAssert.AreEqual(new char[] { 'b', 'b' }, _.pullAll(tempArray, new char[] { 'a', 'c' }));
        }

        [TestMethod()]
        public void pullAtTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'd' };
            CollectionAssert.AreEqual(new char[] { 'b', 'd' }, _.pullAt(ref tempArray, new int[] { 1, 3 }));
            CollectionAssert.AreEqual(new char[] { 'a', 'c' }, tempArray);
        }

        [TestMethod()]
        public void reverseTest()
        {
            int[] tempArray = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(new int[] { 3, 2, 1 }, _.reverse(ref  tempArray));
            CollectionAssert.AreEqual(new int[] { 3, 2, 1 }, tempArray);
        }

        [TestMethod()]
        public void sliceTest()
        {
            int[] tempArray = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, _.slice(tempArray));
            CollectionAssert.AreEqual(new int[] { 2, 3 }, _.slice(tempArray, 1));
            CollectionAssert.AreEqual(new int[] { 2 }, _.slice(tempArray, 1, 2));
        }

        [TestMethod()]
        public void sortedIndexTest()
        {
            Assert.AreEqual(1, _.sortedIndex(new int[] { 30, 50 }, 40));
        }

        [TestMethod()]
        public void sortedIndexOfTest()
        {
            Assert.AreEqual(1, _.sortedIndexOf(new int[] { 4, 5, 5, 5, 6 }, 5));
        }

        [TestMethod()]
        public void sortedLastIndexTest()
        {
            Assert.AreEqual(4, _.sortedLastIndex(new int[] { 4, 5, 5, 5, 6 }, 5));
        }

        [TestMethod()]
        public void sortedLastIndexOfTest()
        {
            Assert.AreEqual(3, _.sortedLastIndexOf(new int[] { 4, 5, 5, 5, 6 }, 5));
        }

        [TestMethod()]
        public void uniqTest()
        {
            CollectionAssert.AreEqual(new int[] { 2, 1 }, _.uniq(new int[] { 2, 1, 2 }));
        }

        [TestMethod()]
        public void sortedUniqTest()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2 }, _.sortedUniq(new int[] { 1, 1, 2 }));
        }

        [TestMethod()]
        public void tailTest()
        {
            CollectionAssert.AreEqual(new int[] { 2, 3 }, _.tail(new int[] { 1, 2, 3 }));
        }

    }
}