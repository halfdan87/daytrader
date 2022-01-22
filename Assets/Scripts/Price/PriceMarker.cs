using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PriceMarker : MonoBehaviour, IComparable<PriceMarker>
{
    public float Price
    {
        get => _price;
        set
        {
            _price = value;
            GetComponent<TextMeshProUGUI>().SetText(Price.ToString());
        }
    }

    private Vector3 pos;
    private float _price;

    [Inject]
    public void Construct(float price)
    {
        this.Price = price;
    }

    void Start()
    {
        pos = transform.localPosition;
    }

    void Update()
    {
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(new Vector3(0f, Price, 0f));
        pos.y = screenPoint.y;
        transform.position = pos;
    }
    
    public class Factory : PlaceholderFactory<UnityEngine.Object, float, PriceMarker> { }

    public int CompareTo(PriceMarker other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Price.CompareTo(other.Price);
    }
}
