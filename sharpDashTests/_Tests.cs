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

        private bool jaggedAreEquals<T>(T[][] expected, T[][] manipulated)
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
        public void differenceByTest()
        {
            CollectionAssert.AreEqual(new double[] { 1.2 }, _.differenceBy(new double[] { 2.1, 1.2 }, new double[] { 2.3, 3.4 }, Math.Floor));
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

        private bool isActive(Dictionary<String, String> dict)
        {
            return dict["active"].Equals("true");
        }

        private bool dictEquals<TKey, TValue>(Dictionary<TKey, TValue>[] dict1, Dictionary<TKey, TValue>[] dict2)
        {
            bool equals = true;
            for(int i = 0; i < dict1.Length; i++)
                foreach (TKey key in dict1[i].Keys)
                    equals &= dict1[i][key].Equals(dict2[i][key]);
            return equals;
        }

        [TestMethod()]
        public void dropRightWhileTest()
        {
            Dictionary<String, String>[] tempDict = new Dictionary<string, string>[] {
                new Dictionary<String, String>(),
                new Dictionary<String, String>(),
                new Dictionary<String, String>()
            };
            tempDict[0].Add("user", "barney");
            tempDict[0].Add("active", "true");
            tempDict[1].Add("user", "fred");
            tempDict[1].Add("active", "false");
            tempDict[2].Add("user", "pebbles");
            tempDict[2].Add("active", "false");
            Dictionary<String, String>[] expectedDict = new Dictionary<string, string>[] {
                new Dictionary<String, String>(),
            };
            expectedDict[0].Add("user", "barney");
            expectedDict[0].Add("active", "true");
            Assert.IsTrue(dictEquals<String, String>(expectedDict, _.dropRightWhile(tempDict, isActive)));
        }

        [TestMethod()]
        public void fillTest()
        {
            CollectionAssert.AreEqual(new char[] {'a','a','a'}, _.fill(new Object[] { 1, 2, 3 }, 'a'));
            CollectionAssert.AreEqual(new int[] { 2, 2, 2 }, _.fill(new int[3], 2));
            CollectionAssert.AreEqual(new Object[] { 4, '*', '*', 10 }, _.fill(new Object[] { 4, 6, 8, 10 }, '*', 1, 3));
        }

        [TestMethod()]
        public void flattenDeepTest()
        {
            object[] tempArray = new object[] { 1, new object[] { 2, new object[] { 3, new object[] { 4 } }, 5 } };
            CollectionAssert.AreEqual(new object[] { 1, 2, 3, 4, 5 }, _.flattenDeep<Object>(tempArray));
        }

        [TestMethod()]
        public void headTest()
        {
            Assert.AreEqual(1, _.head(new int[] { 1, 2, 3 }));
            Assert.AreEqual(0, _.head(new int[] {}));
            Assert.AreEqual(1, _.first(new int[] { 1, 2, 3 }));
            Assert.AreEqual(0, _.first(new int[] { }));
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
        public void intersectionTest()
        {
            CollectionAssert.AreEqual(new int[] { 2 }, _.intersection(new int[] { 2, 1 }, new int[] { 2, 3 }));
        }

        [TestMethod()]
        public void intersectionByTest()
        {
            CollectionAssert.AreEqual(new double[] { 2.1 }, _.intersectionBy(Math.Floor, new double[] { 2.1, 1.2 }, new double[] { 2.3, 3.4 }));
        }

        [TestMethod()]
        public void joinTest()
        {
            Assert.AreEqual("a~b~c", _.join(new char[] { 'a', 'b', 'c' }, "~"));
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
            _.pull(ref tempArray, 'a', 'c');
            CollectionAssert.AreEqual(new char[] { 'b', 'b' }, tempArray);
        }

        [TestMethod()]
        public void pullAllTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            _.pullAll(ref tempArray, new char[] { 'a', 'c' });
            CollectionAssert.AreEqual(new char[] { 'b', 'b' }, tempArray);
        }

        [TestMethod()]
        public void pullAtTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'd' };
            CollectionAssert.AreEqual(new char[] { 'b', 'd' }, _.pullAt(ref tempArray, new int[] { 1, 3 }));
            CollectionAssert.AreEqual(new char[] { 'a', 'c' }, tempArray);
        }

        private bool isEven(int num)
        {
            return num % 2 == 0;
        }

        [TestMethod()]
        public void removeTest()
        {
            int[] tempArray = new int[] { 1, 2, 3, 4 };
            CollectionAssert.AreEqual(new int[] { 2, 4 }, _.remove(ref tempArray, isEven));
            CollectionAssert.AreEqual(new int[] { 1, 3 }, tempArray);
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

        [TestMethod()]
        public void takeTest()
        {
            int[] tempArray = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(new int[] { 1 }, _.take(tempArray));
            CollectionAssert.AreEqual(new int[] { 1, 2 }, _.take(tempArray, 2));
            CollectionAssert.AreEqual(tempArray, _.take(tempArray, 5));
            CollectionAssert.AreEqual(new int[] { }, _.take(tempArray, 0));
        }

        [TestMethod()]
        public void takeRightTest()
        {
            int[] tempArray = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(new int[] { 3 }, _.takeRight(tempArray));
            CollectionAssert.AreEqual(new int[] { 2, 3 }, _.takeRight(tempArray, 2));
            CollectionAssert.AreEqual(tempArray, _.takeRight(tempArray, 5));
            CollectionAssert.AreEqual(new int[] { }, _.takeRight(tempArray, 0));
        }

        [TestMethod()]
        public void unionTest()
        {
            CollectionAssert.AreEqual(new int[] { 2, 1 }, _.union(new int[] { 2 }, new int[] { 1, 2 }));
        }

        [TestMethod()]
        public void unionByTest()
        {
            CollectionAssert.AreEqual(new double[] { 2.1, 1.2 }, _.unionBy(Math.Floor, new double[] { 2.1 }, new double[] { 1.2, 2.3 }));
        }

        [TestMethod()]
        public void withoutTest()
        {
            CollectionAssert.AreEqual(new int[] { 3 }, _.without(new int[] { 2, 1, 2, 3 }, 1, 2));
        }

        [TestMethod()]
        public void xorTest()
        {
            CollectionAssert.AreEqual(new int[] { 1, 3 }, _.xor(new int[] { 2, 1 }, new int[] { 2, 3 }));
        }

        [TestMethod()]
        public void xorByTest()
        {
            CollectionAssert.AreEqual(new double[] { 1.2, 3.4 }, _.xorBy(Math.Floor, new double[] { 2.1, 1.2 }, new double[] { 2.3, 3.4 }));
        }

        [TestMethod()]
        public void zipTest()
        {
            Object[,] toZip = new Object[,]
            {
                {'a', 'b'},
                {1, 2},
                {true, false }
            };

            Object[,] zipped = _.zip(toZip);
            Object[,] expected = new Object[,]
            {
                {'a', 1, true},
                {'b', 2, false}
            };
            CollectionAssert.AreEqual(expected, zipped);
        }

        [TestMethod()]
        public void unzipTest()
        {
            Object[,] zipped = new Object[,]
            {
                {'a', 1, true},
                {'b', 2, false}
            };
            Object[,] unzipped = _.unzip(zipped);
            Object[,] expected = new Object[,]
            {
                {'a', 'b'},
                {1, 2},
                {true, false }
            };
            CollectionAssert.AreEqual(expected, unzipped);
            CollectionAssert.AreEqual(expected, _.unzip(_.zip(unzipped)));
        }

        [TestMethod()]
        public void zipObjectTest()
        {
            Dictionary<char, int> expected = new Dictionary<char, int>();
            expected.Add('a', 1);
            expected.Add('b', 2);
            CollectionAssert.Equals(expected, _.zipObject(new char[] { 'a', 'b' }, new int[] { 1, 2 }));
        }

        [TestMethod()]
        public void countByTest()
        {
            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(4, 1);
            expected.Add(6, 2);
            CollectionAssert.Equals(expected, _.countBy(Math.Floor, new double[] { 6.1, 4.2, 6.3 }));
        }

    }
}