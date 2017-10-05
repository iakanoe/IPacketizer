<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class config
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.desde = New System.Windows.Forms.TextBox()
        Me.hasta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Minutos desde:"
        '
        'desde
        '
        Me.desde.Location = New System.Drawing.Point(98, 10)
        Me.desde.Name = "desde"
        Me.desde.Size = New System.Drawing.Size(100, 20)
        Me.desde.TabIndex = 1
        '
        'hasta
        '
        Me.hasta.Location = New System.Drawing.Point(98, 38)
        Me.hasta.Name = "hasta"
        Me.hasta.Size = New System.Drawing.Size(100, 20)
        Me.hasta.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Minutos hasta:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(61, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(212, 108)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.hasta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.desde)
        Me.Controls.Add(Me.Label1)
        Me.Name = "config"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Configuración"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents desde As TextBox
    Friend WithEvents hasta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
End Class
