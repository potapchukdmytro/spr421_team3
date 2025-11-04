#include <iostream>

using namespace std;
#include <vector>
int main() {



    int n = 3;
    int m = 3;
    int k=0;
    int x1 = 3;
    int y1 = 2;
    int y2 = 3;
    int x2 = 2;
    int count = 0;
    

    vector<vector<int>> board(n, vector<int>(m, 0));

    if (k != 0)
    {
        board[n - y1][x1 - 1] = 1;
        board[n - y2][x2 - 1] = 1;
    }
    

    for (int i = 1; i < n; i++)
    {
        for (int j = 0; j < m; j++) {
          
            
                if (board[n - i][j] == 1)
                {
                    i = n;
                    break;
                }
                else {
                    board[n - i][j] = 2;


                }
            
           
            
           
        }

    }



    for (int i = 0; i < m; i++) {
        for (int j = n - 1; j >= 0; j--) {
            if (board[j][i] == 1) {
                break;
            }
            else {
                board[j][i] = 2;
            }
        }
    }


    
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            cout << board[i][j] << " ";
        }
        cout << endl;
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            if (board[i][j] == 2)
            {
                count++;
            }
        }
        cout << endl;
    }

    cout << count - 1 << endl;
}