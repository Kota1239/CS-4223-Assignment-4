using UnityEngine;
using System.Collections.Generic;
using System.Numerics;

public class SplitImage : MonoBehaviour
{
    public Texture2D PuzzleImage;
    public List<Texture2D> imageTiles;
    public List<GameObject> pieces;

    public void Start()
    {
        GeneratePieces(PuzzleImage);
    }

    void GeneratePieces(Texture2D image)
    {
        int widthPartsCount = 3;
        int piecesPref = GlobalPreferences.GetPiecesPreference();
        if (piecesPref == 0) widthPartsCount = 2;
        else if (piecesPref == 1) widthPartsCount = 3;
        else if (piecesPref == 2) widthPartsCount = 4;
        else if (piecesPref == 3) widthPartsCount = 6;
        else if (piecesPref == 4) widthPartsCount = 8;
        int tileWidth = image.width / widthPartsCount;
        int tileHeight = image.height / widthPartsCount;

        for (int i = 0; i < widthPartsCount; i++)
        {
            for (int j = 0; j < widthPartsCount; j++)
            {
                Texture2D tex = new Texture2D(tileWidth, tileHeight);
                tex.SetPixels(image.GetPixels(i * tileWidth, j * tileHeight, tileWidth, tileHeight));
                tex.Apply();
                imageTiles.Add(tex);
                Sprite sprite;
                sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new UnityEngine.Vector2(0.5f, 0.5f), 100.0f);
                GameObject piece = new GameObject("Piece");
                piece.layer = 6;
                piece.AddComponent<SpriteRenderer>();
                piece.GetComponent<SpriteRenderer>().sprite = sprite;
                piece.AddComponent<BoxCollider2D>();
                piece.GetComponent<BoxCollider2D>().isTrigger = true;
                piece.GetComponent<BoxCollider2D>().excludeLayers = 6;
                piece.AddComponent<PuzzlePieceController>();
                piece.GetComponent<Transform>().localScale = new UnityEngine.Vector3(0.2f, 0.2f, 1f);
                piece.GetComponent<Transform>().position = new UnityEngine.Vector3(Random.Range(0f, 6f) - 3f, Random.Range(0f, 6f) - 3f);
                piece.AddComponent<UniqueIdentifier>();
                piece.GetComponent<UniqueIdentifier>().SetIdentifier(int.Parse(i.ToString() + j.ToString()));
                piece.AddComponent<Rigidbody2D>();
                piece.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                piece.GetComponent<Rigidbody2D>().gravityScale = 0;
                piece.GetComponent<Rigidbody2D>().excludeLayers = 6;
                pieces.Add(piece);
            }
        }
    }
}