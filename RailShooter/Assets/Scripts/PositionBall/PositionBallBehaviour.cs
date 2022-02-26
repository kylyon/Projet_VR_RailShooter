using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBallBehaviour : MonoBehaviour
{
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.Get)
    }

    void Grow()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
    
    void Shrink()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
