#include <iostream>

#define speed ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);

using namespace std;

// int cnt = 0;

void bubbleSort(int *arr, int n) // O(n^2) average & worst case, O(n) best
{
    // iterate through the array

    int i = 0;
    bool swapped = false;
    while (true)
    {
        // check the two adjacent elements
        if (arr[i] > arr[i + 1])
        {
            int temp = arr[i];
            arr[i] = arr[i + 1];
            arr[i + 1] = temp;

            swapped = true;
        }

        i++;

        // reaching the end of the array
        if (i == n - 1)
        {
            if (swapped == false)
            {
                break;
            }
            swapped = false;
            i = 0;
        }
    }
}

int main()
{
    speed;

    int arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 8, 7, 6, 5, 4, 3, 2, 1};
    int n = sizeof(arr) / sizeof(arr[0]);

    bubbleSort(arr, n);

    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }

    // cout << "\nComparisons: " << cnt << endl;

    return 0;
}