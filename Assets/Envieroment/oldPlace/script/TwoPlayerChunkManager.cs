using UnityEngine;

public class TwoPlayerChunkManager : MonoBehaviour
{
    [Header("Chunks")]
    public GameObject caveChunk;
    public Transform caveStart;
    public Transform caveEnd;

    public GameObject ancientChunk;
    public Transform ancientStart;
    public Transform ancientEnd;

    public GameObject finalChunk;
    public Transform finalStart;

    private GameObject selectedChunk;
    private Transform selectedStart;
    private Transform selectedEnd;

    private GameObject otherChunk;
    private Transform otherStart;
    private Transform otherEnd;

    private bool hasSelected = false;

  
    private bool[] hasVisitedChunk = new bool[2]; // 0: بازیکن 1، 1: بازیکن 2

 
    public void PlayerEnter(Transform player, int playerIndex)
    {
        if (!hasSelected)
        {
            
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                selectedChunk = caveChunk;
                selectedStart = caveStart;
                selectedEnd = caveEnd;

                otherChunk = ancientChunk;
                otherStart = ancientStart;
                otherEnd = ancientEnd;
            }
            else
            {
                selectedChunk = ancientChunk;
                selectedStart = ancientStart;
                selectedEnd = ancientEnd;

                otherChunk = caveChunk;
                otherStart = caveStart;
                otherEnd = caveEnd;
            }

            selectedChunk.SetActive(true);
            hasSelected = true;
        }

        
        if (playerIndex == 0)
            player.position = selectedStart.position;
        else
            player.position = otherStart.position;
    }

    
    public void PlayerReachedEnd(Transform player, int playerIndex)
    {
       
        GameObject nextChunk = null;
        Transform nextStart = null;

        if (!hasVisitedChunk[0] || !hasVisitedChunk[1])
        {
            
            if (playerIndex == 0)
            {
                nextChunk = otherChunk;
                nextStart = otherStart;
            }
            else
            {
                nextChunk = selectedChunk;
                nextStart = selectedStart;
            }

            nextChunk.SetActive(true);
            player.position = nextStart.position;
        }
        else
        {
           
            nextChunk = finalChunk;
            nextStart = finalStart;
            finalChunk.SetActive(true);
            player.position = finalStart.position;
        }
        
        hasVisitedChunk[playerIndex] = true;
    }
}