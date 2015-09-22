using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryManager : MonoBehaviour 
{

    public static InventoryManager instance;

    public int mamadeira;
    public int candy;

    public static int lastMamadeira;
    public static int lastCandy;

    public static Vector3 position;

    public static string currentScene;

    public Text mamadeiraText;
    public Text candyText;

    void Start()
    {
        instance = this;
    }

    public void resetCheckPoint()
    {
        lastMamadeira = 0;
        lastCandy = 0;
        position = Vector3.zero;
    }

    public void startCheckPointsInventory()
    {
        this.candy = lastCandy;
        this.mamadeira = lastMamadeira;
    }

    public void loadCheckPointsInventory()
    {
        lastCandy = candy;
        lastMamadeira = mamadeira;
    }

    public void setText()
    {
        mamadeiraText.text = "x" + mamadeira.ToString();
        candyText.text = candy.ToString() + "x";
    }

    public void addCandy()
    {
        candy++;
        setText();
    }

    public void addMamadeira()
    {
        mamadeira++;
        setText();
    }

    public void removeCandy(float candy)
    {
        candy -= candy;
        if (candy <= 0)
            candy = 0;
    }

    public void removeMamadeira(float mamadeira)
    {
        mamadeira -= mamadeira;
        if (mamadeira <= 0)
            mamadeira = 0;
    }


}
