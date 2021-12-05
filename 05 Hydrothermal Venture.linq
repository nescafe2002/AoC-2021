<Query Kind="Statements">
  <Reference Relative="05 input.txt">C:\Drive\Challenges\AoC 2021\05 input.txt</Reference>
</Query>

var input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2".Split("\r\n");

input = File.ReadAllLines("05 input.txt");

var lines = input.Select(x => x.Split(" -> ").SelectMany(x => x.Split(',').Select(int.Parse)).ToArray());

var grid = new Dictionary<(int, int), int>();

foreach (var line in lines) //.Where(x => x[0] == x[2] || x[1] == x[3]))
{
  var d = new[] { line[2] - line[0], line[3] - line[1] };
  var m = d.Max(x => Math.Abs(x));
  var v = (d[0] / m, d[1] / m);
  var s = (line[0], line[1]);
  for (int i = 0; i <= m; i++)
  {
    if (!grid.TryAdd(s, 1)) grid[s]++;
    s = (s.Item1 + v.Item1, s.Item2 + v.Item2);
  }
}

grid.Count(x => x.Value > 1).Dump("Answer 1/2");