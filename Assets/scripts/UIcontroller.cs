using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public static UIcontroller instance;
    public Image heart1, heart2, heart3;
    public Sprite fullHeart, emptyHeart;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthDisplay()
    {
        
        switch (HealthControler.instance.currentHealth)
        {
            case 30: case 29: case 28 : case 27: case 26: case 25: case 24: case 23: case 22: case 21: 
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                break;

            case 20: case 19: case 18: case 17: case 16: case 15: case 14: case 13: case 12: case 11: 
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                break;

            case 10: case 9: case 8: case 7: case 6: case 5: case 4: case 3: case 2: case 1: 
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;

            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;

            default:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;




        }
    }
}
