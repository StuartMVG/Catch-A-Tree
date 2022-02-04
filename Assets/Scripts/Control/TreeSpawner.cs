using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace CatchTree.Control
{
    public class TreeSpawner : MonoBehaviour 
    {
      //Object variables
      [SerializeField] GameObject[] treePrefab;
      [SerializeField] Transform[] spawnPoints;
      private int rangeEnd;
      private Transform spawnPoint;
      [SerializeField] float spawnRangeStart = 0.5f;
      [SerializeField] float spawnRangeEnd = 1.2f;
      private float timeToSpawn;
      private float spawnTimer = 0f;
      private int playerScore = 0;
      private int randomTreeLevel = 0;

        private void OnEnable()
        {
            EventHandler.UpdateScoreEvent += AddScore;
            EventHandler.ResetGameEvent += ResetTrees;
        }
        private void OnDisable()
        {
            EventHandler.UpdateScoreEvent -= AddScore;
            EventHandler.ResetGameEvent -= ResetTrees;
        }

        private void Start()
        {
                rangeEnd = spawnPoints.Length - 1 ;
        }

        private void FixedUpdate()
        {
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            spawnTimer += 0.01f;
            if (spawnTimer >= timeToSpawn){
                    SpawnTree();
                    spawnTimer = 0f;
            }
        }

        private void AddScore(int scoreAmount)
        {
                playerScore += scoreAmount;
        }

        private void SpawnTree()
        {
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPoints[SPnum];
            TreeLevelPicker(spawnPoint);
        }

        private void TreeLevelPicker(Transform spawnPoint)
        {
            if (playerScore > 15)
            {
                randomTreeLevel = Random.Range(0, 3);
            }
            else if (playerScore <= 15 && playerScore > 10)
            {
                randomTreeLevel = Random.Range(0, 2);
            }
            else if (playerScore <= 10 && playerScore > 5)
            {
                randomTreeLevel = Random.Range(0, 1);
            }
            else 
            {
                randomTreeLevel = 0;
            }
            Instantiate(treePrefab[randomTreeLevel], spawnPoint.position, Quaternion.identity, spawnPoint);
        }

        private void ResetTrees()
        {
            playerScore = 0;
            randomTreeLevel = 0;
        }


    }
}