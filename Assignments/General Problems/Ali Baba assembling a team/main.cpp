// NOTE: The exact problem existed on codeforces in the following link: https://codeforces.com/problemset/problem/160/A

#include <bits/stdc++.h>

#define boost ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);
#define el "\n"
#define ll long long
#define ON(n, k) (n | (1 << k))
#define OFF(n, k) (n & ~(1 << k))
#define isOn(n, k) ((n >> k) & 1)
#define isPowerOfTwo(n) n && !(n & (n - 1))
#define file                          \
    freopen("input.txt", "r", stdin); \
    freopen("output.txt", "w", stdout);
#define interval(arr) arr.begin(), arr.end()
#define forN(n) for (int i = 0; i < n; i++)
#define forRevN(n) for (int i = n - 1; i >= 0; i--)

using namespace std;

void solve()
{
    int n;
    cin >> n;

    vector<int> thieves(n);

    // taking input
    forN(n)
    {
        cin >> thieves[i];
    }

    // getting the minimum subarray sum
    int answer = INT_MAX, sum = 0;

    forN(n)
    {
        if (sum > 0)
        {
            sum = thieves[i];
        }
        else
        {
            sum += thieves[i];
        }

        answer = min(answer, sum);
    }

    cout << answer << el;
}

int main()
{
    // file; // uncomment this line to enable file input/output
    boost;
    ll t;
    cin >> t;
    while (t--)
    {
        solve();
    }
    // solve();
    return 0;
}