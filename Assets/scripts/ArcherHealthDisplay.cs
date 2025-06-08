using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArcherHealthDisplay : MonoBehaviour
{
    public static ArcherHealthDisplay instance;
    public Image ArcherHealthBar;
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

        switch (ArcherHealth.instance.ArchercurrentHealth)
        {
            case 30:
                ArcherHealthBar.sprite = bar10; break;
            case 29:
                ArcherHealthBar.sprite = bar9; break;
            case 28:
                ArcherHealthBar.sprite = bar8; break;
            case 27:
                ArcherHealthBar.sprite = bar7; break;
            case 26:
                ArcherHealthBar.sprite = bar6; break;
            case 25:
                ArcherHealthBar.sprite = bar5; break;
            case 24:
                ArcherHealthBar.sprite = bar4; break;
            case 23:
                ArcherHealthBar.sprite = bar3; break;
            case 22:
                ArcherHealthBar.sprite = bar2; break;
            case 21:
                ArcherHealthBar.sprite = bar1; break;


            case 20:
                            AudioManager.instance.PlaySFX(9);

                ArcherHealthBar.sprite = bar0;
                ArcherHealthBar.sprite = bar10;
                break;
            case 19:
                ArcherHealthBar.sprite = bar9; break;
            case 18:
                ArcherHealthBar.sprite = bar8; break;
            case 17:
                ArcherHealthBar.sprite = bar7; break;
            case 16:
                ArcherHealthBar.sprite = bar6; break;
            case 15:
                ArcherHealthBar.sprite = bar5; break;
            case 14:
                ArcherHealthBar.sprite = bar4; break;
            case 13:
                ArcherHealthBar.sprite = bar3; break;
            case 12:
                ArcherHealthBar.sprite = bar2; break;
            case 11:
                ArcherHealthBar.sprite = bar1; break;


            case 10:
                            AudioManager.instance.PlaySFX(9);

                ArcherHealthBar.sprite = bar0;
                ArcherHealthBar.sprite = bar10;
                break;
            case 9:
                ArcherHealthBar.sprite = bar9; break;
            case 8:
                ArcherHealthBar.sprite = bar8; break;
            case 7:
                ArcherHealthBar.sprite = bar7; break;
            case 6:
                ArcherHealthBar.sprite = bar6; break;
            case 5:
                ArcherHealthBar.sprite = bar5; break;
            case 4:
                ArcherHealthBar.sprite = bar4; break;
            case 3:
                ArcherHealthBar.sprite = bar3; break;
            case 2:
                ArcherHealthBar.sprite = bar2; break;

            case 1:
                ArcherHealthBar.sprite = bar1; break;

            case 0:
                            AudioManager.instance.PlaySFX(9);

                ArcherHealthBar.sprite = bar0; break;
            default:
                ArcherHealthBar.sprite = bar0; break;





        }
    }
}
