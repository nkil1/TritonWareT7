using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Camera cam;
    public GameObject toFollow;
    public float viewportSize = 2f; //area the player can move in world coordinates before the camera moves
    public float followSpeed = 10.0f; //area the player can move in world coordinates before the camera moves

    void Start()
    {

    }

    void Update()
    {


        Vector3 camx = cam.transform.position;
        Vector3 f = cam.transform.forward;
        Vector3 current = camx-f*(camx.y/f.y); //position of the center of the screen projected to the (x,0,z) plane.

        Vector3 target = new Vector3(toFollow.transform.position.x, 0f, toFollow.transform.position.z);
        Vector3 targetClamped = new Vector3(
            Mathf.Clamp(target.x, current.x - viewportSize / 2.0f, current.x + viewportSize / 2.0f),
            0f,
            Mathf.Clamp(target.z, current.z - viewportSize / 2.0f, current.z + viewportSize / 2.0f));

        Vector3 translationVector = target - targetClamped;



        Vector3 newCameraPos = cam.transform.position + translationVector;
        cam.transform.position = Vector3.Lerp(cam.transform.position,newCameraPos,1.0f-Mathf.Exp(-followSpeed*Time.deltaTime));


        /*
        //Position of the player in the viewport
        Vector3 viewportPos=cam.WorldToViewportPoint(toFollow.transform.position);

        //clamped viewport position -- what it should be after the move.
        float min = 0.5f - viewportSize / 2.0f, max = 0.5f + viewportSize / 2.0f;
        Vector3 newViewportPos = new Vector3(Mathf.Clamp(viewportPos.x,min,max), Mathf.Clamp(viewportPos.y, min, max), viewportPos.z);

        Vector3 translationVector = toFollow.transform.position-cam.ViewportToWorldPoint(newViewportPos);
        Vector3 newCameraPos = cam.transform.position + translationVector;
        newCameraPos = new Vector3(newCameraPos.x, newCameraPos.y, cam.transform.position.z);
        cam.transform.position = newCameraPos; //could also do something like lerp(cam.transform.position,newCameraPos,dt);

        Debug.Log(cam.transform.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)));*/
    }
}
