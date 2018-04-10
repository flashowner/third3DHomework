using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class CCGetOnTheBoat : SSAction {
    public FirstController sceneController;
    public GameObject obj;

    public static CCGetOnTheBoat GetSSAction(GameObject temp)
    {
        CCGetOnTheBoat action = ScriptableObject.CreateInstance<CCGetOnTheBoat>();
        action.obj = temp;
        return action;
    }

    public void setGame(GameObject temp)
    {
        obj = temp;
    }

    // Use this for initialization
    public override void Start()
    {
        sceneController = SSDirector.getInstance().controll;
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

    // Update is called once per frame
    public override void gameAction() {
        if (sceneController.boatCapacity() != 0)
        {
            obj.transform.parent = sceneController.boat_run.transform;
            if (sceneController.boat[0] == null)
            {
                sceneController.boat[0] = obj;
                obj.transform.localPosition = new Vector3(-0.25F, 3, 0);
            }
            else
            {
                sceneController.boat[1] = obj;
                obj.transform.localPosition = new Vector3(0.25F, 3, 0);
            }
        }
    }
}
