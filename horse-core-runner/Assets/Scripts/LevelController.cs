using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField]
    private Transform blockParent;

    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private float levelSpeed;

    [SerializeField]
    private float blockLength;

    [SerializeField]
    private Vector3 blockRotation;

    [SerializeField]
    private float blockHeight;

    [SerializeField]
    private Vector3 initialBlockPosition;

    private Vector3 lastBlockPosition;

    private float blockProgress;

    private float levelLengthProgress;


    // Use this for initialization
    void Start () {
		GenerateBlock();
	}
	
	// Update is called once per frame
	void Update () {
        if(blockProgress >= blockLength)
        {
            GenerateBlock();
        }

        MoveBlock();
	}

    void MoveBlock()
    {
        float newPosX = levelSpeed * 0.1f;

        blockParent.position = new Vector3(blockParent.position.x - newPosX, blockParent.position.y, blockParent.position.z);
        blockProgress += newPosX;
        levelLengthProgress += newPosX;
        Debug.Log(blockProgress);
    }

    void GenerateBlock()
    {
        if (lastBlockPosition == null)
        {
            lastBlockPosition = initialBlockPosition;
        }

        blockProgress = 0;

        float posX = blockParent.position.x + levelLengthProgress + blockLength;
        float posY = lastBlockPosition.y - blockHeight;

        Debug.Log(blockParent.position.x);

        GameObject blockObject = GameObject.Instantiate
        (
            blockPrefab, 
            new Vector3(posX, posY, lastBlockPosition.z), 
            Quaternion.Euler(blockRotation.x, blockRotation.y, blockRotation.z)
        );

        blockObject.transform.SetParent(blockParent, true);
        lastBlockPosition = blockObject.transform.position;
        Debug.Log(lastBlockPosition);
    }
}
