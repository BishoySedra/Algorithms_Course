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

// function to check if common elements are present in A and B O(mlgn)
bool isCommonElementsFound(int *A, int startA, int endA, int *B, int m)
{
    if (startA > endA)
    {
        return false;
    }

    int midA = startA + (endA - startA) / 2;

    forN(m)
    {
        if (B[i] == A[midA])
        {
            return true;
        }
    }

    return isCommonElementsFound(A, startA, midA - 1, B, m) || isCommonElementsFound(A, midA + 1, endA, B, m);
}

void solve()
{
    int n, m;
    cin >> n >> m;
    int *A = new int[n];
    int *B = new int[m];

    forN(n)
    {
        cin >> A[i];
    }

    forN(m)
    {
        cin >> B[i];
    }

    cout << (isCommonElementsFound(A, 0, n - 1, B, m) ? "Yes" : "No") << el;
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