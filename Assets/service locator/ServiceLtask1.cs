using UnityEngine;

public static class ServiceLtask1
{
    private static IProfile _profile = new NullProfile();
    private static IMapFactory _mapFactory = new NullMapFactory();
    private static IObjectPool _objectPool = new NullObjectPool();

    static void provide(IProfile a) {

        if (a == null)
            _profile = new NullProfile();
        else 
            _profile = a;
    }
    static void provide(IMapFactory a)
    {

        if (a == null)
            _mapFactory = new NullMapFactory();
        else
            _mapFactory = a;
    }
    static void provide(IObjectPool a)
    {

        if (a == null)
            _objectPool = new NullObjectPool();
        else
            _objectPool = a;
    }
    public static IProfile GetProfile() { 
        return _profile;
    }
    public static IMapFactory GetMapFactory() { return _mapFactory; }
    public static IObjectPool GetObjectPool() { return _objectPool; }







}
