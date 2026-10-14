using UnityEngine;

public class carmovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed;
    //private Rigidbody rb;
    void Start()
    {
        float randomFloat = Random.Range(8.0f, 10.0f);
        //rb = GetComponent<Rigidbody>(); 
        speed = randomFloat;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 80f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
    }
}
