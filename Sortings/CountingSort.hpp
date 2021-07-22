#pragma once

#include <iostream>
#include "Utility.hpp"
using namespace std;


void CountingSort(int* a, int size)
{
  int i;
  int max = Max(a, size);
  int min = Min(a, size);
  int range = max - min + 1;
  int c[range] = {0};
  int* b = new int[size];

  for (i = 0; i < size; ++i) 
    ++c[a[i] - min];

  for (i = 1; i <= range; ++i)
    c[i] += c[i - 1];

  for (i = size - 1; i >= 0; --i) {
    b[c[a[i] - min] - 1] = a[i];
    --c[a[i] - min];
  }

  for (i = 0; i < size; ++i)
    a[i] = b[i];
  
}

