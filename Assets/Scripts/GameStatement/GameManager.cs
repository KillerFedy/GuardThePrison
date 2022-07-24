using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnWinEffects;

    public static event Action OnWin;
    public static event Action OnLose;

    public static event Action<int> OnCountGrabbedPrisoners;
    public static event Action<int> OnCountPrisoners;

    private int _countOfPrisoners = 0;
    private int _countOfGrabbedPrisoners = 0;
    private int _countOfRunAwayPrisoners = 0;

    private void Awake()
    {
        InitPrisonerActions();
    }

    private void Start()
    {
        StartCoroutine(WaitToCountPrisoners());
    }

    private void CheckStatement()
    {
        if (_countOfGrabbedPrisoners > (_countOfPrisoners / 2))
        {
            OnWinEffects.Invoke();
            OnWin();
        }
        else if (_countOfRunAwayPrisoners > (_countOfPrisoners / 2))
        {
            OnLose();
        }
    }

    private void CountRunAwayPrisoner()
    {
        _countOfRunAwayPrisoners++;
        CheckStatement();
    }

    private void CountGrabbedPrisoner()
    {
        _countOfGrabbedPrisoners++;
        OnCountGrabbedPrisoners(_countOfGrabbedPrisoners);
        CheckStatement();
    }

    private void DeleteGrabbedPrisoner()
    {
        _countOfGrabbedPrisoners--;
        OnCountGrabbedPrisoners(_countOfGrabbedPrisoners);
    }

    private void CountPrisoners()
    {
        _countOfPrisoners++;
    }

    private IEnumerator WaitToCountPrisoners()
    {
        yield return new WaitForSeconds(0.2f);
        OnCountPrisoners(_countOfPrisoners);
    }

    private void InitPrisonerActions()
    {
        Prisoner.OnInitialized += CountPrisoners;
        Prisoner.OnRanAway += CountRunAwayPrisoner;
        Prisoner.OnRanAwayFromCell += DeleteGrabbedPrisoner;
        Prisoner.OnSetInPrison += CountGrabbedPrisoner;
    }
}
