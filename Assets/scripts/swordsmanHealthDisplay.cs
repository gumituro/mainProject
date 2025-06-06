using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwordsmanHealthDisplay : MonoBehaviour
{
    public static SwordsmanHealthDisplay instance;
    public Image swordsmanHealthBar;
    public Sprite bar10, bar9, bar8, bar7, bar6, bar5, bar4, bar3, bar2, bar1, bar0;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthDisplay(); 

    }

    public void UpdateHealthDisplay()
    {

        switch (SwordsmanHealth.instance.SwordscurrentHealth)
        {
            case 30:
                swordsmanHealthBar.sprite = bar10; break;
            case 29:
                swordsmanHealthBar.sprite = bar9; break;
            case 28:
                swordsmanHealthBar.sprite = bar8; break;
            case 27:
                swordsmanHealthBar.sprite = bar7; break;
            case 26:
                swordsmanHealthBar.sprite = bar6; break;
            case 25:
                swordsmanHealthBar.sprite = bar5; break;
            case 24:
                swordsmanHealthBar.sprite = bar4; break;
            case 23:
                swordsmanHealthBar.sprite = bar3; break;
            case 22:
                swordsmanHealthBar.sprite = bar2; break;
            case 21:
                swordsmanHealthBar.sprite = bar1; break;


            case 20:
                swordsmanHealthBar.sprite = bar0;
                swordsmanHealthBar.sprite = bar10;
                break;
            case 19:
                swordsmanHealthBar.sprite = bar9; break;
            case 18:
                swordsmanHealthBar.sprite = bar8; break;
            case 17:
                swordsmanHealthBar.sprite = bar7; break;
            case 16:
                swordsmanHealthBar.sprite = bar6; break;
            case 15:
                swordsmanHealthBar.sprite = bar5; break;
            case 14:
                swordsmanHealthBar.sprite = bar4; break;
            case 13:
                swordsmanHealthBar.sprite = bar3; break;
            case 12:
                swordsmanHealthBar.sprite = bar2; break;
            case 11:
                swordsmanHealthBar.sprite = bar1; break;


            case 10:
                swordsmanHealthBar.sprite = bar0;
                swordsmanHealthBar.sprite = bar10;
                break;
            case 9:
                swordsmanHealthBar.sprite = bar9; break;
            case 8:
                swordsmanHealthBar.sprite = bar8; break;
            case 7:
                swordsmanHealthBar.sprite = bar7; break;
            case 6:
                swordsmanHealthBar.sprite = bar6; break;
            case 5:
                swordsmanHealthBar.sprite = bar5; break;
            case 4:
                swordsmanHealthBar.sprite = bar4; break;
            case 3:
                swordsmanHealthBar.sprite = bar3; break;
            case 2:
                swordsmanHealthBar.sprite = bar2; break;

            case 1:
                swordsmanHealthBar.sprite = bar1; break;

            case 0:
                swordsmanHealthBar.sprite = bar0; break;
            default:
                swordsmanHealthBar.sprite = bar0; break;





        }

    }
}
