using System.Collections.Generic;
using UnityEngine;
using System;

public static class ServiceLtask2
{
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    // Specific T, need to create a parameter of T (T service)
    public static void provide<T>(T service) where T : class { 
        services[typeof(T)] = service;
    }
    // Just class name, not specific instance. Is passed trough <T>
    public static T GetScript<T>() where T: class
    {
        if (services.TryGetValue(typeof(T), out object service))
        {
            return (T)service;
        }
        else
            return null;


    }
}
