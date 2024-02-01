using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class hook : MonoBehaviour
{
    public  Transform arrowTransform;
    
    private bool isRotating = true;
    private float rotationSpeed = 30f;
    public static float moveSpeed = 1f;
    private float maxRotation = 45f;
    private float t = 0;
    
    public static float maxDistance = 1f;
    private bool isMovingDown = true;
    private bool bar = false;
    private Quaternion initialRotation;

    public GameObject _maxDistance;
    public GameObject _moveSpeed;
    public GameObject partical;

    private Vector3 pos;

    public AudioSource _audio;
    public GameObject MenuPanel;

    void Start()
    {

        initialRotation = arrowTransform.rotation;

        maxDistance = PlayerPrefs.GetFloat("maxDistance", maxDistance);
        moveSpeed = PlayerPrefs.GetFloat("moveSpeed", moveSpeed);
    }

    void Update()
    {
        t = t + Time.deltaTime;
        if (t >= 3)
        {
            FindDel();
            t = 0;
        }
        if (Fish.particalBool)
        {
            Instantiate(partical, pos, Quaternion.identity);
            Fish.particalBool = false;
            _audio.Play();
        }
        pos = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        bar = barrer.barrers;
        
        if (maxDistance >= 6f)
        {
            _maxDistance.SetActive(true);
        }
        if (moveSpeed>= 5f)
        {
            _moveSpeed.SetActive(true);
        }

        PlayerPrefs.SetFloat("maxDistance", maxDistance);
        PlayerPrefs.SetFloat("moveSpeed", moveSpeed);
        if (MenuPanel.activeSelf == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isRotating = false;
            }
        }
        

        if (isRotating)
        {
            float currentRotation = arrowTransform.rotation.eulerAngles.z;
            if (currentRotation < maxRotation || currentRotation > 360 - maxRotation)
            {
                arrowTransform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
            }
            else
            {
                rotationSpeed *= -1;
                arrowTransform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
            }
        }
        else
        {
            if (isMovingDown && !bar)
            {
                if (arrowTransform.position.y > -maxDistance)
                {
                    arrowTransform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
                }
                else
                {
                    isMovingDown = false;
                }
            }
            else
            {
                if (arrowTransform.position.y < initialRotation.y) 
                {
                    arrowTransform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                }
                else
                {
                    isMovingDown = true;
                    isRotating = true;
                    arrowTransform.rotation = initialRotation; 
                }
            }
        }

        
    }

    void FindDel()
    {
        GameObject[] game_oblect = GameObject.FindGameObjectsWithTag("partical");
        foreach (GameObject element in game_oblect)
        {
            Destroy(element);
        }
    }
}
