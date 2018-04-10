using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class CCGetOffTheBoat : SSAction {
    public FirstController sceneController;
    public int side;

    public static CCGetOffTheBoat GetSSAction(int sid)
    {
        CCGetOffTheBoat action = ScriptableObject.CreateInstance<CCGetOffTheBoat>();
        action.side = sid;
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

    public void setSide(int sid)
    {
        side = sid;
    }

    // Update is called once per frame
    public override void gameAction()
    {
        if (sceneController.boat[side] != null)
        {
            sceneController.boat[side].transform.parent = null;
            if (sceneController.director.state == State.END)
            {
                if (sceneController.boat[side].tag == "Priest")
                {
                    sceneController.priest_end.Add(sceneController.boat[side]);
                }
                else if (sceneController.boat[side].tag == "Devil")
                {
                    sceneController.devil_end.Add(sceneController.boat[side]);
                }
            }
            else if (sceneController.director.state == State.START)
            {
                if (sceneController.boat[side].tag == "Priest")
                {
                    sceneController.priest_start.Add(sceneController.boat[side]);
                }
                else if (sceneController.boat[side].tag == "Devil")
                {
                    sceneController.devil_start.Add(sceneController.boat[side]);
                }
            }
            sceneController.boat[side] = null;
        }
    }
}

