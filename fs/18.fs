open System
open System.Net

type Node<'a>(data : 'a, parents : List<Node>) = class

    member x.Parents = parents
    member x.Data = data

(*
type Triangle = class
    val rowCount : int
    val rows : array2D : Node[,]

    member x.

let sum position =
    value(position) + max(parents) 

let read 
*)
