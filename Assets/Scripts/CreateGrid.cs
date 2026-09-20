using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public GameObject tile;
    public float spacing = 25f;
    public float gridOffset = -5f;
    void Start()
    {
        int widthPartsCount = 3;
        int piecesPref = GlobalPreferences.GetPiecesPreference();
        if (piecesPref == 0) widthPartsCount = 2;
        else if (piecesPref == 1) widthPartsCount = 3;
        else if (piecesPref == 2) widthPartsCount = 4;
        else if (piecesPref == 3) widthPartsCount = 6;
        else if (piecesPref == 4) widthPartsCount = 8;

        float tileSize = (0.2f / widthPartsCount);

        for (int i = 0; i < widthPartsCount; i++)
        {
            for (int j = 0; j < widthPartsCount; j++)
            {
                Vector3 spawnPosition = new Vector3(gridOffset + ((i*tileSize)*spacing), gridOffset + ((j*tileSize)*spacing), 0);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject spawnedTile = Instantiate(tile, spawnPosition, spawnRotation);
                spawnedTile.transform.localScale = new UnityEngine.Vector3(tileSize, tileSize, 1f);
                spawnedTile.AddComponent<UniqueIdentifier>();
                spawnedTile.GetComponent<UniqueIdentifier>().SetIdentifier(int.Parse(i.ToString() + j.ToString()));
            }
        }
    }
}
