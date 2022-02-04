using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatchTree.Control
{
    public class BottomBoundryControl : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "tree")
            {
                EventHandler.CallMissedTreeEvent();
                Destroy(other.gameObject);
                Debug.Log("Missed A Tree!!!");
            }
        }
    }
}
