using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatchTree.Control
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float timeMax = 30f;
        [SerializeField] float timePercentageBonus = 5f;
        [SerializeField] float timePercentagePenalty = 30f;
        [SerializeField] GameObject gameRestartButton;
        private GameObject[] allTrees;
        private float gameTime;
        //private float gameTimer = 0f;
        private bool isGameOver = false;

        private void Start() 
        {
            gameTime = timeMax;
            gameRestartButton.SetActive(false);
        }
        private void OnEnable()
        {
            EventHandler.CaughtTreeEvent += CaughtATreeBonus;
            EventHandler.MissedTreeEvent += MissedATreePenalty;
            EventHandler.ResetGameEvent += ResetGame;
        }

        private void OnDisable()
        {
            EventHandler.CaughtTreeEvent -= CaughtATreeBonus;
            EventHandler.MissedTreeEvent -= MissedATreePenalty;
            EventHandler.ResetGameEvent -= ResetGame;
        }

        private void Update() 
        {
            EventHandler.CallUpdateTimerEvent(gameTime, timeMax);
            
            if(isGameOver)
            {
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                //StartCoroutine(StartAudioFade(audioSource, 1.5f, 0f));
                gameRestartButton.SetActive(true);
                gameObject.GetComponent<AudioSource>().Stop();
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public static IEnumerator StartAudioFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }

        private void FixedUpdate()
        {
            countDown();
        }

        private void countDown()
        {
            if (gameTime > 0)
            {
                gameTime -= Time.deltaTime;
            }
            else
            { 
                isGameOver = true;
                Debug.Log("GameOver");
            }

            // gameTimer += 0.01f;
            // if (gameTimer >= 1f)
            // {
            //     gameTime -= 1;
            //     gameTimer = 0;
            // }
            // if (gameTime <= 0){
            //     gameTime = 0;
            //     //gameOverText.SetActive(true);
            // }
        }

        private void CaughtATreeBonus(GameObject tree)
        {
            gameTime += (timePercentageBonus/100) * timeMax;
            gameTime = Mathf.Min(gameTime, timeMax);
        }

        private void MissedATreePenalty()
        {
            gameTime -= (timePercentagePenalty/100) * timeMax;
            gameTime = Mathf.Max(gameTime, 0);
        }

        private void ResetGame()
        {
            ResetAllTrees();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            gameTime = timeMax;
            gameRestartButton.SetActive(false);
            audioSource.volume = 1f;
            audioSource.Play();

            isGameOver = false;
            Time.timeScale = 1;
        }


        private void ResetAllTrees()
        {
            if (allTrees == null)
            {
                allTrees = GameObject.FindGameObjectsWithTag("tree");
            }

            foreach (GameObject tree in allTrees)
            {
                Destroy(tree);
            }
        }
    }
}
