using UnityEngine;
using System.Collections;

public class CoinIcon : MonoBehaviour {

    public Rigidbody2D coinIcon;
    private Vector2 move = new Vector3(-0.15f, 0, 0);
    public float value;
    private MainController controller;


    // Use this for initialization
    public void initialize(MainController controller)
    {
        this.controller = controller;
    }
    // Use this for initialization
    void Start()
    {
        coinIcon = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < -11.1)
        {
            this.remove();
        }
    }

    void FixedUpdate()
    {
        coinIcon.MovePosition(coinIcon.position + move);
    }

    void remove()
    {
        controller.removeCoinIcon(this);
    }
}
