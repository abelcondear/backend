﻿#ExternalChecksum("..\..\GridWindow.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","5BE9670BB88D3BBE42C61FBCC3B23300FC510CA2FC8133ED0CE42707ACE6DED4")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports CRUD
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''GridWindow
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class GridWindow
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\GridWindow.xaml",1)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents WndGrid As GridWindow
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\GridWindow.xaml",14)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents dataGrid As System.Windows.Controls.DataGrid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\GridWindow.xaml",16)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents dataGridTextColumn0 As System.Windows.Controls.DataGridTextColumn
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\GridWindow.xaml",17)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents dataGridTextColumn1 As System.Windows.Controls.DataGridTextColumn
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\GridWindow.xaml",18)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents dataGridTextColumn2 As System.Windows.Controls.DataGridTextColumn
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\GridWindow.xaml",19)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents dataGridTextColumn3 As System.Windows.Controls.DataGridTextColumn
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\GridWindow.xaml",20)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents dataGridTextColumn4 As System.Windows.Controls.DataGridTextColumn
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/CRUD;component/gridwindow.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\GridWindow.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.WndGrid = CType(target,GridWindow)
            Return
        End If
        If (connectionId = 2) Then
            Me.dataGrid = CType(target,System.Windows.Controls.DataGrid)
            Return
        End If
        If (connectionId = 3) Then
            Me.dataGridTextColumn0 = CType(target,System.Windows.Controls.DataGridTextColumn)
            Return
        End If
        If (connectionId = 4) Then
            Me.dataGridTextColumn1 = CType(target,System.Windows.Controls.DataGridTextColumn)
            Return
        End If
        If (connectionId = 5) Then
            Me.dataGridTextColumn2 = CType(target,System.Windows.Controls.DataGridTextColumn)
            Return
        End If
        If (connectionId = 6) Then
            Me.dataGridTextColumn3 = CType(target,System.Windows.Controls.DataGridTextColumn)
            Return
        End If
        If (connectionId = 7) Then
            Me.dataGridTextColumn4 = CType(target,System.Windows.Controls.DataGridTextColumn)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

