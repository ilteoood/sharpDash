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
                toReturn[i] = toChunk.Skip(i * size).Take(size).Cast<T>().ToArray<T>();
            return toReturn;
        }

        public static T[] compact<T>(T[] toCompact)
        {
            return toCompact.Where(element => !element.Equals(false) && !element.Equals(null) && !element.Equals(0) && !element.Equals("")).Cast<T>().ToArray<T>();
        }

        public static T[] concat<T>(params T[] args)
        {
            return args;
        }

        public static T[] difference<T>(T[] toCheck, T[] toExclude)
        {
            return toCheck.Where(element => !toExclude.Contains(element)).Cast<T>().ToArray();
        }
        
        public static T[] drop<T>(T[] toDrop, int n = 1)
        {
            return toDrop.Skip(n).Cast<T>().ToArray();
        }

        public static T[] dropRight<T>(T[] toDrop, int n = 1)
        {
            return toDrop.Reverse().Skip(n).Reverse().Cast<T>().ToArray();
        }

        public static T[] fill<T>(T[] toFill, T fillWith, int start = 0, int end=-1)
        {
            if (end == -1)
                end = toFill.Length;
            IEnumerable<T> firstPart = toFill.Take(start);
            IEnumerable<T> toReplace = Enumerable.Repeat(fillWith, end - start);
            IEnumerable<T> secondPart = toFill.Skip(end);
            return firstPart.Concat(toReplace).Concat(secondPart).Cast<T>().ToArray();
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
            return tempEnumerable.Cast<T>().ToArray();
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
            return sourceSearch[sourceSearch.Length - 1];
        }

        public static int lastIndexOf<T>(T[] sourceSearch, T toSearch, int fromIndex = -1)
        {
            if (fromIndex == -1)
                fromIndex = sourceSearch.Length;
            IEnumerable<T> whereToSearch = sourceSearch.Take(fromIndex);
            return whereToSearch.ToList<T>().FindLastIndex(element => element.Equals(toSearch));
        }


    }
}
