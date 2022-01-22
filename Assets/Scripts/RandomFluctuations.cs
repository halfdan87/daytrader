using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RandomFluctuations : MonoBehaviour
{
    [Inject] private GameManager _gameManager;

    void Update()
    {
        var pos = transform.position;

        pos.y = _gameManager.price;

        transform.position = pos;
    }
}
