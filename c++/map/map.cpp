#include "map.h"
#include <map>

using namespace std;

template<typename K, typename V>  //  K -- Key || V -- Value

class interval_map {

private:
    friend void IntervalMapTest(interval_map <int, int> p_map);

    // private members

    V m_valBegin;

    std::map<K, V> m_map;

public:
    interval_map(V const& val)
        : m_valBegin(val)
    {}

    void assign(K const& keyBegin, K const& keyEnd, V const& val) {
        int static n = 0;

        int b = (int)keyBegin; // b: begin
        int e = (int)keyEnd; // e: end

        if (!(b < e)) {
            m_map.insert({ NULL,NULL }); // if K and V are int type then K=0 and V=0
            return;
        }		
		
        bool found = false;

        for (auto& it : m_map) {
            if (it.second == val) {
                found = true;
                break;
            }
        }

        if (found) {
            return; //exit function --cannot insert value equals to val 
        }

        for (int key = keyBegin; key <= keyEnd; key ++)
        {
            // cannot insert first value equals to m_valBegin
            if (!(n == 0 && val == m_valBegin))
            {
                m_map.insert({ key,val });
                n++;
            }
        }
    }

    void read()
    {		
        // read elements from m_map
        for (auto& it : m_map) {
            cout << "[" << it.first << "]=";
            cout << it.second << endl;
        }
    }

    // look-up of the value associated with key
    V const& operator[](K const& key) const {
        //returns the value "V" corresponding to the K value

        //search Key trying to read Key parameter calling map method upper_bound
        auto it = m_map.upper_bound(key);

        if (it == m_map.begin()) {
            return m_valBegin;
        }
        else {
            return (--it)->second;
        }
    }

};

//std::map<int, int> variable type must be explicit at runtime. 
//type might be used before runtime when it is using templates.   
void IntervalMapTest(interval_map <int, int> p_map) {
    bool repeated=false; //false: default value
    int second=0;
    int previous=-1, current=-1, index=0, count=0;
    
    std::map<int, int> v_map; 
    
    char listvalue[256] = { "" };
    char str_int[256] = { "" };

    for (auto& it : p_map.m_map) {
        int second = (int)it.second;

        current = second;
        
        //remove identical values which 
        //are inserted one after the other
        if (previous != -1 && previous != current) { 
            v_map.insert({ index ++,second });
        }
        else if (previous == -1) {
            v_map.insert({ index ++,second });
        }
        
        previous = second; //before next iteration
    }

    repeated = false;

    for (auto& it_a : v_map) {
        count = 0;

        for (auto& it_b : v_map) {

            if (it_a.second == it_b.second) {
                //if ((++ count) == 1) {
                sprintf(str_int, "%d[%d], ", it_b.second, ++ count);
                strcat(listvalue, str_int);
                repeated = true;
                break;
                //}
            }
                       
        }

    }
        
    index = strlen(listvalue);
    listvalue[index - 2] = NULL;
    
    cout << "There are" <<  ((repeated) ? "":" not") <<  " repeated values." << endl;
    
    if (repeated) {
        cout << "These values " 
            << listvalue 
            << " are repeated values." << endl;
    }

    return;
}

int main()
{
    int n = 100;

    interval_map<int, int> m(n);

    //it should not repeat any value 
    //from the previous assignation

    m.assign(0, 1, 455);

    m.assign(2, 5, 244);

    m.assign(6, 9, 455);

    m.assign(10, 12, 244);    

    m.assign(13, 15, 771);
    
    IntervalMapTest(m);

    printf("\n\n");

    m.read();

    return 0;
}
