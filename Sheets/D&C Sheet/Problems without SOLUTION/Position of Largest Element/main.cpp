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

int indexOfLargestElement(int *arr, int start, int end, int maxNumber, int targetIndex)
{
    if (start >= end)
    {
        if (arr[start] > maxNumber)
        {
            // cout << "Max number: " << arr[start] << el;
            return start;
        }

        if (arr[end] > maxNumber)
        {
            // cout << "Max number: " << arr[end] << el;
            return end;
        }

        // cout << "Max number: " << arr[targetIndex] << el;
        // cout << "maxNumber: " << maxNumber << el;
        return targetIndex;
    }

    int mid = start + (end - start) / 2;

    if (arr[mid] > maxNumber)
    {
        targetIndex = mid;
        maxNumber = arr[mid];
    }

    int firstHalf = indexOfLargestElement(arr, start, mid - 1, maxNumber, targetIndex);
    int secondHalf = indexOfLargestElement(arr, mid + 1, end, maxNumber, targetIndex);

    return arr[firstHalf] > arr[secondHalf] ? firstHalf : secondHalf;
}

void solve()
{
    int arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    int n = sizeof(arr) / sizeof(arr[0]);
    cout << indexOfLargestElement(arr, 0, n - 1, INT_MIN, -1) << el;

    // another test case
    int arr2[] = {1, 2, 3, 10, 4, 5, 6, 7, 8, 9};
    int m = sizeof(arr2) / sizeof(arr2[0]);
    cout << indexOfLargestElement(arr2, 0, m - 1, INT_MIN, -1) << el;
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