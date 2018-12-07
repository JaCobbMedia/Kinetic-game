using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    private bool isDrawn;

    List<Vector2> points;

    public float lifetime = 3f;

    public void UpdateLine(Vector2 mousePos)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePos) > 0.1f)
            SetPoint(mousePos);

    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if(points.Count > 1)
            edgeCol.points = points.ToArray();
    }

    private void Start()
    {
        this.isDrawn = true;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Enemy" ||
            collision.gameObject.tag == "Player") && isDrawn)
        {
            Destroy(gameObject);
        }
    }

    public void FinishDrawing()
    {
        this.isDrawn = false;
    }

}
