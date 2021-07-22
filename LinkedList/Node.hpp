#pragma once

template <class T>
class Node {

public:
  Node* prev = nullptr;
  Node* next = nullptr;
  T data;

  Node(T data) {
    this->data = data;
  }
};
