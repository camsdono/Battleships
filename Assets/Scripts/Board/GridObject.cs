using System;
using UnityEngine;

namespace Board
{
    public class GridObject : MonoBehaviour
    {
        public int GridID;
        public bool isShip;
        public bool isHit, isMiss;
        private SpriteRenderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void ChangeTileColor(Color changeColor)
        {
            _renderer.color = changeColor;
        }
    }
}