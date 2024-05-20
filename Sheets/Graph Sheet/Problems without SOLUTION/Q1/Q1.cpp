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

using namespace std;

void solve()
{
    ll a, b;
    cin >> a >> b;

    stack<ll> numbers;
    while (b != a)
    {

        if (b < a)
        {
            // cout << "NO" << el;
            cout << -1 << el;
            return;
        }

        numbers.push(b);

        // if b is even
        if (!(b & 1))
        {
            b /= 2;
            continue;
        }

        // if last bit is 1
        if (b % 10 == 1)
        {
            b /= 10;
            continue;
        }

        // cout << "NO" << el;
        cout << -1 << el;
        return;
    }

    numbers.push(a);

    cout << 1 << el;
    // cout << "YES" << el;
    // cout << numbers.size() << el;
    // while (!numbers.empty())
    // {
    //     cout << numbers.top() << " ";
    //     numbers.pop();
    // }
    // cout << el;
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