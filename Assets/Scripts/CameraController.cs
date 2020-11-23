using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float bounds;
    public GameObject p1;
    public GameObject p2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = (p1.transform.position + p2.transform.position) * .5f;
        camPos = new Vector3(camPos.x, camPos.y + 1f, -10f);
        transform.position = camPos;
    }
}
