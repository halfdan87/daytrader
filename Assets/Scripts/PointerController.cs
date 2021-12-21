using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    private TrailRenderer _trailRenderer;
    
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
            newCol = new Color((Mathf.Abs(interest) / 100F) * 255, 0F, 0F);
        }
        else
        {
            newCol = new Color(0F, (Mathf.Abs(interest) / 100F) * 255, 0F);
        }
        
        _trailRenderer.material.color = newCol;
    }
}
