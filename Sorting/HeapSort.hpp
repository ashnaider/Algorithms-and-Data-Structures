#pragma once

#include "Utility.hpp"

int Parent(int i)
{
  return i >> 1;
}


int Left(int i)
{
//  i = (i << 1);
//
//  i |= (1 << 0);
  return 2*i + 1;
}


int Right(int i)
{
//  i = (i << 1);

  return 2*i + 2;
}


void MaxHeapify(int* a, int size, int i)
{
  int l = Left(i); // 2 * i + 1
  int r = Right(i); // 2 * i + 2
  int largest = i;
  
  if (l < size && a[l] > a[i]) {
    largest = l;
  }
  if (r < size && a[r] > a[largest]) {
    largest = r;
  }
  if (largest != i) {
    Swap(a, i, largest);
    MaxHeapify(a, size, largest);
  }
}


void BuildMaxHeap(int* a, int size)
{
  for (int i = size / 2 - 1; i >= 0; --i) {
    MaxHeapify(a, size, i);
  }  
}


void HeapSort(int* a, int size, int max)
{
  BuildMaxHeap(a, size);

  for (int i = size - 1; i >= 0; --i) {
    Swap(a, 0, i);

    MaxHeapify(a, i, 0);
  }
}
