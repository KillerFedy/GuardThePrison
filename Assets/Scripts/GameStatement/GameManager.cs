using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _countOfPrisoners = 0;
    private int _countOfGrabbedPrisoners = 0;
    private int _countOfRunAwayPrisoners = 0;

    private void Awake()
    {
        InitPrisonerActions();
    }

    private void CheckStatement()
    {
        if(_countOfGrabbedPrisoners > (_countOfPrisoners / 2))
        {
<<<<<<< HEAD:Assets/Scripts/GameStatement/PrisonersStatement.cs
            //Debug.Log("Win");
        }
        else if(_countOfRunAwayPrisoners > (_countOfPrisoners / 2))
        {
           // Debug.Log("Lose");
        }    
=======
            //Debug.Log("WIN");
        }
        else if(_countOfRunAwayPrisoners > (_countOfPrisoners / 2))
        {
            //Debug.Log("No");
        }
>>>>>>> develop:Assets/Scripts/GameStatement/GameManager.cs
    }

    private void CountRunAwayPrisoner()
    {
        _countOfRunAwayPrisoners++;
        CheckStatement();
    }

    private void CountGrabbedPrisoner()
    {
        _countOfGrabbedPrisoners++;
        CheckStatement();
    }

    private void DeleteGrabbedPrisoner()
    {
        _countOfGrabbedPrisoners--;
    }

    private void CountPrisoners()
    {
        _countOfPrisoners++;
    }

    private void InitPrisonerActions()
    {
        Prisoner.OnInitialized += CountPrisoners;
        Prisoner.OnRanAway += CountRunAwayPrisoner;
        Prisoner.OnRanAwayFromCell += DeleteGrabbedPrisoner;
        Prisoner.OnSetInPrison += CountGrabbedPrisoner;
    }
}
