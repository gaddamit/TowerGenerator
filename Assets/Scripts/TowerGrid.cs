using UnityEngine;
using UnityEditor;

public class TowerGrid : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Sets size of grid")]
    private int _gridSize = 25;
    [SerializeField]
    [Tooltip("Sets minimum tower height")]
    private uint _heightMin = 8;

    [SerializeField]
    [Tooltip("Sets maximum tower height")]
    private uint heightMax = 10;

    [SerializeField]
    [Tooltip("Mode of selecting prefabs: Random or Pairs")]
    private bool _isRandom = true;
    
    [SerializeField]
    private TowerSpawner _towerSpawner;
    
    [SerializeField]
    private GameObject _ground;

    // Start is called before the first frame update
    void Start()
    {
        DestroyGrid();
        CreateGrid();
        AdjustGroundSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        DestroyGrid();
    }

    public void OnButtonGeneratePressed()
    {
        DestroyGrid();
        CreateGrid();
        AdjustGroundSize();
    }

    private void CreateGrid()
    {
        for(int i = 0; i < _gridSize; i++)
        {
            for(int j = 0; j < _gridSize; j++)
            {
                TowerSpawner tower = Instantiate(_towerSpawner, this.transform);
                tower.SetProperties(_heightMin, heightMax, _isRandom);
                tower.name = $"Tower{i * _gridSize + j + 1}"; 
                tower.transform.Translate(_gridSize / 2 - i, 0, _gridSize / 2 - j);
            }
        }
    }

    private void DestroyGrid()
    {
        foreach(Transform child in transform)
        {
            TowerSpawner ts = child.gameObject.GetComponent<TowerSpawner>();
            ts.DestroyTower();
        }
    }

    private void AdjustGroundSize()
    {
        float scale = Mathf.Max(_gridSize / 10.0f + 0.5f);
        _ground.transform.localScale = new Vector3(scale, 1, scale);
    }
}