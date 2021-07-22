#pragma once

#include "Utility.hpp"


void ShellSort(int* a, int size, int max)
{
  int i, j, step;

  for (step = size / 2; step > 0; step /= 2) {
    for (i = 0; i < size - step; ++i) {
      for (j = i; j >= 0; j -= step) {
        if (a[j + step] < a[j])
          Swap(a, j, j + step);
        else j = 0;
        
      }
    }
  }
}


