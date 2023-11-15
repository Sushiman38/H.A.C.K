using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatePipeScript : MonoBehaviour
{
    float[] rotations = { 0,90,180,270 };

    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;
    bool goodmoveCounted = false;
    bool badmoveCounted = false;

    int PossibleRots = 1;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0,0,rotations[rand]);
    }


    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0,0,90));
    }

    private void Update()
    {
        if(PossibleRots > 1)
        {
            if(transform.eulerAngles.z == correctRotation[0]|| transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                if(goodmoveCounted == false)
                {
                    gameManager.correctMove();
                    goodmoveCounted = true;
                    badmoveCounted = false;
                }
            }
            else
            {
                if(isPlaced == true)
                    {
                    isPlaced = false;
                    if(badmoveCounted == false)
                    {
                        gameManager.wrongMove();
                        badmoveCounted = true;
                        goodmoveCounted = false;
                    }
                }
            }
        }
        else
        {
            if(transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                if(goodmoveCounted == false)
                {
                    gameManager.correctMove();
                    goodmoveCounted = true;
                    badmoveCounted = false;
                }
            }
            else
            {
                if(isPlaced == true)
                {
                    isPlaced = false;
                    if(badmoveCounted == false)
                    {
                        gameManager.wrongMove();
                        badmoveCounted = true;
                        goodmoveCounted = false;
                    }
                }
            }
        }
    }
}
