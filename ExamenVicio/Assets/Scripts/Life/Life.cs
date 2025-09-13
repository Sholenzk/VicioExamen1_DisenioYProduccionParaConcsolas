using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour, IHitable
{
    [SerializeField] private int life;

    public void GetDamaged()
    {
        life -= 1;
        if (life <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    public void ReceiveHit(RaycastHit2D hit)
    {
        GetDamaged();
    }
}
