using UnityEngine;

public class ServiceSingleton: MonoBehaviour
{
    public static ServiceSingleton Instance
    { get; private set; }
    public  AbstractMazeFactory MazeFactory { get; private set; }
    public bool ChooseFactory;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        if (ChooseFactory)
            MazeFactory = this.gameObject.GetComponent<MazeFactory1>();
        else
            MazeFactory = this.gameObject.GetComponent<MazeFactory2>();
    }
    private void Start()
    {



    }





}
