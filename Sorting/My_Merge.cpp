#include <iostream>
#include <algorithm>
#include <unordered_map>
#include <vector>

#define speed ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);
#define el "\n"
#define ll long long
#define tc       \
    long long t; \
    cin >> t;    \
    while (t--)
#define ON(n, k) (n | (1 << k))
#define OFF(n, k) (n & ~(1 << k))
#define isOn(n, k) ((n >> k) & 1)
#define isPowerOfTwo(n) n && !(n & (n - 1))

using namespace std;

// merge two sorted arrays
void merge(int *a, int sizeA, int *b, int sizeB) // O(sizeA + sizeB)
{

    int *target = new int[sizeA + sizeB];
    int idxA = 0, idxB = 0, idxC = 0;

    while (idxA < sizeA && idxB < sizeB)
    {
        target[idxC++] = ((a[idxA] < b[idxB]) ? a[idxA++] : b[idxB++]);
    }

    while (idxA < sizeA)
    {
        target[idxC++] = a[idxA++];
    }

    while (idxB < sizeB)
    {
        target[idxC++] = b[idxB++];
    }

    // to use with mergeSort function
    for (int i = 0; i < sizeA + sizeB; i++)
    {
        // a[i] = target[i];
        // to print directly after sorting
        cout << target[i] << " ";
    }

    delete[] target;
}

// testing merge function
void testMerge()
{
    int arr1[] = {1, 2, 3, 4, 5, 6, 8};
    int arr2[] = {6, 7, 8, 9, 10, 11, 20};

    int sz1 = sizeof(arr1) / sizeof(arr1[0]);
    int sz2 = sizeof(arr2) / sizeof(arr2[0]);

    merge(arr1, sz1, arr2, sz2);
}

// divide & conquer algo to sort using merge
void mergeSort(int *arr, int n) // O( n log(n) ) => tree height = log(n) and operations in each level = n;
{
    if (n < 2)
    {
        return;
    }

    int half = n / 2;

    mergeSort(arr, half);                   // sorts the first half
    mergeSort(arr + half, n - half);        // sorts the second half
    merge(arr, half, arr + half, n - half); // combines two sorted array into one array
}

// testing mergeSort
void testMergeSort()
{
    int n;
    cin >> n;
    int *arr = new int[n];
    for (int i = 0; i < n; i++)
    {
        cin >> arr[i];
    }

    mergeSort(arr, n);

    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }
}

// solve pair-sum problem in O(n)
void pairSumProblemSolve() // O(n)
{
    int n, target;
    cin >> n >> target;
    int *arr = new int[n];
    unordered_map<int, int> freq;

    for (int i = 0; i < n; i++)
    {
        cin >> arr[i];
        freq[arr[i]] = true;
    }

    for (int i = 0; i < n; i++)
    {
        int rem = target - arr[i];
        if ((rem == arr[i] && freq[rem] > 1) || (rem != arr[i] && freq[rem]))
        {
            cout << rem << el;
            cout << "YES";
            return;
        }
    }

    cout << "No";
}

// solve pair of topics problem
void pairOfTopicsProblemSolve()
{
    ll n, num;
    cin >> n;

    vector<ll> a(n);

    for (int i = 0; i < n; i++)
    {
        cin >> a[i];
    }

    for (int i = 0; i < n; i++)
    {
        cin >> num;
        a[i] -= num;
    }

    sort(a.begin(), a.end());

    ll cnt = 0;

    for (int i = 0; i < n; i++)
    {
        auto it = upper_bound(a.begin() + i + 1, a.end(), -a[i]);
        cnt += a.begin() + n - it;
    }

    cout << cnt;
}

// testing unique built-in function
void uniqueFunction()
{
    int arr[] = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};
    int size = sizeof arr / sizeof arr[0];

    auto it = unique(arr, arr + size); // O(n)
    size = it - arr;                   // new size of unique values in the array

    sort(arr, arr + size); // O(n*log(n))

    cout << size << el;
    for (int i = 0; i < size; i++)
    {
        cout << arr[i] << " ";
    }
}

// sort array using comparator function
bool comparator(int first, int second)
{
    return first > second;

    // if (first > second)
    // {
    //     return true; // do nothing
    // }
    // else
    // {
    //     return false; // do swapping
    // }
}

bool oddBeforeEven(int first, int second)
{
    return (first & 1) && !(second & 1) || (first & 1) == (second & 1);

    // if ((first & 1) && !(second & 1) || (first & 1) == (second & 1))
    // {
    //     return true; // do nothing
    // }
    // else
    // {
    //     return false; // do swapping
    // }
}

void mySort()
{
    int arr[] = {4, 3, 2, 5, 7};
    int size = sizeof arr / sizeof arr[0];

    // sort(arr, arr + size, comparator);
    sort(arr, arr + size, oddBeforeEven);

    for (auto elem : arr)
    {
        cout << elem << " ";
    }
}

int main()
{
    speed;
    // mySort();
    testMergeSort();
    return 0;
}