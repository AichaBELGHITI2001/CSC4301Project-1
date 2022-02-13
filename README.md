# CSC4301Project-1

I-	Introduction:

 This project is about reproducing the pathfinding project of @SebLague and using it to create a simulation of different search algorithms: DFS, BFS, UCS, and A* with different heuristics. The algorithms are simulated on unity that draws paths produced by each algorithm. The execution time and number of nodes visited by each algorithm are printed while the paths are drawn on the plan.
 
II-	Simulation in unity:

1-	Scenario 1: 

![image](https://user-images.githubusercontent.com/96016773/153768373-87fd37b0-4b98-4cd9-8012-fdcfcc3d6854.png)


Figure 1: Paths formed by BFS(yellow), A* Manhattan(green), A* Euclidian(pink), UCS(white), and DFS cyan

In this scenario, we can conclude that all the pathfinding strategies are complete but not all of the are optimal. I expected DFS  to have a long execution time since it explores a big number of nodes. However, it was quicker than UCS and BFS by 1.467 milliseconds and 0.80 milliseconds respectively. On the other hand, DFS outputted the longest path (223 nodes) among the paths created by the other algorithms since it has to explore all nodes of the grid and check which one is the target node. In addition to that, the A* Manhattan was quicker than A* Euclidian by 0.3679 milliseconds, however, the path created by A* Euclidian was shorter than the path of  A* Manhattan.

2-	Scenario 2:

![image](https://user-images.githubusercontent.com/96016773/153768386-6bf8c5c1-2ad4-4beb-bdc9-4417ab66892c.png)

Figure 2: Paths formed by BFS(yellow), A* Manhattan(green), A* Euclidian(pink), UCS(white), and DFS cyan

In this scenario, I expected DFS to be the slowest, however, it was quicker than UCS and BFS by 1.82 milliseconds and 0.54 milliseconds. We can say that DFS was faster than UCS because it just explores nodes without doing any calculation. Also, DFS outputted the longest path among the paths outputted by other algorithms. 
I expected A* Manhattan to be quicker than A* Euclidian. Indeed,  A* Manhattan was quicker than A* Euclidian by 0.302 milliseconds. However, the path created by A* Euclidian (37 nodes) was shorter than the path of  A* Manhattan (41 nodes).

We can conclude that A* Manhattan was the fastest algorithm to reach the goal (red dot) since it reached it in 0.46 milliseconds. Also, we can conclude that A* Euclidian outputted the shortest path (37 nodes) in the least amount of time compared to UCS and BFS.


3- Scenario 3:

![image](https://user-images.githubusercontent.com/96016773/153768405-ffd62050-b9ca-4966-830e-6c3aa47c5a2f.png)


Figure 3: Paths formed by BFS(yellow), A* Manhattan(green), A* Euclidian(pink), UCS(white)

In this case, I modified the maze in order to test and study the behaviors of the path finding algorithm. I expected A* Manhattan to outperform A* Euclidian. Indeed, A* Manhattan  was quicker than  A* Euclidian by 0.4345 milliseconds. However, the path produced by A* Euclidian( 54 nodes) was shorter than the path of A* Manhattan(60 node). Since UCS try to find the path with the least cost, I expected it to produce a path shorter than the one produced by BFS. However, the path created by UCS and BFS has the same number of nodes(54 nodes).

We can conclude that A* Manhattan is the pathfinding algorithm that reaches the target node(red dot) faster than any other algorithm (0.884 milliseconds), and UCS is the last one to get to it (2.67 milliseconds).


![image](https://user-images.githubusercontent.com/96016773/153768411-e3490aff-d827-473b-bf6c-468524583a75.png)

           Figure 5: Path formed by A* Manhattan and A* Euclidian
As we can see in the image above, the path for A* Manhattan and A* Euclidian are similar in some stages. However, A* Manhattan is quicker than A* Euclidian by 0.4345 milliseconds.

4.	Scenario 4:
 
 ![image](https://user-images.githubusercontent.com/96016773/153768420-c4f07dab-d345-4033-b6cb-5dbd598fea0a.png)
 
     Figure 5: Paths formed by BFS(yellow), A* Manhattan(green), A* Euclidian(pink), UCS(white),DFS(cyan)
     
In this case, I expected DFS to be slower since it takes each node of the grid and checks if it is the target node. Indeed, DFS was slower than UCS and BFS by 8.7 milliseconds and 9 milliseconds respectively. Also, BFS is quicker than UCS by 0.278 milliseconds, yet they outputted a path of the same number of nodes(48 nodes).
I expected the fact that A* Manhattan will be the quickest and will produce the shortest path. Indeed,A* Manhattan  was quicker. It was faster tha A* Euclidien by 0.29 milliseconds.In addition to that, A* Manhattan outputted the shortest path since it uses the Manhattan heuristic, while DFS and BFS tried to check all nodes on the grid until they reache the target node without considering the cost of the path. 

![image](https://user-images.githubusercontent.com/96016773/153768430-11a3d50a-e298-4aac-99d5-8cdda9b512b5.png)

 Figure 6: Paths formed by BFS(yellow), A* Manhattan(green), A* Euclidian(pink), UCS(white)

The screenshot above shows the paths formed by BFS, A* with Manhattan heuristic, A* with Euclidian heuristics, and UCS. We can see that  BFS and A* Euclidian paths are on top on each other meaning they outputted the same path. Also, A* Manhattan(green) and A* Euclidian(pink) intersect in several places.

5- Scenario 5:

![image](https://user-images.githubusercontent.com/96016773/153768436-50a048bb-20d3-4c53-b115-fc5913d1acdb.png)

      Figure 7: Paths formed by BFS(yellow), A* Manhattan(green), A* Euclidian(pink), UCS(white)
      
In this case, I tested the pathfinding algorithms on the same maze that I started with in this report. I did not include DFS since it explores a big number of notes and creates a path that covers other paths. The screenshot above represents separate paths formed by BFS, A* with Manhattan heuristic, A* with Euclidian heuristics, and UCS. Once again, A* Manhattan is the fasters algorithm since it reaches the target node in 0.3227 milliseconds. However, the path produced by A* with Euclidian (42 nodes) is shorter than the path produced by  A* Manhattan (46 nodes).

 I expected that BFS would output the longest path since it searches for the target node and does not consider the costs. However, it outputted the shortest path (40 nodes). We can also conclude from the data presented in the screenshot fact that UCS is the slowest since it is slower than BFS by 1.06 milliseconds and slower than A* Manhattan by 2.18 milliseconds. UCS is also slower than A* Euclidian by 1.41 milliseconds.

6- Scenario 6:

 ![image](https://user-images.githubusercontent.com/96016773/153768449-f84dad42-3292-432c-b6ef-2b0dc539706d.png)

Figure 8: Paths formed by BFS(yellow), A* Manhattan(green), A* Euclidian(pink), and UCS(white)

	In this case, we did not include DFS since it explores a big number of notes and creates a path that covers other paths. The figure shows that A* Manhattan was quicker than A* Euclidian by 0.6 milliseconds. While the  A* Euclidian created the shortest path since A* Manhattan path has 47 nodes and  A* Euclidian path has 42 nodes. UCS and DFS also outputted a path with 42 nodes, but they were slower than A* Euclidian by 1.93 milliseconds and 0.711 milliseconds respectively. We can also see that the path formed by BFS(yellow) is covered by the path formed by the A* Euclidian(pink) algorithm.			

7- Scenario 7: 

 ![image](https://user-images.githubusercontent.com/96016773/153768458-9d66f93d-8e7a-4454-8906-20f9b981e870.png)

Figure 8: Paths formed by BFS(yellow), A* Manhattan(green), A* Euclidian(pink), and UCS(white)


	In this case, I did not include DFS since it explores a big number of notes and creates a path that covers other paths. I expected A* Euclidian to be the faster. However, A* Manhattan was around 0.37 milliseconds quicker. Both A* Euclidian and A* Manhattan formed a path with the same number of nodes 46. I expected UCS to be quicker than BFS and to output the path with the least number of nodes compared to BFS. However, BFS outputted a path with 43 nodes and was quicker than UCS by 1.257 milliseconds. Also, we can remark that the path of UCS(white), A* Manhattan(green), and A* Euclidian(pink) intersect at some points.


III-	Conclusion: 
	Based on the analysis, we can conclude that A* with Manhattan heuristic and  A* with Euclidian heuristics are more optimal than the other algorithms in the two mazed we used in this report. For breadth-first search algorithm, it is complete, and optimal. BFS has a short execution time since it doesn’t do calculations and iterates to all nodes until it finds the target node. Thus, BFS doesn’t output the optimal path since it doesn’t take into consideration the costs. The paths outputted by the DFS algorithm were the longest since the algorithm has to check all nodes to reach the target node and it doesn’t consider the cost of the path from the start node to the target node. Thus, DFS and BFS aim only at guaranteeing that the target is reachable. 

	Simulating the UCS algorithm in unity shows us the fact that it was able to output a short path compared to DFS and BFS. However, UCS was slow compared to A* algorithms. The A* algorithm with Manhattan heuristics was faster than A* with Euclidian heuristic. On the other hand, the paths outputted by A* with Euclidian heuristic were shorter than the paths  outputted by A* with Manhattan heuristic.

# Reference:
Sebastian Lague Youtube channel: https://www.youtube.com/watch?v=-L-WgKMFuhE&list=PLFt_AvWsXl0cq5Umv3pMC9SPnKjfp9eGW

Github course code: https://github.com/SebLague/Pathfinding

# Teammate:

Oumayma Elghamrasni
