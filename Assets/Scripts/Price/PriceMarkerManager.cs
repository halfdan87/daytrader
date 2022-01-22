using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PriceMarkerManager : MonoBehaviour
{
    [Inject] private PriceMarker.Factory _factory;
    [Inject] private GameManager _gameManager;

    public int maxMarkersCount = 10;
    public GameObject textPrefab;
    private List<PriceMarker> markers = new List<PriceMarker>();

    private void Start()
    {
        var price = _gameManager.price;
        for (int i = -maxMarkersCount / 2; i < maxMarkersCount / 2; i++)
        {
            CreateMarker(price + i);
        }
    }

    private PriceMarker CreateMarker(float price)
    {
        PriceMarker marker = _factory.Create(textPrefab, price);
        marker.transform.SetParent(transform, false);
        markers.Add(marker);
        return marker;
    }

    private void Update()
    {
        var minMarker = markers.Min();
        var maxMarker = markers.Max();

        while (minMarker.Price > _gameManager.price - maxMarkersCount / 2 + 1)
        {
            maxMarker.Price = minMarker.Price - 1;
            minMarker = maxMarker;
            maxMarker = markers.Max();
        }
        while (maxMarker.Price < _gameManager.price + maxMarkersCount / 2 - 1)
        {
            minMarker.Price = maxMarker.Price + 1;
            maxMarker = minMarker;
            minMarker = markers.Min();
        }
        //
        // markers.RemoveAll(it =>
        // {
        //     if (it.Price < _gameManager.price - maxMarkersCount / 2 ||
        //         it.Price > _gameManager.price + maxMarkersCount / 2)
        //     {
        //         Destroy(it.gameObject);
        //         return true;
        //     }
        //
        //     return false;
        // });

    }
}
