using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    

    [SerializeField] Transform casaTab;
    public Mapeamento map = new Mapeamento();
    Dictionary<string,Vector2> casas = new Dictionary<string, Vector2>();

    void Start()
    {
      casas = map.Mapear(casaTab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
