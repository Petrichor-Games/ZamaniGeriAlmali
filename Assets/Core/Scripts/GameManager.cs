using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum STATE
{
    RUN,
    ATTACK,
    DEAD
}

public class GameManager : MonoBehaviour
{
    private STATE e_State = STATE.RUN;

    public int score;
    public static GameManager inst;


    public STATE GetState() => e_State;


    private void Awake()
    {
        inst = this;
    }


    public void ChangeState(int state)
    {
        switch (state)
        {
            case 0:
                e_State = STATE.RUN;
                break;
            case 1:
                e_State = STATE.ATTACK;
                break;
            case 2 :
                e_State = STATE.DEAD;
                break;
            default:
                e_State = STATE.RUN;
                break;
        }
    }

}
