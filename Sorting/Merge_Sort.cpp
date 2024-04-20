#include <iostream>

#define speed ios_base::sync_with_stdio(0), cin.tie(0), cout.tie(0);

using namespace std;

void merge(double *arr, int start_1, int end_1, int start_2, int end_2)
{
    int n1 = end_1 - start_1 + 1;
    int n2 = end_2 - start_2 + 1;

    double *temp = new double[n1 + n2];

    int i = start_1, j = start_2, k = 0;

    while (i <= end_1 && j <= end_2)
    {
        if (arr[i] < arr[j])
        {
            temp[k++] = arr[i++];
            continue;
        }

        temp[k++] = arr[j++];
    }

    while (i <= end_1)
    {
        temp[k++] = arr[i++];
    }

    while (j <= end_2)
    {
        temp[k++] = arr[j++];
    }

    for (int i = 0; i < n1 + n2; i++)
    {
        arr[start_1 + i] = temp[i];
    }
}

void merge_sort(double *arr, int start, int end)
{
    if (start >= end)
    {
        return;
    }

    int mid = start + (end - start) / 2;

    merge_sort(arr, start, mid);
    merge_sort(arr, mid + 1, end);

    merge(arr, start, mid, mid + 1, end);
}

int main()
{
    speed;

    // int arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 8, 7, 6, 5, 4, 3, 2, 1, 9};
    double arr[] = {1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8, 8.8, 7.7, 6.6, 5.5, 4.4, 3.3, 2.2, 1.1, 9.9};
    int n = sizeof(arr) / sizeof(arr[0]);

    merge_sort(arr, 0, n - 1);

    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }

    // cout << "\nComparisons: " << cnt << endl;

    return 0;
}