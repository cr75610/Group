using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class cursorpressed : MonoBehaviour
{
    private float timer;
    // private bool m_change;
    // private bool m_notdown;
    //debug varible
    private bool m_debug_timer;

    private bool m_resettimer;
    public GameObject[] m_gameobject;
    private bool m_ray_hit;
    private string m_hitstring;
    private bool m_reset_colour;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        m_debug_timer = false;
        m_resettimer = false;
        m_ray_hit = false;
        m_reset_colour = false;
    }

    void ChangeColour()
    {
        foreach (GameObject go in m_gameobject)
        {
            if (m_ray_hit)
            {               
                if (timer > 0 && timer < 3.0)
                {
                    if (go.name == m_hitstring)
                        go.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else
                {
                    if (go.name == m_hitstring)
                        go.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
            }
        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!m_ray_hit)
            {
                m_resettimer = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction, Color.green, 0.5f);
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    m_hitstring = hit.transform.name;
                    Debug.Log(hit.transform.name);
                    Debug.Log("hit");
                    Debug.Log(Input.mousePosition.x);
                    Debug.Log(Input.mousePosition.y);
                    m_ray_hit = true;
<<<<<<< HEAD

                    

=======
<<<<<<< Updated upstream
                    m_reset_colour = true;
=======
>>>>>>> parent of da97bba (Merge branch 'main' into Liam-Branch)

                    if (hit.collider.CompareTag("Clickable"))
                    {
                        //get the game object and send a message to the gameobject
                        m_gameObject = GameObject.Find(m_hitstring);
                        m_gameObject.transform.SendMessage("Testvoid");
                    }
                    else if (hit.collider.CompareTag("Popped"))
                    {
                        m_gameObject = GameObject.Find(m_hitstring);
                    }

>>>>>>> Stashed changes
                }
                else
                {
                    m_ray_hit = false;
                    Debug.Log("no hit");
                }
            }
           
        }
        
        if (Input.GetButton("Fire1"))
        {
            timer += Time.deltaTime;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (!m_resettimer)
            {
                timer = 0;
                m_resettimer = true;
                m_ray_hit = false;
            }
        }
        if (timer >= 3.0)
        {
            if (!m_debug_timer)
            {
                Debug.Log("timer has passed 3 seconds");
                m_debug_timer = true;
            }
            
            
        }


        //switch colour back to white

        if (timer == 0&& m_reset_colour)
        {
            foreach (GameObject go in m_gameobject)
            {
                if (go.GetComponent<MeshRenderer>().material.color != Color.white)
                {
                    go.GetComponent<MeshRenderer>().material.color = Color.white;
                }
            }
            m_reset_colour = false;
        }

        ChangeColour();
        
    }
}


*/

public class cursorpressed : MonoBehaviour
{
    private player m_player;
    //timers
    private float timer;
    // private bool m_change;
    // private bool m_notdown;
    //debug varible
    //bools
    private bool m_debug_timer;

    private bool m_resettimer;

    //public GameObject[] m_gameobject;
    private bool m_ray_hit;
    //string for the gameobject
    private string m_hitstring;


    //the private gameobject
    private GameObject m_gameObject;

    // Start is called before the first frame update
    void Start()
    {
        //setting up the varibles
        timer = 0;

        m_debug_timer = false;
        m_resettimer = false;
        m_ray_hit = false;

    }

    void ChangeColour()
    {
        m_player = GameObject.FindGameObjectWithTag("PLayerController").GetComponent<player>();
    }



    // Update is called once per frame
    void Update()
    {
        //ray from the mouse initial press
        if (Input.GetButtonDown("Fire1"))
        {

            if (!m_ray_hit)
            {
                //reseting the timer
                m_resettimer = false;
                //ray from the mouse position to the point in screen space
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //the resulting hit from the ray
                RaycastHit hit;
                //should draw the ray on screen it doesn't but oh well
                Debug.DrawRay(ray.origin, ray.direction, Color.green, 0.5f);
                //if there is a hit from the ray cast
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    //get the strign name of the gameobject
                    m_hitstring = hit.transform.name;
                    //debug log of the ray for testing
                    Debug.Log(hit.transform.name);
                    Debug.Log("hit");
                    Debug.Log(Input.mousePosition.x);
                    Debug.Log(Input.mousePosition.y);
                    //bools for the hit result
                    m_ray_hit = true;






                    if (hit.collider.CompareTag("Clickable"))
                    {

                        m_gameObject = GameObject.Find(m_hitstring);
                        Debug.Log(m_gameObject);
                        m_gameObject.SendMessage("Testvoid");
                    }
                    else if (hit.collider.CompareTag("Popped"))
                    {
                        m_gameObject = GameObject.Find(m_hitstring);
                        Debug.Log(m_gameObject);
                    }
                    else
                    {
                        m_ray_hit = false;
                    }

                }
                //no hit
                else
                {
                    m_ray_hit = false;
                }


            }
        }
            //if the button is still down
            if (Input.GetButton("Fire1"))
            {
                //timer increases
                timer += Time.deltaTime;
            }
            //when the button isn't pressed any more
            if (Input.GetButtonUp("Fire1"))
            {
            Debug.Log(m_gameObject);
                //allow the screen to be tapped again
                if (!m_resettimer)
                {
                    if (m_gameObject && m_gameObject.CompareTag("Popped"))
                    {
                        m_gameObject.SendMessage("TimerSetting", timer);
                        Debug.Log("has this happened");
                        m_player.CreateButtons(m_gameObject);
                    }
                    timer = 0;
                    m_resettimer = true;
                    m_ray_hit = false;
                   // Debug.Log("whats wrong with you");
                }
              //  Debug.Log("whats wrong with you");

            }
            //if the timer is after 3
            if (timer >= 3.0)
            {
                //debug for the holdign of the object
                if (!m_debug_timer)
                {
                    Debug.Log("timer has passed 3 seconds");
                    m_debug_timer = true;

                    if (m_gameObject)
                    {
                        m_gameObject.SendMessage("TimerSetting", timer);
                    }
                }
            }


            //switch colour back to white



            if (m_gameObject)
            {

                if (m_gameObject == null)
                {
                    m_gameObject = null;
                }

            }
       
        if (m_player == null)
        {
            ChangeColour();
        }
        
            //change the colour of the object for testing purposes
            // ChangeColour();

        
    }
}