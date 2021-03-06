// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#light

namespace TwoCoinsTutorial

open System
open Microsoft.ML.Probabilistic
open Microsoft.ML.Probabilistic.Models
open Microsoft.ML.Probabilistic.Distributions
open Microsoft.ML.Probabilistic.Factors
open Microsoft.ML.Probabilistic.FSharp

//-----------------------------------------------------------------------------------
// Infer.NET: F# script for two coins tutorial
//-----------------------------------------------------------------------------------

module coins = 
   
    let twoCoinsTestFunc() = 
        Console.WriteLine("\n========================Running Two Coins Tutorial========================\n");
        let firstCoin = Variable.Bernoulli(0.5)
        let secondCoin = Variable.Bernoulli(0.5)
        let bothHeads = firstCoin &&& secondCoin

        // The inference
        let ie = InferenceEngine()

        let bothHeadsPost = ie.Infer<Bernoulli>(bothHeads)
        printfn "Both heads posterior = %A" bothHeadsPost
        bothHeads.ObservedValue <- false

        let firstCoinPost = ie.Infer<Bernoulli>(firstCoin)
        printfn "First coin posterior = %A" firstCoinPost



