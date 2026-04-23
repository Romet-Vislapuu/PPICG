using UnityEngine;

public class Singleton3<T>: MonoBehaviour where T   : Singleton3<T>
{
    private static T instance;



    private void Start()
    {
        if (instance != null && this != instance)
        {
            Destroy(gameObject);
            return;

        }
        instance = (T)this;
        DontDestroyOnLoad(gameObject);
        //Debug.Log("test");
    }

}
