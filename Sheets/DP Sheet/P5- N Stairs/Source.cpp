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
int dp[100];

// T(N-1) + T(N-2) + T(N-3) + O(1) // distinct numbers 
// 1  -> N 
// O(N)  + overhead
int stairs(int N) {
	if (N == 0)
		return dp[N] = 1;
	if (N < 0)
		return dp[N] = 0;
	if (dp[N] != 0)
		return dp[N];
	dp[N - 1] = stairs(N - 1);
	dp[N - 2] = stairs(N - 2);
	dp[N - 3] = stairs(N - 3);
	return dp[N - 1] + dp[N - 2] + dp[N - 3];
}
//bottom up
int stairs2(int N) {
	dp[0] = 1;
	for (int i = 1; i <= N; i++) // O(N)
	{
		if (i - 1 >= 0)
			dp[i] += dp[i - 1];
		if (i - 2 >= 0)
			dp[i] += dp[i - 2];
		if(i - 3 >= 0)
			dp[i] += dp[i - 3];
	}
	return dp[N];
}


int main() {
	cout << stairs2(4);
	return 0;
}
