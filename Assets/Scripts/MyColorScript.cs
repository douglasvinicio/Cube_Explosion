using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColorScript : MonoBehaviour
{
    public GameObject plane;
    private MeshRenderer myRenderer;

    private void Start()
    {
        Debug.Log("We made it here!");
    }

    public void OnClickChangeColor()
    {
        myRenderer = plane.GetComponent<MeshRenderer>();
        myRenderer.enabled = !myRenderer.enabled;
        Debug.Log("Click button!");
    }
}
