using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExittoMainMenu : MonoBehaviour
{
    public void ExitGame() {
        SceneManager.LoadScene("Main menu");
    }
}
