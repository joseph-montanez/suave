﻿module Suave.Json

open System.IO

open System.Runtime.Serialization.Json
open System.Text

let to_json<'a> o =
  let dcs = DataContractJsonSerializer(typeof<'a>)
  let ms = new MemoryStream()
  dcs.WriteObject(ms, o)
  ms.ToArray()

let from_json<'a> (bytes:byte []) =
  let dcs = DataContractJsonSerializer(typeof<'a>)
  let ms = new MemoryStream()
  ms.Write(bytes,0,bytes.Length)
  ms.Seek(0L, SeekOrigin.Begin) |> ignore
  dcs.ReadObject(ms) :?> 'a
