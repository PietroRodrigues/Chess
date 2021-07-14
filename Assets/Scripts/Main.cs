using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    

    [SerializeField] Transform casaTab;
    public Mapeamento mapTotal = new Mapeamento();
    public PecasMap mapPecas = new PecasMap();
    Dictionary<string,Vector2> casas = new Dictionary<string, Vector2>();
    Peca[] peca;

    void Start()
    {
      peca = FindObjectsOfType<Peca>();
      casas = mapTotal.Mapear(casaTab);
      mapPecas.MapearPecas(casas,peca,casaTab);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        mapPecas.attMapPorJogada(casas,peca,casaTab);
    }

}
