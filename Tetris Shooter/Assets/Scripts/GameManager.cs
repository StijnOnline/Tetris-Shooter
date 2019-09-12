using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public float blockSpeed = 1;
    public float middleForce = 1;
    public float middleRotateSpeed = 1;

    private List<Block> blocks = new List<Block>();
    //is this usefull or unneccesary?
    public List<Block> GetBlocks() { return blocks; }
    public void AddBlock(Block _block) { blocks.Add(_block);}
    public void RemoveBlock(Block _block) { blocks.Remove(_block); }

    public GameObject blockPrefab;

    //TODO: other way without player references?
    public Player[] players = new Player[2];

    public event System.Action GetInput;

    private PlayerInput playerInput;
    public BlockPool blockPool;

    public delegate void AttractDelegate(Vector3 target, float force);
    public AttractDelegate Attract;
    public Transform middlepoint;

    private void Awake()
    {
        if ( instance != null && instance != this){ Destroy(this.gameObject); }
        else{ instance = this; }
    }

    private void Start()
    {
        playerInput = new PlayerInput();
        blockPool = new BlockPool(blockPrefab,20);

        //GetInput += playerInput.GetInput;

        players[0].NewBlock();
        players[1].NewBlock();

        
    }

    private void OnDestroy()
    {

        //GetInput -= playerInput.GetInput;
    }

    private void Update()
    {
        
        float[] input = playerInput.GetInput();
        //TODO Rewrite input
        players[0].GetBlock()?.Move(input[0], input[1]);
        players[0].GetBlock()?.Rotate(input[2]);
        if (input[3]==1) { players[0].SaveBlock(); }

        players[1].GetBlock()?.Move(input[4], input[5]);
        players[1].GetBlock()?.Rotate(input[6]);
        if (input[7]==1) { players[1].SaveBlock(); }

        Attract(transform.position, middleForce);
    }

    
}
