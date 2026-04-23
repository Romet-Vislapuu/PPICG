using UnityEngine;

public class Singleton2 : MonoBehaviour
{
    private static Singleton2 instance;


    // I am really confused if I should destroy/not destroy "this" or the gameobject.
    private void Start()
    {
        if (instance != null && this != instance) { 
            Destroy(gameObject);
            return;
        
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

}
