#pragma once

#include <vector>

#include "Utility.hpp"


void SelectionSort(int* a, int size)
{
  for (int i = 0; i < size; ++i) {
    int min = 1;
    for (int j = i + 1; j < size; ++j) {
      if (a[min] > a[j]) {
        min = j;
      }
    }

    Swap(a, min, i);
  }
}


void my_selection_sort(std::vector<int>& v)
{
  for (int i = 0; i < v.size(); ++i) {
    int min = i;
    for (int j = i + 1; j < v.size(); ++j) {
      if (v[min] > v[i]) {
        min = j;
      }
    }
    std::swap(v[i], v[min]);
  }
}
