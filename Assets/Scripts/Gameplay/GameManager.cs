using System;
using Board;
using UnityEngine;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private Color defaultColorTile;
        public int CurrentTileIndex = -1;
        public GridObject[] tileObjects;
        
        private void Start()
        {
            tileObjects = FindObjectsOfType<GridObject>();
            defaultColorTile = FindObjectOfType<GenerateBoard>().gridColor;
        }

        private void Update()
        {
            GridClickDetection();
        }
    
        void GridClickDetection()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
                if (hit.collider != null)
                {
                    for (int i = 0; i < tileObjects.Length; i++)
                    {
                        if (tileObjects[i].GridID != CurrentTileIndex)
                        {
                            if (!tileObjects[i].isHit && !tileObjects[i].isMiss)
                            {
                                tileObjects[i].ChangeTileColor(defaultColorTile);
                            }
                            CurrentTileIndex = -1;
                        }
                    }
                    
                    if (hit.collider.GetComponent<ClickableObject>() != null)
                    {
                        if (hit.collider.GetComponent<ClickableObject>().ObjectName == "GridTile")
                        {
                            if (!hit.collider.GetComponent<GridObject>().isHit && !hit.collider.GetComponent<GridObject>().isMiss)
                            {
                                CurrentTileIndex = hit.collider.GetComponent<GridObject>().GridID;
                                hit.collider.GetComponent<SpriteRenderer>().color = Color.gray; 
                            }
                        }
                    }
                }
            }
        }
    }
}