using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class UserInterface : MonoBehaviour {
    SSDirector director;
    UserBehavior action;

    float width, height;

    float castw(float scale)
    {
        return (Screen.width - width) / scale;
    }

    float casth(float scale)
    {
        return (Screen.height - height) / scale;
    }

	// Use this for initialization
	void Start () {
        director = SSDirector.getInstance();
        action = SSDirector.getInstance() as UserBehavior;
	}
	
	// Update is called once per frame
	void OnGUI () {
        width = Screen.width / 12;
        height = Screen.height / 12;

        if (director.state == State.WIN)
        {
            if (GUI.Button(new Rect(castw(2f), casth(6f), width, height), "WIN"))
            {
                action.restart();
            }
                    
        } else if (director.state == State.LOSE)
        {
            if (GUI.Button(new Rect(castw(2f), casth(6f), width, height), "Lose!"))
            {
                action.restart();
            }
        } else
        {
            if (GUI.RepeatButton(new Rect(10, 10, 120, 20), director.getDescribe().gameName))
            {
                GUI.TextArea(new Rect(10, 40, Screen.width - 20, Screen.height / 2), director.getDescribe().gameRule);
            }
            else if (director.state == State.START || director.state == State.END)
            {
                if (GUI.Button(new Rect(castw(2f), casth(6f), width, height), "Go"))
                {
                    action.moveBoat();
                }
                if (GUI.Button(new Rect(castw(10.5f), casth(4f), width, height), "On"))
                {
                    action.devilOnS();
                }
                if (GUI.Button(new Rect(castw(4.3f), casth(4f), width, height), "On"))
                {
                    action.priestOnS();
                }
                if (GUI.Button(new Rect(castw(1.1f), casth(4f), width, height), "On"))
                {
                    action.devilOnE();
                }
                if (GUI.Button(new Rect(castw(1.3f), casth(4f), width, height), "On"))
                {
                    action.priestOnE();
                }
                if (GUI.Button(new Rect(castw(2.5f), casth(1.3f), width, height), "Off"))
                {
                    action.offBoatL();
                }
                if (GUI.Button(new Rect(castw(1.7f), casth(1.3f), width, height), "Off"))
                {
                    action.offBoatR();
                }
            }
        }
	}
}
