
public class IOCContainer
{
    private static readonly Dictionary<Type, Func<object>> container = new Dictionary<Type, Func<object>>();

    //Resolve Services From Repos.

    public static T Resolve<T>()
    {
        var keyType = typeof(T);
        var method = container[keyType];
        var obj = method();
        var returnType = (T)obj;
        return returnType;
    }

    //Register Repos To IOC

    public static void Register<T>(Func<object> func)
    {
        if (container.ContainsKey(typeof(T)))
            container.Remove(typeof(T));

        container.Add(typeof(T), func);
    }
}