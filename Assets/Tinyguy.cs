using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinyguy : MonoBehaviour
{
    public SpriteRenderer hair;
    public SpriteRenderer hat;
    public SpriteRenderer face;
    public SpriteRenderer shirt;
    public SpriteRenderer body;
    public SpriteRenderer pantsSR;


    // a list of structs to store the tiny guy's potential hairstyles
    public List<Appearance> hairstyles;
    public List<Appearance> hats;
    public List<Appearance> faces;
    public List<Appearance> shirts;
    public List<Appearance> pants;

    public List<Color> hairColors;
    public List<Color> skinColors;
    public List<Color> shirtColors;
    public List<Color> pantsColors;



    // Start is called before the first frame update
    void Start()
    {
        hair.sprite = hairstyles[Random.Range(0, hairstyles.Count)].image;
        hair.color = hairColors[Random.Range(0, hairColors.Count)];
        hat.sprite = hats[Random.Range(0, hats.Count)].image;
        body.color = skinColors[Random.Range(0, skinColors.Count)];
        face.sprite = faces[Random.Range(0, faces.Count)].image;
        shirt.sprite = shirts[Random.Range(0, shirts.Count)].image;
        shirt.color = shirtColors[Random.Range(0, shirtColors.Count)];
        pantsSR.sprite = pants[Random.Range(0, pants.Count)].image;
        pantsSR.color = pantsColors[Random.Range(0, pantsColors.Count)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// a struct to store the tiny guy's potential visuals
[System.Serializable]
public struct Appearance
{
    public string name;
    public Sprite image;
}
