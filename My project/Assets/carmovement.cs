using System.Threading;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed;
    //private Rigidbody rb;
    enum State { Start, Race,Racing, Finish}
    State state = State.Start;
    public bool start = false;
    private float timer = 3f;
    public float randomFloat2 = 0;

    void Start()
    {
        float randomFloat = Random.Range(8.0f, 10.0f);
        //rb = GetComponent<Rigidbody>(); 
        speed = randomFloat;
        //Invoke("Startt", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(transform.position.x < 80f)
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);

        //}
        switch (state)
        {
            case State.Start:
                timer -= Time.deltaTime;
                //Debug.Log(timer);
                if (timer <= 0f)
                {
                    Debug.Log("timer finished");
                    state = State.Race;
                    break;
                }
                break;
            case State.Race:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (transform.position.x >= 40f)
                {
                    state = State.Racing;

                }
                break;

            case State.Racing:
                
                if (randomFloat2 == 0)
                randomFloat2 = Random.Range(8.0f, 10.0f);
                speed = randomFloat2;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                Debug.Log(speed);
                if (transform.position.x >= 80f)
                {
                    state = State.Finish;

                }
                break;

            case State.Finish:
                Debug.Log("Race has finished");
                speed = 0;
                break;
                    


        }
    }

    

    void Startt()
    {
        start = true;
    }
}
