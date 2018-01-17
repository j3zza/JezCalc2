Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClassLibraryJezCalc
Imports WindowsApp1





<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub JezCalcLibraryTest()


        Dim oCalc As New ClassLibraryJezCalc.JezCalculator

        ' when calc switched on it initially displays zero
        Assert.AreEqual("0", oCalc.currentDisplay)

        ' let's clear current entry - it should remain at zero
        oCalc.buttonPress("CE")
        Assert.AreEqual("0", oCalc.currentDisplay)

        oCalc.buttonPress("1")
        Assert.AreEqual("1", oCalc.currentDisplay)

        oCalc.buttonPress("2")
        Assert.AreEqual("12", oCalc.currentDisplay)

        ' let's clear current entry
        oCalc.buttonPress("CE")
        Assert.AreEqual("0", oCalc.currentDisplay)





        oCalc.buttonPress("1")
        Assert.AreEqual("1", oCalc.currentDisplay)

        oCalc.buttonPress("2")
        Assert.AreEqual("12", oCalc.currentDisplay)

        oCalc.buttonPress("+")
        Assert.AreEqual("12", oCalc.currentDisplay)

        oCalc.buttonPress("3")
        Assert.AreEqual("3", oCalc.currentDisplay)

        ' press +
        ' pressing + at this stage will cause the calc to evaluate the calculation
        ' entered so far.
        oCalc.buttonPress("+")
        Assert.AreEqual("15", oCalc.currentDisplay)


        oCalc.buttonPress("1")
        oCalc.buttonPress("2")
        oCalc.buttonPress("=")

        Assert.AreEqual("24", oCalc.currentDisplay)


        oCalc.buttonPress("1")
        oCalc.buttonPress("0")
        oCalc.buttonPress("0")
        oCalc.buttonPress("+")
        oCalc.buttonPress("1")
        oCalc.buttonPress("0")
        oCalc.buttonPress("0")
        oCalc.buttonPress("=")

        Assert.AreEqual("200", oCalc.currentDisplay)




        oCalc.buttonPress("1")
        oCalc.buttonPress("2")
        oCalc.buttonPress("x")
        oCalc.buttonPress("1")
        oCalc.buttonPress("2")
        oCalc.buttonPress("=")

        Assert.AreEqual("144", oCalc.currentDisplay)





    End Sub


    <TestMethod()> Public Sub JezCalcInterfaceTest()





    End Sub





End Class