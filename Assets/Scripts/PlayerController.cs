using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player1, player2;

    private float inputPlayer1, inputPlayer2;

    public float speed, force;

    void Start()
    {
        
    }

    private void Update()
    {
        inputPlayer1 = Input.GetAxis("Player1 Movement");
        inputPlayer2 = Input.GetAxis("Player2 Movement");

        if (Input.GetButtonDown("Player1 Splash"))
            player1.Splash(force);

        if (Input.GetButtonDown("Player2 Splash"))
            player2.Splash(force);
    }

    private void FixedUpdate()
    {
        player1.Move(inputPlayer1 * speed * Time.fixedDeltaTime);
        player2.Move(inputPlayer2 * speed * Time.fixedDeltaTime);
    }
}
