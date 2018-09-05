// This sample will guide you through elements of the F# language.
//
// *******************************************************************************************************
//   To execute the code in F# Interactive, highlight a section of code and press Alt-Enter or right-click 
//   and select "Execute in Interactive".  You can open the F# Interactive Window from the "View" menu. 
// *******************************************************************************************************
//
// For more about F#, see:
//     http://fsharp.org
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/
//
// To see this tutorial in documentation form, see:
//     https://docs.microsoft.com/en-us/dotnet/articles/fsharp/tour
//
// To learn more about applied F# programming, use
//     http://fsharp.org/guides/enterprise/
//     http://fsharp.org/guides/cloud/
//     http://fsharp.org/guides/web/
//     http://fsharp.org/guides/data-science/
//
// To install the Visual F# Power Tools, use
//     'Tools' --> 'Extensions and Updates' --> `Online` and search
//
// For additional templates to use with F#, see the 'Online Templates' in Visual Studio, 
//     'New Project' --> 'Online Templates'

// F# supports three kinds of comments:

//  1. Double-slash comments.  These are used in most situations.
(*  2. ML-style Block comments.  These aren't used that often. *)
/// 3. Triple-slash comments.  These are used for documenting functions, types, and so on.
///    They will appear as text when you hover over something which is decorated with these comments.
///
///    They also support .NET-style XML comments, which allow you to generate reference documentation,
///    and they also allow editors (such as Visual Studio) to extract information from them.
///    To learn more, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/xml-documentation


// Open namespaces using the 'open' keyword.
//
// To learn more, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// A module is a grouping of F# code, such as values, types, and function values. 
/// Grouping code in modules helps keep related code together and helps avoid name conflicts in your program.
///
/// To learn more, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/modules
module IntegersAndNumbers = 


    let helloWorld name =
        printfn "hello world, %s" name
    helloWorld "aaa"

    let myPrintfn =
        printfn "hello world, %s"

    myPrintfn "bbb"

    "ccc" |> myPrintfn

    let result =
        [ 1 .. 10 ]
        |> List.map (fun i->i+2)
        |> List.filter (fun i-> i>10)
        
    printfn "%A" result

    let add x y = x+y
    printfn "... %i" ( 4 |> add <| 6)
    

