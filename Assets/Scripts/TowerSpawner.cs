using UnityEngine; 
using UnityEditor;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Sets minimum tower height")]
    private uint _heightMin = 8;

    [SerializeField]
    [Tooltip("Sets maximum tower height")]
    private uint _heightMax = 10;

    [SerializeField]
    [Tooltip("Mode of selecting prefabs: Random or Pairs")]
    private bool _isRandom = true;

    [SerializeField]
    private GameObject[] _blocks;
    
    // Start is called before the first frame update
    void Start()
    {
        DestroyTower();
        CreateTower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        DestroyTower();
    }

    public void OnButtonGeneratePressed()
    {
        DestroyTower();
        CreateTower();
    }

    public void SetProperties(uint heightMin, uint heightMax, bool isRandom)
    {
        _heightMin = heightMin;
        _heightMax = heightMax;
        _isRandom = isRandom;
    }

    public void DestroyTower()
    {
        foreach(Transform block in transform)
        {
            GameObject.Destroy(block.gameObject);
        }
    }

    public void CreateTower()
    {
        int height = Random.Range((int)_heightMin, (int)_heightMax + 1);
        for(int i = 0; i < height; i++)
        {
            int blockId = _isRandom ? Random.Range(0, _blocks.Length) : (i / 2) % _blocks.Length;
            GameObject block = Instantiate(_blocks[blockId], transform);
            block.name = $"Block{i+1}";
            block.transform.Translate(0, i + 0.5f, 0);
        }
    }
}