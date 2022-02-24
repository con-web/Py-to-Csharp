def swap(array: list[int], index1: int, index2: int) -> None:
    array[index1], array[index2] = array[index2], array[index1]


def sort_by_pivot(array: list[int], left_index: int, right_index: int) -> int:
    pivot_index: int = right_index
    swap_to_index: int = left_index - 1

    for loop_index in range(left_index, right_index):
        if array[loop_index] <= array[pivot_index]:
            swap_to_index += 1
            swap(array, loop_index, swap_to_index)

    new_pivot_index: int = swap_to_index + 1  # new_pivot_index is the position right from the last item swapped
    swap(array, pivot_index, new_pivot_index)  # move pivot item to the appropriate position

    return new_pivot_index


def divide_and_sort(array: list[int], left_index: int, right_index: int) -> None:
    if left_index < right_index:
        pivot: int = sort_by_pivot(array, left_index, right_index)

        divide_and_sort(array, left_index, pivot - 1)
        divide_and_sort(array, pivot + 1, right_index)


def quick_sort(array: list[int]) -> None:
    divide_and_sort(array, 0, len(array) - 1)


test_data: list[int] = [2, 0, 75, 64, 30, 20, 93, 8, 28, 44, ]
quick_sort(test_data)
print(test_data)
