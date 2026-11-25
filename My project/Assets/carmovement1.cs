using System.Threading;
using UnityEngine;
using UnityEngine.Splines;

public class carmovement1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed;
    //private Rigidbody rb;
    enum State { Start, Race,Racing, Finish}
    State state = State.Start;
    public bool start = false;
    private float timer = 3f;
    public float randomFloat2 = 0;
    public SplineContainer spline;
    public SplineContainer spline2;
    public float progress = 0f;
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
               
                Debug.Log(speed);
                Move(speed);
                if (transform.position.x >= 40f)
                {
                    state = State.Racing;

                }
                break;

            case State.Racing:
                
                if (randomFloat2 == 0)
                randomFloat2 = Random.Range(8.0f, 10.0f);
                speed = randomFloat2;
                SwitchSpline(spline2);
                Move(speed);
                Debug.Log(speed);
                if (transform.position.x >= 80f)
                {
                    state = State.Finish;

                }
                break;

            case State.Finish:
                //Debug.Log("Race has finished");
                speed = 0;
                break;

        }
    }

    void Move(float speed)
    {
        progress += (speed / spline.CalculateLength()) * Time.deltaTime;
        progress %= 1f;
        transform.position = spline.EvaluatePosition(progress);
    }

    void SwitchSpline(SplineContainer NewSpline)
    {
        spline = NewSpline;
    }
    

    void Startt()
    {
        start = true;
    }
}
