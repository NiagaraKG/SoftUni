#include <iostream>
#include <string>
#include <map>
#include <set>
#include <vector>

using namespace std;

//it works,but not here

class Team
{
public:
	string name;
	int players_num, wins = 0;
	set<string> players;
};

int main()
{
	vector<Team> Teams_List;
	map<string, int> players_results;
	int T, G;
	cin >> T;
	while (T > 0)
	{
		Team current_team;
		cin >> current_team.name;
		cin >> current_team.players_num;
		while (current_team.players_num > 0)
		{
			string current_player;
			cin >> current_player;
			current_team.players.insert(current_player);
			current_team.players_num--;
		}
		Teams_List.push_back(current_team);
		T--;
	}
	cin >> G;
	while (G > 0)
	{
		string current_winner;
		cin >> current_winner;
		for (int i = 0; i < Teams_List.size(); i++)
		{
			if (Teams_List[i].name == current_winner)
			{
				Teams_List[i].wins++;
				break;
			}
		}
		G--;
	}
	for (Team current_team : Teams_List)
	{
		for (string player : current_team.players)
		{
			players_results[player] += current_team.wins;
		}
	}
	for (auto player : players_results)
	{
		cout << player.second << " ";
	}
	cout << endl;
	return 0;
}
