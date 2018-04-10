
using Com.Mygame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Mygame
{
    public enum State { START, SEMOV, ESMOV, END, WIN, LOSE };

    public interface ISceneController
    {
        void LoadResources();
    }

    public interface UserBehavior
    {
        void moveBoat();
        void offBoatL();
        void offBoatR();
        void priestOnS();
        void priestOnE();
        void devilOnS();
        void devilOnE();
        void restart();
    }




    public class SSDirector : System.Object, UserBehavior
    {
        public static SSDirector _instance;
        public Describe des;
        public FirstController controll;
        public State state = State.START;

        public static SSDirector getInstance()
        {
            if (_instance == null)
            {
                _instance = new SSDirector();
            }
            return _instance;
        }

        public Describe getDescribe()
        {
            return des;
        }

        internal void setDescribe(Describe de)
        {
            if (des == null)
                des = de;
        }

        public FirstController getController()
        {
            return controll;
        }

        internal void setController(FirstController fir)
        {
            if (controll == null)
            {
                controll = fir;
            }
        }

        public void priestOnS()
        {
            controll.priestStartOnBoat();
        }

        public void priestOnE()
        {
            controll.priestEndOnBoat();
        }

        public void devilOnS()
        {
            controll.devilStartOnBoat();
        }

        public void devilOnE()
        {
            controll.devilEndOnBoat();
        }

        public void moveBoat()
        {
            controll.moveBoat();
        }

        public void offBoatL()
        {
            controll.cgf.setSide(0);
            controll.cgf.gameAction();
        }

        public void offBoatR()
        {
            controll.cgf.setSide(1);
            controll.cgf.gameAction();
        }

        public void restart()
        {
            Application.LoadLevel(Application.loadedLevel);
            state = State.START;
        }
    }
}

public class Describe : MonoBehaviour
{
    public string gameName;
    public string gameRule;

    void Start()
    {
        SSDirector director = SSDirector.getInstance();
        director.setDescribe(this);
        gameName = "Priests and Devils";
        gameRule = "河边有三个魔鬼和三个牧师，他们都想过河，但河上只有一条船，这艘船每次只能搭载两个，而且必须有一个人驾驶船行驶。如果河一边的魔鬼数量多于牧师，牧师将被魔鬼击杀，游戏结束。";
    }
}