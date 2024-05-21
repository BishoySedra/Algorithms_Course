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
	int coins[5] = { 25,10,5,1 }; // n => O(n) || const => O(1)

	int n = 30;
	int cnt = 0;
	for (int i = 0; i < 4; i++)
	{
		cnt += n / coins[i];
		n %= coins[i];
	}
	cout << cnt;
	return 0;
}