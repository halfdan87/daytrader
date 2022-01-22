using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PointerController : MonoBehaviour
{
    private TrailRenderer _trailRenderer;

    [Inject] private GameManager.Settings settings;

    internal void Init(float price)
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        var pos = transform.position;
        pos.y = price;
        transform.position = pos;
        _trailRenderer.Clear();
    }

    internal void SetColor(float interest)
    {
        Color newCol;

        if (interest < 0)
        {
            newCol = Color.Lerp(settings.zeroColor, settings.lossColor, (Mathf.Abs(interest) / 100F));
        }
        else
        {
            newCol = Color.Lerp(settings.zeroColor, settings.profitColor, (Mathf.Abs(interest) / 100F));
        }
        
        _trailRenderer.material.color = newCol;
        _trailRenderer.startColor = newCol;
    }
}
