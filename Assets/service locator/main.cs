using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(ServiceLtask2.GetScript<NullProfile>());
        ServiceLtask2.provide<NullProfile>(new NullProfile());
        Debug.Log(ServiceLtask2.GetScript<NullProfile>());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
