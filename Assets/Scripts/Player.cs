using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public float velocity = 2.4f;
    private Rigidbody rigidbody;
    public int Score;
    public GameObject scoretxt;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rigidbody.velocity = Vector2.up * velocity;
        }
        if (transform.position.y <= -4.5)
        {
            SceneManager.LoadScene(1);
        }
            
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(1);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "score")
        {
            Score++;
            scoretxt.GetComponent<Text>().text = "SCORE : " + Score;
        }
    }
}
