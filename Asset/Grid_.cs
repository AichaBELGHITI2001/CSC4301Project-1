using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid_ : MonoBehaviour {

	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	Node[,] grid;

	float nodeDiameter;
	int gridSizeX, gridSizeY;

	void Awake() {
		nodeDiameter = nodeRadius*2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
		CreateGrid();
	}

	void CreateGrid() {
		grid = new Node[gridSizeX,gridSizeY];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

		for (int x = 0; x < gridSizeX; x ++) {
			for (int y = 0; y < gridSizeY; y ++) {
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint,nodeRadius,unwalkableMask));
				grid[x,y] = new Node(walkable,worldPoint, x,y);
			}
		}
	}

	public List<Node> GetNeighbours(Node node) {
		List<Node> neighbours = new List<Node>();

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if (x == 0 && y == 0)
					continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
					neighbours.Add(grid[checkX,checkY]);
				}
			}
		}

		return neighbours;
	}
	
	public Node NodeFromWorldPoint(Vector3 worldPosition) {
		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
		float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
		return grid[x,y];
	}

	public List<Node> pathAstar;
	public List<Node> pathUCS;
	public List<Node> pathDFS;
	public List<Node> pathBFS;
	public List<Node> pathAstarEucliedien;
	public List<Node> pathAstarManhattan;



	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y));
		if (grid != null) {
		foreach (Node n in grid) {
			Gizmos.color= (n.walkable)?Color.black:Color.red;
			Gizmos.DrawCube(n.worldPosition, Vector3.one* (nodeDiameter-.1f));
		}
		}

		if (grid != null) {
			foreach (Node n in grid) {
				if (pathAstar != null){
					foreach (Node n9 in pathAstar){
						if (pathAstar.Contains(n9)){
							Gizmos.color = Color.red;
							Gizmos.DrawCube(n9.worldPosition, Vector3.one * (nodeDiameter-.1f));
						}
					}
				}if(pathUCS!=null){
					foreach (Node n1 in pathUCS) {
						if (pathUCS.Contains(n1)){
							Gizmos.color = Color.white;
							Gizmos.DrawCube(n1.worldPosition, Vector3.one * (nodeDiameter-.1f));
						}
					}
				}if(pathDFS!=null){
					foreach (Node n2 in pathDFS) {
							if (pathDFS.Contains(n2)){
							Gizmos.color = Color.cyan;
							Gizmos.DrawCube(n2.worldPosition, Vector3.one * (nodeDiameter-.1f));
						}
					}
				}if(pathBFS!=null){
					foreach (Node n3 in pathBFS) {
						if (pathBFS.Contains(n3)){
						Gizmos.color = Color.yellow;
						Gizmos.DrawCube(n3.worldPosition, Vector3.one * (nodeDiameter-.1f));
						}
					}
				}if(pathAstarEucliedien!=null){
					
					foreach (Node m in pathAstarEucliedien) {
						if (pathAstarEucliedien.Contains(m)){
							
						Gizmos.color = Color.magenta;
						Gizmos.DrawCube(m.worldPosition, Vector3.one * (nodeDiameter-.1f));
						}
					}
					
				}if(pathAstarManhattan!=null){
					foreach (Node m1 in pathAstarManhattan) {
						if (pathAstarManhattan.Contains(m1)){
						Gizmos.color = Color.green;
						Gizmos.DrawCube(m1.worldPosition, Vector3.one * (nodeDiameter-.1f));
						}
					}
				}


			}
		}
	}
}

