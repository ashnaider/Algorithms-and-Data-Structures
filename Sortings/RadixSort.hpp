#pragma once

#include "Utility.hpp"


void CountingSortByRank(int* a, int size, int rank, int max);


void RadixSort(int* a, int size, int max)
{
  int k = Rank(max);
  int m = 10;

  for (int i = 1; i <= k; ++i) {
    CountingSortByRank(a, size, i, m);
  }
}


void CountingSortByRank(int* a, int size, int rank, int max)
{
  int i, t, min = -10;
  int range = max - min + 1;
  int c[range] = {0};
  int* b = new int[size];

  for (i = 0; i < size; ++i) {
    t = RankDigit(a[i], rank); 
    ++c[t - min];
  }

  for (i = 1; i <= range; ++i)
    c[i] += c[i - 1];

  for (i = size - 1; i >= 0; --i) {
    t = RankDigit(a[i], rank); 
    b[c[t - min] - 1] = a[i];
    --c[t - min];
  }

  for (i = 0; i < size; ++i)
    a[i] = b[i];

  delete [] b;
}










// void CountingSortByRank(int* a, int size, int rank, int max)
// {
//   int i, t, min = -10;
//   int c[max + 1] = {0};
//   int* b = new int[size];

//   for (i = 0; i < size; ++i) {
//     t = RankDigit(a[i], rank); 
//     ++c[t];
//   }

//   for (i = 1; i <= max; ++i)
//     c[i] += c[i - 1];

//   for (i = size - 1; i >= 0; --i) {
//     t = RankDigit(a[i], rank); 
//     b[c[t] - 1] = a[i];
//     --c[t];
//   }

//   for (i = 0; i < size; ++i)
//     a[i] = b[i];
// }
