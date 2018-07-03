object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Delphi Examples for PDF-XChangeEditCore SDK '
  ClientHeight = 675
  ClientWidth = 899
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnClose = FormClose
  OnCreate = FormCreate
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object PXV_Control1: TPXV_Control
    Left = 0
    Top = 0
    Width = 899
    Height = 675
    Align = alClient
    TabOrder = 0
    ExplicitLeft = 288
    ExplicitTop = 192
    ExplicitWidth = 192
    ExplicitHeight = 192
    ControlData = {
      000E0000EA5C0000C34500000800000000001300000000000B00FFFF0B00FFFF
      0B0000000B000000130003000000}
  end
  object MainMenu1: TMainMenu
    Left = 40
    Top = 24
    object File1: TMenuItem
      Caption = 'File'
      object Open2: TMenuItem
        Action = FileOpen1
      end
      object N1: TMenuItem
        Caption = '-'
      end
      object Exit1: TMenuItem
        Action = FileExit1
      end
    end
    object Doc: TMenuItem
      Caption = 'Document'
      object insertPage1: TMenuItem
        Action = insertPage
      end
      object deletePage1: TMenuItem
        Action = deletePage
      end
    end
    object Tool1: TMenuItem
      Caption = 'Tool'
      object VerifyPageLinks1: TMenuItem
        Action = actVerifyPageLinks
      end
      object CertTest1: TMenuItem
        Action = actCertTest
      end
      object GetContent1: TMenuItem
        Action = actGetContent
      end
      object actGotoPage1: TMenuItem
        Action = actGotoPage
      end
    end
    object Help1: TMenuItem
      Caption = 'Help'
      object About1: TMenuItem
        Action = About
      end
    end
  end
  object ActionList1: TActionList
    Left = 120
    Top = 24
    object FileExit1: TFileExit
      Category = 'File'
      Caption = 'E&xit'
      Hint = 'Exit|Quits the application'
      ImageIndex = 43
    end
    object FileOpen1: TFileOpen
      Category = 'File'
      Caption = '&Open...'
      Hint = 'Open|Opens an existing file'
      ImageIndex = 7
      ShortCut = 16463
      OnAccept = FileOpen1Accept
    end
    object actVerifyPageLinks: TAction
      Category = 'Tool'
      Caption = 'VerifyPageLinks'
      OnExecute = actVerifyPageLinksExecute
    end
    object insertPage: TAction
      Category = 'File'
      Caption = 'Insert Page'
      ShortCut = 16429
      OnExecute = insertPageExecute
    end
    object deletePage: TAction
      Category = 'File'
      Caption = 'Delete Page'
      ShortCut = 16430
      OnExecute = deletePageExecute
    end
    object About: TAction
      Category = 'File'
      Caption = 'About'
      OnExecute = AboutExecute
    end
    object actCertTest: TAction
      Category = 'Tool'
      Caption = 'CertTest'
      OnExecute = actCertTestExecute
    end
    object actGetContent: TAction
      Category = 'Tool'
      Caption = 'Get Content'
      OnExecute = actGetContentExecute
    end
    object actGotoPage: TAction
      Category = 'Tool'
      Caption = 'Goto Page'
      OnExecute = actGotoPageExecute
    end
  end
  object FileOpenDialog1: TFileOpenDialog
    FavoriteLinks = <>
    FileTypes = <>
    Options = []
    Left = 200
    Top = 24
  end
end
