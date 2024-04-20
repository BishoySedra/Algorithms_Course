#include <iostream>

#define speed ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);

using namespace std;

int cnt = 0;

void insertionSort(int *arr, int n) // O(n^2)
{

    for (int i = 1; i < n; i++)
    {
        int key = arr[i], j = i - 1;

        if (key >= arr[j])
        {
            cnt++;
        }

        while (key < arr[j] && j >= 0)
        {
            cnt++;
            arr[j + 1] = arr[j];
            j--;
        }

        arr[j + 1] = key;
    }
}

int main()
{
    speed;

    int arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 8, 7, 6, 5, 4, 3, 2, 1};
    int n = sizeof(arr) / sizeof(arr[0]);

    insertionSort(arr, n);

    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }

    cout << "\nComparisons: " << cnt << endl;

    return 0;
}