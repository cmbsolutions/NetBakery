Imports System.Reflection

Public Class FormHelpers
    Shared ReadOnly Property ApplicationTitle(Optional ByVal extraDescription As String = "") As String
        Get
            Dim assy As Assembly = Assembly.GetExecutingAssembly
            Dim description As AssemblyDescriptionAttribute
            description = CType(assy.GetCustomAttributes(GetType(AssemblyDescriptionAttribute), False)(0), AssemblyDescriptionAttribute)
            Dim desc As String = assy.GetName.Name

            'If extraDescription <> "" Then
            '    desc = String.Format("{0} - {1}", description.Description, extraDescription)
            'Else
            '    desc = description.Description
            'End If

            If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                Return String.Format("{0} {1}.{2} build {3}", desc, Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Major, Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor, Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Build)
            Else
                Return String.Format("{0} {1}.{2} build {3} debug", desc, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
            End If
        End Get
    End Property

    Shared ReadOnly Property isDebug() As Boolean
        Get
            Return Not Deployment.Application.ApplicationDeployment.IsNetworkDeployed
        End Get
    End Property

    Public Shared Sub dumpException(ByRef _ex As Exception)
        Try
            Trace.IndentSize = 4
            Trace.WriteLine(_ex.Message)
            Trace.Indent()

            Dim st As StackTrace = New StackTrace(_ex, True)
            For Each sf As StackFrame In st.GetFrames

                If sf.GetFileLineNumber > 0 OrElse sf.GetFileColumnNumber > 0 Then
                    Trace.WriteLine($"Trace line:{sf.GetFileLineNumber}, column:{sf.GetFileColumnNumber}, file:{sf.GetFileName}, method:{sf.GetMethod.Name}")
                End If

            Next
            Trace.Unindent()
        Catch ex As Exception
            Trace.WriteLine("Can't process error")
        End Try
    End Sub

    Public Shared Sub upgradeMySettings()
        Try
            If My.Settings.upgradeRequired Then
                My.Settings.Upgrade()
                My.Settings.upgradeRequired = False
                My.Settings.Save()
            End If
        Catch ex As Exception
            dumpException(ex)
        End Try
    End Sub
End Class
