using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIStepCounter : MonoBehaviour, Observer {

    Dictionary<GridMovement, int> actorSteps = new Dictionary<GridMovement, int>();
    Dictionary<GridMovement, StepCard> actorCards = new Dictionary<GridMovement, StepCard>();

    [SerializeField]
    StepCard cardPrefab;
    [SerializeField]
    Transform container;
    
    /**
    Todo:
        Implement methods: 
            * Start - Use this method to register the observer to the movement subject
            * OnDestroy -  Observers have to always unsubscribe from the subjects. Do this here.
    */

    public void SubjectUpdate(object sender)
    {
        GridMovement mover = sender as GridMovement;
        if (mover == null)
        {
            return;
        }

        if (!actorSteps.ContainsKey(mover))
        {
            actorSteps.Add(mover, 0);

            var card = Instantiate(cardPrefab, container);
            card.SetName(mover.name);
            card.SetSteps(actorSteps[mover]);
            actorCards.Add(mover, card);
        }
        
        actorCards[mover].SetSteps(++actorSteps[mover]);

    }

}
