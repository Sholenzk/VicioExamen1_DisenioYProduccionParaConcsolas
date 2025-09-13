using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public LookDirection lookDirection;

    public Transform shootingPoint;
    public GameObject bullet;
    private float range = 6.5f;
    
    public void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootingPoint.position, transform.up, range);

        GameObject bullets = Instantiate(bullet, shootingPoint.position, Quaternion.identity);

        var bulletScript = bullets.GetComponent<Bullet>();

        if (hit.collider != null)
        {
            bulletScript.SetActualPosition(hit.point);
            var hittable = hit.collider.GetComponent<IHitable>();
            Debug.Log(hit.collider.name);
            if (hittable != null)
            { 
                hittable.ReceiveHit(hit);
            }
        }
        else
        {
            Vector3 endPosition = shootingPoint.position + transform.up * range;
            bulletScript.SetActualPosition(endPosition);
        }
    }
}
