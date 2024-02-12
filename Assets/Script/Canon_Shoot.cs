using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bullet;
    private float TimeBetween;
    public float StartTimeBetween;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeBetween < 0)
        {
            Instantiate(bullet,FirePoint.position,FirePoint.rotation);
            TimeBetween = StartTimeBetween;

        }
        else
        {
            TimeBetween -= Time.deltaTime;
        }
    }
}
