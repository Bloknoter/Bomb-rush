using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Character character;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            character.MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            character.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            character.Jump();
        }
    }
}
