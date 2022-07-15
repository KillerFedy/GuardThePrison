using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour
{
    private PrisonCell[] _prisonCells;

    private void Start()
    {
        _prisonCells = GetComponentsInChildren<PrisonCell>();
    }

    private void SetPrisonersInPrison(Player player)
    {
        for(int i = 0; i < player.Prisoners.Count; i++)
        {
            for(int j = 0; j < _prisonCells.Length; j++)
            {
                if(!_prisonCells[j].IsFull)
                {
                    _prisonCells[j].SetPrisoner(player.Prisoners[i]);
                    break;
                }
            }
        }
        player.DropPrisoners();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log(1);
            if(player.Prisoners.Count > 0)
            {
                Debug.Log(2);
                SetPrisonersInPrison(player);
            }
        }
    }
}
