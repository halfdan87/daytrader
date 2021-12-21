using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Follow : MonoBehaviour
{
    public Transform target;
    [Inject] private GameManager.Settings settings;
    void Update()
    {
        var targetPos = target.position;
        
        targetPos.y = Mathf.Lerp(transform.position.y, target.position.y, settings.followSpeed * Time.deltaTime);
        targetPos.z = transform.position.z;

        transform.position = targetPos;
    }
}
