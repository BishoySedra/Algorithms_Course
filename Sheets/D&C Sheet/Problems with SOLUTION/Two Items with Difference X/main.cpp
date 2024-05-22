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

void merge(int *arr, int start_1, int end_1, int start_2, int end_2)
{
    int size_1 = (end_1 - start_1) + 1;
    int size_2 = (end_2 - start_2) + 1;

    int *mergedArray = new int[size_1 + size_2];

    int index_1 = start_1, index_2 = start_2, readyIndex = 0;
    while (index_1 <= end_1 && index_2 <= end_2)
    {
        if (arr[index_1] < arr[index_2])
        {
            mergedArray[readyIndex++] = arr[index_1++];
            continue;
        }

        mergedArray[readyIndex++] = arr[index_2++];
    }

    // if the first half still has some elements
    while (index_1 <= end_1)
    {
        mergedArray[readyIndex++] = arr[index_1++];
    }

    // if the second half still has some elements
    while (index_2 <= end_2)
    {
        mergedArray[readyIndex++] = arr[index_2++];
    }

    // store the merged array elements to the original array
    for (int i = 0; i < (size_1 + size_2); i++)
    {
        arr[start_1 + i] = mergedArray[i];
    }
}

void mergeSort(int *arr, int start, int end)
{
    if (start >= end)
    {
        return;
    }

    // divide
    int mid = start + (end - start) / 2;

    // conquer
    mergeSort(arr, start, mid);
    mergeSort(arr, mid + 1, end);

    // do the merging after dividing
    merge(arr, start, mid, mid + 1, end);
}

int binarySearch(int *arr, int start, int end, int target)
{
    if (start >= end)
    {
        return start;
    }

    int mid = start + (end - start) / 2;

    if (target == arr[mid])
    {
        return mid;
    }

    if (arr[mid] > target)
    {
        return binarySearch(arr, start, mid, target);
    }

    return binarySearch(arr, mid + 1, end, target);
}

void getTwoItemsWithDiffX(int *arr, int size, int targetDiff)
{
    // sort the array using merge sort
    mergeSort(arr, 0, size - 1);

    // iterate over the array
    for (int i = 0; i < size; i++)
    {
        int diff = targetDiff + arr[i];
        int foundIndex = binarySearch(arr, i, size - 1, diff);

        if (diff == arr[foundIndex])
        {
            cout << "YES" << el;
            cout << arr[foundIndex] << " - " << arr[i] << el;
            return;
        }
    }

    cout << "NO" << el;
}

void solve()
{
    int arr[] = {-7, -2, 5, -3, 8};
    int n = sizeof(arr) / sizeof(arr[0]);
    int X = 4;

    getTwoItemsWithDiffX(arr, n, X);

    int arr2[] = {-10, 4, -5, 9, 8};
    n = sizeof(arr2) / sizeof(arr2[0]);
    X = 2;

    getTwoItemsWithDiffX(arr2, n, X);

    // cout << el;
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