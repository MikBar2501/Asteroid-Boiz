using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Asteroid-Boiz/AsteroidsStats")]
public class AsteroidValues : ScriptableObject
{

    [Header("Movement")]
    public float parentSpeedBuildUp = 0; // asteroidy przyspieszają po smierci rodzica o parentSpeedBuildUp * aktualna predkosc rodzica
    public float parentDirectionInfuence = 2; // dla 1 50% 50% kirunek asteroidy dla 2 75% parenta 25% przypisany przy stworzniu kierunek
    public Vector2 minMaxSpeed = new Vector2( 0.8f, 2f);
    public Vector2 minMaxRotation = new Vector2(0f, 10f);

    [Space]

    [Header("Attributes")]
    public int maxHealth = 1;
    public int maxLevelOfAsteroid = 5;
    [Space]
    public Vector2 minMaxNumberOfNewAsteroidsCreated = new Vector2(0f, 3f);

    [Space]
    [Header("Types of asteroids")]
    public int baseAsteroidID = 10;
    public List<Sprite> AsteroidSpriteList = new List<Sprite>();
    public List<float> AsteroidRadiusList = new List<float>();
    //public List<int> AsteroidLvlGrouping = new List<int>();




}
