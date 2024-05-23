#include <iostream>
#include <math.h>
#include<queue>
#include <algorithm> 
#include <map>
#include <math.h>
#include <stack>

using namespace std;
#define ll long long

//top down 
int dp[100][100];
int knap(int wm, int index, int w[], int v[]) {
	if (index == 4 || wm == 0) {
		return 0;
	}
	if (dp[wm][index] != 0)
		return dp[wm][index];
	if (w[index] > wm)
	{
		// must leave
		return dp[wm][index] = knap(wm, index + 1, w, v);
	}
	int take = knap(wm - w[index], index + 1, w, v) + v[index];
	int leave = knap(wm, index + 1, w, v);
	return dp[wm][index] = max(take, leave);
}

// bottom up  O(wm * index) => O(N*W);
int knap2(int wm, int index, int w[], int v[]) {
	// start , end , dp[wm][index]
	for (int i = 0; i <= wm; i++) // wm 0 1 2 3 4 5 6
	{
		for (int j = 0; j <= index; j++) // index 0 1 2 3 4
		{
			if (j == 0 || i == 0)
				dp[i][j] = 0;
			else if (w[j - 1] > i) {
				dp[i][j] = dp[i][j - 1];
			}
			else {
				int take = dp[i - w[j - 1]][j - 1] + v[j - 1];
				int leave = dp[i][j - 1];
				dp[i][j] = max(take, leave);
			}
		}
	}
	return dp[wm][index];
}

int main() {
	int w[100] = { 2,3,4,5 };
	int v[100] = { 3,4,5,6 };
	int C = 5;
	cout << knap2(C, 4, w, v);
	return 0;
}