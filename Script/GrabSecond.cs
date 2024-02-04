using UnityEngine;

public class GrabSecond : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition;
    private float newRotation ;
    private MovePieces movePieces;
    private int IndexforThis;

    public bool Won;

    private bool OnMouseDownbool;
    
    void Start()
    {
        initialPosition = transform.position;
        movePieces = FindObjectOfType<MovePieces>();
        for(int i=0;i<movePieces.Name.Length;i++)
        {
            Debug.Log(gameObject.name);
            Debug.Log(movePieces.Name[i]);
            if(gameObject.name == movePieces.Name[i])
            {
                IndexforThis = movePieces.IndexPieces2[i];
                
            }

        }
    }

    void OnMouseDown()
    {
        Debug.Log(movePieces.Pieces[IndexforThis].name +"    " +gameObject.name);

        if (movePieces.Pieces[IndexforThis].name == gameObject.name)
        {
            StartDragging();
            OnMouseDownbool = true;
        }
        
    }

    void OnMouseUp()
    {
        StopDragging();
        int storedPositionTensX = Mathf.FloorToInt(movePieces.StoredPosition[IndexforThis].x / 30f) * 30;
        int storedPositionTensY = Mathf.FloorToInt(movePieces.StoredPosition[IndexforThis].y / 30f) * 30;
        OnMouseDownbool = false;

        // Correction : Utilisation d'un quaternion spécifique au lieu d'un tableau de quaternions
        Quaternion storedRotation = movePieces.StoredRotation[IndexforThis];

        if (Mathf.FloorToInt(transform.position.x / 30f) * 30 == storedPositionTensX &&
            Mathf.FloorToInt(transform.position.y / 30f) * 30 == storedPositionTensY)
        {
            Debug.Log(transform.rotation.ToString() + storedRotation.ToString());

            if (Mathf.Abs(transform.rotation.eulerAngles.z - storedRotation.eulerAngles.z) < 0.001f ||
                Mathf.Abs(transform.rotation.eulerAngles.z + storedRotation.eulerAngles.z) < 0.001f)
            {
                transform.position = movePieces.StoredPosition[IndexforThis];
                Won = true;
            }
            else
            {
                transform.position = initialPosition;
            }    
            
        }
        else
        {
            transform.position = initialPosition;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            DragObject();
        }
        if (Input.GetKeyUp(KeyCode.J) && OnMouseDownbool)
        {
            newRotation +=90f;
            movePieces.Pieces[IndexforThis].transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
        }
    }

    void StartDragging()
    {
        isDragging = true;
        gameObject.layer = 2;
        transform.position += new Vector3(0, 0, -10);
        offset = transform.position - GetMouseWorldPos();
    }

    void StopDragging()
    {
        isDragging = false;
        gameObject.layer = 1;
        transform.position -= new Vector3(0, 0, -10);
    }

    void DragObject()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePosition = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 1000f));
    }
}
