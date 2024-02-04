using UnityEngine;

public class SimpleCursorManager : MonoBehaviour
{
    public Texture2D normalCursor;
    public Texture2D clickedCursor;

    void Start()
    {
        // Ajuster la taille des textures du curseur
        normalCursor = ResizeCursorTexture(normalCursor, 32, 32);
        clickedCursor = ResizeCursorTexture(clickedCursor, 32, 32);

        // Définir le curseur initial
        SetNormalCursor();
    }

    void Update()
    {
        // Détecter le clic de souris
        if (Input.GetMouseButtonDown(0))
        {
            SetClickedCursor();
        }

        // Détecter le relâchement du bouton de la souris
        if (Input.GetMouseButtonUp(0))
        {
            SetNormalCursor();
        }
    }

    void SetNormalCursor()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void SetClickedCursor()
    {
        Cursor.SetCursor(clickedCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    Texture2D ResizeCursorTexture(Texture2D originalTexture, int newWidth, int newHeight)
    {
        // Create a new texture with the desired size
        Texture2D resizedTexture = new Texture2D(newWidth, newHeight);

        // Convert the original texture to the new size
        Graphics.ConvertTexture(originalTexture, resizedTexture);

        return resizedTexture;
    }
}
