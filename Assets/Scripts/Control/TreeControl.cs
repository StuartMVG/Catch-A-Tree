using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatchTree.Control
{
    public class TreeControl : MonoBehaviour
    {
        public GameObject hitVFX;
        // Start is called before the first frame update
        void Start()
        {
            
        }
        private void OnEnable()
        {
            EventHandler.CaughtTreeEvent += treeCaught;
        }

        private void OnDisable()
        {
            EventHandler.CaughtTreeEvent -= treeCaught;
        }

        private void treeCaught (GameObject tree)
        {
            gameObject.GetComponent<AudioSource>().Play();
            GameObject boomFX = Instantiate(hitVFX, tree.transform.position, Quaternion.identity);
            StartCoroutine(DestroyVFX(boomFX));
            Destroy(tree);
        }

        IEnumerator DestroyVFX(GameObject theEffect)
        {
            yield return new WaitForSeconds(0.6f);
            gameObject.GetComponent<AudioSource>().Stop();
            Destroy(theEffect);
        }


    }
}
