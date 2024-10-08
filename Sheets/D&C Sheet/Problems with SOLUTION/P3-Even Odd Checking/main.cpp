// #include <bits/stdc++.h>

// #define boost ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);
// #define el "\n"
// #define ll long long
// #define ON(n, k) (n | (1 << k))
// #define OFF(n, k) (n & ~(1 << k))
// #define isOn(n, k) ((n >> k) & 1)
// #define isPowerOfTwo(n) n && !(n & (n - 1))
// #define file                          \
//     freopen("input.txt", "r", stdin); \
//     freopen("output.txt", "w", stdout);
// #define interval(arr) arr.begin(), arr.end()
// #define forN(n) for (int i = 0; i < n; i++)

// using namespace std;

// bool evenOddChecking(int *arr, int start, int end) // O(n)
// {

//     if (start == end)
//     {
//         if (arr[start] % 2 == 0)
//         {
//             return false;
//         }

//         return true;
//     }

//     int mid = start + (end - start) / 2;

//     int firstHalf = evenOddChecking(arr, start, mid);
//     int secondHalf = evenOddChecking(arr, mid + 1, end);

//     if (firstHalf == secondHalf)
//     {
//         return false;
//     }

//     return true;
// }

// void solve()
// {
//     int arr[] = {1, 30, 4, 300000000, 5, 8, 7, 4, 5};
//     int n = sizeof(arr) / sizeof(arr[0]);

//     int answer = evenOddChecking(arr, 0, n - 1);

//     if (answer)
//     {
//         cout << "YES" << el;
//     }
//     else
//     {
//         cout << "NO" << el;
//     }
// }

// int main()
// {
//     // file;
//     // boost;
//     // ll t;
//     // cin >> t;
//     // while (t--)
//     // {
//     //     solve();
//     // }
//     solve();
//     return 0;
// }

// =================================================================================================================================================================

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

bool evenOddChecking(vector<ll> arr, int start, int end)
{
    // step: base case
    if (start == end)
    {
        if (arr[start] & 1)
        {
            return true;
        }
        return false;
    }

    // step: divide
    int mid = start + (end - start) / 2;

    // step: conquer
    bool firstHalf = evenOddChecking(arr, start, mid);
    bool secondHalf = evenOddChecking(arr, mid + 1, end);

    // step: combine
    if (firstHalf == secondHalf)
    {
        return false;
    }
    return true;
}

void solve()
{
    int n;
    cin >> n;

    vector<ll> arr(n);

    for (int i = 0; i < n; i++)
    {
        cin >> arr[i];
    }

    bool answer = evenOddChecking(arr, 0, n - 1);

    if (answer)
    {
        cout << "Odd" << el;
    }
    else
    {
        cout << "Even" << el;
    }
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