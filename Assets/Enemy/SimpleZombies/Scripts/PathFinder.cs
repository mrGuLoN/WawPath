using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PathFinder : MonoBehaviour
{
    public List<Vector3> PathToTarget;
    public List<Node> CheckedNodes = new List<Node>();
    public List<Node> FreeNodes = new List<Node>();
    List<Node> WaitingNodes = new List<Node>();
    public GameObject Target;
    public LayerMask SolidLayer;

    private float timer;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            timer = Random.Range(0, 1);
            StartCoroutine(FindObject());            
        }
    }

    IEnumerator FindObject()
    {
        yield return new WaitForSeconds(timer);
        PathToTarget = GetPath(Target.transform.position);
       
    }

    public List<Vector3> GetPath(Vector3 target)
    {
        PathToTarget = new List<Vector3>();
        CheckedNodes = new List<Node>();
        WaitingNodes = new List<Node>();

        Vector3 StartPosition = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z));
        Vector3 TargetPosition = new Vector3(Mathf.Round(target.x), 0, Mathf.Round(target.z));
        
        if(StartPosition == TargetPosition) return PathToTarget;

        Node startNode = new Node(0, StartPosition, TargetPosition, null);
        CheckedNodes.Add(startNode);
        WaitingNodes.AddRange(GetNeighbourNodes(startNode));
        while(WaitingNodes.Count > 0)
        {
            Node nodeToCheck = WaitingNodes.Where(x => x.F == WaitingNodes.Min(z => z.F)).FirstOrDefault();

            if (nodeToCheck.Position == TargetPosition)
            {
                return CalculatePathFromNode(nodeToCheck);
            }

            Ray ray = new Ray(nodeToCheck.Position, Vector3.zero);
            var walkable = !Physics.SphereCast(ray, 1.5f, 0f, SolidLayer);
            Debug.Log(walkable + " / " + Physics.SphereCast(ray, 1.5f, 0, SolidLayer));
            if(!walkable)
            {
                WaitingNodes.Remove(nodeToCheck);
                CheckedNodes.Add(nodeToCheck);
            }
            else if(walkable)
            {
                WaitingNodes.Remove(nodeToCheck);
                if(!CheckedNodes.Where(x => x.Position == nodeToCheck.Position).Any()) {
                    CheckedNodes.Add(nodeToCheck);
                    WaitingNodes.AddRange(GetNeighbourNodes(nodeToCheck));
                } 
            }
        }
        FreeNodes = CheckedNodes;

        return PathToTarget;
    }

    public List<Vector3> CalculatePathFromNode(Node node)
    {
        var path = new List<Vector3>();
        Node currentNode = node;

        while(currentNode.PreviousNode != null)
        {
            path.Add(new Vector3(currentNode.Position.x,0, currentNode.Position.z));
            currentNode = currentNode.PreviousNode;
        }

        return path;
    }

    List<Node> GetNeighbourNodes (Node node)
    {
        var Neighbours = new List<Node>();

        Neighbours.Add(new Node(node.G + 1, new Vector3(
            node.Position.x-1, 0, node.Position.z), 
            node.TargetPosition, 
            node));
        Neighbours.Add(new Node(node.G + 1, new Vector3(
            node.Position.x+1, 0, node.Position.z),
            node.TargetPosition,
            node));
        Neighbours.Add(new Node(node.G + 1, new Vector3(
            node.Position.x, 0, node.Position.z-1),
            node.TargetPosition,
            node));
        Neighbours.Add(new Node(node.G + 1, new Vector3(
            node.Position.x, 0, node.Position.z+1),
            node.TargetPosition,
            node));
        return Neighbours;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position, 1.5f);
        foreach (var item in CheckedNodes)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(new Vector3(item.Position.x,0,  item.Position.z), 1.5f);
        }
        if (PathToTarget != null)
        foreach (var item in PathToTarget)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(new Vector3(item.x, 0, item.z), 1.5f);
        }
    }

}

public class Node 
{
    public Vector3 Position;
    public Vector3 TargetPosition;
    public Node PreviousNode;
    public int F; // F=G+H
    public int G; // расстояние от старта до ноды
    public int H; // расстояние от ноды до цели

    public Node(int g, Vector3 nodePosition, Vector3 targetPosition, Node previousNode)
    {
        Position = nodePosition;
        TargetPosition = targetPosition;
        PreviousNode = previousNode;
        G = g;
        H = (int)Mathf.Abs(targetPosition.x - Position.x) + (int)Mathf.Abs(targetPosition.y - Position.y);
        F = G + H;
    }
}