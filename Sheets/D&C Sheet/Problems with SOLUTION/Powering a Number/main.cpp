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

int fastPower(int number, int power)
{
    if (power == 1)
    {
        return number;
    }

    int partial_answer = fastPower(number, power / 2);

    if (power % 2 == 0)
    {
        return partial_answer * partial_answer;
    }

    return partial_answer * partial_answer * number;
}

void solve()
{
    int number = 2, power = 3;
    cout << fastPower(number, power) << el;
}

int main()
{
    // file;
    // boost;
    // ll t;
    // cin >> t;
    // while (t--)
    // {
    //     solve();
    // }
    solve();
    return 0;
}