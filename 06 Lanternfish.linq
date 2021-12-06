<Query Kind="Statements">
  <Reference Relative="06 input.txt">C:\Drive\Challenges\AoC 2021\06 input.txt</Reference>
</Query>

var input = "3,4,3,1,2".Split(',');

input = File.ReadAllText("06 input.txt").Split(',');

var occurrences = new long[9];

foreach (var item in input.Select(long.Parse).ToLookup(x => x))
{
  occurrences[item.Key] = item.Count();
}

for (int round = 0; round < 256; round++)
{
  var abc = occurrences[0];
  occurrences[0] = occurrences[1];
  occurrences[1] = occurrences[2];
  occurrences[2] = occurrences[3];
  occurrences[3] = occurrences[4];
  occurrences[4] = occurrences[5];
  occurrences[5] = occurrences[6];
  occurrences[6] = occurrences[7] + abc;
  occurrences[7] = occurrences[8];
  occurrences[8] = abc;
}

occurrences.Sum().Dump("Answer 1/2");