// See https://aka.ms/new-console-template for more information
using YYMDotNetInternshipTraining.EFCoreSample1;

Console.WriteLine("Hello, World!");

EFCoreSample1 sample = new EFCoreSample1();
sample.Read();
sample.Edit();

Console.ReadLine();