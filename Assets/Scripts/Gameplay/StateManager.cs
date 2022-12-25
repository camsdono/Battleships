using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Gameplay
{
    public class StateManager : MonoBehaviour
    {
        public States state;
        private bool player1Start, player2Start;
        private bool player1Turn, player2Turn;
        private bool paused;

        private void Start()
        {
            int rand = Random.Range(0, 3);
            while (rand < 1 || rand > 2)
            {
                rand = Random.Range(0, 3);
            }
            
            if (rand == 1)
            {
                player1Start = true;
            }
            if(rand == 2)
            {
                player2Start = true;
                Debug.Log("Player 2 start");
            }
        }

        void GameStart()
        {
            if (player1Start)
            {
                state = States.PLAYER1TURN;
                player1Turn = true;
                player2Turn = false;
            }

            if (player2Start)
            {
                state = States.PLAYER2TURN;
                player1Turn = false;
                player2Turn = true;
            }
        }

        void GamePause()
        {
            state = States.PAUSED;
            paused = true;
            
            while (paused)
            {
                return;
            }

            if (player1Turn)
                state = States.PLAYER1TURN;
            if (player2Turn)
                state = States.PLAYER2TURN;
        }

        void UpdateState()
        {
            if (state == States.PLAYER1TURN)
            {
                state = States.PLAYER2TURN;
                player1Turn = false;
                player2Turn = true;
            }

            if (state == States.PLAYER2TURN)
            {
                state = States.PLAYER1TURN;
                player1Turn = true;
                player2Turn = false;
            }
        }
    }
}