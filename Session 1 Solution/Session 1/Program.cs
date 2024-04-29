using System.Text.RegularExpressions;
using static Session_1.ListGenerators;

namespace Session_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Implicitly Typed Local Variable [var - dynamic]

            var Data1 = 22.3; // double
            /// Compiler Will Detect Variable Datatype Based On Its Initial Value at Compilation Time
            /// Must be Initialized
            /// Can't be Initialized with null
            /// After Initialization, U Can't Change its datatype

            dynamic Data2; // double
            /// CLR Will Detect Variable Datatype Based On Its Last Value in RunTime
            /// Not Must be initialized
            /// Can be initialized with null
            /// After Initialization, U Can Change its datatype

            Data2 = "Hello";
            Data2 = null;
            Data2 = 66;

			#endregion

			#region Extension Method

			//int X = 12345;
			//int Y = IntExtensions.Reverse(X); // 54321
			//Y = X.Reverse(); // Syntax Sugar
			//Console.WriteLine(Y);

			#endregion

			#region Anonymous Type

			//var E01 = new { ID = 10, Name = "Ahmed", Salary = 20202 };

			//Console.WriteLine(E01.GetType().Name); // AnonymousType0`3
			//Console.WriteLine(E01);

			//// The object created from AnonymousType is a Immutable Object [You Can't Change]
			////E01.ID = 20; // Immutable Object, You Can't Change

			//// if you want to change in E01
			//E01 = new { ID = 20, E01.Name, E01.Salary };
			////var E04 = E01 with { ID = 13 }; new Feature  available only in C# 10.0 


			//var E02 = new { ID = 10, Name = "Hamada", Salary = 34342 };
			//Console.WriteLine(E02.GetType().Name); // AnonymousType0`3
			///// Same Anonymous Class as long as =>
			///// 1. Same Properties Names (Case Sensitive)
			///// 2. Same Properties Datatype
			///// 3. Same Properties Order

			//var E03 = new { ID = 10, FullName = "Ali", Salary = 22323 };
			// Console.WriteLine(E03);
			//Console.WriteLine(E03.GetType().Name); // AnonymousType1`3

			//var product = new { ProductID = 102, ProductName = "Meat" };
			//Console.WriteLine(product.GetType().Name); // AnonymousType2`2

			#endregion

			#region LINQ Intro - LINQ Syntax - LINQ Execution

			#region LINQ Intro

			/// LINQ : stands for Language-Integrated Query
			/// LINQ : Named [Query Operators] Existing at Enumerable Class  
			/// LINQ : +40 Extension Methods (for the classes that implement Built-in interface "IEnumerable" ) 
			///         So All collections(List, Array, Dictionary,..etc) have these Extension Methods[LINQ] because All collections implementing interface "IEnumerable"
			/// LINQ :  ( +40 Extension Methods ) : Categorized to 13

			/// Use "LINQ Operators" with the Data ( Stored at Sequence), Regardless Data Store [SQL Server, MySQL, Oracle, and etc...]
			/// Sequence: an Object from Any Class Implementing "IEnumerable" interface like (List, Array, Dictionary...)
			/// 1. Local  Sequence: LINQ that write in Local  Sequence its name  →→ L2O, L2XML
			/// 2. Remote Sequence: LINQ that write in Remote Sequence its name  →→ L2EF,LINQ Entity FrameWork will convert  L2EF to SQL

			//List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

			//// List<int> oddNumbers =  Numbers.Where((N)=>N%2==1).ToList(); // where → return an IEnumerable 
			//var oddNumbers = Numbers.Where((N) => N % 2 == 1); // L2O

			//foreach (var number in oddNumbers)
			//{
			//    Console.WriteLine(number);
			//} 
			#endregion

			#region LINQ Syntax

			//List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

			#region 1. Fluent Syntax

			//// 1.1 Calling LINQ Operators as Static Methods through Enumerable Class 

			//var Result = Enumerable.Where/*<int>*/(Numbers, (N) => N % 2 == 0);

			//// 2.1 Calling LINQ Operators as Extension Methods [Recommended]

			//Result = Numbers.Where((N) => N % 2 == 0);

			#endregion

			#region 2. Query Syntax [Query Expression]: Like SQL Query Style

			//// Start With keyword "from", Introducing Range Variable(N): Represents Each Element At Sequence
			//// End With select Or group by

			//var Result = from N in Numbers
			//             where N % 2 == 0
			//             select N;

			///// Some Cases, It's Easier To Write Queries Using Query Expression
			///// Instead Of Fluent Syntax (Join, Group) 

			#endregion

			#endregion

			#region LINQ Execution [ VIP Interview ]

			////Ways Of LINQ Execution

			// //1.Differed Execution(Latest Update Of Data)
			// //All LINQ Operators Except[Element, Aggregate, Casting] Operators

			//List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

			//var EvenNumbers = Numbers.Where((i) => i % 2 == 0);

			//Numbers.Remove(2); // 1, 3, 4, 5, 6, 7, 8
			//Numbers.AddRange(new int[] { 9, 10, 11, 12 }); // 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12

			//foreach (var item in EvenNumbers)
			//	Console.Write($"{item},");
			//Console.WriteLine(""); // 4,6,8,10,12

			///***************************************************/

			////2.Immediate Execution(Element Operators - Aggregate Operators - Casting Operators)
			//// Using Casting For Converting Differed Executing LINQ Operators

			//List<int> Numbers2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

			//var EvenNumbers2 = Numbers2.Where((i) => i % 2 == 0).ToList(); // Casting Operators
			//Numbers.Remove(2);
			//Numbers.AddRange(new int[] { 9, 10, 11, 12 });

			//foreach (var item in EvenNumbers)
			//	Console.Write($"{item},");
			//Console.WriteLine("");  // 2,4,6,8

			#endregion

			#endregion

			#region Test ListGenerators Class

			//Console.WriteLine(ListGenerators.ProductList[0]); // U can don't write ListGenerators if u call class (look at first line)[using static Session_1.ListGenerators;]
			//Console.WriteLine(ListGenerators.CustomerList[0]);// U can don't write ListGenerators if u call class (look at first line)[using static Session_1.ListGenerators;]
			//Console.WriteLine(ProductList[0]);
			//Console.WriteLine(CustomerList[0]); 

			#endregion

			#region Filtration (Restriction) Operators → Where - Differed Execution

			//var Result = ProductList.Where((P) => P.UnitsInStock == 0); // Fluent Syntax

			//Result = from P in ProductList
			//			 where P.UnitsInStock == 0
			//			 select P; // Query Syntax


			//Result = ProductList.Where((P) => P.UnitsInStock == 0 && P.Category == "Meat/Poultry"); // Fluent Syntax

			//Result = from P in ProductList
			//		 where P.UnitsInStock == 0 && P.Category == "Meat/Poultry"
			//		 select P; // Query Syntax

			////Indexed Where
			//// Valid Only at Fluent Syntax.Can't be Written Using Query Expression
			//// Get From The First 10 Products, The Products That Are Out Of Stock
			//Result = ProductList.Where((P, index) => P.UnitsInStock == 0 && index < 10); // Fluent Syntax

			//foreach (var Item in Result)
			//{
			//	Console.WriteLine(Item);
			//}

			#endregion

			#region Transformation (Projection Operators) → Select / SelectMany - Differed Execution

			// This operators called Transformation :
			// because the input sequence (say list<product>) and the output sequence is list<string> (say list<products name>)

			//var Result = ProductList.Select((P) => P.ProductName);
			//Result = from P in ProductList
			//		 select P.ProductName;

			//var Result1 = CustomerList.Select(C => C.Orders); // return namespace
			//var Result2 = CustomerList.SelectMany(C => C.Orders);
			//Result2 = from C in CustomerList
			//		 from O in C.Orders
			//		 select O;

			#region Select Anonymous Type

			//var Result = ProductList.Select(P => new { P.ProductID, P.ProductName, P.UnitPrice });  // return list<Anonymous object>
			//Result = from P in ProductList
			//         select new { P.ProductID, P.ProductName, P.UnitPrice };

			//foreach (var Item in Result)
			//{
			//    Console.WriteLine(Item);
			//}

			//var DiscountProducts = ProductList.Where(P => P.UnitsInStock > 10).Select(P => new
			//{
			//	ID = P.ProductID,
			//	Name = P.ProductName,
			//	ProductCategory = P.Category,
			//	Count = P.UnitsInStock,
			//	NewPrice = P.UnitPrice * .8M
			//});

			//DiscountProducts = from P in ProductList
			//				   where P.UnitsInStock > 10
			//				   select new
			//				   {
			//					   ID = P.ProductID,
			//					   Name = P.ProductName,
			//					   ProductCategory = P.Category,
			//					   Count = P.UnitsInStock,
			//					   NewPrice = P.UnitPrice * .8M
			//				   };


			//foreach (var item in DiscountProducts)
			//{
			//    Console.WriteLine(item);
			//}

			#endregion

			// Indexed Select (Valid Only at Fluent Syntax)
			//var Result = ProductList.Select((P, i) => new { Index = i, ProductName = P.ProductName });
			//var Result = ProductList.Where(P =>P.UnitsInStock>0)
			//                        .Select((P, i) => new { Index = i, ProductName = P.ProductName });

			//foreach (var Item in Result)
			//{
			//    Console.WriteLine(Item);
			//}

			#endregion

			#region Ordering Operators - Differed Execution

			// Ascending Order
			//var Result = ProductList.Select(P => new { P.ProductName, P.UnitsInStock })
			//                        .OrderBy(P => P.UnitsInStock);
			//Result = from P in ProductList
			//         orderby P.UnitsInStock
			//         select new {P.ProductName, P.UnitsInStock};

			// Descending Order
			//var Result = ProductList.Select(P => new { P.ProductName, P.UnitsInStock })
			//                        .OrderByDescending(P => P.UnitsInStock);
			//Result = from P in ProductList
			//         orderby P.UnitsInStock descending
			//         select new { P.ProductName, P.UnitsInStock };

			// OrderBy Multiple Columns
			//var Result = ProductList.OrderBy(P => P.UnitsInStock)
			//                        .ThenBy(P => P.UnitPrice)
			//                        .Select(P => new { P.ProductName, P.UnitPrice });
			//Result = from P in ProductList
			//         orderby P.UnitsInStock, P.UnitPrice
			//         select new { P.ProductName, P.UnitPrice };

			//var Result = ProductList.OrderBy(P => P.UnitsInStock)
			//                        .ThenByDescending(P => P.UnitPrice)
			//                        .Select(P => new { P.ProductName, P.UnitPrice });
			//Result = from P in ProductList
			//         orderby P.UnitsInStock, P.UnitPrice descending
			//         select new { P.ProductName, P.UnitPrice };

			////Reverse Operator
			//var Result = ProductList.Select(P => P.ProductName).Reverse();
			//foreach (var item in Result)
			//{
			//	Console.WriteLine(item);
			//}

			#endregion

			#region Element Operators - Immediate Execution [ Valid Only with Fluent Syntax ]

			//var Result = ProductList.First();

			//Result = ProductList.Last();

			//Console.WriteLine(Result?.ProductName ?? "Null");


			//// Disadvantage First(), Last(): if Sequence is Empty ↓

			//List<Product> DiscountedProducts = new List<Product>(); // Empty Sequence

			//var Result = DiscountedProducts.First();
			//Result = DiscountedProducts.Last();
			//// Throw Exception, Because The Sequence (DiscountedProducts) is Empty

			//Result = DiscountedProducts.FirstOrDefault();
			//// Return The First Element at Sequence or Return DefaultValue[Null] if Sequence is Empty
			//// No Exceptions Will be Thrown
			//Result = DiscountedProducts.LastOrDefault();


			//Result = ProductList.First(P => P.UnitPrice == 0);
			//// If No Element doesn't Match Condition, Will Throw Exception
			//Result = ProductList.FirstOrDefault(P => P.UnitPrice == 0);
			//// If No Element doesn't Match Condition, Will Return Null
			//Console.WriteLine(Result?.ProductName ?? "Null");

			/********************************************************************/

			//// ElementAt, ElementAtOrDefault
			//Result = ProductList.ElementAt(200); // If there is No Element in index (200), Will Throw Exception
			//Result = ProductList.ElementAtOrDefault(200); // If there is No Element in index (200), Will Return Null

			/********************************************************************/

			//List<Product> DiscountedProducts = new List<Product>(); // Empty Sequence

			//Result = DiscountedProducts.Single(); // Throw Exception
			//// If Sequence Conatins Just Only One Element, Will Return it
			//// Else Will Throw Exception (Sequence is Empty or Containts More than One Element)

			//DiscountedProducts.Add(ProductList[0]);
			//Result = DiscountedProducts.Single(); // Return Single Element

			//Result = ProductList.SingleOrDefault();
			//// If Sequence is Empty, Will Return Null
			//// If Sequence Conatins Just Only One Element, Will Return it
			//// If Sequence Conatins More than One Element, Throw Exception

			//Result = ProductList.Single(P => P.ProductID == 22);
			//// If Sequence Conatins Just Only One Element Matching the Condition, Will Return it
			//// Throw Exception, if Zero Or More than One Element is Matching the Condition


			//Result = ProductList.SingleOrDefault(P => P.ProductID == 22);
			//// If Sequence Conatins No Element Matching Condition, Will Return Null
			//// If Sequence Conatins Just Only One Element Matching Condition, Will Return it
			//// If Sequence Conatins More than One Element Matching Condition, Will Throw Exception

			//Console.WriteLine(Result?.ProductName ?? "NA");

			//// Hyprid Syntax: (Query Expression).FluentSyntax
			//var R = (from P in ProductList
			//         where P.UnitPrice > 300
			//         select new { P.ProductName, P.Category }).FirstOrDefault();

			//Console.WriteLine(R?.ProductName ?? "NA");


			#endregion

			#region Aggregate Operators - Immediate Execution

			//var Result = ProductList.Count(); // linq operator, // Count() → extension method for object from class implement "IEnumerable"
			//Result = ProductList.Count;  // property at list → Count
			//Result = ProductList.Count(P => P.UnitsInStock == 0); 
			//Console.WriteLine(Result);

			/********************************************/

			//var Result = ProductList.Max();  //product class must implement interface "IComparable"
			//Result = ProductList.Min();     //product class must implement interface "IComparable"

			//Console.WriteLine(Result);

			//var Result = ProductList.Max(P => P.UnitPrice); // Return Maximum Price
			//Console.WriteLine(Result);

			//Result = ProductList.Min(P => P.ProductName.Length);
			//Console.WriteLine(Result);

			/****************************************************/

			//var Result = (from P in ProductList
			//              where P.ProductName.Length == ProductList.Min(P => P.ProductName.Length)
			//              select P).FirstOrDefault();

			/****************************************************/

			//var Result = ProductList.OrderByDescending(P => P.UnitPrice).FirstOrDefault();
			//Console.WriteLine(Result);

			//var Result = ProductList.MaxBy(P => P.UnitPrice); // Return product that have Maximum Price
			//Console.WriteLine(Result); 
			// MaxBy => C# 10.0 [ .Net 6.0 ]

			/*****************************************************************/

			//var Result = ProductList.Max(new Unitstockcomparer());
			//Console.WriteLine(Result);

			//Result = ProductList.Min(new Unitstockcomparer());
			//Console.WriteLine(Result);

			/*****************************************************************/
			//int[] Numbers = { 5, 4, 12, 20, 4, 7, 8, 9, 10, 2, 1 };

			//Array.Sort(Numbers);                    // Sort ASc
			//Array.Sort(Numbers, new SortingDesc());  // Sort Desc

			//foreach (int i in Numbers)
			//{
			//    Console.WriteLine(i);
			//}

			/*****************************  Sum & Average  *********************************/

			//Console.WriteLine(ProductList.Sum(P => P.UnitPrice));
			//Console.WriteLine(ProductList.Average(P => P.UnitPrice));

			/************************  Aggregate  ******************************/

			//string Message = "Helo";
			//string[] Names = { "Ahmed", "Nasr", "Eldein", "Hamdy" };

			//var Result = Names.Aggregate((str1, str2) => $"{str1} {str2}");
			//var result = Names.Aggregate(Message,(str1, str2) => $"{str1} {str2}");

			//Console.WriteLine(Result);
			//Console.WriteLine(result);

			#endregion

			#region Casting Operators - Immediate Execution

			//List<Product> products = ProductList.Where(P => P.UnitsInStock == 0).ToList();

			//Product[] PrdArr = ProductList.Where(P => P.UnitsInStock == 0).ToArray();

			//Dictionary<long, Product> PrdDic = ProductList.Where(P => P.UnitsInStock == 0)
			//                                                .ToDictionary(P => P.ProductID);


			//Dictionary<long, string> PrdDic2 = ProductList.Where(P => P.UnitsInStock == 0)
			//                                                .ToDictionary(P => P.ProductID, P => P.ProductName);

			//HashSet<Product> PrdSet = ProductList.Where(P => P.UnitsInStock == 0).ToHashSet();

			#endregion

			#region Generation Operators

			//// The Only Way To Call them is as Static Methods from Enumerable class

			//var Result = Enumerable.Range(0, 100); //0...99

			//var Result2 = Enumerable.Repeat(new Product(), 10);

			//var Result3 = Enumerable.Empty<Product>().ToArray();  // == ↓

			//Product[] Arr = new Product[0]; // == ↓

			//List<Product> List = new List<Product>();


			#endregion

			#region Set Operators - Union Family

			#region EX01

			//var Seq01 = Enumerable.Range(0, 100); //  0 ... 99
			//var Seq02 = Enumerable.Range(50, 100); // 50 ... 149

			//var Result = Seq01.Union(Seq02); // 0...149 without Duplicate

			//var Result2 = Seq01.Concat(Seq02); //  0 ... 99 , 50 ... 149
			//Result2 = Result2.Distinct();  // 0...149 without Duplicate

			///* union == Concat with Distinct */

			//var Result3 = Seq01.Except(Seq02); // 0 ... 49

			//Result3 = Seq01.Intersect(Seq02); // 50 ... 99

			//foreach (var item in Result3)
			//{
			//    Console.Write($"{item}  ");
			//} 

			#endregion

			#region EX02

			#region Union [ first overload ]

			//var Seq01 = new List<Product>()
			//{
			//	new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
			//	new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
			//	new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments",  UnitPrice = 10.0000M, UnitsInStock = 13 },
			//};
			//var Seq02 = new List<Product>()
			//{
			//	new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
			//	new Product{ ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments",UnitPrice = 21.3500M, UnitsInStock = 0 },
			//	new Product{ ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments",  UnitPrice = 25.0000M, UnitsInStock = 120 },
			//};

			//var Result = Seq01.Union(Seq02);
			//Result = Seq01.Intersect(Seq02);
			//Result = Seq01.Distinct();
			//Result = Seq01.Except(Seq02);

			//foreach (var Product in Result)
			//{
			//	Console.WriteLine(Product);
			//}

			#endregion

			#region Union [ second overload ]

			//var Seq03 = new List<Product>()
			//{
			//    //new Product{ ProductID = 1}, // to test Distinct
			//    new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
			//    new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
			//    new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments",  UnitPrice = 10.0000M, UnitsInStock = 13 },
			//};
			//var Seq04 = new List<Product>()
			//{
			//    new Product{ ProductID = 1, ProductName = "ChaiXX", Category = "BeveragesXX", UnitPrice = 18.00M, UnitsInStock = 100},
			//    new Product{ ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments",UnitPrice = 21.3500M, UnitsInStock = 0 },
			//    new Product{ ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments",  UnitPrice = 25.0000M, UnitsInStock = 120 },
			//};

			//var Result2 = Seq03.Union(Seq04, new MyEqualityComparer());
			//Result2 = Seq03.UnionBy(Seq04,X => X.ProductID);

			////Result2 = Seq03.Intersect(Seq04,new MyEqualityComparer());
			//Result2 = Seq03.IntersectBy(Seq04.Select(x=> x.ProductID),p=>p.ProductID);

			////Result2 = Seq03.Distinct(new MyEqualityComparer());
			//Result2 = Seq03.DistinctBy(p => p.ProductID);

			//// Result2 = Seq03.Except(Seq04, new MyEqualityComparer());
			//Result2 = Seq03.ExceptBy(Seq04.Select(x => x.ProductID), p => p.ProductID);

			//foreach (var Product in Result2)
			//{
			//    Console.WriteLine(Product);
			//}

			#endregion

			#endregion

			#endregion

			#region Quantifier Operators - Return Boolean

			//var Seq01 = Enumerable.Range(0, 100); //  0 ... 99
			//var Seq02 = Enumerable.Range(50, 100); // 50 ... 149

			//Console.WriteLine(
			//    //ProductList.Any() // Return True , if sequence contain at least one element
			//    //ProductList.Any(p => p.UnitPrice == 0) // Return True , if only one element match the condition
			//    //ProductList.All(p => p.UnitPrice > 0)
			//    //Seq01.SequenceEqual(Seq02)
			//    );

			#endregion

			#region Zip Operator

			//string[] Names = { "Ahmed", "Ali", "Omar", "mai" };
			//int [] Numbers = Enumerable.Range(1, 10).ToArray();// 1 ... 10

			//var Result = Names.Zip(Numbers, (name, number) => new {Index = number,Name = name });
			//foreach (var result in Result)
			//{
			//    Console.WriteLine(result);
			//}

			#endregion

			#region Grouping Operators

			#region EX01

			//var Catogeries = from p in ProductList
			//                 group p by p.Category; // Query Syntax

			//Catogeries = ProductList.GroupBy(p => p.Category); //Fluent Syntax

			//// Catogeries => Array of catogery and every catogery Array of product

			//foreach (var catogery in Catogeries)
			//{
			//    Console.WriteLine(catogery.Key);
			//    foreach (var product in catogery)
			//    {
			//        Console.WriteLine($"................{product.ProductName}");
			//    }
			//}

			#endregion

			#region EX02

			//var Catogeries = from p in ProductList
			//                 where p.UnitsInStock != 0
			//                 group p by p.Category
			//                     into Catogery
			//                 where Catogery.Count() > 10
			//                 select Catogery; // Query Syntax

			//Catogeries = ProductList.Where(p => p.UnitPrice != 0)
			//                        .GroupBy(p => p.Category)
			//                        .Where(Category => Category.Count() > 10)
			//                        .Select(Category => Category); // Fluent Syntax

			//foreach (var catogery in Catogeries)
			//{
			//    Console.WriteLine(catogery.Key);
			//    foreach (var product in catogery)
			//    {
			//        Console.WriteLine($"................{product.ProductName}");
			//    }
			//}

			#endregion

			#region EX03

			//var Catogeries = from p in ProductList
			//                 where p.UnitsInStock != 0
			//                 group p by p.Category
			//                     into Catogery
			//                 where Catogery.Count() > 10
			//                 select new { CatogeryName = Catogery.Key, Count = Catogery.Count() }; // Query Syntax

			//Catogeries = ProductList.Where(p => p.UnitsInStock != 0)
			//                        .GroupBy(p => p.Category)
			//                        .Where(Catogery => Catogery.Count() > 10)
			//                        .Select(Catogery => new { CatogeryName = Catogery.Key, Count = Catogery.Count() }); // Fluent Syntax

			//foreach (var catogery in Catogeries)
			//{

			//    Console.WriteLine($"{catogery}");
			//}

			#endregion

			#endregion

			#region Partitioning Operators - Take, TakeLast, Skip, SkipLast, TakeWhile, SkipWhile

			//var Result = ProductList.Where(p => p.UnitPrice > 0).Take(2);     // First 2 product 
			//Result = ProductList.Where(p => p.UnitPrice > 0).TakeLast(2);     // Last 2 product

			//Result = ProductList.Where(p => p.UnitPrice > 0).Skip(2);         // skip the first 2 product
			//Result = ProductList.Where(p => p.UnitPrice > 0).SkipLast(2);     // skip the last 2 product

			//int[] Numbers = { 5, 4, 1, 2, 4, 7, 8, 9, 10, 2, 1 };
			//var Result = Numbers.TakeWhile((Number, Index) => Number > Index);

			//// Get The Elements of the Array starting from the first element divisible by 3.
			//Result = Numbers.SkipWhile(n => n % 3 != 0);

			//foreach (var item in Result)
			//{
			//    Console.WriteLine(item);
			//}

			#endregion

			#region Let and Into

			////aeiouAEIOU
			//List<string> Names = new List<string>() { "Ahmed", "Nasr", "Eldein", "Hamdy", "Sally" };

			//var Result = from N in Names
			//             select Regex.Replace(N, "[aeiouAEIOU]", string.Empty)
			//             into NoVolName // into : Restart Query with Introducing New Range Variable : NoVolName
			//             where NoVolName.Length > 3
			//             select NoVolName;

			//Result = from N in Names
			//         let NoVolName = Regex.Replace(N, "[aeiouAEIOU]", string.Empty) // let : Continue Query with Added New Range Variable : NoVolName
			//         where NoVolName.Length > 3
			//         select NoVolName;

			//foreach (var Name in Names)
			//{
			//    Console.WriteLine(Name);
			//}

			#endregion

		}
	}
}