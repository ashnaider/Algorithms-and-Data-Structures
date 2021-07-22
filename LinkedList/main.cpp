#include <iostream>

#include "DoublyCircularLinkedList.hpp"
#include "Text.hpp"

using namespace std;


int main() {
  
  string path = "text.txt";
  
  Text* text = new Text();

  
  text->Read(path);

  char separator = '\n';
  text->Print();

  cout << "\n\n";

  text->Parse();

  text->PrintRes();


  delete text;

  return 0;
}
