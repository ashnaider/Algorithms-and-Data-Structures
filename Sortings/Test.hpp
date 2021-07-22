#pragma once

#include <ctime>
#include <cstdlib>
#include <iostream>
#include <chrono>
#include <vector>

#include "RadixSort.hpp"
#include "ShellSort.hpp"
#include "HeapSort.hpp"

using namespace std;

void GenerateArray(int* arr1, int* arr2, int* arr3, int size, int min, int max)
{
  int t;
  int range = max - min;

  srand(time(NULL));

  for (int i = 0; i < size; ++i) {
    t = rand() % range + min;
    arr1[i] = t;
    arr2[i] = t;
    arr3[i] = t;
  }

}


void GenerateArray(int* arr1, int size, int min, int max)
{
  int t;
  int range = max - min;

  srand(time(NULL));

  for (int i = 0; i < size; ++i) {
    t = rand() % range + min;
    arr1[i] = t;
  }

}


void GenerateVec(std::vector<int>& v, int min, int max)
{
  int t;
  int range = max - min;

  srand(time(NULL));

  for (int i = 0; i < v.size(); ++i) {
    t = rand() % range + min;
    v[i] = t;
  }

}

void GenerateDescendingArr(int* arr1, int* arr2, int* arr3, int size)
{
  for (int i = size - 1; i >= 0; --i) {
    int t = (i + 1) * 10;
    arr1[i] = t;
    arr2[i] = t;
    arr3[i] = t;
  }
}


bool IsArrAscending(const int* arr, int size)
{
  int prev = arr[0];
  for (int i = 1; i < size; ++i) {
    if (arr[i] >= prev) 
      prev = arr[i];
    else 
      return false;
  }
  
  return true;
}


double AlgoTime(void (*f)(int* arr, int size), int* arr, int size) {
  
  clock_t begin = clock();
  
  f(arr, size);
  
  clock_t end = clock();
  
  return (double)(end - begin) / CLOCKS_PER_SEC;
}


double AlgoTimeWithChrono(void (*f)(int* arr, int size, int max), int* arr, int size, int max) {

  auto start = std::chrono::steady_clock::now();
  f(arr, size, max);
  auto end = std::chrono::steady_clock::now();
  
  std::chrono::duration<double> elapsed_seconds = end-start;
  
  return elapsed_seconds.count();
}


void TestAlgos(int size)
{
  int* arr1 = new int[size];
  int* arr2 = new int[size];
  int* arr3 = new int[size];
  
  GenerateArray(arr1, arr2, arr3, size, 0, size * 10);

  // double RadixSortTime = AlgoTime(RadixSort, arr1, size);
  // double ShellSortTime = AlgoTime(ShellSort, arr2, size);
  // double HeapSortTime = AlgoTime(HeapSort, arr3, size);

  int max = Max(arr1, size);

  double RadixSortTime = AlgoTimeWithChrono(RadixSort, arr1, size, max);
  double ShellSortTime = AlgoTimeWithChrono(ShellSort, arr2, size, max);
  double HeapSortTime = AlgoTimeWithChrono(HeapSort, arr3, size, max);


  if (IsArrAscending(arr1, size)) {
    if (IsArrAscending(arr2, size)) {
      if (IsArrAscending(arr3, size)) {
        cout << "All are sorted!" << endl;
      } else {
        cout << "Error, heap not sorted!" << endl;
      }
    } else {
      cout << "Error, shell not sorted!" << endl;
    }
  } else {
    cout << "Error, radix not sorted!" << endl;
  }

  cout << "Number of elements: " << size << "\n";
  cout << "\tRadixSort time: " << RadixSortTime << endl;
  cout << "\tShellSort time: " << ShellSortTime << endl;
  cout << "\tHeapSort  time: " << HeapSortTime << endl;

  delete [] arr1;
  delete [] arr2;
  delete [] arr3;
}
