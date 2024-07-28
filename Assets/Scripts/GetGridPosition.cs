using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GetGridPosition : MonoBehaviour
{
    public enum Mod { NotDrawing,DrawingLine,DrawingCircle,DrawingCone}
    public Mod DrawingMod; 
    [SerializeField] private Grid grid;
    Vector3Int GridPosition;
    [SerializeField] private Vector3Int IndicatorCenter;
    [SerializeField] private Tilemap IndicatiorTilemap;
    [SerializeField] private Tile Indicator;
    [SerializeField] private Tilemap BlackTilemap;
    [SerializeField] private Tile Black;
    [SerializeField] private Tilemap ShadowTilemap;
    [SerializeField] private Tile Shadow;
    public Vector3Int direction = new Vector3Int(1, 0, 0);
    List<Vector3Int> positions = new List<Vector3Int>();
    [SerializeField] private int maxRange;
    [SerializeField] private float couldown;
    public float couldownTimer;
    [SerializeField] PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GridPosition = grid.WorldToCell(transform.position);
        switch (DrawingMod)
        {
            case Mod.DrawingLine:
                switch (Input.GetAxisRaw("Horizontal"))
                {
                    case 1:
                        direction = new Vector3Int(1, 0, 0);
                        IndicatiorTilemap.ClearAllTiles();
                        DrawLine(IndicatiorTilemap, Indicator, 5);
                        break;
                    case -1:
                        direction = new Vector3Int(-1, 0, 0);
                        IndicatiorTilemap.ClearAllTiles();
                        DrawLine(IndicatiorTilemap, Indicator, 5);
                        break;
                }
                switch (Input.GetAxisRaw("Vertical"))
                {
                    case 1:
                        direction = new Vector3Int(0, 1, 0);
                        IndicatiorTilemap.ClearAllTiles();
                        DrawLine(IndicatiorTilemap, Indicator, 5);
                        break;
                    case -1:
                        direction = new Vector3Int(0, -1, 0);
                        IndicatiorTilemap.ClearAllTiles();
                        DrawLine(IndicatiorTilemap, Indicator, 5);
                        break;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    IndicatiorTilemap.ClearAllTiles();
                    DrawLine(ShadowTilemap, Shadow, 5);
                    DrawLine(BlackTilemap, Black, 5);
                    DrawingMod = Mod.NotDrawing;
                    playerManager.ToggleMovement(true);
                }
                break;
            case Mod.DrawingCircle:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    IndicatiorTilemap.ClearAllTiles();
                    DrawCircle(ShadowTilemap, Shadow, 2);
                    DrawCircle(BlackTilemap, Black, 2);
                    DrawingMod = Mod.NotDrawing;
                    playerManager.ToggleMovement(true);
                }
                if (couldownTimer < 0)
                {
                    MoveCenterPoint();
                }
                else if (couldownTimer > 0)
                {
                    couldownTimer -= Time.deltaTime;
                }
                break;
            case Mod.DrawingCone:
                switch (Input.GetAxisRaw("Horizontal"))
                {
                    case 1:
                        direction = new Vector3Int(1, 0, 0);
                        IndicatiorTilemap.ClearAllTiles();
                        DrawCone(IndicatiorTilemap, Indicator, 2);
                        break;
                    case -1:
                        direction = new Vector3Int(-1, 0, 0);
                        IndicatiorTilemap.ClearAllTiles();
                        DrawCone(IndicatiorTilemap, Indicator, 2);
                        break;
                }
                switch (Input.GetAxisRaw("Vertical"))
                {
                    case 1:
                        direction = new Vector3Int(0, 1, 0);
                        IndicatiorTilemap.ClearAllTiles();
                        DrawCone(IndicatiorTilemap, Indicator, 2);
                        break;
                    case -1:
                        direction = new Vector3Int(0, -1, 0);
                        IndicatiorTilemap.ClearAllTiles();
                        DrawCone(IndicatiorTilemap, Indicator, 2);
                        break;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    IndicatiorTilemap.ClearAllTiles();
                    DrawCone(ShadowTilemap, Shadow, 1);
                    DrawCone(BlackTilemap, Black, 1);
                    DrawingMod = Mod.NotDrawing;
                    playerManager.ToggleMovement(true);
                }
                break;
            default:
                break;
        }
        if (Input.GetKeyDown(KeyCode.C))
        { 
            IndicatorCenter = GridPosition;
            if (DrawingMod == Mod.NotDrawing)
                playerManager.ToggleMovement(false);
            DrawingMod = Mod.DrawingCircle;

        }
        if (Input.GetKeyDown(KeyCode.L))
        {      
            IndicatorCenter = GridPosition;
            if(DrawingMod == Mod.NotDrawing)
                playerManager.ToggleMovement(false);
            //DrawingMod = Mod.DrawingLine;
            DrawingMod = Mod.DrawingCone;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&&DrawingMod!=Mod.NotDrawing)
        {
            IndicatiorTilemap.ClearAllTiles();
            DrawingMod = Mod.NotDrawing;
            playerManager.ToggleMovement(true);
        }   
    }
    public void StartDrawing(Mod mod)
    {
        IndicatorCenter = GridPosition;
        if (DrawingMod == Mod.NotDrawing)
            playerManager.ToggleMovement(false);
        DrawingMod = mod;
    }
    public void DrawLine(Tilemap tilemap, Tile tile,int Length)
    {
        positions.Clear();
        for (int i = 1; i < Length+1; i++)
        {
            tilemap.SetTile(GridPosition + (direction * i), tile);
            positions.Add(GridPosition+(direction * i));
        }
    }
    public void DrawCircle(Tilemap tilemap,Tile tile,int Radius)
    {
        switch(Radius)
        {
            case 1:
                positions.Clear();
                tilemap.SetTile(IndicatorCenter + new Vector3Int(1, 0, 0), tile);
                tilemap.SetTile(IndicatorCenter + new Vector3Int(-1, 0, 0), tile);
                tilemap.SetTile(IndicatorCenter + new Vector3Int(0, 1, 0), tile);
                tilemap.SetTile(IndicatorCenter + new Vector3Int(0, -1, 0), tile);
                break;
            case 2:
                positions.Clear();
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int Pos = y * 5 + x;
                        if (Pos != 0 && Pos != 4 && Pos != 20 && Pos != 24)
                        {
                            tilemap.SetTile(IndicatorCenter + new Vector3Int( x -2, y -2, 0), tile);
                            positions.Add(new Vector3Int(x - 2, y - 2, 0));
                        }
                    }
                }
                break;
        }
    }
    public void DrawCone(Tilemap tilemap, Tile tile, int size)
    {
        Vector3Int other;
        if (direction.x != 0)
        {
            other = new Vector3Int(0, direction.x ,0);
        }else
            other = new Vector3Int(direction.y ,0 ,0);
        switch (size)
        {
            case 1:
                positions.Clear();
                tilemap.SetTile(GridPosition + direction, tile);
                tilemap.SetTile(GridPosition + direction * 2, tile);
                tilemap.SetTile(GridPosition + direction * 3, tile);
                tilemap.SetTile(GridPosition + direction * 2 + other, tile);
                tilemap.SetTile(GridPosition + direction * 2 - other, tile);
                tilemap.SetTile(GridPosition + direction * 3 + other, tile);
                tilemap.SetTile(GridPosition + direction * 3 + other * 2, tile);
                tilemap.SetTile(GridPosition + direction * 3 - other, tile);
                tilemap.SetTile(GridPosition + direction * 3 - other *2, tile);
                break;
            case 2:
                positions.Clear();
                tilemap.SetTile(GridPosition + direction, tile);
                tilemap.SetTile(GridPosition + direction * 2, tile);
                tilemap.SetTile(GridPosition + direction * 3, tile);
                tilemap.SetTile(GridPosition + direction * 4, tile);
                tilemap.SetTile(GridPosition + direction * 2 + other, tile);
                tilemap.SetTile(GridPosition + direction * 2 - other, tile);
                tilemap.SetTile(GridPosition + direction * 3 + other, tile);
                tilemap.SetTile(GridPosition + direction * 3 + other * 2, tile);
                tilemap.SetTile(GridPosition + direction * 3 - other, tile);
                tilemap.SetTile(GridPosition + direction * 3 - other * 2, tile);
                tilemap.SetTile(GridPosition + direction * 4 + other, tile);
                tilemap.SetTile(GridPosition + direction * 4 + other * 2, tile);
                tilemap.SetTile(GridPosition + direction * 4 + other * 3, tile);
                tilemap.SetTile(GridPosition + direction * 4 - other, tile);
                tilemap.SetTile(GridPosition + direction * 4 - other * 2, tile);
                tilemap.SetTile(GridPosition + direction * 4 - other * 3, tile);

                break;
        }
    }
    void MoveCenterPoint()
    {
        switch (Input.GetAxisRaw("Horizontal"))
        {
            case 1:
                if (IndicatorCenter.x < GridPosition.x + maxRange)
                    IndicatorCenter += new Vector3Int(1, 0, 0);
                break;
            case -1:
                if (IndicatorCenter.x > GridPosition.x - maxRange)
                    IndicatorCenter += new Vector3Int(-1, 0, 0);
                break;
        }
        switch (Input.GetAxisRaw("Vertical"))
        {
            case 1:
                if (IndicatorCenter.y < GridPosition.y + maxRange)
                    IndicatorCenter += new Vector3Int(0, 1, 0);
                break;
            case -1:
                if (IndicatorCenter.y > GridPosition.y - maxRange)
                    IndicatorCenter += new Vector3Int(0, -1, 0);
                break;
        }
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            couldownTimer = couldown;
            IndicatiorTilemap.ClearAllTiles();
            DrawCircle(IndicatiorTilemap, Indicator, 2);
        }
    }
}
