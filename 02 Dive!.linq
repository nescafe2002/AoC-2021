<Query Kind="Statements">
  <Reference Relative="02 input.txt">C:\Drive\Challenges\AoC 2021\02 input.txt</Reference>
</Query>

var input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2".Split('\n');

input = File.ReadAllLines("02 input.txt");

// What do you get if you multiply your final horizontal position by your final depth?

var data = input.Select(x => x.Split(' ')).ToLookup(x => x[0], x => int.Parse(x[1]));

var answer1 = (data["forward"].Sum() * (data["down"].Sum() - data["up"].Sum())).Dump("Answer 1");

// What do you get if you multiply your final horizontal position by your final depth?

var (horizontal, depth, aim) = (0, 0, 0);

foreach (var line in input.Select(x => x.Split(' ')))
{
  var value = int.Parse(line[1]);
  if (line[0] == "down")
    aim += value;
  else if (line[0] == "up")
    aim -= value;
  else if (line[0] == "forward")
  {
    horizontal += value;
    depth += value * aim;
  }
}

(horizontal * depth).Dump("Answer 2");