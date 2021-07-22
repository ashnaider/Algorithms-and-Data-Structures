#pragma once

#include <iostream>
using namespace std;


template <class T>
void test_delete() {
  DoublyCircularLinkedList<int>* d = new DoublyCircularLinkedList<int>();

  int n = 10;
  for (int i = 0; i < n; ++i) {
    d->PushBack(i);
  }
  
  while (true) {

    d->Print();

    int indexToDelete = 0;

    cout << "Enter index of element to delete: ";
    cin >> indexToDelete;

    try {
      d->Delete(indexToDelete);
      if (d->Empty()) {
        d->Print();
        return;
      }
    } catch (exception& e) {
      cout << e.what() << endl;
    }
  }

  delete d;
}


template <class T>
void test_insert() {
    DoublyCircularLinkedList<int>* d = new DoublyCircularLinkedList<int>();

    int n = 10;
    for (int i = 0; i < n; ++i) {
      d->PushBack(i);
    }
    
    while (true) {
    d->Print();

    int indexToInsert = 0, elem;
    cout << "Enter index of element to insert: ";
    cin >> indexToInsert;
    cout << "Enter elem data: ";
    cin >> elem;

    try {
      d->Insert(indexToInsert, elem);
    } catch (exception& e) {
      cout << e.what() << endl;
    }
  }
    
  delete d;    
}
