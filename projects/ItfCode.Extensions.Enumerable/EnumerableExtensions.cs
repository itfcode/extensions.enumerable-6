namespace ItfCode.Extensions.Enumerable
{
    public static class EnumerableExtensions
    {
        public static IOrderedEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source, bool isAsc,
            params Func<TSource, TKey>[] keySelectors)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(keySelectors);

            var length = keySelectors.Length;

            if (keySelectors.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(keySelectors), $"Argument '{nameof(keySelectors)}' shoud be not empty array.");

            var ordered = isAsc ? source.OrderBy(keySelectors[0]) : source.OrderByDescending(keySelectors[0]);

            for (int i = 1; i < length; i++)
                ordered = isAsc ? ordered.ThenBy(keySelectors[i]) : ordered.ThenByDescending(keySelectors[i]);

            return ordered;
        }
    }
}