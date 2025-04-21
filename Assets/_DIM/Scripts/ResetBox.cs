using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered reload");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
