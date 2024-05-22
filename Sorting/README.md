# Sorting Algorithms

This repository provides an overview of several popular sorting algorithms, along with their time complexities, illustrative animations, and brief descriptions of how they work. Understanding these algorithms is fundamental to grasping how data can be efficiently organized and retrieved.

## Insertion Sort

![Insertion Sort](https://upload.wikimedia.org/wikipedia/commons/9/9c/Insertion-sort-example.gif)

### Description
Insertion Sort works by building a sorted portion of the array one element at a time. It takes each element from the unsorted portion and finds its correct position in the sorted portion by comparing it with the elements already sorted.

### Time Complexity

- **Worst Case:** O(n²)
- **Best Case:** O(n)
- **Average Case:** O(n²)

## Selection Sort

![Selection Sort](https://miro.medium.com/v2/resize:fit:1100/format:webp/1*5WXRN62ddiM_Gcf4GDdCZg.gif)

### Description
Selection Sort works by repeatedly finding the minimum element from the unsorted portion and placing it at the beginning of the unsorted portion. It maintains two subarrays, the sorted subarray and the unsorted subarray.

### Time Complexity

- **Worst Case:** O(n²)
- **Average Case:** O(n²)
- **Best Case:** O(n²)

## Bubble Sort

![Bubble Sort](https://miro.medium.com/v2/resize:fit:640/format:webp/1*7seGXJi3te9beNfpAvFXEQ.gif)

### Description
Bubble Sort repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order. The pass through the list is repeated until the list is sorted. Each pass through the list moves the next largest element to its correct position.

### Time Complexity

- **Worst Case:** O(n²)
- **Average Case:** O(n²)
- **Best Case:** O(n)

## Merge Sort

![Merge Sort](https://upload.wikimedia.org/wikipedia/commons/c/cc/Merge-sort-example-300px.gif)

### Description
Merge Sort is a divide-and-conquer algorithm that divides the array into two halves, recursively sorts each half, and then merges the two sorted halves to produce the sorted array. It is efficient and guarantees O(n log n) time complexity.

### Time Complexity

- **Worst Case:** O(n log n)
- **Average Case:** O(n log n)
- **Best Case:** O(n log n)

## Quick Sort

![Quick Sort](https://upload.wikimedia.org/wikipedia/commons/6/6a/Sorting_quicksort_anim.gif)

### Description
Quick Sort is also a divide-and-conquer algorithm. It works by selecting a 'pivot' element from the array and partitioning the other elements into two subarrays according to whether they are less than or greater than the pivot. The subarrays are then sorted recursively.

### Time Complexity

- **Worst Case:** O(n²)
- **Average Case:** O(n log n)
- **Best Case:** O(n log n)

## Practice Problem

To apply and test your understanding of these sorting algorithms, try solving the following problem: [Sorting Problem on Codeforces](https://codeforces.com/group/MWSDmqGsZm/contest/219774/problem/H).

Feel free to explore and implement these algorithms in your preferred programming language, and use the problem above to check the correctness and efficiency of your implementations.
