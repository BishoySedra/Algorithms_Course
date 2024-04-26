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

    vector<int> coins(n);

    // iterate over the coins and calculate the sum of all coins
    int brother_sum = 0;
    forN(n)
    {
        cin >> coins[i];
        brother_sum += coins[i];
    }

    // sorting the coins
    sort(interval(coins));

    int answer = 0, my_sum = 0;
    forRevN(n)
    {
        my_sum += coins[i];
        brother_sum -= coins[i];
        answer++;

        if (my_sum > brother_sum)
        {
            break;
        }
    }

    cout << answer << el;
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