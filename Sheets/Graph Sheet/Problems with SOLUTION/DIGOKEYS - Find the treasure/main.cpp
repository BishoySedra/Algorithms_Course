#include <bits/stdc++.h>

using namespace std;

vector<int> lvl, par;
int bfs(vector<vector<int>> v, int n)
{
    queue<int> q;
    q.push(1);

    while (!q.empty())
    {

        int top = q.front();
        if (top == n)
            return lvl[n];
        q.pop();
        for (auto k : v[top])
        {
            q.push(k);
            par[k] = top;
            lvl[k] = lvl[top] + 1;
        }
    }
    return -1;
}
int main()
{
    int tc;
    cin >> tc;
    while (tc--)
    {

        int n;
        cin >> n;
        vector<vector<int>> v(n + 1);

        lvl.resize(n + 1, 0);
        par.resize(n + 1, 0);

        for (int i = 0; i < n - 1; i++)
        {
            int m, x;
            cin >> m;
            for (int j = 0; j < m; j++)
            {
                cin >> x;
                v[i + 1].push_back(x);
            }
        }
        cout << bfs(v, n) << endl;
        par[1] = 0;
        vector<int> ans;
        while (par[n] != 0)
        {
            ans.push_back(par[n]);
            n = par[n];
        }
        reverse(ans.begin(), ans.end());
        for (auto k : ans)
            cout << k << " ";
        cout << endl;
    }
    return 0;
}