using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

	public Vector3 startPosition;

    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
		startPosition = transform.position;
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

	public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
		Launch();
    }
}