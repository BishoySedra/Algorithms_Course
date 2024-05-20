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
    int n, m, a, b;
    cin >> n >> m >> a >> b;

    vector<int> nums;
    nums.push_back(n);

    // looping until reaching out the value of m or n/2 < m
    while (n >= m) // O(log(n))
    {

        if (n / 2 < m)
        {
            break;
        }

        n /= 2;
        nums.push_back(n);
    }

    int vectorSize = nums.size(), answer = 0;
    for (int i = 1; i < vectorSize; i++) // O(log(n))
    {
        // calculating the cost of reducing the units by one unit
        int cost1 = (nums[i - 1] - nums[i]) * b;

        // calculating the cost of reducing the units by half
        int cost2 = a;

        // minimizing the cost
        answer += min(cost1, cost2);
    }

    // calculating the cost of the last element with the value of m
    int cost1 = (nums[vectorSize - 1] - m) * b;
    int cost2 = a;

    answer += min(cost1, cost2);

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