using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Inject] private GameManager.Settings settings;

    private void Start()
    {
        var targetPos = target.position;

        targetPos.y = target.position.y;
        targetPos.z = transform.position.z;

        transform.position = targetPos;
    }

    void Update()
    {
        var targetPos = target.position;

        targetPos.y = Mathf.Lerp(transform.position.y, target.position.y, settings.followSpeed * Time.deltaTime);
        targetPos.z = transform.position.z;

        transform.position = targetPos;
    }
}
