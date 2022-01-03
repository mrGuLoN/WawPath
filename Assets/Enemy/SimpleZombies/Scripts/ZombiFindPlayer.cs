using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ZombiFindPlayer : MonoBehaviour
{
    public List<Vector3> pathToTarget;
    public List<Node> checkNodes = new List<Node>();
    public List<Node> waitingNodes = new List<Node>();
    public GameObject target;
    public LayerMask solidLayer;

    private float playerPositionX, playerPositionZ;
    private float thisPositionX, thisPositionZ;

    private void Start()
    {
       // FindPlayer(out target);
    }
   /* public void FindPlayer(out GameObject player)
    {        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        pathToTarget = GetPath(target.transform.position);
    }

    public List<Vector3> GetPath(Vector3 player)
    {
        pathToTarget = new List<Vector3>();
        checkNodes = new List<Node>();
        waitingNodes = new List<Node>();

        Rounded(target.transform.position.x, out playerPositionX);
        Rounded(target.transform.position.z, out playerPositionZ);
        Rounded(this.transform.position.x, out thisPositionX);
        Rounded(this.transform.position.z, out thisPositionZ);

       

        Vector3 startPosition = new Vector3(thisPositionX, 0, thisPositionZ);
        Vector3 targetPosition = new Vector3(playerPositionX, 0, playerPositionZ);

        if (startPosition == targetPosition) return pathToTarget;

        Node startNode = new Node(0, startPosition, targetPosition, null);
        checkNodes.Add(startNode);
        waitingNodes.AddRange(GetNeighboursNodes(startNode));

        for (int i = 0; i < waitingNodes.Count; i++)
        {
            Node nodeToCheck = waitingNodes.Where(x => x.f == waitingNodes.Min(z => z.f)).FirstOrDefault();
            if (nodeToCheck.position == targetPosition)
            {
                return CalculatePathFromNode(nodeToCheck);
            }

            Ray ray = new Ray(this.transform.position, Vector3.zero) ;
            var walkable = !Physics.SphereCast(ray, 3f, solidLayer);
            if (walkable!)
            {
                waitingNodes.Remove(nodeToCheck);
                checkNodes.Add(nodeToCheck);
            }
            else if (walkable)
            {
                waitingNodes.Remove(nodeToCheck);
                if (!checkNodes.Where(x => x.position == nodeToCheck.position).Any())
                {
                    checkNodes.Add(nodeToCheck);
                    waitingNodes.AddRange(GetNeighboursNodes(nodeToCheck)); 
                }
                else
                {
                    var sameNode = checkNodes.Where(x => x.position == nodeToCheck.position).ToList();
                    for (int j =0; j<sameNode.Count; j++)
                    {
                        if (sameNode[j].f > nodeToCheck.f);
                    }
                }
            }
        }

        return pathToTarget;
    }

    public List<Vector3> CalculatePathFromNode(Node node)
    {
        var path = new List<Vector3>();
        Node currentNode = node;
        while (currentNode.previousNode != null)
        {
            path.Add(new Vector3(currentNode.position.x,0,  currentNode.position.z));
            currentNode = currentNode.previousNode;
        }

        return path;
    }

    public List<Node> GetNeighboursNodes(Node node)
    {
        var Neighbours = new List<Node>();
        Neighbours.Add(new Node(node.g+2, new Vector3(node.position.x+1,0, node.position.z), node.targetPosition, node));
        Neighbours.Add(new Node(node.g+2, new Vector3(node.position.x-1, node.position.z), node.targetPosition, node));
        Neighbours.Add(new Node(node.g+2, new Vector3(node.position.x,0, node.position.z+1), node.targetPosition, node));
        Neighbours.Add(new Node(node.g+2, new Vector3(node.position.x,0, node.position.z-1), node.targetPosition, node));
             
        return Neighbours;
    }

    private void OnDrawGizmos()
    {
        if (pathToTarget != null)
        {
            foreach (var item in checkNodes)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(new Vector3(item.position.x,1, item.position.z), 0.5f);
            }

            foreach (var item in pathToTarget)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(new Vector3(item.x,1, item.z), 0.5f);
            }
        }
    }

    private void Rounded(float position, out float positionRounded)
    {             
       
        if (position % 2 > 1)
        {
            position = Mathf.Round(position);
            if (position % 2 !=0)
            {
                position++;
                
            }
        }
        else if (position % 2 < 1)
        {
            position = Mathf.Round(position);
            if (position % 2 != 0)
            {
                position--;                
            }
        }
        positionRounded = position;       
    }

}


    public class Node
{
    public Vector3 position, targetPosition;
    public Node previousNode;
    public int f, g,h;

    public Node(int nodeG, Vector3 nodePosition, Vector3 nodeTargetPosition, Node nodePreviousNode)
    {
        position = nodePosition;
        targetPosition = nodeTargetPosition;
        previousNode = nodePreviousNode;
        g = nodeG;
        h = (int)Mathf.Abs(nodeTargetPosition.x - position.x) + (int)Mathf.Abs(nodeTargetPosition.z - position.z);
        f = g + h;
    }*/
}