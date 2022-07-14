using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour
{
    [SerializeField] private List<Prisoner> _prisoners;

    private float _distanceToRunPrisoners = 15f;

    private void Start()
    {
        SetPrisonersWait();
    }

    private void Update()
    {
        if(_prisoners.Count > 0 && (GetDistancePlayer() > _distanceToRunPrisoners))
        {
            StartRunPrisoners();
            Debug.Log(GetDistancePlayer());
        }
    }

    private void SetPrisonersWait()
    {
        foreach (Prisoner pr in _prisoners)
        {
             pr.SetPrisonerWait();
        }
    }

    private float GetDistancePlayer()
    {
        return Vector3.Distance(PlayerView.instance.gameObject.transform.position, transform.position);
    }

    private void StartRunPrisoners()
    {
        foreach(Prisoner pr in _prisoners)
        {
            pr.StartRun();
        }
        _prisoners.Clear();
    }
}
