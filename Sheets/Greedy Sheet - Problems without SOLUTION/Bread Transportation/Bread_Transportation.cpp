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

    vector<int> houses(n);
    for (int i = 0; i < n; i++)
    {
        cin >> houses[i];
    }

    vector<int> prefixArray(n);
    prefixArray[0] = houses[0];

    for (int i = 1; i < n; i++)
    {
        prefixArray[i] = prefixArray[i - 1] + houses[i];
    }

    ll sum = 0;
    for (int i = 0; i < n; i++)
    {
        sum += abs(prefixArray[i]);
    }

    cout << sum << el;
}

int main()
{
    file;
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