#include <bits/stdc++.h>

using namespace std;

vector<int> lvl, par;
vector<bool> vis;
int bfs(vector<vector<int>> v, int n)
{
    queue<int> q;
    q.push(1);
    lvl[1] = 0;
    par[1] = 0;
    vis[1] = 1;
    while (!q.empty())
    {

        int top = q.front();
        if (top == n)
            return lvl[n];
        q.pop();
        for (auto k : v[top])
        {
            if (vis[k])
                continue;
            q.push(k);
            par[k] = top;
            lvl[k] = lvl[top] + 1;
            vis[k] = 1;
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

        vis.assign(n + 1, false);
        lvl.assign(n + 1, 0);
        par.assign(n + 1, 0);

        for (int i = 0; i < n - 1; i++)
        {
            int m, x;
            cin >> m;
            for (int j = 0; j < m; j++)
            {
                cin >> x;
                v[i + 1].push_back(x);
            }
            sort(v[i + 1].begin(), v[i + 1].end());
        }
        int res = bfs(v, n);
        if (res == -1)
        {
            cout << -1 << endl;
            continue;
        }

        cout << res << endl;
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
    cout << endl;
    return 0;
}