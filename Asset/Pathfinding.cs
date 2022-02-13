using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEditor;
//using MonoBehaviour;

public class Pathfinding : MonoBehaviour {
	public Transform seeker, target;
	Grid_ grid;
	int visitedNodesAstarM;
	int visitedNodesAstarE;
	int visitedNodesUCS;
	int	visitedNodesBFS;
	int visitedNodesDFS;

	void Awake() {
		grid = GetComponent<Grid_> ();
	}
	void Update() {
		visitedNodesAstarM=0;
		visitedNodesAstarE=0;
		visitedNodesUCS=0;
		visitedNodesBFS=0;
		visitedNodesDFS=0;

		FindPathAstartEucliedien(seeker.position,target.position);
		FindPathAstartManhattan (seeker.position,target.position);
		FindPathBFS(seeker.position,target.position);
		FindPathUCS(seeker.position,target.position );
		FindPathDFS(seeker.position,target.position);
	print("Nodes visited in  A* Euclidian: "+ visitedNodesAstarE + "\n"+ " Nodes visited in A* Manhattan: "+ visitedNodesAstarM + "\n");
	print(" Nodes visited in UCS: "+ visitedNodesUCS + "\n"+ " Nodes visited in BFS: " + visitedNodesBFS+"\n");	
	print(" Nodes visited in DFS: " + visitedNodesDFS+"\n");
	
	}	
	
	void FindPathAstartManhattan(Vector3 startPos, Vector3 targetPos) {
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);
		float timeAstarM = Time.realtimeSinceStartup;
		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0) {
			

			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost) {
					if (openSet[i].hCost < node.hCost){
						node = openSet[i];}
				}
			}
			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode) {
				print("A* Manhattan time: " + (Time.realtimeSinceStartup - timeAstarM).ToString());
				RetracePath(startNode,targetNode,6);
				break;
			}

			foreach (Node neighbour in grid.GetNeighbours(node)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistanceManhattan(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistanceManhattan(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
	}

	void FindPathAstartEucliedien(Vector3 startPos, Vector3 targetPos) {
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);
		float timeAstarE = Time.realtimeSinceStartup;
		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0) {
			
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost) {
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}
			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode) {
				print("A* Euclidien time: " + (Time.realtimeSinceStartup - timeAstarE).ToString());
			
				RetracePath(startNode,targetNode,5);
				break;
			}

			foreach (Node neighbour in grid.GetNeighbours(node)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistanceEuclidien(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistanceEuclidien(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
	}
	void FindPathUCS(Vector3 startPos, Vector3 targetPos) {
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);
		float timeUCS = Time.realtimeSinceStartup;
		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0) {
			
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
				if (openSet[i].gCost < node.gCost) {
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode) {
				print("UCS time: " + (Time.realtimeSinceStartup - timeUCS).ToString());
				RetracePath(startNode,targetNode,2);
				break;
			}

			foreach (Node neighbour in grid.GetNeighbours(node)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistanceAStar(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
					neighbour.gCost = newCostToNeighbour;
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
	}

    void FindPathDFS(Vector3 startPos, Vector3 targetPos) {
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);
        Stack<Node> stack = new Stack<Node> ();
        
		float timeDFS = Time.realtimeSinceStartup;
		HashSet<Node> closedSet = new HashSet<Node>();//explored
		
        stack.Push(startNode);

        while (stack.Count != 0) {
			Node currentNode = stack.Pop ();
            
			if (currentNode == targetNode) {
				print("DFS time: " + (Time.realtimeSinceStartup - timeDFS).ToString());
                RetracePath(startNode,targetNode,3);
                break;
			}
			foreach (Node neighbour in grid.GetNeighbours(currentNode)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}
                if(neighbour.walkable || !stack.Contains(neighbour)) {
					//Mark the node as explored
					closedSet.Add(neighbour);

					//Store a reference to the previous node
                    neighbour.parent = currentNode;

					//Add this to the stack of nodes to examine
					stack.Push(neighbour);
				}
		    }
	    }
    }
	void FindPathBFS(Vector3 startPos, Vector3 targetPos) {
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);
        Queue<Node> queue = new Queue<Node> ();
		float timeBFS = Time.realtimeSinceStartup;
		
       
		HashSet<Node> closedSet = new HashSet<Node>();//explored

        queue.Enqueue (startNode);

        while (queue.Count != 0) {
			Node currentNode = queue.Dequeue ();
            

			if (currentNode == targetNode) {
				print("BFS time: " + (Time.realtimeSinceStartup - timeBFS).ToString());
                RetracePath(startNode,targetNode,4);
                break;
			}
			closedSet.Add(currentNode);
			foreach (Node neighbour in grid.GetNeighbours(currentNode)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}
                if(neighbour.walkable || !queue.Contains(neighbour)) {
					//Mark the node as explored
					closedSet.Add(neighbour);

					//Store a reference to the previous node
                    neighbour.parent = currentNode;

					//Add this to the queue of nodes to examine
					queue.Enqueue (neighbour);
				}
		    }
	    }
    }
	
	void RetracePath(Node startNode, Node endNode,int ID) {
		List<Node> path = new List<Node>();
		Node currentNode = endNode;
		 if(ID==2){
			while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
			visitedNodesUCS++;
			}
			path.Reverse();
			grid.pathUCS = path;
		}else if(ID==3){
			while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
			visitedNodesDFS++;
			}
			path.Reverse();
			grid.pathDFS = path;
		}else if(ID==5){
			while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
			visitedNodesAstarE++;
			}
			path.Reverse();
			grid.pathAstarEucliedien=path;
		}else if(ID==6){
			while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
			visitedNodesAstarM++;
			}
			path.Reverse();
			grid.pathAstarManhattan=path;
		}else if(ID==4){
			while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
			visitedNodesBFS++;
			}
			path.Reverse();
			grid.pathBFS = path;
		}
	}
	int GetDistanceAStar(Node nodeA, Node nodeB) {
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14*dstY + 10* (dstX-dstY);
		return 14*dstX + 10 * (dstY-dstX);
	}
	int GetDistanceEuclidien(Node nodeA, Node nodeB) {
        int dstX = (nodeA.gridX - nodeB.gridX);
        int dstY = (nodeA.gridY - nodeB.gridY);
		int temp = System.Convert.ToInt32(Mathf.Sqrt(dstX*dstX+dstY*dstY));
        return temp ;
    }	
	int GetDistanceManhattan(Node nodeA, Node nodeB) {
        int X = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int Y = Mathf.Abs(nodeA.gridY - nodeB.gridY);
		int temp = System.Convert.ToInt32(X+Y);
        return temp ;
    }	

}
