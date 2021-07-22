#pragma once

#include <cmath>


template<class T>
T Max(const T* arr, int size)
{
  T max = arr[0];
  for (int i = 1; i < size; ++i) {
    if (arr[i] > max) {
      max = arr[i];
    }
  }

  return max;
}


template<class T>
T Min(const T* arr, int size)
{
  T min = arr[0];
  for (int i = 1; i < size; ++i) {
    if (arr[i] < min) {
      min = arr[i];
    }
  }

  return min;
}


int Rank(int num)
{
  int res = 1; 
  while (true) {
    num /= 10;
    if (num != 0) 
      ++res;
    else break;
  }
  return res;
}


int RankDigit(int num, int rank) {
  int c = 1;
  if (num < 0) {
    num *= -1;
    c = -1;
  }

  int t = num / pow(10, rank - 1);
  return (t % 10) * c;
}


void Swap(int* a, int i, int j)
{
  int t;
  t = a[i];
  a[i] = a[j];
  a[j] = t;
}

