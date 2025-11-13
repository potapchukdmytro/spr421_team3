#include <iostream>
#include <vector>
using namespace std;

int main() {

	//int arr[10] = { 5, 3, 8, 6, 2, 7, 4, 1, 9, 0 };
 //   int suma = 0;
 //   for (int i = 0; i < 10; i++)
 //   {
	//	suma += arr[i];
 //   }

	//cout << ": " << suma << endl;
	//cout << "A: " << double(suma) / 10 << endl;




 //   int arr[15] = { 12, -45, 67, 0, -8, 34, 23, -56, 78, 12,
	//		   5, -33, 44, 11, -99 };

	//int max = arr[0];
	//int min = arr[0];

	//for (int i = 0; i < 15; i++)
	//{
	//	if (max < arr[i])
	//	{
	//		max = arr[i];
	//	}
	//	if (min > arr[i])
	//	{
	//		min = arr[i];
	//	}
	//}
	//cout << "MAX: " << max << endl;
	//cout << "MIN: " << min << endl;



    //int arr[20] = { 12, 33, 44, 55, -32, 44, 11, 22, 67, -77,22, 33, 66, -45, -88, 47, -36, -78, 12, 65 };
    //

    //
    //for (int i = 0; i < 5 - 1; i++) {
    //    int minIndex = i;  
    //    for (int j = i + 1; j < 5; j++) {
    //        if (arr[j] < arr[minIndex])
    //            minIndex = j;
    //    }
    //    swap(arr[i], arr[minIndex]);
    //}


    //cout << "SORT: ";
    //for (int i = 0; i < 5; i++) {
    //    cout << arr[i] << " ";
    //}
    //cout << endl;







 //   int arr[30] = { 12, -45, 67, 0, -8, 34, 23, -56, 78, 12,
 //              5, -33, 44, 11, -99, 87, 2, -21, 65, -7,
 //              9, 38, -48, 14, -61, 77, -5, 20, -30, 50 };



 //   for (int i = 0; i < 30; i++)
 //   {
 //       for (int i2 = 0; i2 < 29; i2++)
 //       {
 //           if (arr[i2] > arr[i2 + 1])
 //           {
	//			swap(arr[i2], arr[i2 + 1]);
 //           }
 //       }
 //   }
 //   int count = 0;
 //   for (int i = 0; i < 30; i++)
 //   {
 //       for (int i2 = i + 1; i2 < 30; i2++)
 //       {
 //           if (arr[i] == arr[i2])
 //           {
 //               count++;
 //           }
 //       }
 //   };
 //   int* arr2 = new int[30 - count];
	//bool flag = false;
	//int index = 0;
 //   for (int i = 0; i < 30; i++)
 //   {Â

 //       for (int i2 = i + 1; i2 < 30; i2++)
 //       {
 //           if (arr[i] == arr[i2])
 //           {
	//			flag = true;
 //           }
 //       }
 //       if (!flag)
 //       {
 //           arr2[index] = arr[i];
	//		index++;
 //       }
	//	flag = false;
 //   };
 //  cout << "SORT: ";
 //  for (int i = 0; i < 30 - count; i++) {
 //      cout << arr2[i] << " ";
 //  }
 //  cout << endl;

 //  delete[] arr2;





 //   int arr[50] = {
 //   12, -45, 67, 0, -8, 34, 23, -56, 78, -12,
 //   5, -33, 44, 11, -99, 87, 2, -21, 65, -7,
 //   9, 38, -48, 14, -61, 77, -5, 20, -30, 50,
 //   -11, 6, 29, -72, 41, -16, 3, 88, -34, 19,
 //   25, -50, 46, -9, 13, -67, 35, 7, -23, 60
 //   };
	//vector<int> arr2;
 //   int n = 5;
 //   for ( int i = 0; i <= 50-n; i++)
 //   {
 //       int count = 0;
 //       for (int i2 = i  ; i2 < i + n; i2++)
 //       {
	//		count += arr[i2];
	//		
 //       }
 //       arr2.push_back(count);
 //   }
	//int max = arr2[0];
 //   for (int i = 0; i < arr2.size(); i++)
 //   {
 //       if (arr2[i] > max)
 //       {
 //           max = arr2[i];
 //       }
 //   }
 //   for (int i = 0; i <= 50 - n; i++)
 //   {
 //       int count = 0;
 //       for (int i2 = i; i2 < i + n; i2++)
 //       {
 //           count += arr[i2];

 //       }
 //       

 //       if (count == max)
 //       {
 //           int start = i;
	//		int end = n * (i + 1) - 1;
 //           for(int i2 = i; i2 < i + n; i2++)
 //           {
 //               start = i;
 //               int end = +n;
 //               cout << arr[i2] << " ";

	//			
 //           }
 //           cout << endl;
 //           cout << "Max:" <<max << endl;
 //           cout << "Start iterator:" << i << endl;
 //           cout << "End iterator:" << i + n - 1 << endl;

 //       }

 //   }
}
    