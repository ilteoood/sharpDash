using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpDash
{
    public class _
    {
        public static T[][] chunk<T>(IList<T> toChunk, int size = 1)
        {
            int matrixSize = (toChunk.Count -1)/ size + 1;
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
            return args.Cast<T>().ToArray<T>();
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
    }
}
