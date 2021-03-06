﻿namespace GWallet.Backend

open System

type ExceptionInfo =
    { Type: Type
      Message: string }

type HistoryInfo =
    { TimeSpan: TimeSpan
      Fault: Option<ExceptionInfo> }

[<CustomEquality; NoComparison>]
type Server<'K,'T,'R when 'K: equality> =
    { Identifier: 'K
      HistoryInfo: Option<HistoryInfo>
      Retreival: 'T -> 'R }
    override self.Equals yObj =
        match yObj with
        | :? Server<'K,'T,'R> as y ->
            self.Identifier.Equals y.Identifier
        | _ -> false
    override self.GetHashCode () =
        self.Identifier.GetHashCode()
