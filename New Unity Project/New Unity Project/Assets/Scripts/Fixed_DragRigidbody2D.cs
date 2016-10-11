using UnityEngine;
using System.Collections;

public class Fixed_DragRigidbody2D : MonoBehaviour
{

    public float frequency = 0f;
    public float drag = 1.0f;
    public float angularDrag = 5.0f;

    private TargetJoint2D fixedJoint;

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
            if (!fixedJoint)
            {
                GameObject obj = new GameObject("Rigidbody2D dragger");
                Rigidbody2D body = obj.AddComponent<Rigidbody2D>() as Rigidbody2D;
                this.fixedJoint = obj.AddComponent<TargetJoint2D>() as TargetJoint2D;
                body.isKinematic = true;
            }
        }

        fixedJoint.connectedBody = hit.rigidbody;


        StartCoroutine("DragObject", hit.fraction);

    }

    IEnumerator DragObject(float d)
    {

        float oldDrag = fixedJoint.connectedBody.drag;
        float oldAngularDrag = fixedJoint.connectedBody.angularDrag;

        fixedJoint.connectedBody.drag = drag;
        fixedJoint.connectedBody.angularDrag = angularDrag;

        Camera mainCamera = FindCamera();

        while (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            fixedJoint.transform.position = ray.GetPoint(d);
            yield return null;
        }



        if (fixedJoint.connectedBody)
        {
            fixedJoint.connectedBody.drag = oldDrag;
            fixedJoint.connectedBody.angularDrag = oldAngularDrag;
            fixedJoint.connectedBody = null;
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