using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    private Potion p;
    // Start is called before the first frame update
    void Start()
    {
        p = FindFirstObjectByType<Potion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            loadScene((SceneManager.GetActiveScene().buildIndex + 1) % 3);
        }
    }

    public void loadScene(int index) {
        SceneManager.LoadScene(index);
        p.potionCount = 20;
    }
}
