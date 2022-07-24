using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _instructionText;

    [SerializeField] private Text _countPrisonersText;
    [SerializeField] private Text _countGrabbedPrisonersText;

    private void Start()
    {
        InitGameManagerActions();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            _instructionText.SetActive(false);
        }
    }

    private void SetCountPrisonersText(int count)
    {
        _countPrisonersText.text = count.ToString();
    }

    private void SetCountGrabbedPrisonersText(int count)
    {
        _countGrabbedPrisonersText.text = count.ToString();
    }

    private void ActivateWinPanel()
    {
        _winPanel.SetActive(true);
    }

    private void ActivateLosePanel()
    {
        _losePanel.SetActive(true);
    }

    private void InitGameManagerActions()
    {
        GameManager.OnWin += ActivateWinPanel;
        GameManager.OnLose += ActivateLosePanel;
        GameManager.OnCountPrisoners += SetCountPrisonersText;
        GameManager.OnCountGrabbedPrisoners += SetCountGrabbedPrisonersText;
    }
}
