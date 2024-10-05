using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public bool zoomedIn = false;
    public AnimationCurve zoomCurve;
    public float zoomDuration = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // get mouse position on screen
        Vector3 mousePos = Input.mousePosition;

        // if mouse is at the left edge of the screen
        if (mousePos.x < 10 || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        
        {
            // move the camera left
            transform.position += new Vector3(-0.1f, 0, 0.1f);
        }
        // if mouse is at the right edge of the screen
        if (mousePos.x > Screen.width - 10 || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        
        {
            // move the camera right
            transform.position += new Vector3(0.1f, 0, -0.1f);
        }
        // if mouse is at the top edge of the screen
        if (mousePos.y > Screen.height - 10 || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        
        
        {
            // move the camera up
            transform.position += new Vector3(0.1f, 0, 0.1f);
        }
        // if mouse is at the bottom edge of the screen
        if (mousePos.y < 10 || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        
        
        {
            // move the camera down
            transform.position += new Vector3(-0.1f, 0, -0.1f);
        }

        // if right mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // toggle zoom
            zoomedIn = true;
            StartCoroutine(Zoom(true));
        }

        // zoom out on right mouse button up
        if (Input.GetMouseButtonUp(0))
        {
            zoomedIn = false;
            StartCoroutine(Zoom(false));
        }
    }

    IEnumerator Zoom(bool isZoomingIn){

        float target = isZoomingIn ? 2 : 5;
        float start = Camera.main.orthographicSize;
        float timer = 0;

        while(timer < zoomDuration){
            Camera.main.orthographicSize = Mathf.Lerp(start, target, zoomCurve.Evaluate(timer/zoomDuration));
            timer += Time.deltaTime;
            yield return null;
        }

        Camera.main.orthographicSize = target;
    }
}
