#include <iostream>
#include <vector>

#include "Test.hpp"
using namespace std;

#define in :

template<class T>
void PrintArr(const T* arr, int size);

void PrintVec(vector<int>& v);


int main() {
  int size1 = 10000;
  int size2 = 150000;
  int size3 = 10000000;

  TestAlgos(size1);
  cout << "\n";

  TestAlgos(size2);
  cout << "\n";

  TestAlgos(size3);
  cout << "\n";
  
  cout << "Ok" << endl;
  return 0;
} 


template<class T>
void PrintArr(const T* arr, int size)
{
  for (int i = 0; i < size; ++i) {
    printf("%4d ", arr[i]);
  }
  cout << endl;
}


void PrintVec(vector<int>& v) {
  for (int i in v) {
      cout << i << " ";
  }
  cout << endl;
}
