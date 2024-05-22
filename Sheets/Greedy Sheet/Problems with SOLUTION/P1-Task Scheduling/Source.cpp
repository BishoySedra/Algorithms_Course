#include <iostream>
#include <math.h>
#include<queue>
#include <algorithm> 
#include <map>
#include <math.h>
#include <stack>

using namespace std;
#define ll long long

int main() {
	int tasks[10] = { 5,3,2,10,4,1 }; // 1 2 3 4 5 10
	int tasksNumber = 6;

	sort(tasks, tasks + tasksNumber); // O(NlgN)

	double sum = 0;
	// O(N)
	for (int i = 0; i < tasksNumber; i++)
	{
		if (i != 0)
			tasks[i] += tasks[i - 1];
		sum += tasks[i];
	}
	cout << sum / tasksNumber;
	return 0;
}