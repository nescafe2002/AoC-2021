<Query Kind="Statements">
  <Reference Relative="07 input.txt">C:\Drive\Challenges\AoC 2021\07 input.txt</Reference>
</Query>

var input = new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

input = File.ReadAllText("07 input.txt").Split(',').Select(int.Parse).ToArray();

Enumerable.Range(0, input.Max()).Select(i => new { i, sum = input.Sum(x => Math.Abs(i - x))}).OrderBy(x => x.sum).First().sum.Dump("Answer 1");

int Distance(int value) => Enumerable.Range(0, value).Sum(x => x + 1);

Enumerable.Range(0, input.Max()).Select(i => new { i, sum = input.Sum(x => Distance(Math.Abs(i - x))) }).OrderBy(x => x.sum).First().sum.Dump();
