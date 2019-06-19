using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    float zAngle = 0;
    float xVelocity = 0.0f;
    float x;

    void Start()
    {
        xVelocity = Random.Range(0.05f, 0.025f);
        x = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        zAngle += Time.deltaTime * 25.0f;

        if (zAngle > 360.0f)
        {
            zAngle = 0.0f;
        }

        transform.localRotation = Quaternion.Euler(0, 0, zAngle);

        x -= xVelocity;

        transform.position = new Vector3(x, transform.position.y);
    }
}
