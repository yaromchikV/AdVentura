using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickLevel : MonoBehaviour
{
    [SerializeField] private int openSceneIndex;

    public void Pick()
    {
        SceneManager.LoadScene(openSceneIndex);
    }
}
