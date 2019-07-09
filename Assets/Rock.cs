using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    Rigidbody rocketRB;
    [SerializeField] AudioClip mainEngine;
    AudioSource audioSource;

    [SerializeField] float thrustSpeed;
    [SerializeField] float RotationSpeed;
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Rotate();
        Thrust();
    }

    // Update is called once per frame
    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRB.AddRelativeForce(Vector3.up * thrustSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRB.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
       else
        {
            audioSource.Stop();
        }
    }

    void Rotate()
    {
        rocketRB.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * RotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * RotationSpeed);
        }
        rocketRB.freezeRotation = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) {
            case "Friendly":
                print("Your Okay");
                break;
            case "Finish":
                print("You Win");
                break;
            case "Deathly":
                print("YOU Dead");
                break;
        }
    }







}