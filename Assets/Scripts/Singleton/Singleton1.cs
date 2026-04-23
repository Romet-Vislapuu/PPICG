using UnityEngine;

public class Singleton1
{
    private static Singleton1 instance;

    private Singleton1() { }// Note to self, makes the constructor private.

    public static Singleton1 GetInstance()
    {
        if (instance == null)
            instance = new Singleton1();
        return instance;


    }

    
}
