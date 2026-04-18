using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConsoleStepCounter : MonoBehaviour, Observer {

    Dictionary<GridMovement, int> actorSteps = new Dictionary<GridMovement, int>();

    /**
    Todo:
        Implement methods: 
            * Start - Use this method to register the observer to the movement subject
            * OnDestroy -  Observers have to always unsubscribe from the subjects. Do this here.
    */

    public void SubjectUpdate(object sender)
    {
        GridMovement mover = sender as GridMovement;
        if(mover == null)
        {
            return;
        }

        if(!actorSteps.ContainsKey(mover))
        {
            actorSteps.Add(mover, 0);
        }

        actorSteps[mover]++;
        Debug.LogFormat("{0} has made step #{1}",mover.name,actorSteps[mover]);

    }



}
