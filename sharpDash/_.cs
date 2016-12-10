using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sharpDash
{
    public class _
    {
        public static T[][] chunk<T>(IList<T> toChunk, int size = 1)
        {
            int matrixSize = (toChunk.Count - 1)/ size + 1;
            T[][] toReturn = new T[matrixSize][];
            for (int i = 0; i < matrixSize; i++)
                toReturn[i] = toChunk.Skip(i * size).Take(size).ToArray();
            return toReturn;
        }

        public static T[] compact<T>(T[] toCompact)
        {
            return toCompact.Where(element => !element.Equals(false) && !element.Equals(null) && !element.Equals(0) && !element.Equals("")).ToArray<T>();
        }

        public static T[] concat<T>(params T[] args)
        {
            return args;
        }

        public static T[] difference<T>(T[] toCheck, T[] toExclude)
        {
            return toCheck.Where(element => !toExclude.Contains(element)).ToArray();
        }
        
        public static T[] drop<T>(T[] toDrop, int n = 1)
        {
            return toDrop.Skip(n).ToArray();
        }

        public static T[] dropRight<T>(T[] toDrop, int n = 1)
        {
            return toDrop.Reverse().Skip(n).Reverse().ToArray();
        }

        public static T[] fill<T>(T[] toFill, T fillWith, int start = 0, int end=-1)
        {
            if (end == -1)
                end = toFill.Length;
            IEnumerable<T> firstPart = toFill.Take(start);
            IEnumerable<T> toReplace = Enumerable.Repeat(fillWith, end - start);
            IEnumerable<T> secondPart = toFill.Skip(end);
            return firstPart.Concat(toReplace).Concat(secondPart).ToArray();
        }

        public static T head<T>(T[] toHead)
        {
            return toHead.FirstOrDefault();
        }

        public static int indexOf<T>(T[] sourceSearch, T toSearch, int fromIndex = 0)
        {
            IEnumerable<T> whereToSearch = sourceSearch.Skip(fromIndex);
            return fromIndex + whereToSearch.ToList<T>().FindIndex(element => element.Equals(toSearch));
        }

        public static T[] initial<T>(T[] toInitial)
        {
            return dropRight(toInitial);
        }

        public static T[] intersect<T>(params T[][] args)
        {
            IEnumerable<T> tempEnumerable = args[0];
            foreach (T[] tempArg in args)
                tempEnumerable = tempEnumerable.Intersect(tempArg);
            return tempEnumerable.ToArray();
        }

        public static String join<T>(T[] toJoin, String separator = ",")
        {
            String toReturn = "";
            int arrayLength = toJoin.Length;
            foreach (T element in toJoin)
                toReturn += element + separator;
            return toReturn.Substring(0, toReturn.LastIndexOf(separator));
        }

        public static T last<T>(T[] sourceSearch)
        {
            return sourceSearch.LastOrDefault();
        }

        public static int lastIndexOf<T>(T[] sourceSearch, T toSearch, int fromIndex = -1)
        {
            if (fromIndex == -1)
                fromIndex = sourceSearch.Length;
            IEnumerable<T> whereToSearch = sourceSearch.Take(fromIndex);
            return whereToSearch.ToList<T>().FindLastIndex(element => element.Equals(toSearch));
        }

        public static T nth<T>(T[] sourceSeach, int n=0)
        {
            if (n < 0)
                n = sourceSeach.Length + n;
            return sourceSeach[n];
        }

        public static T[] pull<T>(ref T[] toPull, params T[] args)
        {
            foreach(T arg in args)
                toPull = difference(toPull, new T[] { arg });
            return toPull;
        }

        public static T[] pullAll<T>(ref T[] toPull, params T[][] args)
        {
            foreach (T[] arg in args)
                toPull = pull(ref toPull, arg);
            return toPull;
        }

        public static T[] pullAt<T>(ref T[] toPull, params int[] indexes)
        {
            List<T> toReturn = new List<T>();
            T[] toReturnArray;
            foreach (int index in indexes)
                toReturn.Add(toPull[index]);
            toReturnArray = toReturn.ToArray();
            pull(ref toPull, toReturnArray);
            return toReturnArray;
        }

        public static T[] reverse<T>(ref T[] toReverse)
        {
            return toReverse = toReverse.Reverse().ToArray();
        }

        public static T[] slice<T>(T[] toSlice, int start = 0, int end = -1)
        {
            if (end == -1)
                end = toSlice.Length;
            return toSlice.Skip(start).Take(end-start).ToArray();
        }

        public static int sortedIndex(int[] sourceSearch, int value)
        {
            return sourceSearch.ToList().FindIndex(element => element <= value) + 1;
        }

        public static int sortedIndexOf<T>(T[] sourceSearch, T toSearch)
        {
            return indexOf(sourceSearch, toSearch);
        }

        public static int sortedLastIndex(int[] sourceSearch, int value)
        {
            return sourceSearch.ToList().FindLastIndex(element => element <= value) + 1;
        }

        public static int sortedLastIndexOf<T>(T[] sourceSearch, T value)
        {
            return lastIndexOf(sourceSearch, value);
        }

        public static T[] uniq<T>(T[] sourceSearch)
        {
            return sourceSearch.Distinct().ToArray();
        }
        public static int[] sortedUniq(int[] sourceSearch)
        {
            return uniq(sourceSearch);
        }
        public static T[] tail<T>(T[] sourceSearch)
        {
            return sourceSearch.Skip(1).ToArray();
        }

        public static T[] take<T>(T[] toTake, int n=1)
        {
            return toTake.Take(n).ToArray();
        }

        public static T[] takeRight<T>(T[] toTake, int n = 1)
        {
            return toTake.Reverse().Take(n).Reverse().ToArray();
        }

        public static T[] union<T>(params T[][] toUnion)
        {
            IEnumerable<T> temp = new List<T>();
            foreach(T[] union in toUnion)
                temp = temp.Union(union);
            return temp.ToArray();
        }

        public static T[] without<T>(T[] sourceSearch, params T[] toRemove)
        {
            T[] copy = (T[]) sourceSearch.Clone();
            return pullAll(ref copy, toRemove);
        }

    }
}
