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

int unimodal_search(vector<int> arr, int start, int end)
{
    // step: base case
    if (start == end)
    {
        return arr[start];
    }

    // step: divide
    int mid = start + (end - start) / 2;

    // step: check if mid is the peak
    if (arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1])
    {
        return arr[mid];
    }
    else if (arr[mid] > arr[mid - 1] && arr[mid] < arr[mid + 1])
    {
        return unimodal_search(arr, mid + 1, end);
    }
    else
    {
        return unimodal_search(arr, start, mid - 1);
    }
}

void solve()
{
    int n;
    cin >> n;

    vector<int> arr(n);

    for (int i = 0; i < n; i++)
    {
        cin >> arr[i];
    }

    cout << unimodal_search(arr, 0, n - 1) << el;
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