﻿using Obisoft.HSharp.Models;
using System;

namespace Obisoft.HSharp
{
    class Example
    {
        public static string ExampleHtml = $@"
<html>
<head>
<meta charset={"\"utf-8\""}>
<meta name={"\"viewport\""}>
<title>Example</title>
</head>
<body>
Some Text
<table>
<tr>OneLine</tr>
<tr>TwoLine</tr>
<tr>ThreeLine</tr>
</table>
Other Text
</body>
</html>";
        public static void Example1()
        {
            var Document = new HDoc(DocumentOptions.BasicHTML);
            Document["html"]["body"].AddChild("div");
            Document["html"]["body"]["div"].AddChild("a", new HProp("href", "/#"));
            Document["html"]["body"]["div"].AddChild("table");
            Document["html"]["body"]["div"]["table"].AddChildren(
             new HTag("tr"),
             new HTag("tr", "SomeText"),
             new HTag("tr", new HTag("td")));
            var Result = Document.GenerateHTML();
            Console.WriteLine(Result);
        }
        public static void Example2()
        {
            var Document = HtmlConvert.DeserializeHtml(ExampleHtml);
            Console.WriteLine(Document["html"]["head"]["meta", 0].Properties["charset"]);
            Console.WriteLine(Document["html"]["head"]["meta", 1].Properties["name"]);
            foreach (var Line in Document["html"]["body"]["table"])
            {
                Console.WriteLine(Line.Son);
            }
            Console.WriteLine(Document.Root.html.head.meta.Properties["charset"]);
        }
        public static void Example3()
        {
            var Document = new HDoc(new Uri("https://www.obisoft.com.cn"));
            Console.WriteLine(Document["html"]["head"]["title"].Children[1]);
            Console.WriteLine(Document.FindTagById("service")["div"]["div"]["div"]["div"]["h3"]["b"].Son);
            Console.WriteLine(Document.FindTagByTagName("nav").GenerateHTML());
        }
        public static void Example4()
        {
            var Document = HtmlConvert.DeserializeHtmlDynamic(ExampleHtml);
            Console.WriteLine(Document.html.head.meta.Properties["charset"]);
            Console.WriteLine(Document.html.body.table.Children.Count);
        }
        public static void Main(string[] args)
        {
            //Example1();
            //Example2();
            //Example3();
            Example4();
            Console.ReadLine();
        }
    }
}
