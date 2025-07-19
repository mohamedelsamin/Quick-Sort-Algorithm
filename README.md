# Quick-Sort-Algorithm
Quick Sort Algorithm with C# 


##Pseudocode##
function QuickSort(array, low, high):
    if low < high:
        pivotIndex = Partition(array, low, high)
        QuickSort(array, low, pivotIndex - 1)   // Sort left half
        QuickSort(array, pivotIndex + 1, high) // Sort right half

function Partition(array, low, high):
    pivot = array[high]  // Choose the last element as pivot
    i = low - 1           // Index of smaller element
     for j from low to high - 1:
        if array[j] <= pivot:
            i = i + 1
            Swap array[i] and array[j]
    Swap array[i + 1] and array[high]  // Move pivot to correct position
    return i + 1

   
