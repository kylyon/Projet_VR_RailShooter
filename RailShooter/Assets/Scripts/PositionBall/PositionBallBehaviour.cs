using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBallBehaviour : MonoBehaviour
{
    public Transform transform;

    private bool looked;
    // Start is called before the first frame update
    void Start()
    {
        looked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (looked)
        {
            Grow();
        }
        else
        {
            Shrink();
        }
    }

    public void Looked()
    {
        looked = true;
    }

    public void NotLooked()
    {
        looked = false;
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
