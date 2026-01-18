#include <stdio.h>
#include <iostream>
#include <map>
#include <string>
#include <vector>

using namespace std;

int main() {
    cout << "" << endl;

    cout << "Description:" << endl;
    cout << "Read value, reverse value, ";
    cout << "replace characters using this relation rule." << endl;

    cout << "" << endl;

    cout << "" << endl;

    cout << "A - T" << endl;
    cout << "C - G" << endl;
    cout << "G - C" << endl;
    cout << "T - A" << endl;

    cout << "" << endl;
    cout << "" << endl;
  
    map<string, string> relation
    {
            { "A", "T"},
            { "C", "G"},
            { "G", "C"},
            { "T", "A"}
    };

    string x;

    cout << "Input value: "; 
    cin >> x;

    string xx = x;

    // reverse user input value
    reverse(xx.begin(), xx.end());

    cout << endl;
    cout << "Reversed Value: " << xx << endl;
    cout << endl;

    vector<string> col_s;

    int index;
    map<string, string>::iterator ii;

    string vv = xx; // reversed value

    char cc;

    for (auto ii = relation.begin(); ii != relation.end(); ii++) {        
        // create new string with spaces
        string str = "";
        char c = ' ';

        for (int j = 0; j < x.length(); j ++) {
            str = str + c;
        }

        index = 0;

        for (auto h = 0; h < vv.length(); h ++) {
            if (ii->first[0] == vv[h]) {
                cc = ii->second[0];
            }
            else {
                cc = ' ';
            }

            str[index] = cc;
            index += 1;
        }

        col_s.push_back(str);
    }

    string prev_text;
    string cur_text;

    int iteration = 0;

    for (auto m = 0; m < col_s.size(); m ++) {
        if (iteration == 0) {
            iteration ++;
            continue;
        }

        prev_text = col_s[iteration - 1];
        cur_text = col_s[iteration];

        for (auto mm = 0; mm < prev_text.length(); mm ++) {
            if (cur_text[mm] == ' ' && prev_text[mm] != ' ') {
                cur_text[mm] = prev_text[mm];
            }
        }

        col_s[iteration] = cur_text;
        iteration ++;
    }

    // print last value from array
    cout << "Output: " << col_s[col_s.size() - 1] << endl;

    return 0;
}
