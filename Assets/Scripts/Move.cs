using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    void Update()
    {
        var  position = transform.position;

        position.x += speed * Time.deltaTime;

        transform.position = position;
    }
}
