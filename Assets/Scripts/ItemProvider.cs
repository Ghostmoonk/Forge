﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatternDifficulty
{
    EASY, NORMAL, HARD
}

public class ItemProvider : MonoBehaviour
{
    bool hasCalledEndgame;

    public int maxItemsInQueue;
    public int totalItemsInLevel;
    public int remainingItemsInLevel;
    [SerializeField] GameObject[] easyPatternPrefabs;
    [SerializeField] GameObject[] normalPatternPrefabs;
    [SerializeField] GameObject[] hardPatternPrefabs;

    [SerializeField] Transform spawnPosition;
    GameObject itemsContainer;

    [SerializeField] float offsetBetweenItems;

    private void Start()
    {
        hasCalledEndgame = false;
        itemsContainer = GameObject.FindGameObjectWithTag("ItemContainer");
        remainingItemsInLevel = totalItemsInLevel - itemsContainer.transform.childCount;
    }

    private void Update()
    {
        if (itemsContainer.transform.childCount > 0)
        {
            if (Mathf.Abs(spawnPosition.transform.position.x - itemsContainer.transform.GetChild(itemsContainer.transform.childCount - 1).transform.position.x) > offsetBetweenItems)
            {
                if (remainingItemsInLevel > 0)
                {
                    //Debug.Log("I must intantiate !");
                    InstantiateItem(PickRandomDifficulty());
                    remainingItemsInLevel--;
                }
            }
        }
        else
        {
            if (itemsContainer.transform.childCount == 0 && !hasCalledEndgame)
            {
                Debug.Log("EndGame");
                hasCalledEndgame = true;
                _MGR_GameManager.Instance.EndGame();
            }
        }
    }

    private PatternDifficulty PickRandomDifficulty()
    {
        int randomPick = Random.Range(0, 100);
        if (remainingItemsInLevel > totalItemsInLevel * 2 / 3)
        {
            if (randomPick < 70)
            {
                return PatternDifficulty.EASY;
            }
            else if (randomPick < 90)
            {
                return PatternDifficulty.NORMAL;
            }
            else
            {
                return PatternDifficulty.HARD;
            }
        }
        else if (remainingItemsInLevel > totalItemsInLevel * 1 / 2)
        {
            if (randomPick < 40)
            {
                return PatternDifficulty.EASY;
            }
            else if (randomPick < 80)
            {
                return PatternDifficulty.NORMAL;
            }
            else
            {
                return PatternDifficulty.HARD;
            }
        }
        else
        {
            if (randomPick < 20)
            {
                return PatternDifficulty.EASY;
            }
            else if (randomPick < 60)
            {
                return PatternDifficulty.NORMAL;
            }
            else
            {
                return PatternDifficulty.HARD;
            }
        }
    }

    public void InstantiateItem(PatternDifficulty difficulty)
    {
        GameObject patternToInstantiate;
        switch (difficulty)
        {
            case PatternDifficulty.EASY:
                patternToInstantiate = Instantiate(easyPatternPrefabs[Random.Range(0, easyPatternPrefabs.Length)], spawnPosition.position, Quaternion.Euler(-26.16f, 0, 0), itemsContainer.transform);
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            case PatternDifficulty.NORMAL:
                patternToInstantiate = Instantiate(normalPatternPrefabs[Random.Range(0, normalPatternPrefabs.Length)], spawnPosition.position, Quaternion.Euler(-26.16f, 0, 0), itemsContainer.transform);
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            case PatternDifficulty.HARD:
                patternToInstantiate = Instantiate(hardPatternPrefabs[Random.Range(0, hardPatternPrefabs.Length)], spawnPosition.position, Quaternion.Euler(-26.16f, 0, 0), itemsContainer.transform);
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            default:
                break;
        }
    }
}
