using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void btnTryAgain_click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
