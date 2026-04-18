using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    /*
        Todo:
            Implement methods: 
                * AddObserver - Used by observers to register to this subject
                * RemoveObserver - Used by observers to deregister from this subject
                * Notify - Used by owner of this subject to notify observers, that something has happened.   
    */

    private List<Observer> observers = new List<Observer>();
    private GridMovement subject;

    public Subject(GridMovement subject)
    {
        this.subject = subject;
    }

    public void AddObserver(Observer observer) {

        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }

    }
    public void RemoveObserver(Observer observer) {
        if (observers.Contains(observer)) { 
            observers.Remove(observer);
        }
    }
    public void Notify() {
        foreach(Observer elem in observers)
        {
            elem.Update(subject);
        }
    
    
    }
}