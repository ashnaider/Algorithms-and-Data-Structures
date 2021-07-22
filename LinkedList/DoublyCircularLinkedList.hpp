#pragma once

#include <iostream>

#include "Node.hpp"


template <class T>
class DoublyCircularLinkedList {
public:

  ~DoublyCircularLinkedList();
  
  void CreateList(T data);
  
  void PushBack(T data);

  void PushFront(T data);

  void Insert(int i, T data);

  void Insert(Node<T>* curr, T data);

  T Delete(int i);

  T Delete(Node<T>* curr);

  T DeleteFirst();

  T DeleteLast();

  T GetDataByIndex(int n) const;

  void Clear();
  
  bool Empty() const {
    return 0 == count;
  }
  
  int Count() const {
    return this->count;
  }
  
  T Last() const {
    if (nullptr == tail) {
      throw std::length_error("List is empty. Unable to read last element!");
    }
    return this->tail->data;
  }

  T Front() const {
    if (nullptr == head) {
      throw std::length_error("List is empty. Unable to read first element!");      
    }
    return this->head->data;
  }
  
  void Print(char separator=' ') const;
  
private:
  Node<T>* GetElemByIndex(int n) const;
  
  Node<T>* head = nullptr;
  Node<T>* tail = nullptr;

  int count = 0;
};



template <class T>
void DoublyCircularLinkedList<T>::CreateList(T data) {
  head = new Node<T>(data);
  
  head->next = head;
  head->prev = head;

  tail = head;
  
  tail->next = tail;
  tail->prev = tail;

  ++count;
}


template <class T>
void DoublyCircularLinkedList<T>::PushBack(T data) {
  if (0 == count) {

    CreateList(data);

  } else {

    tail->next = new Node<T>(data);
    tail->next->prev = tail;
    tail = tail->next;
    tail->next = head;

    ++count;
  }
}


template <class T>
void DoublyCircularLinkedList<T>::PushFront(T data) {
  if (0 == count) {

    CreateList(data);
      
  } else {

    head->prev = new Node<T>(data);
    head->prev->next = head;
    head = head->prev;
    head->prev = tail;
    
    ++count;
  }
}


template <class T>
T DoublyCircularLinkedList<T>::DeleteFirst() {
  // std::cout << "In deleteFirst" << std::endl;
  if (0 == count) {
    throw std::out_of_range("Unable to delete first element. List is empty!");
  }
  
  T pop;
  if (1 == count) {
    pop = head->data;
    
    delete head;
    head = tail = nullptr;
  }
  else {
    pop = head->data;
    // std::cout << pop << std::endl;

    head = head->next;
    // std::cout << head->data << std::endl;

    delete head->prev;

    head->prev = tail;
    // std::cout << head->prev->data << std::endl;

  }
  
  --count;

  return pop;
}


template <class T>
T DoublyCircularLinkedList<T>::DeleteLast() {
  if (0 == count) {
    throw std::out_of_range("Unable to delete last element. List is empty!");    
  }
  
  T pop;
  
  if (1 == count) {
    pop = tail->data;
    
    delete tail;
    head = tail = nullptr;
  }
  else {
    pop = tail->data;
    
    tail = tail->prev;
    delete tail->next;
    tail->next = head;
  }
  
  --count;

  return pop;
}

template <class T>
T DoublyCircularLinkedList<T>::Delete(int n) {
  // std::cout << "In delete by index" << std::endl;
  if (0 == n) {
    return DeleteFirst();
  }
  else if (n == count - 1) {
    return DeleteLast();
  }

  Node<T>* curr = GetElemByIndex(n);

  return Delete(curr);
}


template <class T>
T DoublyCircularLinkedList<T>::Delete(Node<T>* curr) {
  if (curr == nullptr) {
    throw std::invalid_argument("Pointer to elemet to delete is nullptr! Unable to delete elememt!");
  }
  
  T pop = curr->data;
  
  curr->prev->next = curr->next;
  curr->next->prev = curr->prev;
  delete curr;

  --count;

  return pop;  
}


template <class T>
void DoublyCircularLinkedList<T>::Insert(int i, T data) {

  if (i >= count || i < 0) {
    throw std::range_error("Unable to insert element at index " + std::to_string(i) + ". Index out of range!");
  }
  
  if (0 == i) {
    PushFront(data);
    return;
  }
  
  Node<T>* curr = GetElemByIndex(i);

  Insert(curr, data);
}


template <class T>
void DoublyCircularLinkedList<T>::Insert(Node<T>* curr, T data) {
  if (curr == nullptr) {
    throw std::invalid_argument("Unable to insert new element at pointer. Pointer is nullptr!");
  }
  
  Node<T>* newElem = new Node<T>(data);

  newElem->prev = curr->prev;
  newElem->next = curr;
  curr->prev = newElem;
  newElem->prev->next = newElem;

  ++count;
  
}


template <class T>
Node<T>* DoublyCircularLinkedList<T>::GetElemByIndex(int n) const {
  if (n < 0 || n >= count) {
    throw std::invalid_argument("Index out of range!");
  }
  
  Node<T>* curr = nullptr;
  bool fromStart = count - n >= (count / 2);

  if (fromStart) {
    curr = head;
    for (int i = 0; i <= n; ++i) {
      if (i == n) {
        return curr;
      }
      curr = curr->next;
    }
  }
  else {
    curr = tail;
    for (int i = count - 1; i >= n; --i) {
      if (i == n) {
        return curr;
      }
      curr = curr->prev;
    }
  }
  
  return nullptr;
}


template <class T>
T DoublyCircularLinkedList<T>::GetDataByIndex(int n) const {
  Node<T>* t = GetElemByIndex(n);
  return t->data;
}




template <class T>
void DoublyCircularLinkedList<T>::Clear() {
  if (0 == count) {
    return;
  }
  
  while (true) {
    if (head == tail) {
      delete head;
      head = tail = nullptr;
      break;
    }
    head = head->next;
    delete head->prev;
  }
}

template <class T>
void DoublyCircularLinkedList<T>::Print(char separator) const {
  Node<T>* node = head;
  
  if (0 == count) {
    std::cout << "List is empty" << std::endl;
    return;
  }

  for (int i = 0; i < count; ++i) {
    std::cout << node->data << separator;
    node = node->next;
  }
  // std::cout << "here" << std::endl;
  // while (true) {
  //   //    std::cout << "in loop" << std::endl;
  //   std::cout << node->data << " ";    
  //   node = node->next;
  //   if (node == head) {
  //     std::cout << "in check" << std::endl;
  //     break;
  //   }
  // }

  std::cout << std::endl;
}
  

template <class T>
DoublyCircularLinkedList<T>::~DoublyCircularLinkedList() {
  Clear();
}
