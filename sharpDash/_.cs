using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;
using System.Security;
using System.Globalization;

namespace sharpDash
{
    public class _
    {
        public static T[][] chunk<T>(IList<T> array, int size = 1)
        {
            int matrixSize = (array.Count - 1)/ size + 1;
            T[][] toReturn = new T[matrixSize][];
            for (int i = 0; i < matrixSize; i++)
                toReturn[i] = array.Skip(i * size).Take(size).ToArray();
            return toReturn;
        }

        public static T[] compact<T>(T[] array)
        {
            object[] toAvoid = new object[] { false, null, 0, "" };
            return array.Where(element => !toAvoid.Contains(element)).ToArray();
        }

        public static T[] concat<T>(params T[] array)
        {
            return array;
        }

        public static T[] difference<T>(T[] array, T[] values)
        {
            return array.Where(element => !values.Contains(element)).ToArray();
        }

        public static T[] differenceBy<T>(T[] array, T[] values, Func<T, T> iteratee)
        {
            IEnumerable<T> excludeIterated = values.Select(element => iteratee(element));
            return (from check in array
                            where !excludeIterated.Contains(iteratee(check))
                            select check).ToArray();
        }

        public static T[] drop<T>(T[] array, int n = 1)
        {
            return array.Skip(n).ToArray();
        }

        public static T[] dropRight<T>(T[] array, int n = 1)
        {
            return array.Reverse().Skip(n).Reverse().ToArray();
        }

        public static T[] dropRightWhile<T>(T[] array, Func<T, bool> predicate)
        {
            return array.Reverse().Where(element => predicate(element)).Reverse().ToArray();
        }

        public static T[] fill<T>(T[] array, T value, int start = 0, int end=-1)
        {
            if (end == -1)
                end = array.Length;
            IEnumerable<T> firstPart = array.Take(start);
            IEnumerable<T> toReplace = Enumerable.Repeat(value, end - start);
            IEnumerable<T> secondPart = array.Skip(end);
            return firstPart.Concat(toReplace).Concat(secondPart).ToArray();
        }

        public static T first<T>(T[] toHead)
        {
            return head(toHead);
        }

        private static T[] flatterMethod<T>(T[] toFlatten, int maxDeep)
        {
            Func<IEnumerable<T>, int, IEnumerable<T>> flatter = null;
            flatter = (f, curDeep) => f.SelectMany(element => element is Array && (curDeep != maxDeep || maxDeep == 999) ? flatter(((IEnumerable)element).Cast<T>(), curDeep + 1) : Enumerable.Repeat(element, 1));
            return flatter(toFlatten, 0).ToArray();
        }

        public static T[] flatten<T>(T[] array)
        {
            return flatterMethod(array, 1);
        }

        public static T[] flattenDeep<T>(T[] array)
        {
            return flatterMethod(array, 999);
        }

        public static T[] flattenDepth<T>(T[] array, int depth=1)
        {
            return flatterMethod(array, depth);
        }

        public static T head<T>(T[] array)
        {
            return array.FirstOrDefault();
        }

        public static int indexOf<T>(T[] array, T value, int fromIndex = 0)
        {
            IEnumerable<T> whereToSearch = array.Skip(fromIndex);
            return fromIndex + whereToSearch.ToList<T>().FindIndex(element => element.Equals(value));
        }

        public static T[] initial<T>(T[] array)
        {
            return dropRight(array);
        }

        public static T[] intersection<T>(params T[][] arrays)
        {
            IEnumerable<T> tempEnumerable = arrays[0];
            foreach (T[] tempArg in arrays.Skip(1))
                tempEnumerable = tempEnumerable.Intersect(tempArg);
            return tempEnumerable.ToArray();
        }

        public static T[] intersectionBy<T>(Func<T, T> iteratee, params T[][] arrays)
        {
            T[] temp = arrays[0];
            return (from argArray in arrays.Skip(1)
                    from argElement in argArray
                    from argFirst in temp
                    where iteratee(argFirst).Equals(iteratee(argElement))
                    select argFirst).ToArray();
        }

        public static String join<T>(T[] array, String separator = ",")
        {
            String toReturn = "";
            foreach (T element in array)
                toReturn += element + separator;
            return toReturn.Substring(0, toReturn.LastIndexOf(separator));
        }

        public static T last<T>(T[] array)
        {
            return array.LastOrDefault();
        }

        public static int lastIndexOf<T>(T[] array, T value, int fromIndex = -1)
        {
            if (fromIndex == -1)
                fromIndex = array.Length;
            IEnumerable<T> whereToSearch = array.Take(fromIndex);
            return whereToSearch.ToList<T>().FindLastIndex(element => element.Equals(value));
        }

        public static T nth<T>(T[] array, int n=0)
        {
            if (n < 0)
                n = array.Length + n;
            return array[n];
        }

        public static T[] pull<T>(ref T[] array, params T[] values)
        {
            foreach(T arg in values)
                array = difference(array, new T[] { arg });
            return array;
        }

        public static T[] pullAll<T>(ref T[] array, params T[][] values)
        {
            foreach (T[] arg in values)
                array = pull(ref array, arg);
            return array;
        }

        public static T[] pullAt<T>(ref T[] array, params int[] indexes)
        {
            List<T> toReturn = new List<T>();
            foreach (int index in indexes)
                toReturn.Add(array[index]);
            T[] toReturnArray = toReturn.ToArray();
            pull(ref array, toReturnArray);
            return toReturnArray;
        }

        public static T[] remove<T>(ref T[] array, Func<T, bool> predicate)
        {
            T[] toReturn = array.Where(element => predicate(element)).ToArray();
            array = difference(array, toReturn);
            return toReturn;
        }

        public static T[] reverse<T>(ref T[] array)
        {
            return array = array.Reverse().ToArray();
        }

        public static T[] slice<T>(T[] array, int start = 0, int end = -1)
        {
            if (end == -1)
                end = array.Length;
            return array.Skip(start).Take(end-start).ToArray();
        }

        public static int sortedIndex(int[] array, int value)
        {
            return array.ToList().FindIndex(element => element <= value) + 1;
        }

        public static int sortedIndexOf<T>(T[] array, T value)
        {
            return indexOf(array, value);
        }

        public static int sortedLastIndex(int[] array, int value)
        {
            return array.ToList().FindLastIndex(element => element <= value) + 1;
        }

        public static int sortedLastIndexOf<T>(T[] array, T value)
        {
            return lastIndexOf(array, value);
        }

        public static T[] uniq<T>(T[] array)
        {
            return array.Distinct().ToArray();
        }
        public static int[] sortedUniq(int[] array)
        {
            return uniq(array);
        }

        public static T[] tail<T>(T[] array)
        {
            return array.Skip(1).ToArray();
        }

        public static T[] take<T>(T[] array, int n=1)
        {
            return array.Take(n).ToArray();
        }

        public static T[] takeRight<T>(T[] array, int n = 1)
        {
            return array.Reverse().Take(n).Reverse().ToArray();
        }

        public static T[] union<T>(params T[][] arrays)
        {
            IEnumerable<T> temp = new List<T>();
            foreach(T[] union in arrays)
                temp = temp.Union(union);
            return temp.ToArray();
        }

        public static T[] unionBy<T>(Func<T,T> iteratee, params T[][] arrays)
        {
            T[] tempArray = arrays[0];
            IEnumerable<T> temp = arrays[0].Select(element => iteratee(element));
            return tempArray.Concat(from unionArray in arrays.Skip(1)
                        from union in unionArray
                        where !temp.Contains(iteratee(union))
                        select union).ToArray();
        }

        public static T[] without<T>(T[] array, params T[] values)
        {
            T[] copy = (T[]) array.Clone();
            return pullAll(ref copy, values);
        }

        public static T[] xor<T>(params T[][] arrays)
        {
            return difference(union(arrays), intersection(arrays));
        }

        public static T[] xorBy<T>(Func<T,T> iteratee, params T[][] arrays)
        {
            return difference(unionBy(iteratee, arrays), intersectionBy(iteratee, arrays));
        }

        public static T[,] zip<T>(T[,] arrays)
        {
            int row = arrays.GetLength(0), column = arrays.GetLength(1);
            T[,] tempMatrix = new T[column, row];
            for (int i = 0; i < row; i++)
                for (int k = 0; k < column; k++)
                    tempMatrix[k, i] = arrays[i, k];
            return tempMatrix;
        }

        public static T[,] unzip<T>(T[,] arrays)
        {
            return zip(arrays);
        }

        public static Dictionary<TKey,TValue> zipObject<TKey, TValue>(TKey[] props, TValue[] values)
        {
            Dictionary<TKey, TValue> toReturn = new Dictionary<TKey, TValue>();
            for (int i = 0; i < props.Length; i++)
                toReturn.Add(props[i], values[i]);
            return toReturn;
        }

        public static Dictionary<T, int> countBy<T>(T[] collection, Func<T, T> iteratee)
        {
            Dictionary<T, int> toReturn = new Dictionary<T, int>();
            IEnumerable<IGrouping<T, T>> iterated = collection.Select(element => iteratee(element)).GroupBy(element => element);
            foreach (var element in iterated)
                toReturn.Add(element.Key, element.Count());
            return toReturn;
        }

        public static T[] filter<T>(T[] collection, Func<T, bool> predicate)
        {
            return collection.Where(element => predicate(element)).ToArray();
        }

        public static T find<T>(T[] collection, Func<T, bool> predicate, int fromIndex = 0)
        {
            return filter(collection.Skip(fromIndex).ToArray(), predicate).First();
        }

        public static T findLast<T>(T[] collection, Func<T, bool> predicate, int fromIndex = -1)
        {
            if (fromIndex == -1)
                fromIndex = collection.Count() - 1;
            return find(collection.Reverse().ToArray(), predicate);
        }

        public static bool includes<T>(T[] collection, T value, int fromIndex = 0)
        {
            return collection.Skip(fromIndex).Contains(value);
        }

        public static bool includes(IEnumerable<dynamic> collection, dynamic value, int fromIndex = 0)
        {
            bool temp = false;
            foreach (dynamic elem in collection.Skip(fromIndex))
                foreach (PropertyInfo property in elem.GetType().GetProperties())
                    temp |= property.GetValue(elem, null).Equals(value);
            return temp;
        }

        public static bool includes(String collection, String value, int fromIndex = 0)
        {
            return collection.Substring(fromIndex).Contains(value);
        }

        public static double now()
        {
            return DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public static double clamp(double number, double lower, double upper)
        {
            return Math.Min(Math.Max(number, lower), upper);
        }

        public static bool inRange(double number, double end, double start = 0)
        {
            if(end < start)
            {
                end = end * start;
                start = end / start;
                end = end / start;
            }
            return number > start && number < end;
        }

        public static double random(double lower = 0, double upper = 1, bool floating = false)
        {
            Random random = new Random();
            double toReturn = random.NextDouble() * (upper - lower) + lower;
            if (floating || lower % 1 != 0 && upper % 1 != 0)
                return toReturn;
            return (int)toReturn;
        }

        private static String changeFirstChar(String toChange, bool toUpper)
        {
            if (toUpper)
                return char.ToUpper(toChange[0]) + toChange.Substring(1);
            return char.ToLower(toChange[0]) + toChange.Substring(1);
        }

        private static String caseManager(String toCase, String separator, bool firstCharUp, bool otherCharsUp, String pattern = "[a-zA-Z]+")
        {
            Match matches = Regex.Match(toCase, pattern);
            String toReturn = changeFirstChar(matches.Value.ToLower(), firstCharUp);
            while (!(matches = matches.NextMatch()).Value.Equals(""))
                toReturn += separator + changeFirstChar(matches.Value.ToLower(), otherCharsUp);
            if (toReturn.ToLower().Equals(toCase.ToLower()))
                return caseManager(toCase, separator, firstCharUp, otherCharsUp, "([a-z]|[A-Z])[a-z]+");
            return toReturn;
        }

        public static String camelCase(String str= "")
        {
            return caseManager(str, "", false, true);
        }

        public static String capitalize(String str = "")
        {
            return changeFirstChar(str.ToLower(), true);
        }

        public static String deburr(String str = "")
        {
            str = str.Normalize(NormalizationForm.FormD);
            String temp = "";
            foreach (char c in str)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    temp += c;
            return temp.Normalize(NormalizationForm.FormC);
        }

        public static bool endsWith(String str, String target, int position = -1)
        {
            if (position == -1)
                position = str.Length;
            return str.Substring(0, position).EndsWith(target);
        }

        public static String escape(String str)
        {
            return SecurityElement.Escape(str);
        }

        public static String kebabCase(String str)
        {
            return caseManager(str, "-", false, false);
        }

        public static String lowerFirst(String str = "")
        {
            return changeFirstChar(str, false);
        }

        public static int parseInt(String str = "", int radix = 10)
        {
            int parsed;
            int.TryParse(str, out parsed);
            return int.Parse(Convert.ToString(parsed, radix));
        }

        public static String repeat(String str = "", int n = 1)
        {
            return new StringBuilder().Insert(0, str, n).ToString();
        }

        public static String replace(String str, String pattern, String replacement)
        {
            return str.Replace(pattern, replacement);
        }

        public static String snakeCase(String str)
        {
            return caseManager(str, "_", false, false);
        }

        public static String[] split(String str, String separator, int limit)
        {
            return str.Split(separator.ToCharArray()).Take(limit).ToArray();
        }

        public static String startCase(String str="")
        {
            return caseManager(str, " ", true, true);
        }

        public static bool startsWith(String str, String target, int position = 0)
        {
            return new String(str.Skip(position).ToArray()).StartsWith(target);
        }

        public static String toLower(String str = "")
        {
            return str.ToLower();
        }

        public static String toUpper(String str = "")
        {
            return str.ToUpper();
        }

        public static String trim(String str, String chars=" ")
        {
            foreach (char c in chars)
                str = str.Replace(c + "", "");
            return str;
        }

        public static String upperCase(String str = "")
        {
            return startCase(str).ToUpper();
        }

        public static String upperFirst(String str)
        {
            return changeFirstChar(str, true);
        }

        public static String[] words(String str, String pattern = "[a-zA-Z]+")
        {
            return Regex.Split(str, "(?!" + pattern + ").").Where(elem => elem.Length > 0).ToArray();
        }

    }
}
