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
    int A[] = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    int B[] = {10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
    int n = sizeof(A) / sizeof(A[0]);
    int m = sizeof(B) / sizeof(B[0]);

    bool answer = isCommonElementsFound(A, 0, n - 1, B, m);

    cout << (answer ? "YES" : "NO") << el;

    // another test case
    int A2[] = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    int B2[] = {10, 11, 12, 13, 14, 9, 15, 16, 17, 18, 9};
    n = sizeof(A2) / sizeof(A2[0]);
    m = sizeof(B2) / sizeof(B2[0]);

    answer = isCommonElementsFound(A2, 0, n - 1, B2, m);

    cout << (answer ? "YES" : "NO") << el;
}

int main()
{
    // file;
    boost;
    // ll t;
    // cin >> t;
    // while (t--)
    // {
    //     solve();
    // }
    solve();
    return 0;
}