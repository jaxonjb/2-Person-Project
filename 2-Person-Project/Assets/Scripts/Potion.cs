using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public Text potionText;
    public float force = 1f;
    public float radius = 5.0f;
    public float delay = 1.0f;
    public int potionCount = 20;
    public GameObject player;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            ApplyForce(pos);
            // potionCount--;
            // potionText.text = "Potions: " + potionCount;
            Debug.Log("Clicked on position: " + pos);
        }
        transform.position = pos;
    }

    private void ApplyForce(Vector2 pos)
    {
        Vector2 launchAngle = (rigidbody.position - pos).normalized;
        float finalForce = force * (1/Vector2.Distance(rigidbody.position, pos));
        if(finalForce > 500f) finalForce = 500f;
        rigidbody.AddRelativeForce(launchAngle * finalForce, ForceMode2D.Force);
    }
} 
