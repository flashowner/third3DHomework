using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class CCRunBoat : SSAction {
    public FirstController sceneController;

    public static CCRunBoat GetSSAction()
    {
        CCRunBoat action = ScriptableObject.CreateInstance<CCRunBoat>();
        return action;
    }

    public FirstController getController()
    {
        return sceneController;
    }

    internal void setController(FirstController fir)
    {
        if (sceneController == null)
        {
            sceneController = fir;
        }
    }

    // Use this for initialization
    public override void Start()
    {
        sceneController = SSDirector.getInstance().controll;
    }

    // Update is called once per frame
    public override void gameAction() {
        if (sceneController.director.state == State.SEMOV)
        {
            sceneController.boat_run.transform.position = Vector3.MoveTowards(sceneController.boat_run.transform.position, sceneController.boatEnd, sceneController.speed * Time.deltaTime);
            if (sceneController.boat_run.transform.position == sceneController.boatEnd)
            {
                sceneController.director.state = State.END;
            }
        }
        else if (sceneController.director.state == State.ESMOV)
        {
            sceneController.boat_run.transform.position = Vector3.MoveTowards(sceneController.boat_run.transform.position, sceneController.boatStart, sceneController.speed * Time.deltaTime);
            if (sceneController.boat_run.transform.position == sceneController.boatStart)
            {
                sceneController.director.state = State.START;
            }
        }
        else
        {
            sceneController.check();
        }
    }
}
