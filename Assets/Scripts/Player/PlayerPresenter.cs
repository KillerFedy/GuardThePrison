using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    public PlayerPresenter(PlayerView view, PlayerModel model)
    {
        _playerView = view;
        _playerModel = model;
    }

}
