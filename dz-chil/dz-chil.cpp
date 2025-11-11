using namespace std;
#include <iostream>
#include <vector>

int main()
{
	int n = 0;
	cout << "Enter a:" << endl;
	cin >> n;
	int iterator = 1;
	
	if (n < 0)
	{
		cout << "Negative number" << endl;
		
	}
	else
	{
		while(n >= iterator)
		{
			if (iterator % 7 == 0)
			{
				cout << iterator << endl;
				break;
			}
			iterator++;
		}
		cout << "End of program" << endl;
	}

	//////////////////////////////////////////////////////


	int n = 0;
	cout << "Enter a:" << endl;
	cin >> n;
	int iterator = 1;
	
	do
	{
		if (iterator % 2 == 0)
		{
			iterator++;
			continue;
		}
		cout << iterator << endl;
			iterator++;
			
	} while (n >= iterator);


	/////////////////////////////


	vector<int> numbers;

	int n = 0;
	int n2 = 0;
	int suma = 0;
	int iterator = 0;
	cout << "enter a:" << endl;
	cin >> n;
	for (int i = 1; i <= n; i++)
	{
		cout << "enter number " << i << ":";
		cin >> n2;
		numbers.push_back(n2);
	}

	while (n > iterator){
		if (numbers[iterator] > 0)
		{
			suma += numbers[iterator];
		}
		else
		{
			break;
		}
		iterator++;
	}
	cout << "sum is: " << suma << endl;



	int n = 0;
	int suma = 1;
	cout << "Enter a:" << endl;
	cin >> n;
	for (int i = 1; i <= n; i++)
	{
		suma *= i;
	}
	cout << "Factorial is: " << suma << endl;
}

