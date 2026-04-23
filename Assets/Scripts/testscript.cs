using UnityEngine;

public class testscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(Singleton1.instance);
        Singleton1.GetInstance();
        //Debug.Log(Singleton1.instance);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
