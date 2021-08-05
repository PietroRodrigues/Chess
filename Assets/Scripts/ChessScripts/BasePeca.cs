using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePeca : MonoBehaviour
{
    [SerializeField] private string cordenada;

    public string Cordenada { get => cordenada; set => cordenada = value; }
}
