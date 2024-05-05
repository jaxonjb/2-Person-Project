using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Potion : MonoBehaviour
{
    public Text potionText;
    private float force = 1000f;
    public int potionCount = 20;
    public GameObject player;
    private Rigidbody2D rigidbody;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (potionCount < 1) {
            gameOverScreen.SetActive(true);
            Destroy(player);
        }

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            ApplyForce(pos);
            ExplosionAnimation(pos);
            potionCount--;
        }
        transform.position = pos;
    }

    private void ApplyForce(Vector2 pos)
    {
        Vector2 launchAngle = (rigidbody.position - pos).normalized;
        float finalForce = force * (1/Vector2.Distance(rigidbody.position, pos));
        if(finalForce > 1000f) finalForce = 1000f;
        rigidbody.AddRelativeForce(launchAngle * finalForce, ForceMode2D.Force);
    }
    private void ExplosionAnimation(Vector2 pos)
    {
        GameObject e = Instantiate(Resources.Load("Prefabs/Explosion") as GameObject);
        e.transform.position = pos;
        Destroy(e, 1.1f);
    }


    public void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.normal.textColor = Color.green;
        style.fontStyle = FontStyle.Bold;
        style.fontSize = 40;
        GUI.Label(new Rect(Screen.width - 450, 40, 1000, 80), "POTIONS: " + potionCount, style);
    }
} 
