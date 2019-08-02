using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
     
     public float speed;
     public float speedy;
     

     private Rigidbody rb;

     void Start()
     {
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
     }
     void Update()
     {
           if (Input.GetKeyDown (KeyCode.H))
            {
               SceneManager.LoadScene("Main");
               speed = speed * -100;
               
            }
          
     }
     
}