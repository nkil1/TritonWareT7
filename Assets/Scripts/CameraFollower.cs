using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    private Camera cam;
    public GameObject toFollow;
    public float viewportSize = 0.2f; //size the player can move in the screen before camera starts to follow
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        //Position of the player in the viewport
        Vector3 viewportPos=cam.WorldToViewportPoint(toFollow.transform.position);

        //clamped viewport position -- what it should be after the move.
        float min = 0.5f - viewportSize / 2.0f, max = 0.5f + viewportSize / 2.0f;
        Vector3 newViewportPos = new Vector3(Mathf.Clamp(viewportPos.x,min,max), Mathf.Clamp(viewportPos.y, min, max), viewportPos.z);

        Vector3 translationVector = toFollow.transform.position-cam.ViewportToWorldPoint(newViewportPos);
        Vector3 newCameraPos = cam.transform.position + translationVector;
        newCameraPos = new Vector3(newCameraPos.x, newCameraPos.y, cam.transform.position.z);
        cam.transform.position = newCameraPos; //could also do something like lerp(cam.transform.position,newCameraPos,dt);

        Debug.Log(cam.transform.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)));
    }
}
