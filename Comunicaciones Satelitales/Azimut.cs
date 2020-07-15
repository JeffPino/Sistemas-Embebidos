using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azimut : MonoBehaviour
{
    public float angulo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.down, angulo);
    }
}
