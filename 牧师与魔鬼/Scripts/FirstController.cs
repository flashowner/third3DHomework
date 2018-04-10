using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class FirstController : MonoBehaviour, ISceneController {
    public SSDirector director;
    public CCRunBoat ccr;
    public CCGetOnTheBoat cgn;
    public CCGetOffTheBoat cgf;

    public List<GameObject> priest_start = new List<GameObject>();
    public List<GameObject> priest_end = new List<GameObject>();
    public List<GameObject> devil_start = new List<GameObject>();
    public List<GameObject> devil_end = new List<GameObject>();

    public GameObject[] boat = new GameObject[2];
    public GameObject boat_run;
    public float speed = 100F;

    public Vector3 boatStart = new Vector3(2, 2.9F, 0);
    public Vector3 boatEnd = new Vector3(-2, 2.9F, 0);
    
    float gap = 1.0F;
    Vector3 priestStartPos = new Vector3(3.5F, 3.5F, 0);
    Vector3 priestEndPos = new Vector3(-5.5F, 3.5F, 0);
    Vector3 devilStartPos = new Vector3(6.5F, 3.5F, 0);
    Vector3 devilEndPos = new Vector3(-8.5F, 3.5F, 0);

	// Use this for initialization
	void Start () {
        director = SSDirector.getInstance();
        director.setController(this);
        ccr = new CCRunBoat();
        cgf = new CCGetOffTheBoat();
        cgn = new CCGetOnTheBoat();
        ccr.setController(this);
        cgn.setController(this);
        cgf.setController(this);
        LoadResources();
	}

    public void LoadResources()
    {
        Instantiate(Resources.Load("Prefabs/Shore"), Vector3.zero, Quaternion.identity);

        boat_run = Instantiate(Resources.Load("Prefabs/Boat"), boatStart, Quaternion.identity) as GameObject;

        for (int i = 0; i < 3; i++)
        {
            priest_start.Add(Instantiate(Resources.Load("Prefabs/Priest")) as GameObject);
            devil_start.Add(Instantiate(Resources.Load("Prefabs/Devil")) as GameObject);
        }

        Instantiate(Resources.Load("Prefabs/Light"));
    }

    public int boatCapacity()
    {
        int capacity = 0;
        for (int i = 0; i < 2; i++)
        {
            if (boat[i] == null)
                capacity++;
        }
        return capacity;
    }

    public void moveBoat()
    {
        if (boatCapacity() != 2)
        {
            if (director.state == State.START)
            {
                director.state = State.SEMOV;
            }
            else if (director.state == State.END)
            {
                director.state = State.ESMOV;
            }
        }
    }

    public void priestStartOnBoat()
    {
        if (priest_start.Count != 0 && boatCapacity() != 0 && director.state == State.START)
        {
            for (int i = 0; i < priest_start.Count; i++)
            {
                if (priest_start[i] != null)
                {
                    cgn.setGame(priest_start[i]);
                    cgn.gameAction();
                    priest_start.RemoveAt(i);
                    break;
                }
            }
        }
    }

    public void priestEndOnBoat()
    {
        if (priest_end.Count != 0 && boatCapacity() != 0 && director.state == State.END)
        {
            for (int i = 0; i < priest_end.Count; i++)
            {
                if (priest_end[i] != null)
                {
                    cgn.setGame(priest_end[i]);
                    cgn.gameAction();
                    priest_end.RemoveAt(i);
                    break;
                }
            }
        }
    }

    public void devilStartOnBoat()
    {
        if (devil_start.Count != 0 && boatCapacity() != 0 && director.state == State.START)
        {
            for (int i = 0; i < devil_start.Count; i++)
            {
                if (devil_start[i] != null)
                {
                    cgn.setGame(devil_start[i]);
                    cgn.gameAction();
                    break;
                }
            }
        }
    }

    public void devilEndOnBoat()
    {
        if (devil_end.Count != 0 && boatCapacity() != 0 && director.state == State.END)
        {
            for (int i = 0; i < devil_end.Count; i++)
            {
                if (devil_end[i] != null)
                {
                    cgn.setGame(devil_end[i]);
                    cgn.gameAction();
                    break;
                }
            }
        }
    }

    void setCharacterPositions(List<GameObject> store, Vector3 pos)
    {
        for (int i = 0; i < store.Count; ++i)
        {
            if (store[i] != null)
                store[i].transform.position = new Vector3(pos.x + gap * i, pos.y, pos.z);
        }
    }

	// Update is called once per frame
	void Update () {
        setCharacterPositions(priest_start, priestStartPos);
        setCharacterPositions(priest_end, priestEndPos);
        setCharacterPositions(devil_start, devilStartPos);
        setCharacterPositions(devil_end, devilEndPos);

        ccr.gameAction();
	}

    public void check()
    {
        int pOnb = 0, dOnb = 0;
        int priests_s = 0, devils_s = 0, priests_e = 0, devils_e = 0;

        if (priest_end.Count == 3 && devil_end.Count == 3)
        {
            director.state = State.WIN;
            return;
        }

        for (int i = 0; i < 2; i++)
        {
            if (boat[i] != null && boat[i].tag == "Priest") pOnb++;
            else if (boat[i] != null && boat[i].tag == "Devil") dOnb++;
        }

        if (director.state == State.START)
        {
            priests_s = priest_start.Count + pOnb;
            devils_s = devil_start.Count + dOnb;
            priests_e = priest_end.Count;
            devils_e = devil_end.Count;
        } else if (director.state == State.END)
        {
            priests_s = priest_start.Count;
            devils_s = devil_start.Count;
            priests_e = priest_end.Count + pOnb;
            devils_e = devil_end.Count + dOnb;
        }

        if ((priests_s != 0 && priests_s < devils_s) || (priests_e != 0 && priests_e < devils_e))
        {
            director.state = State.LOSE;
        }
    }
}
