using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SellController : MonoBehaviour
{
    [Inject] private GameManager _gameManager;
    
    public void OnClick()
    {
        _gameManager.Sell();
    }
}
