#include <iostream>

#define speed ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);

using namespace std;

void selection_sort(int *arr, int size)
{
    for (int i = 0; i < size; i++)
    {
        int index = i;

        for (int j = i + 1; j < size; j++)
        {
            if (arr[j] < arr[index])
            {
                index = j;
            }
        }

        swap(arr[i], arr[index]);
    }
}

void bubble_sort(int *arr, int size)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = i + 1; j < size; j++)
        {
            if (arr[i] > arr[j])
            {
                swap(arr[i], arr[j]);
            }
        }
    }
}

int main()
{
    speed;
    int n;
    cin >> n;
    int *arr = new int[n];

    for (int i = 0; i < n; i++)
    {
        cin >> arr[i];
    }

    selection_sort(arr, n);
    // bubble_sort(arr, n);

    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }

    return 0;
}