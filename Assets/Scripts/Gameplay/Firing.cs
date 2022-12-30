using Board;
using UnityEngine;

namespace Gameplay
{
    public class Firing : MonoBehaviour
    {
        public void OnFiring(GridObject[] tileObjects, int tileIndex) 
        {
            for (int i = 0; i < tileObjects.Length; i++)
            {
                if (tileObjects[i].GridID == tileIndex)
                {
                    if (tileObjects[i].isShip)
                    {
                        tileObjects[i].ChangeTileColor(Color.red);
                        tileObjects[i].isHit = true;
                    }
                    else
                    {
                        tileObjects[i].ChangeTileColor(Color.white);
                        tileObjects[i].isMiss = true;
                    }
                }
            }
        }
    }
}