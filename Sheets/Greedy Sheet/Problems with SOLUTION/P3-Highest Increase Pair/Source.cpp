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
	int arr[100] = { 31,-41,59,26,-53,58,97,-93,-23,84 };
	int index = 0;
	int s = 0, e = 0;
	int maxx = -1000;
	for (int j = 1; j < 10; j++)
	{
		if (arr[j] < arr[index]) {
			index = j;
			continue;
		}
		int dif = arr[j] - arr[index];
		if (maxx < dif) {
			maxx = dif;
			s = index;
			e = j;
		}
	}
	cout << maxx << " " << arr[s] << " " << arr[e];

	return 0;
}