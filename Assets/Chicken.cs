using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

    public Rigidbody2D rb;
    public Rigidbody2D slingshot;
    private bool isDragged= false;
    public float letGoDelay = .15f;
    public float maxDrag = 1f;


    void Update()
    {
        if (isDragged)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, slingshot.position) > maxDrag)
                rb.position = slingshot.position + (mousePos - slingshot.position).normalized * maxDrag;
            else
                rb.position = mousePos;
        }
    }

    void OnMouseDown ()
    {
        isDragged = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isDragged = false;
        rb.isKinematic = false;
        StartCoroutine(LetGo());
    }
     IEnumerator LetGo ()
    {
        yield return new WaitForSeconds(letGoDelay);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
    }


}
