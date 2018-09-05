open System
open System.Net

//let fetchHtmlAsync url =
//    async {
//        let uri = Uri(url)
//        use webClient = new WebClient()
//        let! html = webClient.AsyncDownloadString(uri)
//        return html
//    }

//let html = "https://dotnetfoundation.org" |> fetchHtmlAsync |> Async.RunSynchronously

//printfn "%i" html.Length

//let uploadDataAsync url =
//    async{
//        let uri = Uri(url)
//        use webClient = new WebClient()
//        let! html = webClient.AsyncDownloadString(uri)
//        printfn "getting html .. %i" html.Length 
//    }
//let workflow = uploadDataAsync "https://dotnetfoundation.org"

//Async.Start(workflow)

//printfn "%s" "uploadDataAsync is rnning in the background..."


async {
  do! Async.Sleep 1000
  printfn "step 1"
  do! Async.Sleep 1000
  printfn "step 2"
  do! Async.Sleep 1000
  printfn "step 3"
} |> Async.StartImmediate

printfn "started"