#include <iostream>

#define speed ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);

using namespace std;

// int cnt = 0;

void selectionSort(int *arr, int n) // O(n^2) worst & best case
{
    // iterate through the array
    for (int i = 0; i < n; i++)
    {
        // iterate through the unsorted array to find the minimum element
        int temp = arr[i], swapIndex = i, minElement = arr[i];
        for (int j = i + 1; j < n; j++)
        {
            // check if the element is less than the current element
            if (arr[j] <= minElement)
            {
                minElement = arr[j];
                swapIndex = j;
            }
        }

        if (swapIndex != i)
        {
            arr[i] = minElement;
            arr[swapIndex] = temp;
        }
    }
}

int main()
{
    speed;

    int arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 8, 7, 6, 5, 4, 3, 2, 1};
    int n = sizeof(arr) / sizeof(arr[0]);

    selectionSort(arr, n);

    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }

    // cout << "\nComparisons: " << cnt << endl;

    return 0;
}