object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 360
  ClientWidth = 582
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object ToolBar1: TToolBar
    Left = 0
    Top = 0
    Width = 582
    Height = 29
    ButtonHeight = 21
    ButtonWidth = 52
    Caption = 'ToolBar1'
    ShowCaptions = True
    TabOrder = 0
    object ToolButton2: TToolButton
      Left = 0
      Top = 0
      Caption = 'Open File'
      ImageIndex = 1
      OnClick = ToolButton2Click
    end
    object ToolButton1: TToolButton
      Left = 52
      Top = 0
      Caption = 'Goto'
      ImageIndex = 0
      OnClick = ToolButton1Click
    end
  end
  object PXV_Control1: TPXV_Control
    Left = 0
    Top = 29
    Width = 582
    Height = 331
    Align = alClient
    TabOrder = 1
    ExplicitLeft = 200
    ExplicitTop = 104
    ExplicitWidth = 192
    ExplicitHeight = 192
    ControlData = {000C0000273C000036220000}
  end
  object FileOpenDialog1: TFileOpenDialog
    FavoriteLinks = <>
    FileTypes = <>
    Options = []
    Left = 24
    Top = 56
  end
end
