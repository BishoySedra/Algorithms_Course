#include <iostream>

#define speed ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);

using namespace std;

int partition(int *arr, int start, int end)
{
    int pivot = arr[start], left = start + 1, right = end;
    while (true)
    {
        if (right < left)
        {
            break;
        }

        while (left <= right && arr[left] <= pivot)
        {
            left++;
        }

        while (left <= right && arr[right] >= pivot)
        {
            right--;
        }

        if (left <= right)
        {
            swap(arr[left], arr[right]);
        }
    }

    int pivotIndex = right;

    swap(arr[start], arr[pivotIndex]);

    return pivotIndex;
}

void quickSort(int *arr, int start, int end)
{
    if (start >= end)
    {
        return;
    }

    int q = partition(arr, start, end);

    quickSort(arr, start, q - 1);
    quickSort(arr, q + 1, end);
}

int main()
{
    speed;

    int arr[] = {5, 4, 3, 2, 1};
    int n = sizeof(arr) / sizeof(arr[0]);

    quickSort(arr, 0, n - 1);

    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }

    cout << "\n";
    // another test case

    int arr2[] = {1, 2, 3, 4, 5, -1, -100000};
    int n2 = sizeof(arr2) / sizeof(arr2[0]);

    quickSort(arr2, 0, n2 - 1);

    for (int i = 0; i < n2; i++)
    {
        cout << arr2[i] << " ";
    }

    return 0;
}