using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenterController : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;

    private PlayerModel _playerModel;
    private PlayerPresenter _playerPresenter;

    private void Awake()
    {
        _playerModel = new PlayerModel();
        _playerPresenter = new PlayerPresenter(_playerView, _playerModel);
    }
}
