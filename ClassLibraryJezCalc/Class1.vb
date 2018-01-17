Public Class JezCalculator


    Private _strCurrentDisplay As String


    Private valueIndex As Integer = 0

    Private strEntitiesEntered(9) As String

    ''' <summary>
    ''' True if data entry for a new calculation is about to begin
    ''' </summary>
    Private _NewCalculation As Boolean = True

    Public Sub New()

        ' all calculators begin by displaying zero
        _strCurrentDisplay = "0"


    End Sub

    ReadOnly Property currentDisplay As String
        Get
            Return _strCurrentDisplay
        End Get
    End Property





    Public Sub buttonPress(charToAppend As String)


        If _NewCalculation Then

            ' if we're beginning data entry for a new calculation then
            ' we need to clear the existing display
            _strCurrentDisplay = ""

        End If

        _NewCalculation = False

        Select Case charToAppend
            Case "0" To "9"

                strEntitiesEntered(valueIndex) &= charToAppend

                _strCurrentDisplay = strEntitiesEntered(valueIndex)

            Case "+", "-", "x"

                ' these are the operators


                If strEntitiesEntered.GetLength(0) = 3 Then

                    ' a full calculation specification has already been
                    ' entered by user (e.g. 5 + 12) so on receiving another operator
                    ' calculator must evaluate current calculation and display this



                Else
                    ' there is no complete calculation yet. 
                    ' we move to the next entity slot and store the operator there                 
                    valueIndex += 1
                    strEntitiesEntered(valueIndex) &= charToAppend

                    ' then we move on to the next entity for more input from user
                    valueIndex += 1

                End If





            Case "C"
                ' clear everything.
                Reset()
                _strCurrentDisplay = "0"

            Case "CE"

                ' current entity being entered needs to be cleared
                strEntitiesEntered(valueIndex) = ""
                _strCurrentDisplay = "0"

            Case "="
                ' now we compute everything that's been entered so far
                ' and display the result
                _strCurrentDisplay = Evaluate()
                Reset()

        End Select









    End Sub

    ''' <summary>
    '''  Will evaluate outstanding calculation held in calculator. 
    ''' </summary>
    ''' <returns>Result of calculation.</returns>
    Private Function Evaluate() As Double


        Dim total As Double

        Dim strCurrentOperation As String = ""

        For Each currentEntity As String In strEntitiesEntered

            ' we've reached the end of the entered data
            If currentEntity = "" Then
                Exit For
            End If


            If currentEntity = "+" Or
                    currentEntity = "-" Or
                    currentEntity = "x" Then

                ' entity is an operation
                strCurrentOperation = currentEntity

            Else
                ' entity is a value

                If strCurrentOperation = "+" Then
                    total += currentEntity
                ElseIf strCurrentOperation = "-" Then
                    total -= currentEntity
                ElseIf strCurrentOperation = "x" Then
                    total *= currentEntity
                Else
                    total = currentEntity
                End If

            End If
        Next

        Return total
    End Function



    ''' <summary>
    ''' Resets calculator engine
    ''' </summary>
    Private Sub Reset()

        For index As Integer = 0 To strEntitiesEntered.Length - 1
            strEntitiesEntered(index) = ""
        Next
        valueIndex = 0

        _NewCalculation = True


    End Sub



    Private Sub ComputeResult()

        Dim runningTotal As Double

        Dim entityCount As Integer













    End Sub



    'Public Function add(ByVal a, ByVal b) As Integer


    'Return a + b



    'End Function





End Class
