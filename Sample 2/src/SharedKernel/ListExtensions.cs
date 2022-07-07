namespace SharedKernel;

public static class ListExtensions
{
    public static void Do<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
            action(item);
    }

    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        foreach (var item in items) 
            collection.Add(item);
    }
}