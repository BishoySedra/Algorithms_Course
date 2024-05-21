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
	int sum = 0;
	int maxx = -1000;
	int start = 0, end = 0;
	for (int i = 0; i < 10; i++)
	{
		sum += arr[i];
		if (sum < 0) {
			sum = 0;
			start = end = i+1;
		}
		if (maxx < sum) {
			maxx = sum;
			end = i;
		}
	}
	cout << "max " << maxx << " start " << start << " end " << end;
	
	return 0;
}