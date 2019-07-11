using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

    private Rigidbody2D rb;
    private SpringJoint2D springJoint;

    public GameObject slingshot;
    private SlingshotScript slingshotScript;

    public float letGoDelay = .15f;
    public float maxDrag = 1f;
    public float cameraOffset = .92f;


    public bool isDragged = false;
    public bool isFiring = false;

    public bool watchKiniematic = false;

    public Vector3 beforeFiringPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slingshotScript = slingshot.GetComponent<SlingshotScript>();
        springJoint = GetComponent<SpringJoint2D>();
    }

    void Update()
    {
        watchKiniematic = rb.isKinematic;

        if (isDragged && !isFiring)
        {
            beforeFiringPosition = this.transform.position;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, slingshot.transform.position) > maxDrag) {
                rb.position = (Vector2)slingshot.transform.position + (mousePos - (Vector2)slingshot.transform.position).normalized * maxDrag;
            } else { 
                rb.position = mousePos;
            }
        }

        if (rb.velocity == Vector2.zero && isFiring)
        {
            Debug.Log("chicken stopped");

            Camera.main.transform.position += this.transform.position - beforeFiringPosition;

            isFiring = false;

            rb.position += Vector2.up * 1;

            slingshotScript.setNewPosition(rb.position);
        }

        if (!isFiring)
        {
            springJoint.enabled = true;
        }
    }

    void OnMouseDown ()
    {

        rb.isKinematic = true;
        isDragged = true;
    }

    void OnMouseUp()
    {

        isFiring = true;
        rb.isKinematic = false;

        isDragged = false;
        StartCoroutine(LetGo());
    }
     IEnumerator LetGo ()
    {
        yield return new WaitForSeconds(letGoDelay);
        springJoint.enabled = false;
    }


}
