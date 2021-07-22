#pragma once

#include <iostream>
#include <string>
#include <sstream>
#include <fstream>

#include "DoublyCircularLinkedList.hpp"

using namespace std;


class Text {
public:
  Text();

  ~Text();

  bool Read(const string& path);

  void Parse();

  void ReverseStr(const string& in, string& out);

  bool IsPalindrom(const string& str);
  
  bool GetOnlyLetters(const string& path);

  void PrintRes() const;

  void Print(char separator=' ') const;

private:
  DoublyCircularLinkedList<string>* textList = nullptr;
};



Text::Text() {
  textList = new DoublyCircularLinkedList<string>();
}

Text::~Text() {
  if (textList != nullptr) {
    textList->Clear();
  }
}

bool Text::Read(const string& path) {
  ifstream file(path);

  if (file.is_open() == false) {
    return false;
  }
  
  string tmp, tmp2;

  while (file >> tmp) {
    textList->PushBack(tmp);
  }
  
  file.close();
  
  return true;
}



void Text::Parse() {
  string curr, rev;
  int c = 0;
  for (int i = 0; i < textList->Count(); ++i) {
    curr = textList->GetDataByIndex(i);

    if (IsPalindrom(curr) && curr.size() > 1) {
      string t = textList->Delete(i);
      cout << "this word been deleted: " << t << endl;
      --i;
      ++c;
      continue;
    }
    ReverseStr(curr, rev);
    if (i + 1 < textList->Count() - 1) {
      textList->Insert(i + 1, rev);
      ++i;
    }
  }
  cout << "count of palindroms: " << c << endl;
}


void Text::ReverseStr(const string& in, string& out) {
  out.clear();
  for (int i = in.size() - 1; i >= 0; --i) {
    out += in[i];
  }
}


bool Text::IsPalindrom(const string& str) {
  for (int i = 0; i < str.size() / 2; ++i) {
    if (tolower(str[i]) != tolower(str[str.size() - i - 1])) {
      return false;
    }
  }
  return true;
}


void Text::PrintRes() const {
  string curr, next;
  int c = 0;
  int max = 40;

  cout << endl;
  for (int i = 0; i < textList->Count(); ++i) {
    curr = textList->GetDataByIndex(i);
    cout << curr << " ";
 
    if (i + 1 < textList->Count() - 1) {
      next = textList->GetDataByIndex(i + 1);
      if (c >= max ) {
        cout << endl;
        c = 0;
      }
    }

    if (i % 2 == 0) {
      c += curr.size() + 1;
    
      if (0 == c) {
        c -= 1;
      }
    }
  }
  
  cout << endl;
}


void Text::Print(char separator) const {
  textList->Print(separator);
}


bool Text::GetOnlyLetters(const string& path) {
  ifstream file(path);

  if (file.is_open() == false) {
    return false;
  }

  string res = "", tmp;
  char ch;
  while (file >> noskipws >> ch) {
    if ((ch >= 'a' && ch <= 'z') ||
        (ch >= 'A' && ch <= 'Z') ||
        ch == ' ' || ch == '\t' || ch == '\n') {
      res += ch;
    }
  }

  file.close();
  
  ofstream out("output.txt", ios::trunc);
  if (out.is_open() == false) {
    return false;
  }

  out << res;

  out.close();

  return true;
}
