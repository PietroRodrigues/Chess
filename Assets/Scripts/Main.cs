using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    

  public Transform casaTab;
  public Mapeamento mapTotal = new Mapeamento();
  public PecasMap mapPecas = new PecasMap();
  Dictionary<string,Vector2> casas = new Dictionary<string, Vector2>();
  Peca[] peca;    
  RaycastHit hit;
  [SerializeField] Peca pecaSelect;

  void Start()
  {
    peca = FindObjectsOfType<Peca>();
    casas = mapTotal.Mapear(casaTab);
    mapPecas.MapearPecas(casas,peca,casaTab);
  }

  void Update()
  {
      MovimentoPecasInput();

  }

  void MovimentoPecasInput(){
    
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
    bool too = Physics.Raycast(ray,out hit);

    if(too){
    
      if(Input.GetMouseButtonDown(0)){       

        bool mover = false;

        for(int i = 0;i < peca.Length;i++){
                    
          if(peca[i].casaAtual == hit.collider.gameObject.name){

            if(pecaSelect == null || peca[i].lado == pecaSelect.lado){
              pecaSelect = peca[i];
              mover = false;
              i = peca.Length;
            }

          }else{
            mover = true;
          }                  
        }

        if(mover && pecaSelect != null){
          pecaSelect.casaSelecionada = hit.collider.gameObject.name;
          mapPecas.attMapPorJogada(casas,peca,casaTab);
          pecaSelect.movimentada = true;
          pecaSelect = null;

        }                                        
      
      }

    }
  }

}
