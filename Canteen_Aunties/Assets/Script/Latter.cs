using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Latter : MonoBehaviour
{
    public static Latter instance = null;

    public SpriteRenderer cursorSprite;

    private Ingredient currentIngredient;
    public Ingredient CurrentIngredient
    {
        get { return currentIngredient; }
        set { currentIngredient = value; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();

        mousePos.z = 10;
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public Ingredient AddToLatter(Ingredient ID)
    {
        return CurrentIngredient = ID;
    }
}
