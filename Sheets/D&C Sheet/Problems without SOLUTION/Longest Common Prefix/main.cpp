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

string getThePrefix(string w1, string w2)
{
    string result = "";

    int size = w1.size();

    if (w2.size() < size)
    {
        size = w2.size();
    }

    for (int i = 0; i < size; i++)
    {
        if (w1[i] == w2[i])
        {
            result += w1[i];
            continue;
        }

        break;
    }

    return result;
}

string LCP(string *words, int start, int end)
{
    // base case
    if (start >= end)
    {
        return words[start];
    }

    // divide
    int mid = start + (end - start) / 2;
    string w1 = LCP(words, start, mid);
    string w2 = LCP(words, mid + 1, end);

    // conquer
    return getThePrefix(w1, w2);
}

void solve()
{
    string words[] = {"geeksforgeeks", "geeks", "geek", "geezer"};
    int size = sizeof words / sizeof words[0];
    string result = LCP(words, 0, size - 1);
    cout << result << "\n";

    string words_1[] = {"apple", "ape", "april"};
    size = sizeof words_1 / sizeof words_1[0];
    result = LCP(words_1, 0, size - 1);
    cout << result << "\n";

    string words_2[] = {"bishoysedrasabersedra", "bishoysedrasaber"};
    size = sizeof words_2 / sizeof words_2[0];
    result = LCP(words_2, 0, size - 1);
    cout << result << "\n";
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