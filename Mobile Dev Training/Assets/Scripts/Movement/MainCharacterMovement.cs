using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    //variables
    public float moveSpeed = 300;
    public GameObject character;

    public Rigidbody characterBody;
    private float ScreenWidth;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<GameObject>();
        ScreenWidth = Screen.width;
        characterBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right
                RunCharacter(1.0f);
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                RunCharacter(-1.0f);
            }
            ++i;
        }
    }

    private void RunCharacter(float horizontalInput)
    {
        //move player
        Vector3 new_vector = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0,0);
        characterBody.AddForce(new_vector);
    }

    void FixedUpdate()
    {
        #if UNITY_EDITOR
		RunCharacter(Input.GetAxis("Horizontal"));
        #endif
    }


}
