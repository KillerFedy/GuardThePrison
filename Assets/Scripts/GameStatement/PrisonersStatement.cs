using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonersStatement : MonoBehaviour
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

    }

    private void CountRunAwayPrisoner()
    {
        _countOfRunAwayPrisoners++;
    }

    private void CountGrabbedPrisoner()
    {
        _countOfGrabbedPrisoners++;
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
