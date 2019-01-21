using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    int breackableBlocks;

    //cached reference
    SceneLoader sceneLoader;


    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breackableBlocks++;
    }

    public void BlockDestroyed()
    {
        breackableBlocks--;

        if (breackableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
