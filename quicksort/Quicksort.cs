void Swap(int[] array, int index1, int index2){
    (array[index1], array[index2]) = (array[index2], array[index1]);
}

int SortByPivot(int[] array, int leftIndex, int rightIndex){
    int pivotIndex = rightIndex;
    int swapToIndex = leftIndex - 1;

    for (int loopIndex = leftIndex; loopIndex < rightIndex; loopIndex++) {
        if (array[loopIndex] <= array[pivotIndex]){
            swapToIndex += 1;
            Swap(array, loopIndex, swapToIndex);
        }
    }

    int newPivotIndex = swapToIndex + 1;
    Swap(array, pivotIndex, newPivotIndex);

    return newPivotIndex;
}

void DivideAndSort(int[] array, int leftIndex, int rightIndex) {
    if (leftIndex < rightIndex) {
        int pivot = SortByPivot(array, leftIndex, rightIndex);

        DivideAndSort(array, leftIndex, pivot - 1);
        DivideAndSort(array, pivot + 1, rightIndex);
    }
}

void QuickSort(int[] array) {
    DivideAndSort(array, 0, (array.Length) - 1);
}


int[] testData = {2, 0, 75, 64, 30, 20, 93, 8, 28, 44, };
QuickSort(testData);
Array.ForEach(testData, Console.WriteLine);
