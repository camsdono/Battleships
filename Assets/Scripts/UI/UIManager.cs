using System;
using Board;
using Gameplay;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        private GameManager manager;
        private Firing firing;
        public int tileIndex;

        private void Start()
        {
            manager = FindObjectOfType<GameManager>();
            firing = gameObject.AddComponent<Firing>();
        }

        private void Update()
        {
            tileIndex = manager.CurrentTileIndex;
        }

        public void FireButton()
        {
            firing.OnFiring(manager.tileObjects, tileIndex);
        }
    }
}