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
bool dp[100][100] = {};
bool sumcheck(int a[], int N, int T) {
	if (N == 0)
		return false;

	if (dp[N][T] != 0)
		return dp[N][T];
	if (a[N - 1] < T)
		return dp[N][T] = sumcheck(a, N - 1, T) || sumcheck(a, N - 1, T - a[N - 1]);
	if (a[N - 1] > T)
		return dp[N][T] = sumcheck(a, N - 1, T);
	return dp[N][T] = true;
}

//bottom up
bool sumcheck2(int a[], int N, int T) {
	for (int i = 0; i <= N; i++)
	{
		for (int j = 0; j <= T; j++)
		{
			if (i == 0 || j == 0)
				dp[i][j] = false;
			if (a[i] == j)
				dp[i][j] = true;
			else if (a[i] < j) {
				bool take, leave;
				take = dp[i - 1][j - a[i]];
				leave = dp[i - 1][j];
				dp[i][j] = take || leave;
			}
			else
				dp[i][j] = dp[i - 1][j];
		}
	}
	return dp[N][T];
}

int main() {
	int A[100] = { 1,1,3,4 };
	//int A[100] = { 4,1,3,4 };
	int B = 2;
	int N = 4;
	cout << sumcheck2(A, N, B);
	return 0;
}