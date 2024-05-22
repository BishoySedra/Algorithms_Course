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

bool areEquivalentStrings(string a, string b)
{
    if (a == b)
    {
        return true;
    }

    if (a.size() & 1)
    {
        return false;
    }

    string a1 = a.substr(0, a.size() / 2);
    string a2 = a.substr(a.size() / 2, a.size());
    string b1 = b.substr(0, b.size() / 2);
    string b2 = b.substr(b.size() / 2, b.size());

    return (areEquivalentStrings(a1, b1) && areEquivalentStrings(a2, b2)) || (areEquivalentStrings(a2, b1) && areEquivalentStrings(a1, b2));
}

void solve()
{
    string word1, word2;
    word1 = "aaba";
    word2 = "abaa";
    bool answer = areEquivalentStrings(word1, word2);
    cout << (answer ? "YES" : "NO") << el;

    // another test case
    word1 = "aabb";
    word2 = "abab";
    answer = areEquivalentStrings(word1, word2);
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