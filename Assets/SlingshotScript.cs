using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotScript : MonoBehaviour {

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if (rb.constraints == RigidbodyConstraints2D.None)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void setNewPosition(Vector2 pos)
    {
        rb.constraints = RigidbodyConstraints2D.None;

        rb.position = pos;
    }
}
