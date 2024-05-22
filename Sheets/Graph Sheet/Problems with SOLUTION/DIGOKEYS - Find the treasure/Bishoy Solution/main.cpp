#include <bits/stdc++.h>

#define boost ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0)
#define el "\n"
#define ll long long
#define ON(n, k) (n | (1 << k))
#define OFF(n, k) (n & ~(1 << k))
#define isOn(n, k) ((n >> k) & 1)
#define isPowerOfTwo(n) n && !(n & (n - 1))
#define file                          \
    freopen("input.txt", "r", stdin); \
    freopen("output.txt", "w", stdout)
#define interval(arr) arr.begin(), arr.end()
#define forN(n) for (int i = 0; i < n; i++)

using namespace std;

map<int, vector<int>> graph;
vector<int> levels;
vector<int> parents;
map<int, bool> visited;

// function to traverse the graph using bfs
int bfs(int target)
{
    queue<int> q;
    q.push(1);

    while (!q.empty())
    {
        int top = q.front();

        visited[top] = true;

        if (top == target)
        {
            return levels[top];
        }

        q.pop();

        for (int child : graph[top])
        {
            if (visited[child])
            {
                continue;
            }

            q.push(child);
            parents[child] = top;
            levels[child] = levels[top] + 1;
            visited[child] = true;
        }
    }

    return -1;
}

void solve()
{
    int n;
    cin >> n;

    // clear the graph
    graph.clear();
    levels.clear();
    parents.clear();
    visited.clear();

    // construct the graph
    forN(n - 1)
    {
        int keysNumber;
        cin >> keysNumber;
        for (int j = 0; j < keysNumber; j++)
        {
            int key;
            cin >> key;
            graph[i + 1].push_back(key);
        }
        sort(interval(graph[i + 1]));
    }

    // initialize the levels and parents vectors
    levels.assign(n + 1, 0);
    parents.assign(n + 1, 0);

    // bfs
    int answer = bfs(n);

    if (answer == -1)
    {
        cout << answer << el;
        return;
    }

    cout << answer << el;
    // construct the path
    vector<int> path;
    while (true)
    {
        path.push_back(parents[n]);
        n = parents[n];

        if (n == 1)
        {
            // path.push_back(1);
            break;
        }
    }

    // print the path
    int pathSize = path.size();
    for (int i = pathSize - 1; i >= 0; i--)
    {
        cout << path[i] << " ";
    }

    cout << el;
}

int main()
{
    // file;
    boost;
    ll t;
    cin >> t;
    while (t--)
    {
        solve();

        cout << el;
    }
    return 0;
}
