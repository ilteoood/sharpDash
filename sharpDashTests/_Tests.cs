using Xunit;
using System;
using System.Collections.Generic;

namespace sharpDash.Tests
{
    public class _Tests
    {
        [Fact]
        public void chunkTest()
        {
            char[] testArray = new char[] { 'a','b','c','d' };
            char[][] expected = new char[][]{
                new char[]{ 'a', 'b' },
                new char[]{ 'c', 'd' }
            };
            Assert.Equal(expected, _.chunk<char>(testArray, 2));
            expected = new char[][]{
                new char[]{ 'a', 'b', 'c' },
                new char[]{ 'd', }
            };
            Assert.Equal(expected, _.chunk<char>(testArray, 3));
        }

        [Fact]
        public void compactTest()
        {
            var testArray = new Object[] { 0, 1, false, 2, "", 3 };
            Object[] expected = new Object[] { 1, 2, 3 };
            Assert.Equal(expected, _.compact(testArray));
        }

        [Fact]
        public void concatTest()
        {
            int[] expected = new int[] { 1, 2, 3, 4 };
            Assert.Equal(expected, _.concat<int>(1, 2, 3, 4));
        }

        [Fact]
        public void differenceTest()
        {
            Assert.Equal(new int[]{ 1 }, _.difference(new int[] { 2, 1 }, new int[] { 2, 3 }));
        }

        [Fact]
        public void differenceByTest()
        {
            Assert.Equal(new double[] { 1.2 }, _.differenceBy(new double[] { 2.1, 1.2 }, new double[] { 2.3, 3.4 }, Math.Floor));
        }

        [Fact]
        public void dropTest()
        {
            Assert.Equal(new int[] {2,3}, _.drop(new int[] { 1, 2, 3 }));
            Assert.Equal(new int[] { 3 }, _.drop(new int[] { 1, 2, 3 }, 2));
            Assert.Equal(new int[] { }, _.drop(new int[] { 1, 2, 3 }, 5));
            Assert.Equal(new int[] { 1, 2, 3 }, _.drop(new int[] { 1, 2, 3 }, 0));
        }

        [Fact]
        public void dropRightTest()
        {
            Assert.Equal(new int[] { 1, 2}, _.dropRight(new int[] { 1, 2, 3 }));
            Assert.Equal(new int[] { 1 }, _.dropRight(new int[] { 1, 2, 3 }, 2));
            Assert.Equal(new int[] { }, _.dropRight(new int[] { 1, 2, 3 }, 5));
            Assert.Equal(new int[] { 1, 2, 3 }, _.dropRight(new int[] { 1, 2, 3 }, 0));
        }

        private bool isActive(Dictionary<String, String> dict)
        {
            return dict["active"].Equals("true");
        }

        [Fact]
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
            Assert.Equal(expectedDict, _.dropRightWhile(tempDict, isActive));
        }

        [Fact]
        public void fillTest()
        {
            Assert.Equal(new Object[] {'a','a','a'}, _.fill(new Object[] { 1, 2, 3 }, 'a'));
            Assert.Equal(new int[] { 2, 2, 2 }, _.fill(new int[3], 2));
            Assert.Equal(new Object[] { 4, '*', '*', 10 }, _.fill(new Object[] { 4, 6, 8, 10 }, '*', 1, 3));
        }

        [Fact]
        public void flattenDeepTest()
        {
            object[] tempArray = new object[] { 1, new object[] { 2, new object[] { 3, new object[] { 4 } }, 5 } };
            Assert.Equal(new object[] { 1, 2, 3, 4, 5 }, _.flattenDeep<Object>(tempArray));
        }

        [Fact]
        public void headTest()
        {
            Assert.Equal(1, _.head(new int[] { 1, 2, 3 }));
            Assert.Equal(0, _.head(new int[] {}));
            Assert.Equal(1, _.first(new int[] { 1, 2, 3 }));
            Assert.Equal(0, _.first(new int[] { }));
        }

        [Fact]
        public void indexOfTest()
        {
            int[] tempArray = new int[] { 1, 2, 1, 2 };
            Assert.Equal(1, _.indexOf(tempArray, 2));
            Assert.Equal(3, _.indexOf(tempArray, 2, 2));
        }

        [Fact]
        public void initialTest()
        {
            Assert.Equal(new int[] { 1, 2 }, _.initial(new int[] { 1, 2, 3 }));
        }

        [Fact]
        public void intersectionTest()
        {
            Assert.Equal(new int[] { 2 }, _.intersection(new int[] { 2, 1 }, new int[] { 2, 3 }));
        }

        [Fact]
        public void intersectionByTest()
        {
            Assert.Equal(new double[] { 2.1 }, _.intersectionBy(Math.Floor, new double[] { 2.1, 1.2 }, new double[] { 2.3, 3.4 }));
        }

        [Fact]
        public void joinTest()
        {
            Assert.Equal("a~b~c", _.join(new char[] { 'a', 'b', 'c' }, "~"));
        }

        [Fact]
        public void lastTest()
        {
            Assert.Equal(3, _.last(new int[] { 1, 2, 3 }));
        }

        [Fact]
        public void lastIndexOfTest()
        {
            int[] tempArray = new int[] { 1, 2, 1, 2 };
            Assert.Equal(3, _.lastIndexOf(tempArray, 2));
            Assert.Equal(1, _.lastIndexOf(tempArray, 2, 2));
        }

        [Fact]
        public void nthTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'd' };
            Assert.Equal('b', _.nth(tempArray, 1));
            Assert.Equal('c', _.nth(tempArray, -2));
        }

        [Fact]
        public void pullTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            _.pull(ref tempArray, 'a', 'c');
            Assert.Equal(new char[] { 'b', 'b' }, tempArray);
        }

        [Fact]
        public void pullAllTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            _.pullAll(ref tempArray, new char[] { 'a', 'c' });
            Assert.Equal(new char[] { 'b', 'b' }, tempArray);
        }

        [Fact]
        public void pullAtTest()
        {
            char[] tempArray = new char[] { 'a', 'b', 'c', 'd' };
            Assert.Equal(new char[] { 'b', 'd' }, _.pullAt(ref tempArray, new int[] { 1, 3 }));
            Assert.Equal(new char[] { 'a', 'c' }, tempArray);
        }

        private bool isEven(int num)
        {
            return num % 2 == 0;
        }

        [Fact]
        public void removeTest()
        {
            int[] tempArray = new int[] { 1, 2, 3, 4 };
            Assert.Equal(new int[] { 2, 4 }, _.remove(ref tempArray, isEven));
            Assert.Equal(new int[] { 1, 3 }, tempArray);
        }

        [Fact]
        public void reverseTest()
        {
            int[] tempArray = new int[] { 1, 2, 3 };
            Assert.Equal(new int[] { 3, 2, 1 }, _.reverse(ref  tempArray));
            Assert.Equal(new int[] { 3, 2, 1 }, tempArray);
        }

        [Fact]
        public void sliceTest()
        {
            int[] tempArray = new int[] { 1, 2, 3 };
            Assert.Equal(new int[] { 1, 2, 3 }, _.slice(tempArray));
            Assert.Equal(new int[] { 2, 3 }, _.slice(tempArray, 1));
            Assert.Equal(new int[] { 2 }, _.slice(tempArray, 1, 2));
        }

        [Fact]
        public void sortedIndexTest()
        {
            Assert.Equal(1, _.sortedIndex(new int[] { 30, 50 }, 40));
        }

        [Fact]
        public void sortedIndexOfTest()
        {
            Assert.Equal(1, _.sortedIndexOf(new int[] { 4, 5, 5, 5, 6 }, 5));
        }

        [Fact]
        public void sortedLastIndexTest()
        {
            Assert.Equal(4, _.sortedLastIndex(new int[] { 4, 5, 5, 5, 6 }, 5));
        }

        [Fact]
        public void sortedLastIndexOfTest()
        {
            Assert.Equal(3, _.sortedLastIndexOf(new int[] { 4, 5, 5, 5, 6 }, 5));
        }

        [Fact]
        public void uniqTest()
        {
            Assert.Equal(new int[] { 2, 1 }, _.uniq(new int[] { 2, 1, 2 }));
        }

        [Fact]
        public void sortedUniqTest()
        {
            Assert.Equal(new int[] { 1, 2 }, _.sortedUniq(new int[] { 1, 1, 2 }));
        }

        [Fact]
        public void tailTest()
        {
            Assert.Equal(new int[] { 2, 3 }, _.tail(new int[] { 1, 2, 3 }));
        }

        [Fact]
        public void takeTest()
        {
            int[] tempArray = new int[] { 1, 2, 3 };
            Assert.Equal(new int[] { 1 }, _.take(tempArray));
            Assert.Equal(new int[] { 1, 2 }, _.take(tempArray, 2));
            Assert.Equal(tempArray, _.take(tempArray, 5));
            Assert.Equal(new int[] { }, _.take(tempArray, 0));
        }

        [Fact]
        public void takeRightTest()
        {
            int[] tempArray = new int[] { 1, 2, 3 };
            Assert.Equal(new int[] { 3 }, _.takeRight(tempArray));
            Assert.Equal(new int[] { 2, 3 }, _.takeRight(tempArray, 2));
            Assert.Equal(tempArray, _.takeRight(tempArray, 5));
            Assert.Equal(new int[] { }, _.takeRight(tempArray, 0));
        }

        [Fact]
        public void unionTest()
        {
            Assert.Equal(new int[] { 2, 1 }, _.union(new int[] { 2 }, new int[] { 1, 2 }));
        }

        [Fact]
        public void unionByTest()
        {
            Assert.Equal(new double[] { 2.1, 1.2 }, _.unionBy(Math.Floor, new double[] { 2.1 }, new double[] { 1.2, 2.3 }));
        }

        [Fact]
        public void withoutTest()
        {
            Assert.Equal(new int[] { 3 }, _.without(new int[] { 2, 1, 2, 3 }, 1, 2));
        }

        [Fact]
        public void xorTest()
        {
            Assert.Equal(new int[] { 1, 3 }, _.xor(new int[] { 2, 1 }, new int[] { 2, 3 }));
        }

        [Fact]
        public void xorByTest()
        {
            Assert.Equal(new double[] { 1.2, 3.4 }, _.xorBy(Math.Floor, new double[] { 2.1, 1.2 }, new double[] { 2.3, 3.4 }));
        }

        [Fact]
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
            Assert.Equal(expected, zipped);
        }

        [Fact]
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
            Assert.Equal(expected, unzipped);
            Assert.Equal(expected, _.unzip(_.zip(unzipped)));
        }

        [Fact]
        public void zipObjectTest()
        {
            Dictionary<char, int> expected = new Dictionary<char, int>();
            expected.Add('a', 1);
            expected.Add('b', 2);
            Assert.Equal(expected, _.zipObject(new char[] { 'a', 'b' }, new int[] { 1, 2 }));
        }

        [Fact]
        public void countByTest()
        {
            Dictionary<double, int> expected = new Dictionary<double, int>();
            expected.Add(4, 1);
            expected.Add(6, 2);
            Assert.Equal(expected, _.countBy(new double[] { 6.1, 4.2, 6.3 }, Math.Floor));
        }

        private bool isInactive(dynamic obj)
        {
            return obj.active.Equals(false);
        }

        private bool odd(int num)
        {
            return num % 2 == 1;
        }

        [Fact]
        public void filterTest()
        {
            var temp = new[] {
                new {user = "barney", age = 36, active = true },
                new {user = "fred",  age = 40, active = false}
            };
            Assert.Equal(new[] { new { user = "fred", age = 40, active = false } }, _.filter(temp, isInactive));
            Assert.Equal(new int[] { 1, 3 }, _.filter(new int[] { 1, 2, 3, 4 }, odd));
        }

        private bool age(dynamic obj)
        {
            return obj.age <  40;
        }

        [Fact]
        public void findTest()
        {
            var temp = new[] {
                new {user = "barney", age = 36, active = true },
                new {user = "fred",  age = 40, active = false},
                new {user = "pebbles", age = 1, active = true }
            };
            Assert.Equal(new { user = "barney", age = 36, active = true }, _.find(temp, age));
            Assert.Equal(1, _.find(new int[] { 1, 2, 3, 4 }, odd));
        }

        [Fact]
        public void findLastTest()
        {
            var temp = new[] {
                new {user = "barney", age = 36, active = true },
                new {user = "fred",  age = 40, active = false},
                new {user = "pebbles", age = 1, active = true }
            };
            Assert.Equal(new { user = "pebbles", age = 1, active = true }, _.findLast<dynamic>(temp, age));
            Assert.Equal(3, _.findLast(new int[] { 1, 2, 3, 4 }, odd));
        }

        [Fact]
        public void includesTest()
        {
            Assert.True(_.includes(new[] { 1, 2, 3 }, 1));
            Assert.False(_.includes(new[] { 1, 2, 3 }, 1, 2));
            Assert.True(_.includes(new[] {new {a = 1, b = 2}}, 1));
            Assert.True(_.includes("abcd", "bc"));
        }

        [Fact]
        public void clampTest()
        {
            Assert.Equal(-5, _.clamp(-10, -5, 5));
            Assert.Equal(5, _.clamp(10, -5, 5));
        }

        [Fact]
        public void inRangeTest()
        {
            Assert.True(_.inRange(3,4,2));
            Assert.True(_.inRange(4,8));
            Assert.False(_.inRange(4, 2));
            Assert.False(_.inRange(2, 2));
            Assert.True(_.inRange(1.2, 2));
            Assert.False(_.inRange(5.2, 4));
            Assert.True(_.inRange(-3, -6, -2));
        }

        [Fact]
        public void randomTest()
        {
            double temp = _.random(0, 5);
            Assert.Equal((int)temp, temp);
            temp = _.random(upper: 5);
            Assert.Equal((int)temp, temp);
            temp = _.random(upper: 5, floating: true);
            Assert.NotEqual((int)temp, temp);
            temp = _.random(1.2, 5.2);
            Assert.NotEqual((int)temp, temp);
        }

    }
}