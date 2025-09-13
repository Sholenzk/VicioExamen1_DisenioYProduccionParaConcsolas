using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPoint;

    private float actualPosition;
    private float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.WithAxis(Axis.z, -1);
    }

    // Update is called once per frame
    void Update()
    {
        actualPosition = Time.deltaTime * speed;
        actualPosition = Mathf.Clamp01(actualPosition);
        transform.position = Vector3.Lerp(startPosition, endPoint, actualPosition);
    }

    public void SetActualPosition(Vector3 targetPosition)
    {
        endPoint = targetPosition.WithAxis(Axis.z, -1);
    }
}
