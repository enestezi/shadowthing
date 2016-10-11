using UnityEngine;
using System.Collections;

public class DragRigidbody2D : MonoBehaviour
{
    public float distance = 0.5f;
    public float damper = 1.0f; 
    public float frequency = 1000000.0f;
    public float drag = 1.0f;
    public float angularDrag = 5.0f;

    private SpringJoint2D springJoint;

    void Update()
    {
        //
        // If the player did not press the mouse button down, do not run
        // through Update().
        //
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Camera camera = FindCamera();
        RaycastHit2D hit = Physics2D.Raycast(
                camera.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero);

        if (hit.collider == null || !hit.rigidbody || hit.rigidbody.isKinematic)
        {
            return;
        }

        if (hit.collider != null || hit.rigidbody || !hit.rigidbody.isKinematic) 
            {
                if (!springJoint)
                {
                    GameObject obj = new GameObject("Rigidbody2D dragger");
                    Rigidbody2D body = obj.AddComponent<Rigidbody2D>() as Rigidbody2D;
                    this.springJoint = obj.AddComponent<SpringJoint2D>() as SpringJoint2D;
                    body.isKinematic = true;
                }
            }

        springJoint.distance = distance;
        springJoint.dampingRatio = damper;
        springJoint.frequency = frequency;
        springJoint.autoConfigureDistance = false;
        springJoint.connectedBody = hit.rigidbody;


        StartCoroutine("DragObject", hit.fraction);
        
    }

    IEnumerator DragObject(float d)
    {

        float oldDrag = springJoint.connectedBody.drag;
        float oldAngularDrag = springJoint.connectedBody.angularDrag;

        springJoint.connectedBody.drag = drag;
        springJoint.connectedBody.angularDrag = angularDrag;

        Camera mainCamera = FindCamera();

        while (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            springJoint.transform.position = ray.GetPoint(d);
            yield return null;
        }



        if (springJoint.connectedBody)
        {
            springJoint.connectedBody.drag = oldDrag;
            springJoint.connectedBody.angularDrag = oldAngularDrag;
            springJoint.connectedBody = null;
        }

    }

    Camera FindCamera()
    {
        if (GetComponent<Camera>())
        {
            return GetComponent<Camera>();
        }
        else
        {
            return Camera.main;
        }
    }
}