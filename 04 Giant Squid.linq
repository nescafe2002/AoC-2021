<Query Kind="Statements">
  <Reference Relative="04 input.txt">C:\Drive\Challenges\AoC 2021\04 input.txt</Reference>
</Query>

var input = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7".Split("\r\n");

input = File.ReadAllLines("04 input.txt");

var boards = new List<Dictionary<int, (int, int)>>();
var done = new HashSet<int>();

var (row, col) = (0, 0);
var board = default(Dictionary<int, (int, int)>);

// Parse

foreach (var line in input.Skip(1))
{
  if (string.IsNullOrEmpty(line))
  {
    row = 0;
    boards.Add(board = new Dictionary<int, (int, int)>());
  }
  else
  {
    col = 0;
    foreach (var letter in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    {
      board.Add(int.Parse(letter), (row, col++));
    }
    row++;
  }
}

// Draw, remove from board and distribute to rows and cols collection per board (ix)

var rows = Enumerable.Range(0, boards.Count).Select(x => new Dictionary<int, int>()).ToArray();
var cols = Enumerable.Range(0, boards.Count).Select(x => new Dictionary<int, int>()).ToArray();

foreach (var letter in input[0].Split(',').Select(int.Parse))
{
  foreach (var i in Enumerable.Range(0, boards.Count))
  {
    if (boards[i].Remove(letter, out var cell))
    {
      rows[i][cell.Item1] = (rows[i].TryGetValue(cell.Item1, out var v) ? v : 0) + 1;
      cols[i][cell.Item2] = (cols[i].TryGetValue(cell.Item2, out var w) ? w : 0) + 1;
    }
  }
  
  // Output completed boards

  foreach (var i in Enumerable.Range(0, boards.Count).Where(x => !done.Contains(x) && (cols[x].Values.Contains(5) || rows[x].Values.Contains(5)) && done.Add(x)))
  {
    (letter * boards[i].Sum(x => x.Key)).Dump($"Board {i}");
  }
}