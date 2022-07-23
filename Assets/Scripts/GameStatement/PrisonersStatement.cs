using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonersStatement : MonoBehaviour
{
    [SerializeField] private List<Prisoner> _prisoners = new List<Prisoner>();

    private int _countOfPrisoners;
    private int _countOfGrabbedPrisoners = 0;
    private int _countOfRunAwayPrisoners = 0;

    private void Start()
    {
        _countOfPrisoners = _prisoners.Count;
        foreach (Prisoner prisoner in _prisoners)
        {
            InitPrisonerActions(prisoner);
        }
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

    public void InitPrisonerActions(Prisoner prisoner)
    {
        prisoner.OnRanAway += CountRunAwayPrisoner;
        prisoner.OnRanAwayFromCell += DeleteGrabbedPrisoner;
        prisoner.OnSetInPrison += CountGrabbedPrisoner;
    }
}
