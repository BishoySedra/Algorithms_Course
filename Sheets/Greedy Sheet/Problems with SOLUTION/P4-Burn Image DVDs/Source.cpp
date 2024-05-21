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
	pair<int, int>images[100];
	int ranks[100] = { 3,2,5,1,2,2,2,4,4 };
	for (int i = 0; i < 9; i++)
		images[i] = make_pair(i + 1, ranks[i]);
	
	int C = 4.5;
	int DVDs = 2;
	int S = 2;

	sort(images, images + 9, [](pair<int, int>& a, pair<int, int>& b) {return a.second > b.second; });

	int index = 0;
	while (DVDs--) {
		int tmp = C;
		cout << DVDs + 1 << endl;
		while (tmp)
		{
			tmp -= S;
			cout << images[index].first << " " << images[index].second << endl;
			index++;
		}
	}

	return 0;
}