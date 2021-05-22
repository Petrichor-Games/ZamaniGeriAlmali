using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcilisEkrani : MonoBehaviour
{
    public float wait_time = 7f;
    void Start()
    {
        StartCoroutine(WaitForinfo());
    }

    // Update is called once per frame
    IEnumerator WaitForinfo()
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(1);
    }
}
